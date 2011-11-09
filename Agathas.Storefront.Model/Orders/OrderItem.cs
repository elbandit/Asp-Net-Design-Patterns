using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Orders
{
    public class OrderItem : EntityBase<int>
    {
        private readonly Product _product;
        private readonly Order _order;
        private readonly int _quantity;
        private readonly decimal _price;

        public OrderItem()
        {
        }

        public OrderItem(Product product, Order order, int quantity)
        {
            _product = product;
            _order = order;
            _price = product.Price;
            _quantity = quantity;            
        }
        
        public Product Product
        {
            get { return _product; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public decimal Price
        {
            get { return _price;  }
        }

        public Order Order
        {
            get { return _order;}
        }

        public decimal LineTotal()
        {
            return Quantity * Price;
        }

        protected override void Validate()
        {
            if (Order == null)
                base.AddBrokenRule(OrderItemBusinessRules.OrderRequired);

            if (Product == null)
                base.AddBrokenRule(OrderItemBusinessRules.ProductRequired);

            if (Price  < 0)
                base.AddBrokenRule(OrderItemBusinessRules.PriceNonNegative);

            if (Quantity > 0)
                base.AddBrokenRule(OrderItemBusinessRules.QtyNonNegative);
        }

        public bool Contains(Product product)
        {
            return Product == product;
        }
    }
}
