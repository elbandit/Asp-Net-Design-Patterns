using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.Messaging.CustomerService
{
    public class GetCustomerRequest
    {
        public string CustomerIdentityToken { get; set; }
        public bool LoadOrderSummary { get; set; }                
    }
}
