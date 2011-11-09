using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.CommandHandler;

namespace Agathas.Storefront.Commands
{
    public class AddCustomerDeliveryAddressCommand : ICommand
    {
        public string CustomerIdentityToken { get; set; }        
    }
}
