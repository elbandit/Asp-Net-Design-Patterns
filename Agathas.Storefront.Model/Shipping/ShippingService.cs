using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Shipping
{
    public class ShippingService : EntityBase<int>
    {
        private readonly string _code;
        private readonly string _description;
        private readonly Courier _courier;

        private ShippingService()
        {    }

        public ShippingService(string code, string description, Courier courier)
        {
            _code = code;
            _description = description;
            _courier = courier;
        }
        
        public string Code
        {
            get { return _code;}
        }

        public string Description
        {
            get { return _description; }
        }

        public Courier Courier
        {
            get { return _courier; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
