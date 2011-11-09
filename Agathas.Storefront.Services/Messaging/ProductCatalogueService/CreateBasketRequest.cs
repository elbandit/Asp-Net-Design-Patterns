using System.Collections.Generic;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class CreateBasketRequest
    {
        public CreateBasketRequest()
        {
            ProductsToAdd = new List<int>();
        }
        public IList<int> ProductsToAdd { get; set; }
    }
}
