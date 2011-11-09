<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Checkout.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PaymentCancel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Payment Cancel</h2>
    
    You cancelled your payment. You can always <%=Html.ActionLink("pay for you order at a later date", "List", "Order")%>.

</asp:Content>
