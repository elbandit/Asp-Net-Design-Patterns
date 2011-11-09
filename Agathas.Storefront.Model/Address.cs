using System;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.Validation;

namespace Agathas.Storefront.Model
{
    public class Address
    {
        private Address()
        { }

        public Address(string line1, string line2, string city, string state, string country, string zipCode)
        {
            Check.ThatIsNotAnEmptyString(line1, () => { throw new InvalidAddressException("An address must have a street"); });
            AddressLine1 = line1;

            // Optional
            AddressLine2 = line2;

            Check.ThatIsNotAnEmptyString(city, () => { throw new InvalidAddressException("An address must have a city"); });
            City = city;

            Check.ThatIsNotAnEmptyString(state, () => { throw new InvalidAddressException("An address must have a state"); });
            State = state;

            Check.ThatIsNotAnEmptyString(country, () => { throw new InvalidAddressException("An address must have a country"); });
            Country = country;

            Check.ThatIsNotAnEmptyString(zipCode, () => { throw new InvalidAddressException("An address must have a zip code."); });
            ZipCode = zipCode;
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }                
    }
}
