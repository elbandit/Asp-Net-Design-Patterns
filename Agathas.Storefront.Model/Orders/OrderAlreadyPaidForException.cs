using System;

namespace Agathas.Storefront.Model.Orders
{
    public class OrderAlreadyPaidForException : Exception
    {
        public OrderAlreadyPaidForException(string message) : base (message)
        {            
        }
    }
}