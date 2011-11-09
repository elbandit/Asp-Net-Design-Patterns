using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Services.Presentation.Model.Specifications
{
    public class ProductDtoIsInCategorySpecification : CompositeSpecification<ProductDto>
    {
        private readonly int _categoryId;

        public ProductDtoIsInCategorySpecification(int categoryId)
        {
            _categoryId = categoryId;
        }

        public override bool IsSatisfiedBy(ProductDto candidate)
        {
            return candidate.CategoryId == _categoryId;
        }

        public override Expression<Func<ProductDto, bool>> IsSatisfied()
        {
            return p => p.CategoryId == _categoryId;
        }
    }
}
