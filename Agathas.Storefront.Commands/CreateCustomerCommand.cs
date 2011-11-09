using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.CommandHandler;

namespace Agathas.Storefront.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public string CustomerIdentityToken;
        public string Email;
        public string FirstName;
        public string SecondName;
    }
}
