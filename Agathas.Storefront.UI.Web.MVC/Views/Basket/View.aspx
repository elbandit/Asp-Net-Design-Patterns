<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductCatalogue.Master" 
         Inherits="System.Web.Mvc.ViewPage<BasketDetailView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.UI.Web.MVC.Helpers" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.ProductCatalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Your Basket
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">

        function removeItem(productId) {

            var postData = { productId: productId };

            showOverlay("overlay", "main");
            showOverlay("smoverlay", "basketSummary");
            
            $.post('<%=Html.Resolve("/Basket/RemoveItem") %>', postData, updateBasket, "json");
        }

        function updateItemQtys() {

            showOverlay("overlay", "main");
            showOverlay("smoverlay", "basketSummary");

            var postData;
            var postArr = [];
            var index = 0;

            $("[id^='Qty-']").each(function() {

                itemElementId = $(this).attr('id');
                var productId = 0;
                productId = itemElementId.replace("Qty-", "");

                postArr[index] = { ProductId: productId, Qty: $(this).val() }
                index++;
            });

            postData = { Items: postArr };

            var jsonData = JSON.stringify(postData);

            $.post('<%=Html.Resolve("/Basket/UpdateItems") %>', jsonData, updateBasket, "json");
        }

        function updateShippingService(ddlShippingService) {
            
            var postData = { shippingServiceId: $(ddlShippingService).val() };

            showOverlay("overlay", "main");
            showOverlay("smoverlay", "basketSummary");

            $.post('<%=Html.Resolve("/Basket/UpdateShipping") %>', postData, updateBasket, "json");
        }

        function updateBasket(basketDetailView) {

            if (basketDetailView.BasketSummary.NumberOfItems == 0) {
                $("#basketDisplay").text("You have no items in your basket.");                
            }
            else {
                $("#basketDisplay").setTemplate($("#basketTemplate").html());
                $("#basketDisplay").processTemplate(basketDetailView);                
            }

            updateBasketSummary(basketDetailView.BasketSummary);

            hideOverlay("overlay");
            hideOverlay("smoverlay");
        }       	        
    </script>

    <h2>Your Basket</h2>        
    
     <% if (Model.Basket.Items.Count() > 0)
        {%>
     <div id="overlay" class="overlay"></div>
     <div id="basketDisplay">
     <table width="100%">
        <tr>
            <td>Product</td>
            <td>Qty</td>
            <td align="right">Price</td>
            <td align="right">Total</td>
        </tr>
        <tr>
            <td colspan="4"><hr /></td>
        </tr>
    <%
            foreach (BasketItemView item in Model.Basket.Items)
            {%>
    
        <tr>
            <td><%=Html.Encode(item.ProductName) %> - <%=Html.Encode(item.ProductSizeName) %><br />
                <a href="JavaScript:removeItem(<%=Html.Encode(item.ProductId) %>)">remove this item</a>
            </td>
            <td><%=Html.TextBox("Qty-" + item.ProductId.ToString(), item.QuantityValue, new { @class = "itemQtyBox" })%></td>
            <td align="right"><%=Html.Encode(item.ProductPrice) %></td>            
            <td align="right"><%=Html.Encode(item.LineTotal) %></td>
        </tr>    
           <%
            }%> 
        <tr>
            <td></td>
            <td><a href="JavaScript:updateItemQtys();">update</a></td>
            <td></td>
            <td></td>
        </tr> 
        <tr>
            <td colspan="4"><hr /></td>
        </tr>
        <tr>            
            <td align="right" colspan="3">Basket: </td>
            <td align="right"><%=Html.Encode(Model.Basket.ItemsTotal) %></td>
        </tr>
        <tr>            
            <td align="right"  colspan="3">Shipping:
                <select class="item-sortdropdown" name="ddlShippingService"  onchange="JavaScript:updateShippingService(this);" id="ddlShippingService">
                <% foreach (DeliveryOptionView deliveryOption in Model.DeliveryOptions){%>                
                    <option value="<%=Html.Encode(deliveryOption.Id) %>" 
                    <% if (Model.Basket.DeliveryOptionId == deliveryOption.Id) { %>
                        selected
                    <%}%>
                    ><%=Html.Encode(deliveryOption.ShippingServiceDescription) %></option>                
                 <%}%>
                </select>
            </td>
            <td align="right"><%=Html.Encode(Model.Basket.DeliveryCost) %></td>
        </tr>        
        <tr>            
            <td align="right" colspan="3"> Total: </td>
            <td align="right"><%=Html.Encode(Model.Basket.BasketTotal) %></td>
        </tr>
        <tr>            
            <td colspan="3"></td>            
            <td align="right"><%=Html.ActionLink("Check Out", "Checkout", "Checkout")%></td>
        </tr>
    </table>
    </div>
    <p></p>
    <%
        }
        else
        {
    %>
    You have no items in your basket.
    <%
        }%>
        
    
    <script type="text/html" id="basketTemplate"> 
       <table width="100%">
        <tr>
            <td>Product</td>
            <td>Qty</td>
            <td align="right">Price</td>
            <td align="right">Total</td>
        </tr>                
        <tr>
            <td colspan="4"><hr /></td>
        </tr>
			{#foreach $T.Basket.Items as record}
	    <tr>						                
            <td>{$T.record.ProductName} - {$T.record.ProductSizeName}<br />
                <a href="JavaScript:removeItem({$T.record.ProductId})">remove this item</a>
            </td>
            <td><input class="itemQtyBox" id="Qty-{$T.record.ProductId}" type="text" value="{$T.record.QuantityValue}" /></td>
            <td align="right">{$T.record.ProductPrice}</td>
            <td align="right">{$T.record.LineTotal}</td>
        </tr>
			{#/for}	
	    <tr>
            <td></td>
            <td><a href="JavaScript:updateItemQtys();">update</a></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4"><hr /></td>
        </tr>
        <tr>            
            <td align="right" colspan="3">Basket: </td>
            <td align="right">{$T.Basket.ItemsTotal}</td>
        </tr>
        <tr>                        
            <td align="right"  colspan="3">Shipping:
                <select class="item-sortdropdown" name="ddlShippingService" onchange="JavaScript:updateShippingService(this);" id="ddlShippingService">
                {#foreach $T.DeliveryOptions as deliveryOption}               
                    <option value="{$T.deliveryOption.Id}" 
                        {#if $T.deliveryOption.Id == $T.Basket.DeliveryOptionId} selected {#/if}
                        
                    >{$T.deliveryOption.ShippingServiceDescription}</option>                
                 {#/for}	
                </select>
            </td>
            <td align="right">{$T.Basket.DeliveryCost}</td>
        </tr>        
        <tr>            
            <td align="right" colspan="3"> Total: </td>
            <td align="right">{$T.Basket.BasketTotal}</td>
        </tr>
        <tr>            
            <td colspan="3"></td>
            <td align="right"><%=Html.ActionLink("Check Out", "Checkout", "Checkout")%></td>
        </tr>
    </table>
    </script> 

</asp:Content>
