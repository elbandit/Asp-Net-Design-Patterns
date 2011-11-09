using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomersOrderSummaryView : BaseCustomerAccountView 
    {
        public IEnumerable<OrderSummaryView> Orders { get; set; }
    }
}
