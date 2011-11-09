using System;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Basket;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class BasketRepository : Repository<Basket, Guid>, IBasketRepository
    {
        public BasketRepository(IUnitOfWork uow)
            : base(uow)
        {
        }    
    }
}
