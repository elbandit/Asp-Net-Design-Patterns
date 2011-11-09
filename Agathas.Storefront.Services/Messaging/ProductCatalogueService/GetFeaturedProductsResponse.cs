using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.Presentation.Model;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<FeaturedProductDto> Products { get; set; }
    }
}
