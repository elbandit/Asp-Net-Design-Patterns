using System;
using System.Linq;
using System.Linq.Expressions;
using Agathas.Storefront.Infrastructure.Specification;
using Agathas.Storefront.Services.Presentation.Model;

namespace Agathas.Storefront.Services.Presentation.Model.Specifications
{
    public class ProductDtoIsInSizeSpecification : CompositeSpecification<ProductDto>
    {
        private readonly int[] _sizeIds;

        public ProductDtoIsInSizeSpecification(int[] sizeIds)
        {
            _sizeIds = sizeIds;
        }

        public override bool IsSatisfiedBy(ProductDto product)
        {
            if (_sizeIds.Count() > 0 )
                return _sizeIds.Any(s => product.SizeId == s);

            return true;
        }

        public override Expression<Func<ProductDto, bool>> IsSatisfied()
        {
            if (_sizeIds.Count() == 0)
                return p => true;
            else
                return p => _sizeIds.Contains(p.SizeId);
                //return p => _sizeIds.Contains(p.Products.SizeId);
        }
    }
}