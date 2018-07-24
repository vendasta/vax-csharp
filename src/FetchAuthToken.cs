using System.Threading.Tasks;

namespace Vendasta.Vax
{
    public interface IFetchAuthToken
    {
        Task<string> FetchToken();
        void InvalidateToken();
    }
}