using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model
{
    public class AddressBusinessRules
    {
        public static readonly BusinessRule AddressLine1Required = new BusinessRule("AddressLine1", "The 1st line of an Address is required.");
        public static readonly BusinessRule CityRequired = new BusinessRule("City", "An address must have a city.");
        public static readonly BusinessRule StateRequired = new BusinessRule("State", "An address must have a state.");
        public static readonly BusinessRule CountryRequired = new BusinessRule("Country", "An address must have a country.");
        public static readonly BusinessRule ZipCodeRequired = new BusinessRule("ZipCode", "An address must have a zip code.");

    }
}
