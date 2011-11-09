using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Infrastructure.Payments;

namespace Agathas.Storefront.Controllers 
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<OrderView, OrderPaymentRequest>()
                .ForMember(o => o.Total, ov => ov.ResolveUsing<OrderTotalResolver>())
                .ForMember(o => o.ShippingCharge, ov => ov.ResolveUsing<ShippingChargeResolver>());

            Mapper.CreateMap<OrderItemView, OrderItemPaymentRequest>()
                .ForMember(o => o.Price, ov => ov.ResolveUsing<ItemPriceResolver>());
        }
    }

    public class OrderTotalResolver : ValueResolver<OrderView, decimal>
    {
        protected override decimal ResolveCore(OrderView source)
        {
            return decimal.Parse(source.Total.Substring(1, source.Total.Length -1));
        }
    }

    public class ShippingChargeResolver : ValueResolver<OrderView, decimal>
    {
        protected override decimal ResolveCore(OrderView source)
        {
            return decimal.Parse(source.ShippingCharge.Substring(1, source.ShippingCharge.Length - 1));
        }
    }

    public class ItemPriceResolver : ValueResolver<OrderItemView, decimal>
    {
        protected override decimal ResolveCore(OrderItemView source)
        {
            return decimal.Parse(source.Price.Substring(1, source.Price.Length - 1));
        }
    }
}
