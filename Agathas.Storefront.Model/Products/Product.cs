using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Categories;

namespace Agathas.Storefront.Model.Products
{
    public class Product : EntityBase<int>, IAggregateRoot
    {
        private ProductTitle _title;
        private ProductSize _size;

        public Product()
        {                
        }

        public Product(ProductTitle title, ProductSize size)
        {
            _title = title;
            _size = size;
        }
                      
        public ProductSize Size
        {
            get { return _size; }
        }
             
        public string Name
        {
            get { return _title.Name; }
        }

        public ProductTitle Title
        {
            get { return _title; }
        }

        public Decimal Price
        {
            get { return _title.Price; } 
        }
        public Brand Brand
        {
            get { return _title.Brand; }
        }

        public ProductColour Colour
        {
            get { return _title.Colour; }
        }

        public Category Category 
        {
            get { return _title.Category; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
