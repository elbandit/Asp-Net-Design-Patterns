using System;

namespace Agathas.Storefront.Model.Orders.States
{
    public class SubmittedOrderState : OrderState 
    {
        public override OrderStatus Status
        {
            get { return OrderStatus.Submitted; }
        }

        public override bool CanAddProduct()
        {
            return false;
        }

        public override void Submit(Order order)
        {
            throw new InvalidOperationException("You cannot Submit this order as it has already been submitted.");
        }
    }
}
