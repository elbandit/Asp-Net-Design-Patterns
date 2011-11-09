using System;
using System.Collections;
using System.Collections.Generic;
using Agathas.Storefront.Infrastructure.Domain.Events;

namespace Agathas.Storefront.Model.Tests.Order_Specs
{
    public class StubDomaubinEventHandlerFactory : IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent
        {
            IEnumerable<IDomainEventHandler<T>> domainEventHandlers = new List<IDomainEventHandler<T>>();

            return domainEventHandlers;
        }
    }
}