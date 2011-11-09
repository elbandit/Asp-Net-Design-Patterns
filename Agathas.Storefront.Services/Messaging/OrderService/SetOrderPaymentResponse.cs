using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.OrderService
{
    public class SetOrderPaymentResponse
    {
        public OrderView Order { get; set; }
    }
}
