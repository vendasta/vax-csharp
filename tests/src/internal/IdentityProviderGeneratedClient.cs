// Code generated by sdkgen
// Generated on 2018-08-03 14:36:42.9118512 +0000 UTC using container gcr.io/repcore-prod/sdkgen:latest
// DO NOT EDIT!

using Vendasta.Vax;

namespace Vendasta.Sso
{
    public class IdentityProviderGeneratedClient: IIdentityProvider 
    {
        private readonly IIdentityProvider _transport;
        public IdentityProviderGeneratedClient(Environment env, float defaultTimeout)
        {
            _transport = GetTransportClient(env, defaultTimeout);
        }

        private static IIdentityProvider GetTransportClient(Environment env, float defaultTimeout)
        {
            var config = GetEnvConfig(env);
            return new IdentityProviderGrpcClient(
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

        public global::Sso.V1.GetEntryURLResponse GetEntryURL(global::Sso.V1.GetEntryURLRequest req, RequestOptions? options = null) {
            return _transport.GetEntryURL(req, options);
        }

        public global::Sso.V1.GetEntryURLWithCodeResponse GetEntryURLWithCode(global::Sso.V1.GetEntryURLWithCodeRequest req, RequestOptions? options = null) {
            return _transport.GetEntryURLWithCode(req, options);
        }

        public Google.Protobuf.WellKnownTypes.Empty Logout(global::Sso.V1.LogoutRequest req, RequestOptions? options = null) {
            return _transport.Logout(req, options);
        }
    }
}
