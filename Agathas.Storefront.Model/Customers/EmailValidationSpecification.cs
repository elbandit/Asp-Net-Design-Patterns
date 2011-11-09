using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Agathas.Storefront.Model.Customers
{
    public class EmailValidationSpecification
    {
        public bool IsSatisfiedBy(string email)
        {
            Regex emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            return emailregex.IsMatch(email);
        }
    }
}
