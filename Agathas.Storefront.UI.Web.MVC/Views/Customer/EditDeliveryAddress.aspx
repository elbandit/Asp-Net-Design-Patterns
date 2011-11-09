<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CustomerAccount.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDeliveryAddressView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.CustomerAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Address
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Address Detail</h2>
    
    <% using (Html.BeginForm()) {%>
       
             <% Html.RenderPartial("~/Views/Shared/AddressEdit.ascx", Model.Address); %>    
            <p>
                <input type="submit" value="Save" />
            </p> 
    <% } %>
   
</asp:Content>

