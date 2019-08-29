using Vendasta.Vax;

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Environment = Vendasta.Vax.Environment;
using gen = global::Sso.V1;

namespace Vendasta.Sso
{
    public class IdentityProviderClient : IdentityProviderGeneratedClient
    {
        public IdentityProviderClient(Environment env, float defaultTimeout = 10000, TextReader credentials = null) : base(env, defaultTimeout, credentials)
        {
        }

        /// <summary>
        /// RPC for getting the entry URL of a service provider
        /// </summary>
        /// <param name="serviceProviderId">The ID of the service provider (such as a marketplace application)</param>
        /// <param name="encodedContext">A base64 encoded JSON string representing a particular ServiceContext, 
        /// provided in the serviceContext query param of a session transfer handler request. The context helps form 
        /// the entry URL by providing parametrized fields, such as an account ID.</param>
        /// <returns>The entry URL</returns>
        public string GetEntryURL(string serviceProviderId, string encodedContext)
        {
            var decodedContext = BuildContext(encodedContext);
            var req = new gen.GetEntryURLRequest { ServiceProviderId = serviceProviderId, Context = decodedContext };
            var resp = GetEntryURL(req);
            return resp.EntryUrl;
        }

        /// <summary>
        /// RPC for getting the entry URL of the service provider, with the authentication code attached
        /// </summary>
        /// <param name="serviceProviderID">The ID of a service provider (such as a marketplace application)</param>
        /// <param name="sessionID">The user's session ID. This can be the session ID directly from your application, 
        /// or it can be a hashed version, or something else unique. Whatever it is, the same session ID must be passed 
        /// to the logout RPC.</param>
        /// <param name="userID">The user's ID</param>
        /// <param name="email">The user's email</param>
        /// <param name="encodedContext">A base64 encoded JSON string representing a particular ServiceContext, 
        /// provided in the serviceContext query param of a session transfer handler request. The context helps form 
        /// the entry URL by providing parametrized fields, such as an account ID.</param>
        /// <param name="nextURL">The next URL to send the user to, once the code exchange is complete on the entry URL</param>
        /// <returns>The entry URL, with the authentication code attached</returns>
        public string GetEntryURLWithCode(string serviceProviderID, string sessionID, string userID, string email,
            string encodedContext, string nextURL)
        {
            var decodedContext = BuildContext(encodedContext);
            var req = new gen.GetEntryURLWithCodeRequest
            {
                Email = email,
                SessionId = sessionID,
                ServiceProviderId = serviceProviderID,
                NextUrl = nextURL,
                UserId = userID,
                Context = decodedContext
            };
            var resp = GetEntryURLWithCode(req);
            return resp.EntryUrl;
        }

        private static gen.ServiceContext BuildContext(string b64EncodedContext)
        {
            var decodedBytes = Convert.FromBase64String(b64EncodedContext);
            var decodedString = Encoding.UTF8.GetString(decodedBytes);
            var obj = JObject.Parse(decodedString);
            var ctxType = obj["_type"].ToString();

            var serviceCtx = new gen.ServiceContext();
            switch (ctxType)
            {
                case "account":
                    serviceCtx.Account = new gen.ServiceContext.Types.Account { AccountId = obj["account_id"].ToString() };
                    break;
                case "partner":
                    serviceCtx.Partner = new gen.ServiceContext.Types.Partner { PartnerId = obj["partner_id"].ToString() };
                    break;
            }
            return serviceCtx;
        }
    }
}
