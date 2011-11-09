using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Agathas.Storefront.Infrastructure.Configuration;

namespace Agathas.Storefront.Infrastructure.Payments
{
    public class PayPalPaymentService : IPaymentService 
    {        
        public PaymentPostData GeneratePostDataFor(OrderPaymentRequest orderRequest)
        {
            PaymentPostData paymentPostData = new PaymentPostData();
            NameValueCollection postDataAndValue = new NameValueCollection();

            paymentPostData.PostDataAndValue = postDataAndValue;

            // When a real PayPal account is used, the form should be sent to https://www.paypal.com/cgi-bin/webscr.
            // For testing use "https://www.sandbox.paypal.com/cgi-bin/webscr"
            paymentPostData.PaymentPostToUrl = ApplicationSettingsFactory.GetApplicationSettings().PayPalPaymentPostToUrl; 

            // For shopping cart purchases.
            postDataAndValue.Add("cmd", "_cart");
            // Indicates the use of third party shopping cart.
            postDataAndValue.Add("upload", "1");
            
            // This is the sellers email address. You must supply your own address here!!!
            postDataAndValue.Add("business", ApplicationSettingsFactory.GetApplicationSettings().PayPalBusinessEmail); 

            // This field does not take part in the shopping process. 
            // It simply will be passed to the IPN script at the time of transaction confirmation.
            postDataAndValue.Add("custom", orderRequest.Id.ToString());

            // This parameter represents a currency code. 
            postDataAndValue.Add("currency_code", "GBP"); 

            postDataAndValue.Add("first_name", orderRequest.CustomerFirstName);
            postDataAndValue.Add("last_name", orderRequest.CustomerSecondName);

            postDataAndValue.Add("address1", orderRequest.DeliveryAddressAddressLine1);
            postDataAndValue.Add("address2", orderRequest.DeliveryAddressAddressLine2);
            postDataAndValue.Add("city", orderRequest.DeliveryAddressCity);
            postDataAndValue.Add("state", orderRequest.DeliveryAddressState);
            postDataAndValue.Add("country", orderRequest.DeliveryAddressCountry);
            postDataAndValue.Add("zip", orderRequest.DeliveryAddressZipCode);

            // This parameter determines whether the delivery address should be requested. 
            // "1" means that the address will be requested; "0" means that it will be not.
            //postDataAndValue.Add("no_shipping", "0");
            
            // This is the URL where the user will be redirected after the payment is successfully performed. 
            // If this parameter is not passed, the buyer remains on the PayPal site.
            postDataAndValue.Add("return", Helpers.UrlHelper.Resolve("/Payment/PaymentComplete"));
            // This is the URL where the user will be redirected when he cancels the payment. 
            // If the parameter is not passed, the buyer remains on the PayPal site.
            postDataAndValue.Add("cancel_return", Helpers.UrlHelper.Resolve("/Payment/PaymentCancel"));
            // This is the URL where PayPal will pass information about the transaction (IPN). 
            // If the parameter is not passed, the value from the account settings will be used. 
            // If this value is not defined in the account settings, IPN will not be used.
            postDataAndValue.Add("notify_url", Helpers.UrlHelper.Resolve("/Payment/PaymentCallBack"));

            int itemIndex = 1;
            foreach(OrderItemPaymentRequest item in orderRequest.Items )
            {
                postDataAndValue.Add("item_name_" + itemIndex.ToString(), item.ProductName);
                postDataAndValue.Add("amount_" + itemIndex.ToString(), item.Price.ToString());
                postDataAndValue.Add("item_number_" + itemIndex.ToString(), item.Id.ToString());
                postDataAndValue.Add("quantity_" + itemIndex.ToString(), item.Quantity.ToString());

                itemIndex++;
            }
                    
            postDataAndValue.Add("shipping", orderRequest.ShippingCharge.ToString());

            return paymentPostData;
        }

        public TransactionResult HandleCallBack(OrderPaymentRequest orderRequest, FormCollection collection)
        {
            TransactionResult transactionResult = new TransactionResult();
                                    
            string response = ValidatePaymentNotification(collection);

            if (response == "VERIFIED")
            {                
                string sAmountPaid = collection["mc_gross"];
                string transactionId = collection["txn_id"];    
                                                
                Decimal amountPaid = 0;
                Decimal.TryParse(sAmountPaid, out amountPaid);

                if (orderRequest.Total == amountPaid)
                {
                    transactionResult.PaymentToken = transactionId;
                    transactionResult.Amount = amountPaid;
                    transactionResult.PaymentMerchant = "PayPal";
                    transactionResult.PaymentOk = true;
                }
                else
                {                                        
                    transactionResult.PaymentToken = transactionId;
                    transactionResult.Amount = amountPaid;
                    transactionResult.PaymentMerchant = "PayPal";
                    transactionResult.PaymentOk = false;
                }
            }

            return transactionResult;
        }
        
      
        private string ValidatePaymentNotification(FormCollection formCollection)
        {            
            formCollection["cmd"] = "_notify-validate";

            string paypalUrl = ApplicationSettingsFactory.GetApplicationSettings().PayPalPaymentPostToUrl;
                
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(paypalUrl);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            byte[] param = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            
            StringBuilder postFormData = new StringBuilder();

            foreach (string key in formCollection.Keys)
            {
                postFormData.AppendFormat("&{0}={1}", key, formCollection[key]);
            }

            strRequest = postFormData.ToString();
            req.ContentLength = strRequest.Length;

            
            string response = "";
            using (StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII))
            {

                streamOut.Write(strRequest);
                streamOut.Close();
                using (StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    response = streamIn.ReadToEnd();
                }
            }

            return response;
        }

        public int GetOrderIdFor(FormCollection collection)
        {
            return int.Parse(collection["custom"]);
            ;
        }
    }
}
