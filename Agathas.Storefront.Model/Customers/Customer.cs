using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.Validation;
using Agathas.Storefront.Model.Orders;

namespace Agathas.Storefront.Model.Customers
{
    public class Customer : EntityBase<int>, IAggregateRoot
    {
        private Customer()
        { }

        public Customer(string identityToken, EmailAddress emailAddress, Name name)
        {
            Check.ThatIsNotAnEmptyString(identityToken, () => { throw new InvalidCustomerException("Customer IdentityToken must not be empty or null."); });
            IdentityToken = identityToken;

            Check.IsNotNull(emailAddress, () => { throw new InvalidCustomerException("Customer must be created with a valid email address."); });
            Email = emailAddress;

            Check.IsNotNull(name, () => { throw new InvalidCustomerException("Customer must be created with a valid name."); });
            Name = name;            
        }

        private IList<DeliveryAddress> _deliveryAddressBook = new List<DeliveryAddress>();
        
        public string IdentityToken { get; private set; }        
        public EmailAddress Email { get; private set; }

        public Name Name { get; private set; }

        public void AddAddress(Address deliveryAddress,string friendlyName)
        {
            Check.IsNotNull(deliveryAddress, () => { throw new InvalidAddressException("Address cannot be null."); });

            Check.ThatIsNotAnEmptyString(friendlyName, () => { throw new InvalidAddressException("A delivery address must have a name."); });

            _deliveryAddressBook.Add(new DeliveryAddress(friendlyName, this, deliveryAddress));
        }
        
        public IEnumerable<DeliveryAddress> DeliveryAddressBook
        {
            get { return _deliveryAddressBook; }
        }

        public IList<Order> Orders { get; set; }

        protected override void Validate()
        {                                    
        }

        public void ChangeNameTo(Name newCustomerName)
        {
            Check.IsNotNull(newCustomerName, () => { throw new InvalidNameException("A customers name cannot be null."); });
            this.Name = newCustomerName;            
        }

        public void ChangeEmailTo(EmailAddress email)
        {
            Check.IsNotNull(email, () => { throw new InvalidEmailAddressException("A customers email cannot be null."); });
            this.Email = email;
        }
    }
}
