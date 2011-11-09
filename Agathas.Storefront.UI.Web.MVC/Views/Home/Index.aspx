<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ProductCatalogue.Master" Inherits="System.Web.Mvc.ViewPage<HomePageView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.ProductCatalogue" %>
<%@ Import Namespace="Agathas.Storefront.Services.Presentation.Model" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.UI.Web.MVC.Helpers" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">   
    <img width="559" height="297" src="<%=Html.Resolve("/Content/Images/Products/product-lifestyle.jpg")%>"
        style="border-width: 0px; padding: 0px; margin: 0px" />
    <div style="clear: both;">
    </div>
    <h2>
        Top Products</h2>
    <div id="items" style="border-width: 1px; padding: 0px; margin: 0px">
        <ul class="items-list">
            <% foreach (FeaturedProductDto product in Model.Products)
               {%>
            <li class="item-detail"><a class="item-productimage-link" href="<%=Url.Action("Detail", "Product", 
                                                                                              new { id = product.Id, brand = product.BrandName, productname = product.Name.TrimEnd().Replace(" ", "-") }, null) %>">
                <img class="item-productimage" src="<%=Html.Resolve("/Content/Images/Products/" + product.Id.ToString() +".jpg")%>" /></a>
                <div class="item-productname">
                    <%= Html.ActionLink(product.BrandName + " " + product.Name, 
                                "Detail", "Product", new { id = product.Id, brand = product.BrandName, productname = product.Name.TrimEnd().Replace(" ", "-") }, null)%></div>
                <div class="item-price">
                    <%= Html.Encode(product.Price)%></div>
            </li>
            <%}%>
        </ul>
    </div>
</asp:Content>
