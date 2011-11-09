using System;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.JsonDTOs;
using Agathas.Storefront.Controllers.ViewModels;
using Agathas.Storefront.Controllers.ViewModels.ProductCatalogue;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Services.Implementations;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;

namespace Agathas.Storefront.Controllers.Controllers
{
    public class BasketController : ProductCatalogueBaseController
    {        
        private readonly IBasketService _basketService;        
        private readonly ICookieStorageService _cookieStorageService;        

        public BasketController(IProductCatalogueService productCatalogueService,
                                IBasketService basketService,                                
                                ICookieStorageService cookieStorageService)
            : base(cookieStorageService, productCatalogueService)
        {                        
            _basketService = basketService;            
            _cookieStorageService = cookieStorageService;            
        }

        public ActionResult Detail()
        {
            BasketDetailView basketView = new BasketDetailView();
            Guid basketId = base.GetBasketId();

            GetBasketRequest basketRequest = new GetBasketRequest() {BasketId = basketId};
            GetBasketResponse basketResponse = _basketService.GetBasket(basketRequest);

            GetAllDespatchOptionsResponse despatchOptionsResponse = _basketService.GetAllDespatchOptions();

            basketView.Basket = basketResponse.Basket;
            basketView.Categories = base.GetCategories();
            basketView.BasketSummary = base.GetBasketSummaryView();
            basketView.DeliveryOptions = despatchOptionsResponse.DeliveryOptions;
            
            return View("View", basketView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RemoveItem(int productId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.ItemsToRemove.Add(productId);
            request.BasketId = base.GetBasketId();

            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems, reponse.Basket.BasketTotal);

            BasketDetailView basketDetailView = new BasketDetailView();

            basketDetailView.BasketSummary = new BasketSummaryView()
                                           {
                                               BasketTotal = reponse.Basket.BasketTotal,
                                               NumberOfItems = reponse.Basket.NumberOfItems
                                           };

            basketDetailView.Basket = reponse.Basket;
            basketDetailView.DeliveryOptions = _basketService.GetAllDespatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateShipping(int shippingServiceId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.SetShippingServiceIdTo = shippingServiceId;
            request.BasketId = base.GetBasketId();

            BasketDetailView basketDetailView = new BasketDetailView();

            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems, reponse.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = reponse.Basket.BasketTotal,
                NumberOfItems = reponse.Basket.NumberOfItems
            };

            basketDetailView.Basket = reponse.Basket;
            basketDetailView.DeliveryOptions = _basketService.GetAllDespatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateItems(JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();            
            request.BasketId = base.GetBasketId();
            request.ItemsToUpdate = jsonBasketQtyUpdateRequest.ConvertToBasketItemUpdateRequests(); ;

            BasketDetailView basketDetailView = new BasketDetailView();
            ModifyBasketResponse reponse = _basketService.ModifyBasket(request);

            SaveBasketSummaryToCookie(reponse.Basket.NumberOfItems, reponse.Basket.BasketTotal);

            basketDetailView.BasketSummary = new BasketSummaryView()
            {
                BasketTotal = reponse.Basket.BasketTotal,
                NumberOfItems = reponse.Basket.NumberOfItems
            };

            basketDetailView.Basket = reponse.Basket;

            basketDetailView.DeliveryOptions = _basketService.GetAllDespatchOptions().DeliveryOptions;

            return Json(basketDetailView);
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddToBasket(int productId)
        {
            BasketSummaryView basketSummaryView = new BasketSummaryView();            
            Guid basketId = base.GetBasketId();
            bool createNewBasket = basketId == Guid.Empty;

            if (createNewBasket == false)
            {
                ModifyBasketRequest modifyBasketRequest = new ModifyBasketRequest();

                modifyBasketRequest.ProductsToAdd.Add(productId);
                modifyBasketRequest.BasketId = basketId;

                try
                {
                    ModifyBasketResponse response = _basketService.ModifyBasket(modifyBasketRequest);
                    basketSummaryView = response.Basket.ConvertToSummary();
                    SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems, basketSummaryView.BasketTotal);
                }
                catch (BasketDoesNotExistException ex)
                {
                    createNewBasket = true;
                }                                
            }

            if (createNewBasket)
            {
                CreateBasketRequest createBasketRequest = new CreateBasketRequest();

                createBasketRequest.ProductsToAdd.Add(productId);

                CreateBasketResponse response = _basketService.CreateBasket(createBasketRequest);
                
                SaveBasketIdToCookie(response.Basket.Id);
                basketSummaryView = response.Basket.ConvertToSummary();
                SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems, basketSummaryView.BasketTotal);
            }
                                                            
            return Json(basketSummaryView);
        }
        
        private void SaveBasketIdToCookie(Guid basketId)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketId.ToString(), basketId.ToString(), DateTime.Now.AddDays(1));
        }

        private void SaveBasketSummaryToCookie(int numberOfItems, string basketTotal)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(), numberOfItems.ToString(), DateTime.Now.AddDays(1));
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(), basketTotal.ToString(), DateTime.Now.AddDays(1));
        }
    }
}
