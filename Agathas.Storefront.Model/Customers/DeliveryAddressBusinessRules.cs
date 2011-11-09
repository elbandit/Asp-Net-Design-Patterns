using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Customers
{
    public class DeliveryAddressBusinessRules
    {
        public static readonly BusinessRule NameRequired = new BusinessRule("Name", "A delivery address must have a name.");
        public static readonly BusinessRule CustomerRequired = new BusinessRule("Customer", "A delivery address must have associated with a customer.");
    }
}
