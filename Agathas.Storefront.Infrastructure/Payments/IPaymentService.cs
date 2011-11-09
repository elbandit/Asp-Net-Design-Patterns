using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Agathas.Storefront.Infrastructure.Payments
{
    public interface IPaymentService
    {
        PaymentPostData GeneratePostDataFor(OrderPaymentRequest orderRequest);
        TransactionResult HandleCallBack(OrderPaymentRequest orderRequest, FormCollection collection);
        int GetOrderIdFor(FormCollection collection);        
    }
}
