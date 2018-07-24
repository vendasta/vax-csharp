namespace Vendasta.Vax
{
    public class VaxClient
    {
        private readonly float _defaultTimeout;

        public VaxClient(float defaultTimeout)
        {
            _defaultTimeout = defaultTimeout;
        }

        protected RequestOptions BuildRequestOptionsWithDefaults(RequestOptions? reqOpts)
        {
            var opts = new RequestOptions(_defaultTimeout, true);

            if (reqOpts == null)
            {
                return opts;
            }

            opts.Timeout = reqOpts.Value.Timeout ?? opts.Timeout;
            opts.IncludeToken = reqOpts.Value.IncludeToken ?? opts.IncludeToken;
            return opts;
        }
    }
}