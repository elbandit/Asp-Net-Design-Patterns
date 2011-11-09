using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.Checkout
{
    public class OrderConfirmationView
    {
        public BasketView Basket { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddresses { get; set; }
    }
}
