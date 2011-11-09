using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductTitleRepository : Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork uow) : base(uow)
        {
        }       
    }
}
