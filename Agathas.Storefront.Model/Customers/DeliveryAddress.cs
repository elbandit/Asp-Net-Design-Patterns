using System;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.Validation;

namespace Agathas.Storefront.Model.Customers
{
    public class DeliveryAddress : EntityBase<int>
    {
        private DeliveryAddress()
        { }

        public DeliveryAddress(string deliveryAddressFriendlyName, Customer customer, Address address) 
        {
            Check.ThatIsNotAnEmptyString(deliveryAddressFriendlyName, () => {throw new InvalidDeliveryAddressException("A delivery adddress must have a name."); });
            Name = deliveryAddressFriendlyName;

            Check.IsNotNull(customer, () => { throw new InvalidDeliveryAddressException("A delivery adddress must be associated with a customer."); });
            Customer = customer;

            Check.IsNotNull(address, () => { throw new InvalidDeliveryAddressException("A delivery adddress have an address."); });
            Address = address;
        }

        public string Name { get; private set; }
        public Customer Customer { get; private set; }

        public Address Address { get; private set; }
        
        public void ChangeNameTo(string newAddressName)
        {
            Check.ThatIsNotAnEmptyString(newAddressName, () => { throw new InvalidDeliveryAddressException("The delivery address name cannot be empty."); });

            Name = newAddressName;
        }

        public void ChangeAddressTo(Address address)
        {
            Check.IsNotNull(address, () => { throw new InvalidDeliveryAddressException("A delivery adddress have an address."); });

            Address = address;
        }

        protected override void Validate()
        {
        }        
    }
}
