using Agathas.Storefront.Services.Messaging.OrderService;

namespace Agathas.Storefront.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);

        SetOrderPaymentResponse SetOrderPayment(SetOrderPaymentRequest paymentRequest);        

        GetOrderResponse GetOrder(GetOrderRequest request);       
    }
}