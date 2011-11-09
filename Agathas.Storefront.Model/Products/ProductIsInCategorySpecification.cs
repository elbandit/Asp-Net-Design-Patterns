using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Model.Products
{
    public class ProductIsInCategorySpecification : CompositeSpecification<Product>
    {
        private readonly int _categoryId;

        public ProductIsInCategorySpecification(int categoryId)
        {
            _categoryId = categoryId;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Title.Category.Id == _categoryId;
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => p.Title.Category.Id == _categoryId;
        }
    }
}
