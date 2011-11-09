<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CategoryDto>>" %>
<%@ Import Namespace="Agathas.Storefront.Services.Presentation.Model" %>

<h2>Categories</h2>
<ul class="refine-attributes">						
<% foreach (CategoryDto categoryView in Model) 
   { %>    
    <li><%= Html.ActionLink(categoryView.Name, "GetProductsByCategory", "Product", new { categoryId = categoryView.Id, category = categoryView.Name  }, null)%></li>                                        
<% }  %>				
</ul>


