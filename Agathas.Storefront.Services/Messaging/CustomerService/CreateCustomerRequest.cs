using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.CommandHandler;

namespace Agathas.Storefront.Services.Messaging.CustomerService
{
    public class CreateCustomerRequest : ICommand
    {
        public string CustomerIdentityToken { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
         
    }
}
