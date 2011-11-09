using System;

namespace Agathas.Storefront.Model.Customers
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message)
            : base(message)
        {
         
        }
    }
}