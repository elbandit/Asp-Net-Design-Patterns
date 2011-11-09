namespace Agathas.Storefront.Infrastructure.Payments
{
    public class TransactionResult
    {
        public string PaymentMerchant { get; set; }
        public bool PaymentOk { get; set; }
        public string PaymentToken { get; set; }
        public decimal Amount { get; set; } 
    }
}