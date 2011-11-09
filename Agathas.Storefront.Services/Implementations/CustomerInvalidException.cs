using System;

namespace Agathas.Storefront.Services.Implementations
{
    public class CustomerInvalidException : Exception
    {
        public CustomerInvalidException(string message) : base (message)
        {            
        }
    }
}