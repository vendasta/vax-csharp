using System;
using System.Linq;

namespace Vendasta.Vax
{
    public class RetryOptions
    {
        /// <summary> The maximum value of the retry envelope, defaults to 30 seconds. </summary>
        private readonly float _max;
        
        /// <summary>
        /// The factor by which the retry envelope increases. It should be greater than 1 and defaults to 2.
        /// </summary>
        private readonly float _multiplier;
        
        /// <summary> Disables the default randomization of backoff durations. </summary>
        private readonly bool _disableJitter;

        /// <summary> How long should this request retry for, defaults to 30 seconds. </summary>
        private readonly float _maxCallDuration;
        
        /// <summary>
        /// Response codes to retry on
        /// Defaults to [
        ///     408, // RequestTimeout
        ///     500, // InternalServerError
        ///     503, // ServiceUnavailable
        /// ]
        /// </summary>
        private readonly int[] _retryOnCodes;
        
        /// <summary> The current retry envelope </summary>
        private float _cur;
        
        private readonly Random _rnd = new Random();
        
        /// <summary>Instantiates a RetryOptions.</summary>
        /// <param name="maxCallDuration">(milliseconds) how long should this request retry for, defaults to 30 second</param>
        /// <param name="initial">(milliseconds) initial value of the retry envelope, defaults to 1 second</param>
        /// <param name="max">(milliseconds) maximum value of the retry envelope, defaults to 30 seconds</param>
        /// <param name="multiplier">factor by which the retry envelope increases, defaults to 2</param>
        /// <param name="retryOnCodes">http response codes to retry on, defaults to [408, 500, 503]</param>
        /// <param name="disableJitter">disables the default randomization of backoff durations</param>
        public RetryOptions(float maxCallDuration = 30000, float initial = 1000, float max = 30000,
            float multiplier = 2, int[] retryOnCodes = null, bool disableJitter = false)
        {
            _maxCallDuration = (maxCallDuration > 0) ? maxCallDuration : 30000;
            _max = (max > 0) ? max : 30000;
            _multiplier = (multiplier > 1) ? multiplier : 2;
            _disableJitter = disableJitter;
            _retryOnCodes = retryOnCodes ?? new[] {408, 500, 503};
            _cur = (initial > 0) ? initial : 1000;
        }
        
        /// <summary> Get the max call duration </summary>
        public DateTime MaxCallDuration => DateTime.Now.AddMilliseconds(_maxCallDuration);

        /// <summary>
        /// Calculates how long a request should sleep for before retrying. Every subsequent call will sleep for longer
        /// and longer periods until the maximum is hit.
        /// </summary>
        /// <returns>milliseconds to wait for until the next retry.</returns>
        public float Pause()
        {
            float d;
            if (_disableJitter)
            {
                d = _cur;
            }
            else
            {
                d = ((_cur / 2) * Convert.ToSingle(_rnd.NextDouble())) + (_cur / 2);
            }

            _cur = _cur * _multiplier;

            if (_cur > _max)
            {
                _cur = _max;
            }

            return d;
        }

        /// <summary>
        /// Checks if we should be retrying on the specified status code.
        /// </summary>
        /// <param name="statusCode">HTTP Status code to retry on</param>
        /// <returns>True if we should retry this request based on status code</returns>
        public bool ShouldRetry(int statusCode)
        {
            return _retryOnCodes.Contains(statusCode);
        }
    }
}