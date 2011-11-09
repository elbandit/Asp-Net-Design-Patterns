<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Checkout.Master" Inherits="System.Web.Mvc.ViewPage<PaymentPostData>" %>
<%@ Import Namespace="Agathas.Storefront.Infrastructure.Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Payment Post
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Payment Post</h2>
    
    <script type="text/javascript">
    
    $(document).ready(function() {

            $('#paymentForm').submit();
    
            });
    </script>
      
    
    <form id="paymentForm" name="paymentForm" action="<%=Html.Encode(Model.PaymentPostToUrl) %>" method="post">
     
    <% foreach (String postDataKey in Model.PostDataAndValue.AllKeys) {%>
           <%=Html.Hidden(postDataKey, Model.PostDataAndValue[postDataKey])%>
    <% } %>
    
    <input id="Submit" type="submit" value="Click here if page doesn't auto redirect in 5 seconds" />
            
    </form>
    
</asp:Content>