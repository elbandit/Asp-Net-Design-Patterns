using System;

namespace Agathas.Storefront.Model.Orders
{
    public class CannotAmendOrderException : Exception
    {
        public CannotAmendOrderException(string message) : base(message)
        {
            
        }
    }
}