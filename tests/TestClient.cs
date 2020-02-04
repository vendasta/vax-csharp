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

        public FailThenSucceedResponse FailThenSucceed(FailThenSucceedRequest req, RequestOptions? options = null)
        {
            return DoRequest("FailThenSucceed", req, options) as FailThenSucceedResponse;
        }
    }
}