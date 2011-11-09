using System.Collections.Specialized;

namespace Agathas.Storefront.Infrastructure.Payments
{
    public class PaymentPostData
    {
        public string PaymentPostToUrl { get; set;}
        public NameValueCollection PostDataAndValue { get; set; }        
    }
}