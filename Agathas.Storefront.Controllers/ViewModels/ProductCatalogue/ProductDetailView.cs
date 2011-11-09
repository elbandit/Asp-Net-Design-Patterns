using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalogue
{
    public class ProductDetailView : BaseProductCataloguePageView 
    {
        public ProductDetailDto Product { get; set; }
    }
}