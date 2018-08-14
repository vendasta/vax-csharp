using System.Collections.Generic;
using Vendasta.Vax;

namespace Vendasta.Sso
{
    internal static class Config
    {
        private static readonly Dictionary<Environment, EnvironmentConfig> Envs = new Dictionary<Environment, EnvironmentConfig>
        {
            {Environment.Prod, new EnvironmentConfig("sso-api-prod.vendasta-internal.com:443", "https://sso-api-prod.vendasta-internal.com", "https://sso-api-prod.vendasta-internal.com", true)},
            {Environment.Demo, new EnvironmentConfig("sso-api-demo.vendasta-internal.com:443", "https://sso-api-demo.vendasta-internal.com", "https://sso-api-demo.vendasta-internal.com", true)},
        };

        public static EnvironmentConfig GetEnvironmentConfig(Environment env)
        {
            if (Envs.ContainsKey(env)) {
                return Envs[env];
            }
            throw new SdkException($"No config found for env: '{env}'");
        }
    }

    internal struct EnvironmentConfig
    {
        public readonly string Host;
        public readonly string Scope;
        public readonly string Url;
        public readonly bool Secure;

        public EnvironmentConfig(string host, string scope, string url, bool secure)
        {
            Host = host;
            Scope = scope;
            Url = url;
            Secure = secure;
        }
    }
}
