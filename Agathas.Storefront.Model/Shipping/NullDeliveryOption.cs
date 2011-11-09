using System;

namespace Agathas.Storefront.Model.Shipping
{
    public class NullDeliveryOption : IDeliveryOption
    {
        public int Id { get; set; }

        public decimal FreeDeliveryThreshold
        {
            get { return 0; }
        }

        public decimal Cost
        {
            get { return 0;}            
        }

        public ShippingService ShippingService
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            return 0;
        }
    }
}
