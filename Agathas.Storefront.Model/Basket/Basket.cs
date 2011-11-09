using System;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Basket
{
    public class Basket : EntityBase<Guid>, IAggregateRoot
    {
        private IList<BasketItem> _items;
        private IDeliveryOption _deliveryOption;

        public Basket()
        {
            _items = new List<BasketItem>();
            _deliveryOption = new NullDeliveryOption();
        }

        
        public int NumberOfItems
        {
            get { return _items.Sum(i => i.Quantity.Value);  }
        }

        public decimal BasketTotal
        {
            get { return ItemsTotal + DeliveryCost(); }
        }

        public decimal ItemsTotal
        {
            get { return _items.Sum(i => i.Quantity.Value * i.Product.Price); }
        }

        public void Add(Product product)
        {            
            if (BasketContainsAnItemFor(product))
                GetItemFor(product).IncreaseItemQtyBy(new NonNegativeQuantity(1));
            else            
                _items.Add(BasketItemFactory.CreateItemFor(product, this));           
        }

        private BasketItem GetItemFor(Product product)
        {
            return _items.Where(i => i.Contains(product)).FirstOrDefault();
        }

        private bool BasketContainsAnItemFor(Product product)
        {            
            return _items.Any(i => i.Contains(product));
        }

        public void Remove(Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                _items.Remove(GetItemFor(product));
            }           
        }

        public void ChangeQuantityOfProduct(NonNegativeQuantity quantity, Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                if (quantity.IsZero())
                {
                    Remove(product);
                }
                else
                    GetItemFor(product).ChangeItemQtyTo(quantity);                
            }
        }

        public int NumberOfItemsInBasket()
        {
            return _items.Sum(i => i.Quantity.Value);
        }

        public IEnumerable<BasketItem> Items()
        {
            return _items;            
        }

        public decimal DeliveryCost()
        {
            return DeliveryOption.GetDeliveryChargeForBasketTotalOf(ItemsTotal);
        }

        public IDeliveryOption DeliveryOption
        {
            get { return _deliveryOption; }
        }

        public void SetDeliveryOption(IDeliveryOption deliveryOption)
        {
            _deliveryOption = deliveryOption;
        }
               
        protected override void Validate()
        {
            if (DeliveryOption == null)
                base.AddBrokenRule(BasketBusinessRules.DeliveryOptionRequired);
            
            foreach (BasketItem item in this.Items())
            {
                if (item.GetBrokenRules().Count() > 0)
                    base.AddBrokenRule(BasketBusinessRules.ItemInvalid);
            }
        }       
    }
}
