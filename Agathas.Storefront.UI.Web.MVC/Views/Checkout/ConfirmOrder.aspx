<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Checkout.Master" Inherits="System.Web.Mvc.ViewPage<OrderConfirmationView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ConfirmOrder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirm Order</h2>
    
        <%using (Html.BeginForm("PlaceOrder", "Checkout")) {%>
         
        Delivery Address
         <select id="DeliveryAddress" name="DeliveryAddress">
        <%
              foreach (DeliveryAddressView deliveryAddress in Model.DeliveryAddresses)
              {
        %>
             <option value="<%=Html.Encode(deliveryAddress.Id)%>"><%=Html.Encode(deliveryAddress.Name)%></option>
        <%
              }%>          
        </select>
        
        - <%=Html.ActionLink("Create new address", "AddDeliveryAddress", "Checkout")%>
                                                          
        <ul>
        <% foreach(BasketItemView item in Model.Basket.Items) {%>
            <li><%=Html.Encode(item.QuantityValue) %> of <%=Html.Encode(item.ProductName) %> at <%=Html.Encode(String.Format("{0:F}", item.ProductPrice))%></li>    
        <% }%>
        </ul>
        
        <p>Total: <%= Html.Encode(String.Format("{0:F}", Model.Basket.ItemsTotal)) %></p>
        
        <p>DeliveryCharge: <%= Html.Encode(String.Format("{0:F}", Model.Basket.DeliveryCost)) %></p>
            
        <p>Total: <%= Html.Encode(String.Format("{0:F}", Model.Basket.BasketTotal )) %></p>
                                   
        <input id="Submit" type="submit" value="Place Order" />
        <%
          }%>
</asp:Content>
