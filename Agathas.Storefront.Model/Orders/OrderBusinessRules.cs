using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Orders
{
    public class OrderBusinessRules
    {
        public static readonly BusinessRule CreatedDateRequired = new BusinessRule("CreatedDate", "An order must have a created date.");
        public static readonly BusinessRule PaymentTransactionIdRequired = new BusinessRule("PaymentTransactionId", "If an order is set as paid it must have a corresponding payment transaction id.");
        public static readonly BusinessRule CustomerRequired = new BusinessRule("Customer", "An order must be associated with a customer.");
        public static readonly BusinessRule DeliveryAddressRequired = new BusinessRule("DeliveryAddress", "An order must have a valid delilvery address.");
        public static readonly BusinessRule ItemsRequired = new BusinessRule("Items", "An order must contain at least one order item.");
        public static readonly BusinessRule ShippingServiceRequired = new BusinessRule("ShippingService", "An order have a shipping service set.");
    }
}
