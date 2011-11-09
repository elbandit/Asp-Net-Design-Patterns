using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Model.Customers
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }

        private Name()
        {
            
        }

        public Name(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;

            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(secondName))
                throw new InvalidNameException("Name should be composed of a not null or empty first and second name");
        }
    }
}
