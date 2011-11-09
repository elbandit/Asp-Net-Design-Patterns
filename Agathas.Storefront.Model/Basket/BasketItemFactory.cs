using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Basket
{
    public static class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Product product, Basket basket)
        {
            return new BasketItem(product, basket, new NonNegativeQuantity(1));
        }
    }
}
