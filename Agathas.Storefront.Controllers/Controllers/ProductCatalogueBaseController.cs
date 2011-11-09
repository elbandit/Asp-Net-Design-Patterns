using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Infrastructure.CookieStorage;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class ProductCatalogueBaseController : BaseController
    {
        private readonly IProductCatalogueService _productCatalogueService;

        public ProductCatalogueBaseController(ICookieStorageService cookieStorageService,
                                              IProductCatalogueService productCatalogueService)
            : base(cookieStorageService)
        {
            _productCatalogueService = productCatalogueService;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            GetAllCategoriesResponse response = _productCatalogueService.GetAllCategories();

            return response.Categories;
        }

    }
}
