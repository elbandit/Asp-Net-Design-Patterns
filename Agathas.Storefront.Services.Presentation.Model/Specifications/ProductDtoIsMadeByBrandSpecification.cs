using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Services.Presentation.Model.Specifications
{
    public class ProductDtoIsMadeByBrandSpecification : CompositeSpecification<ProductDto> 
    {
        private readonly int[] _brandIds;

        public ProductDtoIsMadeByBrandSpecification(int[] brandIds)
        {
            _brandIds = brandIds;            
        }

        public override bool IsSatisfiedBy(ProductDto product)
        {
            if (_brandIds.Count() > 0)
                return _brandIds.Any(b => b == product.BrandId);
            
            return true;
        }

        public override Expression<Func<ProductDto, bool>> IsSatisfied()
        {
            if (_brandIds.Count() == 0)
                return p => true;
            else
                return p => _brandIds.Contains(p.BrandId);
        }
    }
}
