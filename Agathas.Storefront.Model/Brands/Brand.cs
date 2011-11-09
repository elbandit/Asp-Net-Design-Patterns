using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Brands
{
    public class Brand : IAggregateRoot, IProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
