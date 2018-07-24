using System;

namespace Vendasta.Vax
{
    public class CredentialsException : Exception
    {
        public CredentialsException(string message) : base(message)
        {
        }

        public CredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}