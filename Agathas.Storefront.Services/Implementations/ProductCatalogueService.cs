using System.Collections.Generic;
using Agathas.Storefront.Infrastructure.Presentation;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Mapping;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;
using Agathas.Storefront.Services.Presentation.Model;
using Agathas.Storefront.Services.Presentation.Model.Specifications;

namespace Agathas.Storefront.Services.Implementations
{
    public class ProductCatalogueService : IProductCatalogueService
    {                
        private readonly IPresentationRepository _presentationRepository;

        public ProductCatalogueService(IPresentationRepository presentationRepository)
        {                        
            _presentationRepository = presentationRepository;
        }

        private IEnumerable<ProductDto> GetAllProductsMatchingQuery(GetProductsByCategoryRequest request)
        {                        
            var queryDtoSpec = new ProductDtoIsInCategorySpecification(request.CategoryId)
                    .And(new ProductDtoIsInColourSpecification(request.ColourIds))
                    .And(new ProductDtoIsMadeByBrandSpecification(request.BrandIds))
                    .And(new ProductDtoIsInSizeSpecification(request.SizeIds));

            IEnumerable<ProductDto> productsMatchingRefinement =
                _presentationRepository.FindBySpec<ProductDto>(queryDtoSpec); 

            
            // TODO: Correct Sort By Logic)
            //switch (request.SortBy)
            //{
            //    case ProductsSortBy.PriceLowToHigh:
            //        productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
            //        break;
            //    case ProductsSortBy.PriceHighToLow:
            //        productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
            //        break;
            //}

            return productsMatchingRefinement;
        }
                
     
        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            var response = new GetFeaturedProductsResponse();

            response.Products = _presentationRepository.FindByType<FeaturedProductDto>();
            
            return response;
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;
            
            //ISpecification<Product> productSpec = ProductSearchRequestQueryGenerator.CreateSpecificationFor(request);

            var productsMatchingRefinement = GetAllProductsMatchingQuery(request);

            response = productsMatchingRefinement.CreateProductSearchResultFrom(request);

             var category = _presentationRepository.FindFirstByExample<CategoryDto>(new { Id = request.CategoryId });

            response.SelectedCategoryName = category.Name;

            
            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse
                               {
                                   Product =
                                       _presentationRepository.FindFirstByExample<ProductDetailDto>(
                                           new {Id = request.ProductId})
                               };

            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            var response = new GetAllCategoriesResponse();

            response.Categories = _presentationRepository.FindByType<CategoryDto>();
            
            return response;
        }
    }
}
