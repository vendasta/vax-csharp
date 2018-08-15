using Vendasta.Vax;

namespace Vendasta.SalesOrders
{
    public class SalesOrdersClient: SalesOrdersGeneratedClient 
    {
        public SalesOrdersClient(Environment env, float defaultTimeout = 10000): base(env, defaultTimeout)
        {
        }
    }
}
