using Vendasta.Vax;

namespace Vendasta.Sso
{
    public class ServiceProviderClient: ServiceProviderGeneratedClient 
    {
        public ServiceProviderClient(Environment env, float defaultTimeout = 10000): base(env, defaultTimeout)
        {
        }
    }
}
