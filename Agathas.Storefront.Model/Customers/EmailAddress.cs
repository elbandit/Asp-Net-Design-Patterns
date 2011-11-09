using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Model.Customers
{
    public class EmailAddress
    {
        private readonly string _emailAddress;

        private EmailAddress()
        { }

        public EmailAddress(string emailAddress)
        {
            if (new EmailValidationSpecification().IsSatisfiedBy(emailAddress))
                _emailAddress = emailAddress;
            else
                throw new InvalidEmailAddressException(_emailAddress);
        }

        public string Address
        {
            get { return _emailAddress;  }
        }
    }
}
