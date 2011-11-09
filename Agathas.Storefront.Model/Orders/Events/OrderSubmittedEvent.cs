using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain.Events;

namespace Agathas.Storefront.Model.Orders.Events
{
    public class OrderSubmittedEvent : IDomainEvent
    {
        public Order Order { get; set; }
    }
}
