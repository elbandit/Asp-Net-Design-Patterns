using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.CustomerAccount
{
    public abstract class BaseCustomerAccountView
    {
        public BasketSummaryView BasketSummary { get; set; }
    }
}
