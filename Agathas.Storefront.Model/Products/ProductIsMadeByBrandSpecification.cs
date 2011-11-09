using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Agathas.Storefront.Infrastructure.Specification;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Products
{
    public class ProductIsMadeByBrandSpecification : CompositeSpecification<Product> 
    {
        private readonly int[] _brandIds;

        public ProductIsMadeByBrandSpecification(int[] brandIds)
        {
            _brandIds = brandIds;            
        }

        public override bool IsSatisfiedBy(Product product)
        {
            if (_brandIds.Count() > 0)
                return _brandIds.Any(b => b == product.Title.Brand.Id);
            
            return true;
        }    

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            if (_brandIds.Count() == 0)
                return p => true;
            else
                return p => _brandIds.Contains(p.Title.Brand.Id);
        }
    }
}
