using System;
using System.Linq;
using System.Linq.Expressions;
using Agathas.Storefront.Infrastructure.Specification;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Products
{
    public class ProductIsInSizeSpecification : CompositeSpecification<Product>
    {
        private readonly int[] _sizeIds;

        public ProductIsInSizeSpecification(int[] sizeIds)
        {
            _sizeIds = sizeIds;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            if (_sizeIds.Count() > 0 )
                return _sizeIds.Any(s => product.Title.Products.Any(p => p.Size.Id == s));

            return true;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            if (_sizeIds.Count() == 0)
                return p => true;
            else
                return p => _sizeIds.Contains(p.Size.Id);
        }
    }
}