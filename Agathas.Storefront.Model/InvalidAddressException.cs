using System;

namespace Agathas.Storefront.Model
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message)
            : base(message)
        {            
        }
    }
}