using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.CommandHandler;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.CustomerService
{
    public class DeliveryAddressModifyRequest : ICommand
    {
        public string CustomerIdentityToken { get; set; }
        public DeliveryAddressView Address { get; set; }
    }
}
