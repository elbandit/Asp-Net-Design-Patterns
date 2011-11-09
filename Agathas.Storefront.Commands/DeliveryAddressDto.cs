using System;

namespace Agathas.Storefront.Commands
{
    public class DeliveryAddressDto
    {
        public string AddressLine1;
        public string AddressLine2;
        public string City;
        public string State;
        public string Country;
        public string ZipCode;
        public int Id { get; set; }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}