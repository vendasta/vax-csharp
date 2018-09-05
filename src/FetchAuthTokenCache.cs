using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Vendasta.Vax
{
    public class FetchAuthTokenCache : IFetchAuthToken
    {
        private readonly IFetchAuthToken _fetcher;
        private string _token;
        private DateTime? _tokenExpiry;

        public FetchAuthTokenCache(IFetchAuthToken fetcher)
        {
            _fetcher = fetcher;
        }

        public async Task<string> FetchToken()
        {
            var now = DateTime.UtcNow;
            if (_token == null || _tokenExpiry == null || _tokenExpiry < now) {
                _token = await _fetcher.FetchToken().ConfigureAwait(false);
                _tokenExpiry = ParseExpiry(_token);
            }

            if (_token == null) {
                throw new CredentialsException("Could not refresh token");
            }

            return _token;
        }

        public void InvalidateToken()
        {
            _token = null;
            _tokenExpiry = null;
        }

        private static DateTime? ParseExpiry(string token) {
            if (token == null) {
                return null;
            }
            var jwtToken = new JwtSecurityToken(token);
            if (jwtToken.Payload.Exp != null)
                return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double) jwtToken.Payload.Exp);
            return null;
        }
    }
}