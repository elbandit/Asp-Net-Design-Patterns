using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Specification
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _innerSpecification;

        public NotSpecification(ISpecification<T> innerSpecification)
        {
            _innerSpecification = innerSpecification;
        }

        public override Expression<Func<T, bool>> IsSatisfied()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(_innerSpecification.IsSatisfied())); 
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !_innerSpecification.IsSatisfiedBy(candidate);
        }
    }
}
