using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Products;
using NHibernate;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow) 
            : base(uow)
        {
        }

        public override void AppendCriteria(ICriteria criteria)
        {                        
            // Need to create some Alias's here because Nhibernate wouldn't be able to resolve "Category.Id" or "Brand.Id"
            // as a query from the Product enity as NHibernate will assume that you're referring to an explicit property name and is unclear as to how the object model should be traversed.                         
            // Using CreateAlias lets NHibernate know how to resolve the relationship, this way when we are buidling a query in the service we can happily refer to 
            // the Product properties             

            criteria.CreateAlias("Title", "ProductTitle"); 
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Colour", "Colour");                       
        }
    }
}
