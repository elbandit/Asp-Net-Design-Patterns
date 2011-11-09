using System.Collections.Generic;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;

namespace Agathas.Storefront.Services.Interfaces
{
    public interface IProductCatalogueService
    {
        GetFeaturedProductsResponse GetFeaturedProducts(); 
        GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);

        GetAllCategoriesResponse GetAllCategories();        
    }
}