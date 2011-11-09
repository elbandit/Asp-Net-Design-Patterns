using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Model.Orders.States;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Orders
{
    public class Order : EntityBase<int>, IAggregateRoot
    {        
        private IList<OrderItem> _items;        
        private DateTime _created;                
        private Payment _payment;
        private IOrderState _state;
        
        public Order()
        {
            _created = DateTime.Now;            
            _items = new List<OrderItem>();
            _state = OrderStates.Open; 
        }
        
        public DateTime Created
        {
            get { return _created; }
        }

        public decimal ShippingCharge { get; set; }

        public ShippingService ShippingService { get; set; } 
               
        public decimal ItemTotal()
        {
            return Items.Sum(i => i.LineTotal());
        }

        public decimal Total()
        {            
            return Items.Sum(i => i.LineTotal()) + ShippingCharge;
        }

        public Payment Payment
        {
            get { return _payment; }
        }

        public void SetPayment(Payment payment)
        {                                     
                if (OrderHasBeenPaidFor())
                    throw new OrderAlreadyPaidForException(GetDetailsOnExisitingPayment());
           
                if (OrderTotalMatches(payment))            
                    _payment = payment;            
                else            
                    throw new PaymentAmountDoesNotEqualOrderTotalException(GetDetailsOnIssueWith(payment));           

                _state.Submit(this);                                   
        }

        private string GetDetailsOnExisitingPayment()
        {
            return String.Format("Order has already been paid for. "+
                                 "{0} was paid on {1}. Payment token '{2}'", 
                                 Payment.Amount, Payment.DatePaid, Payment.TransactionId);
        }

        private string GetDetailsOnIssueWith(Payment payment)
        {
            return String.Format("Payment amount is invalid. " +
                                "Order total is {0} but payment for {1}. Payment token '{2}'",
                                this.Total(), payment.Amount, payment.TransactionId);
        }

        public bool OrderHasBeenPaidFor()
        {
            return Payment != null && OrderTotalMatches(Payment);
        }

        private bool OrderTotalMatches(Payment payment)
        {            
            return Total() == payment.Amount;
        }

        public Customer Customer { get; set; }

        public Address DeliveryAddress { get; set; } 
       
        public IEnumerable<OrderItem> Items
        {
            get { return _items; }
        }

        public OrderStatus Status
        {
            get { return _state.Status; }
        }
        
        public void AddItem(Product product, int qty)
        {
            if (_state.CanAddProduct())
            {
                if (!OrderContains(product))
                    _items.Add(OrderItemFactory.CreateItemFor(product, this, qty));
            }
            else
                throw new CannotAmendOrderException(String.Format("You cannot add an item to an order with the status of '{0}'.", Status.ToString()));
        }

        private bool OrderContains(Product product)
        {
            return _items.Any(i => i.Contains(product));
        }
      
        protected override void Validate()
        {
            if (Created == DateTime.MinValue)
                base.AddBrokenRule(OrderBusinessRules.CreatedDateRequired);
            
            if (Customer == null)
                base.AddBrokenRule(OrderBusinessRules.CustomerRequired);

            if (DeliveryAddress == null)
                base.AddBrokenRule(OrderBusinessRules.DeliveryAddressRequired);

            if (Items == null || Items.Count() == 0)
                base.AddBrokenRule(OrderBusinessRules.ItemsRequired);
            else
            {
                if (Items.Any(i => i.GetBrokenRules().Count() > 0))
                {
                    foreach (OrderItem item in Items.Where(i => i.GetBrokenRules().Count() > 0))
                    {
                        foreach (BusinessRule businessRule in item.GetBrokenRules())
                        {
                            base.AddBrokenRule(businessRule);
                        }
                    }
                }
            }            

            if (ShippingService == null)
                base.AddBrokenRule(OrderBusinessRules.ShippingServiceRequired);            

        }

        internal void SetStateTo(IOrderState state)
        {
            this._state = state;
        }

        public override string ToString()
        {
            StringBuilder orderInfo = new StringBuilder();

            foreach (OrderItem item in _items)
            {
                orderInfo.AppendLine(String.Format("{0} of {1} ", item.Quantity, item.Product.Name));
            }

            orderInfo.AppendLine(String.Format("Shipping: {0}", this.ShippingCharge));
            orderInfo.AppendLine(String.Format("Total: {0}", this.Total()));

            return orderInfo.ToString();

        }
    }
}
