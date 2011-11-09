<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDetailView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Customer Delivery Address Book
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delivery Addresses</h2>

    <%=Html.ActionLink("Add new address", "AddDeliveryAddress", "Customer")%>
    
    <ul>
    <% foreach (DeliveryAddressView deliveryAddress in Model.Customer.DeliveryAddressBook)
       {
    %>
       <li><%=Html.ActionLink(deliveryAddress.Name, "EditDeliveryAddress", "Customer", new { deliveryAddressId = deliveryAddress.Id }, null)%></li>
    <% }%>
    </ul>    

</asp:Content>

