<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDeliveryAddressView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Delivery Address
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddDeliveryAddress</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <% Html.RenderPartial("~/Views/Shared/AddressEdit.ascx", Model.Address); %>      
        <p>
            <input type="submit" value="Save" />
        </p> 
    <% } %>
    
</asp:Content>

