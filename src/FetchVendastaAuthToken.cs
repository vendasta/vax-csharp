using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace Vendasta.Vax
{
    public class ServiceAccount
    {
        [JsonProperty("private_key_id")] public string KeyId;
        [JsonProperty("private_key")] public string Key;
        [JsonProperty("client_email")] public string Email;
        [JsonProperty("token_uri")] public string TokenUrl;
    }

    public class FetchVendastaAuthToken : IFetchAuthToken
    {
        private readonly string _scope;
        private readonly ServiceAccount _creds;
        private readonly ECDsa _ecdsa;

        public FetchVendastaAuthToken(string scope)
        {
            _scope = scope;
            var path = global::System.Environment.GetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS");
            if (string.IsNullOrEmpty(path))
            {
                throw new CredentialsException("VENDASTA_APPLICATION_CREDENTIALS is not set");
            }

            using (var file = File.OpenText(path))
            {
                var serializer = new JsonSerializer();
                _creds = (ServiceAccount)serializer.Deserialize(file, typeof(ServiceAccount));
            }

            _ecdsa = LoadPrivateKey(_creds.Key);
        }

        public async Task<string> FetchToken()
        {
            string token;
            try
            {
                token = BuildJwt();
            }
            catch (Exception e)
            {
                throw new CredentialsException("Something went wrong with building the credentials", e);
            }

            using (var client = new HttpClient())
            {
                var stringContent = new StringContent($"{{\"token\":\"{token}\"}}", Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync(_creds.TokenUrl, stringContent);
                var responseString = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JObject.Parse(responseString);
                    return (string)responseData["token"];
                }
                else
                {
                    try
                    {
                        var responseData = JObject.Parse(responseString);
                        throw new CredentialsException((string)responseData["token"]);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            throw new CredentialsException("An error occured while fetching the token");
        }

        private string BuildJwt()
        {
            var now = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));

            var header = new JwtHeader(new SigningCredentials(
                new ECDsaSecurityKey(_ecdsa), SecurityAlgorithms.EcdsaSha256
            ));

            var payload = new JwtPayload
            {
                {"sub", _creds.Email},
                {"aud", "vendasta.com"},
                {"iat", (int) now.TotalSeconds},
                {"exp", (int) now.Add(new TimeSpan(0, 10, 0)).TotalSeconds},
                {"kid", _creds.KeyId}
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }

        private static ECDsa LoadPrivateKey(string pem)
        {
            var bytes = Encoding.ASCII.GetBytes(pem);
            var cert = new X509Certificate2(bytes);
            return cert.GetECDsaPrivateKey();
        }

        public void InvalidateToken()
        {
        }
    }
}
