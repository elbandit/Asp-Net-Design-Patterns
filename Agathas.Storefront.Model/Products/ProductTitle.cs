using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Categories;

namespace Agathas.Storefront.Model.Products
{
    public class ProductTitle : EntityBase<int>, IAggregateRoot
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly Brand _brand;
        private readonly Category _category;
        private readonly ProductColour _colour;
        private readonly IEnumerable<Product> _products;

        public ProductTitle()
        {
        }

        public ProductTitle(string name, decimal price, Brand brand, 
                            Category category, ProductColour colour,
                            IEnumerable<Product> products)
        {
            _name = name;
            _price = price;
            _brand = brand;
            _category = category;
            _colour = colour;
            _products = products;
        }
                
        public string Name
        {
            get { return _name; }
        }

        public Decimal Price
        {
            get { return _price; }
        }

        public Brand Brand
        {
            get { return _brand;}
        }

        public Category Category
        {
            get { return _category; }
        }
        public ProductColour Colour
        {
            get { return _colour; }
        }

        public IEnumerable<Product> Products
        {
            get { return _products; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
