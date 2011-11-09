using System;
using System.Collections.Generic;

namespace Agathas.Storefront.Services.ViewModels
{
    public class BasketView
    {
        public BasketView()
        {
            Items = new List<BasketItemView>();            
        }
        public Guid Id { get; set; }
        public string ItemsTotal { get; set; }
        public int NumberOfItems { get; set; }
        public IEnumerable<BasketItemView> Items { get; set; }
        public string BasketTotal { get; set; }
        public string DeliveryCost { get; set; }
        public string ShippingServiceDescription { get; set; }
        public int DeliveryOptionId { get; set; }           
    }
}
