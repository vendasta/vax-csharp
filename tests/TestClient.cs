using Helloworld;
using Vendasta.Vax;

namespace tests
{
    public class TestClient : GrpcClient<Helloworld.Greeter.GreeterClient>
    {
        public TestClient(string hostname, float defaultTimeout = 10000) : base(hostname, defaultTimeout)
        {
        }

        public HelloReply SayHello(HelloRequest req, RequestOptions? options = null)
        {
            return DoRequest("SayHello", req, options) as HelloReply;
        }

        public FailResponse Fail(FailRequest req, RequestOptions? options = null)
        {
            return DoRequest("Fail", req, options) as FailResponse;
        }

        public FailThenSucceedResponse FailThenSucceed(FailThenSucceedRequest req, RequestOptions? options = null)
        {
            return DoRequest("FailThenSucceed", req, options) as FailThenSucceedResponse;
        }
    }
}