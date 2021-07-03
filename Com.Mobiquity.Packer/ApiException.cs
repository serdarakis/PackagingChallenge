using System;

namespace Com.Mobiquity.Packer
{
    public class ApiException : Exception
    {
        public ApiException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}
