using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;

namespace Vendasta.Vax
{
    public class GrpcClient<T>: VaxClient where T: ClientBase
    {
        private readonly string _version;
        private readonly T _client;
        private readonly IFetchAuthToken _auth;

        public GrpcClient(string hostname, string scope, bool secure, float defaultTimeout = 10000) : base(defaultTimeout)
        {
            _version = System.Reflection.Assembly.GetAssembly(GetType()).GetName().Version.ToString();
            _auth = new FetchAuthTokenCache(new FetchVendastaAuthToken(scope));

            _client = Activator.CreateInstance(typeof(T), BuildChannel(hostname, secure)) as T;
        }

        private static Channel BuildChannel(string hostname, bool secure)
        {
            return secure ? new Channel(hostname, new SslCredentials()) : new Channel(hostname, ChannelCredentials.Insecure);
        }

        protected IMessage DoRequest(string function, IMessage request, RequestOptions? reqOpts = null)
        {
            try
            {
                return CallMethodOnClient(function, request, reqOpts);
            }
            catch (RpcException e)
            {
                if (!e.Status.StatusCode.Equals(StatusCode.Unauthenticated))
                {
                    throw new SdkException(e.Message, e);
                }

                _auth.InvalidateToken();
                try
                {
                    return CallMethodOnClient(function, request, reqOpts);
                }
                catch (RpcException e1)
                {
                    throw new SdkException(e1.Message, e1);
                }
            }
        }

        private Metadata GetMetadata(bool includeToken)
        {
            var metadataAsync = GetMetadataAsync(includeToken);
            metadataAsync.Wait();
            return metadataAsync.Result;
        }

        private async Task<Metadata> GetMetadataAsync(bool includeToken)
        {
            var metadata = new Metadata();

            metadata.Add("sdk_language", "csharp");
            metadata.Add("sdk_version", _version);

            if (!includeToken)
            {
                return metadata;
            }
            
            var token = await _auth.FetchToken();
            metadata.Add("authorization", $"Bearer {token}");
            return metadata;
        }

        private static DateTime? GetTimeout(float timeout)
        {
            if (Math.Abs(timeout) <= 0)
            {
                return null;
            }

            return DateTime.UtcNow.AddMilliseconds(timeout);
        }

        private IMessage CallMethodOnClient(string function, IMessage request, RequestOptions? reqOpts = null)
        {
            var theMethod = _client.GetType().GetMethods().First(m => m.Name == function);
            if (theMethod == null)
            {
                throw new MissingMethodException("Could not find method " + function);
            }

            var options = BuildRequestOptionsWithDefaults(reqOpts);
            if (options.Timeout == null || options.IncludeToken == null)
            {
                // This should never be thrown - we should be using the default request options at this point.
                throw new SdkException("Invalid request options.");
            }
            
            var timeout = GetTimeout(options.Timeout.Value);
            var metadata = GetMetadata(options.IncludeToken.Value);

            try
            {
                return theMethod.Invoke(_client,
                    new object[] {request, metadata, timeout, default(System.Threading.CancellationToken)}) as IMessage;
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException != null && e.InnerException.GetType() == typeof(RpcException))
                {
                    throw e.InnerException;
                }

                throw new SdkException($"Issue calling out to method {request}: {e.Message}", e);
            }
        }
    }
}