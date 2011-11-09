using Agathas.Storefront.Services.Messaging.ProductCatalogueService;

namespace Agathas.Storefront.Services.Interfaces
{
    public interface IBasketService
    {
        GetBasketResponse GetBasket(GetBasketRequest basketRequest);
        CreateBasketResponse CreateBasket(CreateBasketRequest basketReques);
        ModifyBasketResponse ModifyBasket(ModifyBasketRequest request);
        GetAllDespatchOptionsResponse GetAllDespatchOptions();                                   
    }
}