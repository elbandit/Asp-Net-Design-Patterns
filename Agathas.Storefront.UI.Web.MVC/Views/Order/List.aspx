<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomersOrderSummaryView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Orders</h2>
    
    <ul>
    <% foreach(OrderSummaryView order in Model.Orders)
       {
    %>
            <li><%=Html.Encode(order.Created.ToLongDateString()) %> 
                <% if (order.IsSubmitted == false)
                { %>
                <%=Html.ActionLink("Pay", "CreatePaymentFor", "Payment", new { orderId = order.Id}, null)%>                                       
                <% } %>
                <%=Html.ActionLink("View Detail", "Detail", "Order", new { orderId = order .Id}, null)%>
                </li>    
    <% }%>
    </ul>

</asp:Content>
