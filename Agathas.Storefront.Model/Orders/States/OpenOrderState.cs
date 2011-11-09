using System;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Model.Orders.Events;

namespace Agathas.Storefront.Model.Orders.States 
{
    public class OpenOrderState : OrderState
    {                
        public override OrderStatus Status
        {
            get { return OrderStatus.Open; }
        }

        public override bool CanAddProduct()
        {
            return true;
        }

        public override void Submit(Order order)
        {
            if (order.OrderHasBeenPaidFor())
                order.SetStateTo(OrderStates.Submitted);

            DomainEvents.Raise(new OrderSubmittedEvent() {Order = order});
        }
    }
}