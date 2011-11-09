using System;
using System.Linq.Expressions;

namespace Agathas.Storefront.Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfied();

        bool IsSatisfiedBy(T entity);
    }
}
