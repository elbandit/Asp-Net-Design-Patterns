using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Payments;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.CustomerAccount
{
    public class CustomerOrderView : BaseCustomerAccountView 
    {
        public OrderView Order { get; set; }        
    }
}
