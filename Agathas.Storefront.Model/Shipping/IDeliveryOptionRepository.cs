using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Shipping
{
    public interface IDeliveryOptionRepository : IReadOnlyRepository<DeliveryOption, int>
    {        
    }
}
