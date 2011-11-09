using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Controllers.ViewModels.Account
{
    public class CallBackSettings
    {      
        public string ReturnUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
