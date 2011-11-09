using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Basket
{
    public class BasketItem : EntityBase<int>
    {
        private NonNegativeQuantity _quantity;
        private Product _product;
        private Basket _basket;

        private BasketItem()
        {
        }

        public BasketItem(Product product, Basket basket, NonNegativeQuantity quantity)
        {
            _product = product;
            _basket = basket;
            Quantity = quantity;
        }
        
        public decimal LineTotal()
        {
            return Product.Price*Quantity.Value;
        }

        public NonNegativeQuantity Quantity { get; private set; }

        public Product Product { get { return _product; } }

        public Basket Basket { get { return _basket; } }
       
        public bool Contains(Product product)
        {
            return Product == product;
        }

        public void IncreaseItemQtyBy(NonNegativeQuantity quantity)
        {
            Quantity = Quantity.Add(quantity);
        }

        public void ChangeItemQtyTo(NonNegativeQuantity quantity)
        {
            Quantity = quantity;
        }

        protected override void Validate()
        {            
            if (Product == null)
                base.AddBrokenRule(BasketItemBusinessRules.ProductRequired);

            if (Basket == null)
                base.AddBrokenRule(BasketItemBusinessRules.BasketRequired);
        }
    }
}
