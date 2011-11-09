using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.CustomerService
{
    public class ModifyCustomerResponse
    {
        public CustomerView Customer { get; set; }
    }
}
