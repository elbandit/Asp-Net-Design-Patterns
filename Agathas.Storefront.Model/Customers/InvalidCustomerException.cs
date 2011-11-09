using System;

namespace Agathas.Storefront.Model.Customers
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string message) : base (message)
        {            
        }
    }
}