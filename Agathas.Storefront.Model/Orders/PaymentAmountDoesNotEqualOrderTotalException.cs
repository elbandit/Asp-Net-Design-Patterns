using System;

namespace Agathas.Storefront.Model.Orders
{
    public class PaymentAmountDoesNotEqualOrderTotalException : Exception
    {
        public PaymentAmountDoesNotEqualOrderTotalException(string message)
            : base(message)
        {
        }
    }
}