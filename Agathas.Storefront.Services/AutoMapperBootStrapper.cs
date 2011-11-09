using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Agathas.Storefront.Model;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Infrastructure.Helpers;
using Agathas.Storefront.Infrastructure.Payments;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Orders.States;
using Agathas.Storefront.Model.Orders;

namespace Agathas.Storefront.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Product Title
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();
           
            // Category
            Mapper.CreateMap<Category, CategoryView>();

            // IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            // Orders
            Mapper.CreateMap<Order, OrderView>();                            
            Mapper.CreateMap<OrderItem, OrderItemView>();
            Mapper.CreateMap<Address, DeliveryAddressView>();         
            Mapper.CreateMap<Order, OrderSummaryView>()
                .ForMember(o => o.IsSubmitted, ov => ov.ResolveUsing<OrderStatusResolver>());

                       
            // Customer
            Mapper.CreateMap<Customer, CustomerView>();            
            Mapper.CreateMap<DeliveryAddress, DeliveryAddressView>();            

            // Basket
            Mapper.CreateMap<DeliveryOption, DeliveryOptionView>();            
            Mapper.CreateMap<BasketItem, BasketItemView>();
            Mapper.CreateMap<BasketItem, OrderItem>();
            Mapper.CreateMap<Basket, BasketView>();

            // Global Money Formatter
            Mapper.AddFormatter<MoneyFormatter>();

        }
    }

    public class OrderStatusResolver : ValueResolver<Order, bool>
    {
        protected override bool ResolveCore(Order source)
        {
            if (source.Status == OrderStatus.Submitted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class MoneyFormatter : IValueFormatter
    {        
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                decimal money = (decimal)context.SourceValue;

                return money.FormatMoney();
            }

            return context.SourceValue.ToString();
        }     
    }
}
