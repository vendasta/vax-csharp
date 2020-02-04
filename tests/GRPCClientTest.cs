using Grpc.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helloworld;
using System;
using Vendasta.Vax;

namespace tests
{
    [TestClass]
    public class GRPCClientTest
    {
        static int Port = 50051;
        Server server;

        [TestInitialize]
        public void TestInitialize()
        {
            server = new Server
            {
                Services = { Greeter.BindService(new GreeterServer()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            server.ShutdownAsync().Wait();
            Port++; // Use a different port for each test.
        }

        [TestMethod]
        public void TestNoVax()
        {
            Channel channel = new Channel(String.Format("127.0.0.1:{0}", Port), ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);
            String user = "world";
            var reply = client.SayHello(new HelloRequest { Name = user });
            Assert.AreEqual("Hello world", reply.Message);
        }

        [TestMethod]
        public void TestVax()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            String user = "world";
            var reply = client.SayHello(new HelloRequest { Name = user });
            Assert.AreEqual("Hello world", reply.Message);
        }

        [TestMethod]
        public void TestRetryOnInternalError()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            var resp = client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.Internal, SucceedAfter = 2 });
            Assert.AreEqual(2, resp.Retries);
        }

        [TestMethod]
        public void TestRetryOnUnavailable()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            var resp = client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.Unavailable, SucceedAfter = 2 });
            Assert.AreEqual(2, resp.Retries);
        }

        [TestMethod]
        public void TestRetryOnDeadlineExceeded()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            var resp = client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.DeadlineExceeded, SucceedAfter = 2 });
            Assert.AreEqual(2, resp.Retries);
        }

        [TestMethod]
        public void TestRetryOnUnresponsiveServer()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port), 1000);
            var resp = client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.Unavailable, SleepForMilliseconds = 40000, SucceedAfter = 3 });
            Assert.AreEqual(3, resp.Retries);
        }

        [TestMethod]
        public void TestNoRetryOnInvalidArgument()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            Assert.ThrowsException<SdkException>(() => client.Fail(new FailRequest { Code = (long)Grpc.Core.StatusCode.InvalidArgument }));
        }

        [TestMethod]
        public void TestRetryOnSingleUnauthenticatedError()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            var resp = client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.Unauthenticated, SucceedAfter = 1 });
            Assert.AreEqual(1, resp.Retries);
        }

        [TestMethod]
        public void TestNoRetryOnMultipleUnauthenticatedErrors()
        {
            var client = new TestClient(String.Format("127.0.0.1:{0}", Port));
            Assert.ThrowsException<SdkException>(() => client.FailThenSucceed(new FailThenSucceedRequest { Code = (long)Grpc.Core.StatusCode.Unauthenticated, SucceedAfter = 2 }));
        }
    }
}
