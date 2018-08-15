using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vendasta.SalesOrders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using gen = global::Salesorders.V1;

namespace Vendasta.SalesOrders.Test
{
    [TestClass]
    public class SalesOrdersServiceClientTest
    {
        private readonly SalesOrdersClient _client;
        private const string BusinessId = "AG-123456";

        public SalesOrdersServiceClientTest()
        {
            Environment.SetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS", "/Users/twiebe/demo-service-account.json");
            _client = new SalesOrdersClient(Vax.Environment.Demo);
        }

        [TestMethod]
        public void SmokeTest()
        {
            var req = new Salesorders.V1.GetSalesOrderRequest
            {
                BusinessId = "AG-25BM6HCD73",
                OrderId = "ORD-HJCZD28TDS"
            };
            var resp = _client.GetSalesOrder(req);
            Assert.AreEqual("AG-25BM6HCD73", resp.Order.BusinessId);
        }
    }
}
