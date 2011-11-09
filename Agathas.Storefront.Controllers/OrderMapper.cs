using System;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Infrastructure.Payments;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Controllers
{
    public static class OrderMapper
    {
        public static OrderPaymentRequest ConvertToOrderPaymentRequest(this OrderView order)
        {
            return Mapper.Map<OrderView, OrderPaymentRequest>(order);
        }   
    }
}
