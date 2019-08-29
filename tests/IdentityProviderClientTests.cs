using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = System.Environment;

namespace Vendasta.Sso.Test
{
    [TestClass]
    public class IdentityProviderClientTests
    {
        private readonly IdentityProviderClient _client;

        public IdentityProviderClientTests()
        {
            Environment.SetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS", "/Users/twiebe/demo-service-account.json");
            _client = new IdentityProviderClient(Vax.Environment.Demo, 20000);
        }

        [TestMethod]
        public void GetEntryUrlFromAccountContext()
        {
            var accountCtx = new global::Sso.V1.ServiceContext.Types.Account { AccountId = "AG-VJF85XDC" };
            var serviceContext = new global::Sso.V1.ServiceContext { Account = accountCtx };
            var req = new global::Sso.V1.GetEntryURLRequest { ServiceProviderId = "RM", Context = serviceContext };
            var resp = _client.GetEntryURL(req);
            Assert.AreEqual("http://abc.steprep-demo.com/entry/AG-VJF85XDC/", resp.EntryUrl);
        }

        [TestMethod]
        public void GetEntryUrlWithStringAccountContext()
        {
            var entryUrl =
                _client.GetEntryURL("RM", "eyJfdHlwZSI6ImFjY291bnQiLCJhY2NvdW50X2lkIjoiQUctVkpGODVYREMifQ==");
            Assert.AreEqual("http://abc.steprep-demo.com/entry/AG-VJF85XDC/", entryUrl);
        }
        
        [TestMethod]
        public void GetEntryUrlWithCustomClient()
        {
            IdentityProviderClient client;
            using (var file = new StreamReader("/Users/twiebe/demo-service-account.json"))
            {
                client = new IdentityProviderClient(Vax.Environment.Demo, 20000, file);
            }
            var entryUrl = client.GetEntryURL("RM", "eyJfdHlwZSI6ImFjY291bnQiLCJhY2NvdW50X2lkIjoiQUctVkpGODVYREMifQ==");
            Assert.AreEqual("http://abc.steprep-demo.com/entry/AG-VJF85XDC/", entryUrl);
        }
    }
}
