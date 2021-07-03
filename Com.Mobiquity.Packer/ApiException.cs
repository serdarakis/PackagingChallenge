using System;

namespace Com.Mobiquity.Packer
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {

        }
    }
}
