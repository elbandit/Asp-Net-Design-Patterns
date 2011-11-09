using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Orders
{
    public class PaymentBusinessRules
    {
        public static readonly BusinessRule TransactionIdRequired = new BusinessRule("TransactionId", "A payment must have a transaction id.");
        public static readonly BusinessRule MerchantRequired = new BusinessRule("Merchant", "A payment must have a Merchant.");
        public static readonly BusinessRule AmountValid = new BusinessRule("Amount", "A payment must be for a non negative amount.");        
    }
}
