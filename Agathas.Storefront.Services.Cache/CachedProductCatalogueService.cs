using System;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Infrastructure.Presentation;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Cache.CacheStorage;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Mapping;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.Presentation.Model.Specifications;

namespace Agathas.Storefront.Services.Cache
{
    public class CachedProductCatalogueService : IProductCatalogueService
    {
        private readonly ICacheStorage _cachStorage;
        private readonly IProductCatalogueService _realProductCatalogueService;
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPresentationRepository _presentationRepository;
        private readonly Object _getTopSellingProductsLock = new Object();
        private readonly Object _getAllProductTitlesLock = new Object();
        private readonly Object _getAllProductsLock = new Object();
        private readonly object _getAllCategoriesLock = new object();

        public CachedProductCatalogueService(ICacheStorage cachStorage,
                                             IProductCatalogueService realProductCatalogueService,
                                             IProductTitleRepository productTitleRepository,
                                             IProductRepository productRepository,
                                             IPresentationRepository presentationRepository)
        {
            _cachStorage = cachStorage;
            _realProductCatalogueService = realProductCatalogueService;
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _presentationRepository = presentationRepository;
        }

        private IEnumerable<ProductDetailDto> FindAllProductTitles()
        {
            lock (_getAllProductTitlesLock)
            {
                IEnumerable<ProductDetailDto> allProductTitles;

                allProductTitles =
                    _cachStorage.Retrieve<IEnumerable<ProductDetailDto>>(CacheKeys.AllProductTitles.ToString());

                if (allProductTitles == null)
                {
                    allProductTitles = _presentationRepository.FindByType<ProductDetailDto>();
                    _cachStorage.Store(CacheKeys.AllProductTitles.ToString(), allProductTitles);
                }

                return allProductTitles;
            }
        }

        private IEnumerable<ProductDto> FindAllProducts()
        {
            lock (_getAllProductsLock)
            {
                IEnumerable<ProductDto> allProducts;

                allProducts = _cachStorage.Retrieve<IEnumerable<ProductDto>>(CacheKeys.AllProducts.ToString());

                if (allProducts == null)
                {
                    allProducts = _presentationRepository.FindByType<ProductDto>();
                    _cachStorage.Store(CacheKeys.AllProducts.ToString(), allProducts);
                }

                return allProducts;
            }
        }

        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            lock (_getTopSellingProductsLock)
            {
                var response = new GetFeaturedProductsResponse();
                var productViews = _cachStorage.Retrieve<IEnumerable<FeaturedProductDto>>(CacheKeys.TopSellingProducts.ToString());

                if (productViews == null)
                {
                    response = _realProductCatalogueService.GetFeaturedProducts();
                    _cachStorage.Store(CacheKeys.TopSellingProducts.ToString(), response.Products);
                }
                else
                {
                    response.Products = productViews;
                }

                return response;
            }
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {

            var spec = new ProductDtoIsInCategorySpecification(request.CategoryId)
                    .And(new ProductDtoIsInColourSpecification(request.ColourIds))
                    .And(new ProductDtoIsMadeByBrandSpecification(request.BrandIds))
                    .And(new ProductDtoIsInSizeSpecification(request.SizeIds));            

            IEnumerable<ProductDto> matchingProducts = FindAllProducts().Where(spec.IsSatisfiedBy);                

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceLowToHigh:
                    matchingProducts = matchingProducts.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceHighToLow:
                    matchingProducts = matchingProducts.OrderByDescending(p => p.Price);
                    break;
            }

            GetProductsByCategoryResponse response = matchingProducts.CreateProductSearchResultFrom(request);

            response.SelectedCategoryName =
                GetAllCategories().Categories.Where(c => c.Id == request.CategoryId).FirstOrDefault().Name;                                

            return response;
        }
        
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            response.Product = FindAllProductTitles().Where(p => p.Id == request.ProductId).FirstOrDefault();

            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            lock (_getAllCategoriesLock)
            {
                GetAllCategoriesResponse response =
                    _cachStorage.Retrieve<GetAllCategoriesResponse>(CacheKeys.AllCategories.ToString());

                if (response == null)
                {
                    response = _realProductCatalogueService.GetAllCategories();
                    _cachStorage.Store(CacheKeys.AllCategories.ToString(), response);
                }

                return response;
            }
        }
    }
}
    