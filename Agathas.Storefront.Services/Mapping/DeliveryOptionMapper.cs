using System;
using System.Collections.Generic;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ConvertToDeliveryOptionViews(this IEnumerable<DeliveryOption> deliveryOptions)
        {
            return Mapper.Map<IEnumerable<DeliveryOption>, IEnumerable<DeliveryOptionView>>(deliveryOptions);
        }
    }
}
