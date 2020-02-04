using System;

namespace Vendasta.Vax
{
    public class VaxClient
    {
        private readonly RequestOptions _defaultRequestOptions;

        public VaxClient(float timeout = 10000, bool includeToken = true, RetryOptions retryOptions = null)
        {
            if (retryOptions == null)
            {
                retryOptions = new RetryOptions();
            }
            _defaultRequestOptions = new RequestOptions(timeout, includeToken, retryOptions);
        }

        protected RequestOptions BuildRequestOptionsWithDefaults(RequestOptions? reqOpts)
        {
            if (reqOpts == null)
            {
                return _defaultRequestOptions;
            }

            return new RequestOptions(
                reqOpts.Value.Timeout ?? _defaultRequestOptions.Timeout,
                reqOpts.Value.IncludeToken ?? _defaultRequestOptions.IncludeToken,
                reqOpts.Value.RetryOptions ?? _defaultRequestOptions.RetryOptions
            );
        }
        
        protected static bool IsRetryWithinMaxCallDuration(float retryTime, DateTime? maxTime) {
            return DateTime.Now.AddMilliseconds(retryTime) < maxTime;
        }
    }
}