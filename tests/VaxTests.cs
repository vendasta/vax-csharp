using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = System.Environment;
using Grpc.Core;
using Vendasta.Vax;

namespace Vendasta.Tests.Test
{
    [TestClass]
    public class VaxTests
    {
        public VaxTests()
        {
            Environment.SetEnvironmentVariable("VENDASTA_APPLICATION_CREDENTIALS", "/Users/twiebe/demo-service-account.json");
        }
        
        [TestMethod]
        public void Smoke()
        {
            var client = new GrpcClient<TestClass>("", "", false);
        }
    }

    internal class TestClass : ClientBase
    {
        public TestClass(Channel channel)
        {
            
        }

        public TestClass(CallInvoker callInvoker)
        {
        }

        protected TestClass()
        {
            
        }

        protected TestClass(ClientBaseConfiguration configuration)
        {
            
        }
    }
}
