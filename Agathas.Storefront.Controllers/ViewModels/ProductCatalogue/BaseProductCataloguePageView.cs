using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalogue
{
    public abstract class BaseProductCataloguePageView : BasePageView 
    {
        public IEnumerable<CategoryDto> Categories { get; set; }        
    }
}
