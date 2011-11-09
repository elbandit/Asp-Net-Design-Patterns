using System;
using System.Collections.Generic;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class ModifyBasketRequest
    {        
        public ModifyBasketRequest()
        {
            ItemsToRemove = new List<int>();
            ProductsToAdd = new List<int>();
            ItemsToUpdate = new List<ProductQtyUpdateRequest>();
        }

        public Guid BasketId { get; set; }
        public IList<int> ItemsToRemove { get; set; }
        public IList<ProductQtyUpdateRequest> ItemsToUpdate { get; set; }
        public int SetShippingServiceIdTo {get; set;}
        public IList<int> ProductsToAdd { get; set; }
    }
}
