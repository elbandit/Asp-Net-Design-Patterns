using System;
using System.Linq;
using System.Linq.Expressions;
using Agathas.Storefront.Infrastructure.Specification;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Products
{
    public class ProductIsInColourSpecification : CompositeSpecification<Product>
    {
        private readonly int[] _colourIds;

        public ProductIsInColourSpecification(int[] colourIds)
        {
            _colourIds = colourIds;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            if (_colourIds.Count() > 0)
                return _colourIds.Any(c => c == product.Title.Colour.Id);
            
            return true;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            if (_colourIds.Count() == 0)
                return p => true;
            else
                return p => _colourIds.Contains(p.Title.Colour.Id);
        }
    }
}