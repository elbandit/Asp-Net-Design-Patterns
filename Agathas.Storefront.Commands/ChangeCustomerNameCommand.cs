using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.CommandHandler;

namespace Agathas.Storefront.Commands
{
    public class ChangeCustomerNameCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerIdentityToken { get; set; }        
    }
}
