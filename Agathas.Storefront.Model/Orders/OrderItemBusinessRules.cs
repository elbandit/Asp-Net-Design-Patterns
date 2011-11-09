using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Orders
{
    public class OrderItemBusinessRules
    {        
        public static readonly BusinessRule OrderRequired = new BusinessRule("OrderRequired", "An order item must be associated with an order.");
        public static readonly BusinessRule PriceNonNegative = new BusinessRule("Price", "An order item must have a non negative price value.");
        public static readonly BusinessRule QtyNonNegative = new BusinessRule("Quantity", "An order item must have a positive qty value.");
        public static readonly BusinessRule ProductRequired = new BusinessRule("Product", "An order item must be associated with a valid product.");
    }
}
