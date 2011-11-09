using System;
using System.Linq;
using System.Linq.Expressions;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Services.Presentation.Model.Specifications
{
    public class ProductDtoIsInColourSpecification : CompositeSpecification<ProductDto>
    {
        private readonly int[] _colourIds;

        public ProductDtoIsInColourSpecification(int[] colourIds)
        {
            _colourIds = colourIds;
        }

        public override bool IsSatisfiedBy(ProductDto product)
        {
            if (_colourIds.Count() > 0)
                return _colourIds.Any(c => c == product.ColourId);
            
            return true;
        }

        public override Expression<Func<ProductDto, bool>> IsSatisfied()
        {
            if (_colourIds.Count() == 0)
                return p => true;
            else
                return p => _colourIds.Contains(p.ColourId);
        }
    }
}