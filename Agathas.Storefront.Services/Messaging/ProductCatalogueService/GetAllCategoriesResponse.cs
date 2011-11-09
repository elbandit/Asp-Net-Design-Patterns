using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
