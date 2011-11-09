using System.Collections.Generic;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Infrastructure.Presentation
{
    public interface IPresentationRepository
    {
        IEnumerable<T> FindByType<T>();

        IEnumerable<T> FindByExample<T>(object propertiesAndValues);

        IEnumerable<T> FindBySpec<T>(ISpecification<T> specification);

        T FindFirstByExample<T>(object propertiesAndValues);

        T FindFirstBySpec<T>(ISpecification<T> specification);
    }
}
