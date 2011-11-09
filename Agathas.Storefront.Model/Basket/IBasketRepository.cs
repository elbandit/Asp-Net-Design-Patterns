using System;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Basket
{
    public interface IBasketRepository : IRepository<Basket, Guid>
    {        
    }
}
