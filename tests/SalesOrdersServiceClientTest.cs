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
        private readonly SalesOrdersClient _clientDemo;
        private readonly SalesOrdersClient _clientProd;
        private const string BusinessId = "AG-123456";

        public SalesOrdersServiceClientTest()
        {
            Environment.SetEnvironmentVariable("GRPC_TRACE", "all");
            Environment.SetEnvironmentVariable("GRPC_VERBOSITY", "DEBUG");
            
            
            Environment.SetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS", "/Users/twiebe/demo-service-account.json");
            _clientDemo = new SalesOrdersClient(Vax.Environment.Demo);
            Environment.SetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS", "/Users/twiebe/vendasta-prod@iam.vendasta.com-dada44bc.json");
            _clientProd = new SalesOrdersClient(Vax.Environment.Prod, 20000);
        }

//        [TestMethod]
//        public void EndpointsTest()
//        {
//            var reqProd = new Salesorders.V1.GetSalesOrderRequest
//            {
//                BusinessId = "AG-2C56J8TC2Z",
//                OrderId = "SO-NVX7TCGHLJ"
//            };
//            var respProd = _clientProd.GetSalesOrder(reqProd);
//            Assert.AreEqual("AG-25BM6HCD73", respProd.Order.BusinessId);
//        }

        [TestMethod]
        public void StormbreakerTest()
        {          
            var reqDemo = new Salesorders.V1.GetSalesOrderRequest
            {
                BusinessId = "AG-25BM6HCD73",
                OrderId = "ORD-HJCZD28TDS"
            };
            var respDemo = _clientDemo.GetSalesOrder(reqDemo);
            Assert.AreEqual("AG-25BM6HCD73", respDemo.Order.BusinessId);
        }
    }
}
