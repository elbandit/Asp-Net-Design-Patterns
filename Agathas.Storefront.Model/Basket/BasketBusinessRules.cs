using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Basket
{
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequired = new BusinessRule("DeliveryOption", "An order must have a valid delivery option.");        
        public static readonly BusinessRule ItemInvalid = new BusinessRule("Item", "A basket cannot have any invalid items.");
    }
}
