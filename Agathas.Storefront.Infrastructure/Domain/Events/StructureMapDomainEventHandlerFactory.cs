using System;
using System.Collections.Generic;
using StructureMap;

namespace Agathas.Storefront.Infrastructure.Domain.Events
{
    public class StructureMapDomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent
        {
            return ObjectFactory.GetAllInstances<IDomainEventHandler<T>>();  
        }
    }
}
