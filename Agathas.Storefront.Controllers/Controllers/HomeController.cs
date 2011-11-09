using System.Net.Mail;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ViewModels.ProductCatalogue;
using Agathas.Storefront.Infrastructure.Email;
using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Infrastructure.CookieStorage;

namespace Agathas.Storefront.Controllers.Controllers
{    
    public class HomeController : ProductCatalogueBaseController
    {                        
        private readonly IProductCatalogueService _productCatalogueService;

        public HomeController(IProductCatalogueService productCatalogueService,
                              ICookieStorageService cookieStorageService)
            : base(cookieStorageService, productCatalogueService)
        {            
            _productCatalogueService = productCatalogueService;
        }

        public ActionResult Index()
        {                                    
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            homePageView.BasketSummary = base.GetBasketSummaryView();

            GetFeaturedProductsResponse response = _productCatalogueService.GetFeaturedProducts();
            homePageView.Products = response.Products; 

            return View(homePageView);
        }       
    }
}
