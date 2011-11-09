using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Model.Customers
{
    public class InvalidDeliveryAddressException : Exception 
    {
        public InvalidDeliveryAddressException(string message)
            : base(message)
        {
                
        }
    }
}
