namespace Vendasta.Vax
{
    public struct RequestOptions
    {
        public float? Timeout { get; set; }
        public bool? IncludeToken { get; set; }

        public RequestOptions(float? timeout = null, bool? includeToken = null)
        {
            Timeout = timeout;
            IncludeToken = includeToken;
        }
    }
}