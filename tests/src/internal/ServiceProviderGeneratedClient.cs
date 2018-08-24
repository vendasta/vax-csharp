// Code generated by sdkgen
// Generated on 2018-08-03 14:36:42.9118512 +0000 UTC using container gcr.io/repcore-prod/sdkgen:latest
// DO NOT EDIT!

using Vendasta.Vax;

namespace Vendasta.Sso
{
    public class ServiceProviderGeneratedClient: IServiceProvider 
    {
        private readonly IServiceProvider _transport;
        public ServiceProviderGeneratedClient(Environment env, float defaultTimeout)
        {
            _transport = GetTransportClient(env, defaultTimeout);
        }

        private static IServiceProvider GetTransportClient(Environment env, float defaultTimeout)
        {
            var config = GetEnvConfig(env);
            return new ServiceProviderGrpcClient(
                config.Host,
                config.Scope,
                config.Secure,
                defaultTimeout
            );
        }

        private static EnvironmentConfig GetEnvConfig(Environment env)
        {
            return Config.GetEnvironmentConfig(env);
        }

        public global::Sso.V1.GetSessionTransferURLResponse GetSessionTransferURL(global::Sso.V1.GetSessionTransferURLRequest req, RequestOptions? options = null) {
            return _transport.GetSessionTransferURL(req, options);
        }
    }
}