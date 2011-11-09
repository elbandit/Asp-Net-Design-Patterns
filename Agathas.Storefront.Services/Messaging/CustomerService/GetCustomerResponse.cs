using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.CustomerService
{
    public class GetCustomerResponse
    {
        public bool CustomerFound { get; set; }
        public CustomerView Customer { get; set; }
        public IEnumerable<OrderSummaryView> Orders { get; set; }        
    }
}
