<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<h2>Menu</h2>
    <ul class="refine-attributes">		
    <li><%=Html.ActionLink("Your Details", "Detail", "Customer") %></li>
    <li><%=Html.ActionLink("Delivery Address Book", "DeliveryAddresses", "Customer")%></li>
    <li><%=Html.ActionLink("Your Orders", "List", "Order")%></li>
</ul>