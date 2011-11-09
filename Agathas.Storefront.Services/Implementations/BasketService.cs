using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Mapping;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;        
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly IUnitOfWork _uow;

        public BasketService(IBasketRepository basketRepository,
                             IProductRepository productRepository,
                             IDeliveryOptionRepository deliveryOptionRepository,
                             IUnitOfWork uow)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _uow = uow;
        }
        
        public GetBasketResponse GetBasket(GetBasketRequest request)
        {
            GetBasketResponse response = new GetBasketResponse();

            Basket basket = _basketRepository.FindBy(request.BasketId);
            BasketView basketView;

            if (basket != null)
                basketView = basket.ConvertToBasketView();
            else
                basketView = new BasketView();
            
            response.Basket = basketView;

            return response;
        }

        public CreateBasketResponse CreateBasket(CreateBasketRequest request)
        {

            // 1. Send Create Basket Command

            // 2. Query the presentation layer for the new basket

            CreateBasketResponse response = new CreateBasketResponse();

            Basket basket = new Basket();
                                   
            basket.SetDeliveryOption(GetCheapestDeliveryOption());

            AddProductsToBasket(request.ProductsToAdd, basket);

            ThrowExceptionIfBasketIsInvalid(basket);

            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();

            return response;
        }

        private DeliveryOption GetCheapestDeliveryOption()
        {
            return _deliveryOptionRepository.FindAll().OrderBy(d => d.Cost).FirstOrDefault();
        }

        private void ThrowExceptionIfBasketIsInvalid(Basket basket)
        {
            if (basket.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the Basket:");
                foreach(BusinessRule businessRule in basket.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new ApplicationException(brokenRules.ToString());

            }
        }

        public ModifyBasketResponse ModifyBasket(ModifyBasketRequest request)
        {
            ModifyBasketResponse response = new ModifyBasketResponse();
            Basket basket = _basketRepository.FindBy(request.BasketId);

            if (basket == null)
                throw new BasketDoesNotExistException();

            AddProductsToBasket(request.ProductsToAdd, basket);
            
            UpdateLineQtys(request.ItemsToUpdate, basket);

            RemoveItemsFromBasket(request.ItemsToRemove, basket);

            if (request.SetShippingServiceIdTo != 0)
            {
                DeliveryOption deliveryOption = _deliveryOptionRepository.FindBy(request.SetShippingServiceIdTo);
                basket.SetDeliveryOption(deliveryOption);
            }

            ThrowExceptionIfBasketIsInvalid(basket);
   
            _basketRepository.Save(basket);
            _uow.Commit();

            response.Basket = basket.ConvertToBasketView();

            return response;            
        }

        private void RemoveItemsFromBasket(IList<int> productsToRemove, Basket basket)
        {
            foreach (int productId in productsToRemove)
            {
                Product product = _productRepository.FindBy(productId);
                if (product != null)
                    basket.Remove(product);
            }
        }

        private void UpdateLineQtys(IList<ProductQtyUpdateRequest> productQtyUpdateRequests, Basket basket)
        {
            foreach (ProductQtyUpdateRequest productQtyUpdateRequest in productQtyUpdateRequests)
            {
                Product product = _productRepository.FindBy(productQtyUpdateRequest.ProductId);

                if (product != null)
                    basket.ChangeQuantityOfProduct(new NonNegativeQuantity(productQtyUpdateRequest.NewQty), product);
            }
        }

        private void AddProductsToBasket(IList<int> productsToAdd, Basket basket)
        {
            Product product;

            if (productsToAdd.Count() > 0)
                foreach (int productId in productsToAdd)
                {
                    product = _productRepository.FindBy(productId);
                    basket.Add(product);
                }
        }

        public GetAllDespatchOptionsResponse GetAllDespatchOptions()
        {
            GetAllDespatchOptionsResponse response = new GetAllDespatchOptionsResponse();
            response.DeliveryOptions = _deliveryOptionRepository.FindAll().OrderBy(d => d.Cost).ConvertToDeliveryOptionViews();

            return response;
        }
    }
}
