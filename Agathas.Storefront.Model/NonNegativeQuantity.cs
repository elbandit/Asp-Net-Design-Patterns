using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Validation;

namespace Agathas.Storefront.Model
{
    public class NonNegativeQuantity
    {
        private NonNegativeQuantity()
        {  }

        public NonNegativeQuantity(int value)
        {
            Check.IsGreaterThan(-1, value, () => { throw new ArgumentOutOfRangeException();});
            Value = value;
        }

        public int Value { get; private set; }

        public NonNegativeQuantity Add(NonNegativeQuantity quantity)
        {
            return new NonNegativeQuantity(Value + quantity.Value);
        }

        public bool IsZero()
        {
            return Value == 0;
        }
    }
}
