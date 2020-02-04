using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;

namespace tests
{
    class GreeterServer : Greeter.GreeterBase
    {
        long retries = 0;

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override Task<FailResponse> Fail(FailRequest request, ServerCallContext context)
        {
            throw new RpcException(new Status((StatusCode)request.Code, ""));
        }

        public override Task<FailThenSucceedResponse> FailThenSucceed(FailThenSucceedRequest request, ServerCallContext context)
        {
            if (retries >= request.SucceedAfter)
            {
                return Task.FromResult(new FailThenSucceedResponse { Retries = retries });
            }
            retries++;

            if (request.SleepForMilliseconds > 0)
            {
                Thread.Sleep((int)request.SleepForMilliseconds);
            }
            throw new RpcException(new Status((StatusCode)request.Code, ""));
        }
    }
}