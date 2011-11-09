using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Infrastructure.Specification;

namespace Agathas.Storefront.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int index, int count);        
        IEnumerable<T> QueryWith(ISpecification<T> specification);
        IEnumerable<T> QueryWith(ISpecification<T> specification, int index, int count);
    }
}
