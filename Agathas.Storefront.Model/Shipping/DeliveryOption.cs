using System;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Shipping
{
    public class DeliveryOption : EntityBase<int>, IAggregateRoot, IDeliveryOption
    {
        private readonly decimal _freeDeliveryThreshold;
        private readonly decimal _cost;
        private readonly ShippingService _shippingService;

        private DeliveryOption()
        {
        }

        public DeliveryOption(decimal freeDeliveryThreshold, decimal cost, ShippingService shippingService)
        {
            _freeDeliveryThreshold = freeDeliveryThreshold;
            _cost = cost;
            _shippingService = shippingService;
        }
        
        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            if (total > FreeDeliveryThreshold)
                return 0;

            return Cost;
        }
        
        public decimal FreeDeliveryThreshold
        {
            get { return _freeDeliveryThreshold; }
        }

        public decimal Cost
        {
            get { return _cost;}
        }

        public ShippingService ShippingService
        {
            get { return _shippingService; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
