using System;

namespace Agathas.Storefront.Model.Customers
{
    public class InvalidEmailAddressException : Exception
    {
        public InvalidEmailAddressException(string emailAddress) : base(emailAddress)
        {
            
        }
    }
}