using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain.Events;
using StructureMap;

namespace Agathas.Storefront.Infrastructure.Container
{
    public interface IContainer
    {
        IEnumerable<T> ResolveAll<T>();
    }

    public class StructureMapContainer : IContainer
    {
        public IEnumerable<T> ResolveAll<T>()
        {
            return ObjectFactory.GetAllInstances<T>();  
        }
    }
}
