namespace Vendasta.Vax
{
    public struct RequestOptions
    {
        public float? Timeout { get; set; }
        public bool? IncludeToken { get; set; }
        public RetryOptions RetryOptions { get; set; }

        public RequestOptions(float? timeout = null, bool? includeToken = null, RetryOptions retryOptions = null)
        {
            Timeout = timeout;
            IncludeToken = includeToken;
            RetryOptions = retryOptions;
        }
    }
}