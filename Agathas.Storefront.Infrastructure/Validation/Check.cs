using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Validation
{
    public sealed class Check
    {        
        public static void That(bool assertion, Action exceptionToThrow)
        {
            if (!assertion)
                exceptionToThrow.Invoke();
        }

        public static void IsNotNull(Object value, Action exceptionToThrow)
        {
            That(value != null, exceptionToThrow);
        }

        public static void ThatIsNotAnEmptyString(string value, Action exceptionToThrow)
        {
            That(!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value), exceptionToThrow);
        }

        public static void IsGreaterThan(int numberToCompare, int quantity, Action exceptionToThrow)
        {
            That(quantity >= numberToCompare, exceptionToThrow);
        }
    } 
}
