using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;

namespace Vendasta.Vax
{
    public class GrpcClient<T> : VaxClient where T : ClientBase
    {
        private readonly string _version;
        private readonly T _client;
        private readonly IFetchAuthToken _auth;

        public GrpcClient(string hostname, string scope, bool secure, float defaultTimeout = 10000) : base(defaultTimeout)
        {
            _version = Assembly.GetAssembly(GetType()).GetName().Version.ToString();
            _auth = new FetchAuthTokenCache(new FetchVendastaAuthToken(scope));

            _client = Activator.CreateInstance(typeof(T), BuildChannel(hostname, secure)) as T;
        }

        private static Channel BuildChannel(string hostname, bool secure)
        {
            return secure ? new Channel(hostname, new SslCredentials()) : new Channel(hostname, ChannelCredentials.Insecure);
        }

        protected IMessage DoRequest(string function, IMessage request, RequestOptions? reqOpts = null)
        {
            var options = BuildRequestOptionsWithDefaults(reqOpts);
            var maxTime = options.RetryOptions?.MaxCallDuration;
            while (true)
            {
                try
                {
                    return CallMethodOnClient(function, request, options);
                }
                catch (RpcException e)
                {
                    if (options.RetryOptions == null || !options.RetryOptions.ShouldRetry(GrpctoHttpCode(e.Status.StatusCode)))
                    {
                        throw new SdkException(e.Message, e);
                    }

                    var time = options.RetryOptions.Pause();
                    if (IsRetryWithinMaxCallDuration(time, maxTime))
                    {
                        System.Threading.Thread.Sleep(Convert.ToInt32(time));
                    }
                    else
                    {
                        throw new SdkException(e.Message, e);
                    }
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

        private IMessage CallMethodOnClient(string function, IMessage request, RequestOptions options)
        {
            var theMethod = _client.GetType().GetMethods().Where(m => m.Name == function).ElementAt(1);
            if (theMethod == null)
            {
                throw new MissingMethodException("Could not find method " + function);
            }

            if (options.Timeout == null || options.IncludeToken == null)
            {
                // This should never be thrown - we should be using the default request options at this point.
                throw new SdkException("Invalid request options.");
            }

            var timeout = GetTimeout(options.Timeout.Value);
            var metadata = GetMetadata(options.IncludeToken.Value);
            var callOptions = new CallOptions(metadata, timeout).WithWaitForReady();
            try
            {
                return theMethod.Invoke(_client, new object[] { request, callOptions }) as IMessage;
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
        
        private static int GrpctoHttpCode(StatusCode code) {
            switch (code) {
                case StatusCode.OK:
                return 200;
                case StatusCode.InvalidArgument:
                return 400;
                case StatusCode.Unauthenticated:
                return 401;
                case StatusCode.PermissionDenied:
                return 403;
                case StatusCode.NotFound:
                return 404;
                case StatusCode.DeadlineExceeded:
                return 408;
                case StatusCode.AlreadyExists:
                return 409;
                case StatusCode.FailedPrecondition:
                return 412;
                case StatusCode.ResourceExhausted:
                return 429;
                case StatusCode.Unimplemented:
                return 501;
                case StatusCode.Cancelled:
                return 503;
                case StatusCode.Aborted:
                return 503;
                case StatusCode.Unavailable:
                return 503;
                default:
                    return 500;
            }
        }
    }
}
