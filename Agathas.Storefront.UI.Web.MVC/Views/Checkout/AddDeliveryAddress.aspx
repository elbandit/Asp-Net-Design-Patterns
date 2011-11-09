<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Checkout.Master" 
         Inherits="System.Web.Mvc.ViewPage<DeliveryAddressView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddDeliveryAddress
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add DeliveryAddress</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("AddDeliveryAddress", "Checkout")) {%>

         <% Html.RenderPartial("~/Views/Shared/AddressEdit.ascx", Model); %>    
         <p>
            <input type="submit" value="Create Address and Checkout" />
         </p>        
    <% } %>

    <div>
        <%=Html.ActionLink("Check Out", "Checkout", "Checkout")%>
    </div>

</asp:Content>

