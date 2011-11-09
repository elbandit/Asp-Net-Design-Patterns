using System;

namespace Agathas.Storefront.Services.Messaging.OrderService
{
    public class CreateOrderRequest
    {
        public int DeliveryId { get; set; }
        public Guid BasketId { get; set; }
        public string CustomerIdentityToken { get; set; }
    }
}
