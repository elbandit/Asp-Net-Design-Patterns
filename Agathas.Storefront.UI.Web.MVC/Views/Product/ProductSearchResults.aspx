<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductCatalogue.Master" 
         Inherits="System.Web.Mvc.ViewPage<ProductSearchResultView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.ProductCatalogue" %>
<%@ Import Namespace="Agathas.Storefront.Services.Presentation.Model" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>
<%@ Import Namespace="Agathas.Storefront.UI.Web.MVC.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuContent" runat="server">
        
        <div class="productsTitle">
        <h2>Refine By</h2>   	   
        </div> 	    
        <% foreach (RefinementGroup refinementGroup in Model.RefinementGroups)
           { %>    	    
             <h3><%=Html.Encode(refinementGroup.Name) %></h3>
             <div class="refinement-box">
             <ul class="refine-attributes">
                  <% foreach (Refinement refinement in refinementGroup.Refinements)
                     { %> 
                            <li><a class="availableItem" id="RefGrp-<%=Html.Encode(refinementGroup.GroupId.ToString() + '-' + 
                                                                       refinement.Id.ToString())%>" 
                                 href="JavaScript:refineSearch(<%=Html.Encode(refinementGroup.GroupId)%>, 
                                                               <%=Html.Encode(refinement.Id.ToString())%>)">
                                 <%=Html.Encode(refinement.Name)%></a></li>		                              
                  <% }%>	                             
             </ul>                 
             </div>   
        <% } %>        
                           	    	    	    	  
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    // Array to store the refinment selections made by a user.
    var refinementSelections = [];
    // Flag to stop user selecting doing anything while page is being reloaded.
    var disallowUpdates = false;     
    // Vars to store data on the last refinement selection.
    var lastSelectedRefinementItemId;
    var lastSelectedRefinementGroupId;  
    // Flag to show if last action was a narrowing or critera widerning selection.  
    var lastActionWasToNarrowProductRefinement = false;


    // OnPage Load function, run when DOM is fully loaded.
    // ===============================================================
    $().ready(function() {

        $('#ddlSortBy').change(function() {
            if (disallowUpdates == false)
                displayPage(1);
        });

        jQuery("#dialog-noproducts").dialog({
            bgiframe: true, autoOpen: false, height: 100, modal: true
        });

    });

    // Method called to determine the sort ordering and the current category.
    // ===============================================================
    function displayPage(index) {

        if (disallowUpdates == false) {

            var categoryId = $('#categoryId').val();
            var sortBy = $('#ddlSortBy').val();

            getProducts(index, categoryId, sortBy);
        }
    }

    // Method called when a refinement is clicked, this changes the image dispalyed
    // and stores the selection before calling displayPage to update the view.
    // ===============================================================
    function refineSearch(refinementGroupId, refinementItemId) {

        if (disallowUpdates == false) {
            itemRefinementElementId = buildRefinementItemElementIdForm(refinementGroupId, refinementItemId);

            lastSelectedRefinementItemId = refinementItemId;
            lastSelectedRefinementGroupId = refinementGroupId;

            if (!isDisabled(itemRefinementElementId)) {
                if (isAvailable(itemRefinementElementId)) {
                    setAsSelected(itemRefinementElementId);
                    saveRefinementToFilterSelection(refinementGroupId, refinementItemId);
                    lastActionWasToNarrowProductRefinement = true;
                    displayPage(1);
                }
                else if (isSelectedButDisabled(itemRefinementElementId)) {
                    setAsDisabled(itemRefinementElementId);
                    removeRefinementFromFilterSelection(refinementGroupId, refinementItemId);
                }
                else {
                    setAsAvailable(itemRefinementElementId);
                    removeRefinementFromFilterSelection(refinementGroupId, refinementItemId);
                    lastActionWasToNarrowProductRefinement = false;
                    displayPage(1);
                }
            }
        }
    }

    // This function sends a post request to obtain the new view model after a users has changeed there refinement
    // criteria, changed page or changed the product result ordering.
    // ===============================================================
    function getProducts(index, categoryId, sortBy) {

        if (disallowUpdates == false) {
            disallowUpdates = true;

            showOverlay("overlay", "main", 10);

            var jsonData = JSON.stringify(
                { "CategoryId": categoryId,
                    "Index": index,
                    "SortBy": sortBy,                    
                    "RefinementGroups": refinementSelections
                });

                $.ajax({
                    url: '<%=Html.Resolve("/Product/GetProductsByAjax") %>',
                    type: 'POST',
                    dataType: 'json',
                    data: jsonData,
                    contentType: 'application/json; charset=utf-8',
                    success: function(data) {

                        var mydata = { items: data.Products };

                        if (data.Products.length == 0) {

                            showNoProductsFoundDialogBoxAndRevertSelection();
                        }
                        else {

                            $("#items").setTemplate($("#productItemTemplate").html());
                            $("#items").processTemplate(mydata);

                            $('#numberOfProductsFound').text(data.NumberOfTitlesFound);

                            buildPageLinksFor("#pageLinksTop", data.CurrentPage, data.TotalNumberOfPages);
                            buildPageLinksFor("#pageLinksBottom", data.CurrentPage, data.TotalNumberOfPages);

                            for (var i = data.RefinementGroups.length - 1; i >= 0; --i) {
                                filterOutRefinements(data.RefinementGroups[i].GroupId, data.RefinementGroups[i].Refinements);
                            }
                        }

                        hideOverlay("overlay");

                        disallowUpdates = false;
                    }
                });
        }
    }

    //  Method used to work out which refinements to mark as available/disabled/selected based on the list of
    // products taht matched the users last selection.
    // ===============================================================
    function filterOutRefinements(refinementGroupId, availableProductRefinements) {

        $("[id^='" + buildGroupRefinementElementIdForm(refinementGroupId) + "']").each(function() {

            itemRefinementElementId = $(this).attr('id');

            var refinementItemId = findRefinementItemIdFrom(itemRefinementElementId);

            var refinementItemIdMatched = refinementItemIdIsInProductAvailableRefinements(availableProductRefinements, refinementItemId);

            if (!lastSelectionWasMadeIn(refinementGroupId)) {
                                
                if (lastActionWasToNarrowProductRefinement == true) {

                    if ((isSelected(itemRefinementElementId) || isSelectedButDisabled(itemRefinementElementId)) && !refinementItemIdMatched) {                
                        setAsSelectedButDisabled(itemRefinementElementId);
                    }
                    else if (!refinementItemIdMatched) {                        
                        setAsDisabled(itemRefinementElementId);
                    }
                    else if (isDisabled(itemRefinementElementId) && refinementItemIdMatched) {
                        setAsAvailable(itemRefinementElementId);
                    }
                    else if (isSelectedButDisabled(itemRefinementElementId) && refinementItemIdMatched) {
                        setAsSelected(itemRefinementElementId);
                    }
                }
                else {
                    
                    if ((isSelected(itemRefinementElementId) || isSelectedButDisabled(itemRefinementElementId)) && !refinementItemIdMatched) {
                        setAsSelectedButDisabled(itemRefinementElementId);
                    }
                    else if ((isSelected(itemRefinementElementId) || isSelectedButDisabled(itemRefinementElementId)) && refinementItemIdMatched) {
                        setAsSelected(itemRefinementElementId);
                    }
                    else if (isDisabled(itemRefinementElementId) && refinementItemIdMatched) {
                        setAsAvailable(itemRefinementElementId);
                    }
                    else if (isDisabled(itemRefinementElementId) && !refinementItemIdMatched && !otherRefinementSelectionsExistApartFrom(refinementGroupId)) {                        
                        setAsAvailable(itemRefinementElementId);
                    }
                    else if (isAvailable(itemRefinementElementId) && !refinementItemIdMatched) {
                        setAsDisabled(itemRefinementElementId);
                    }
                }
            }
            else if (lastActionWasToNarrowProductRefinement == false) {

                if (isSelected(itemRefinementElementId)) {
                    setAsSelected(itemRefinementElementId);
                }
                else if (!otherRefinementSelectionsExistApartFrom(refinementGroupId)) {
                    setAsAvailable(itemRefinementElementId);
                }
            }
            else if (isDisabled(itemRefinementElementId) && refinementItemIdMatched) {
                setAsAvailable(itemRefinementElementId);
            }
        });
    }

    // Method called to short a dialog box and revert selection if user makes a selection that produces no results.
    // ===============================================================
    function showNoProductsFoundDialogBoxAndRevertSelection() {

        itemRefinementElementId = buildRefinementItemElementIdForm(lastSelectedRefinementGroupId, lastSelectedRefinementItemId);

        setAsSelected(itemRefinementElementId);

        saveRefinementToFilterSelection(lastSelectedRefinementGroupId, lastSelectedRefinementItemId);
                
        $("#dialog-noproducts").dialog('open');
    }

    // Method used to get the refinement item id from the element name.
    // ===============================================================
    function findRefinementItemIdFrom(itemRefinementElementId) {

        var refinementItemId = 0;
        
        refinementItemId = itemRefinementElementId.substring(itemRefinementElementId.lastIndexOf("-")+1, itemRefinementElementId.length);

        return refinementItemId;
    }

    // Method used to determine if the given refinement group id is of the same group that the last selection was made.
    // ===============================================================
    function lastSelectionWasMadeIn(refinementGroupId)
    {
        return lastSelectedRefinementGroupId == refinementGroupId;
    }

    // Method used to determine if the user has selected other refinements in other groups than the given refinement group id.
    // ===============================================================
    function otherRefinementSelectionsExistApartFrom(refinementGroupId) {

        var refinementSelectionsCount = 0;

        for (var i = refinementSelections.length - 1; i >= 0; --i) {

            if (refinementSelections[i].GroupId != refinementGroupId) {
                refinementSelectionsCount += refinementSelections[i].SelectedRefinements.length;
            }
        }
        
        return refinementSelectionsCount > 0;                             
    }

    // Method to determine if the given refinement item is in the list of matches for the last
    // ===============================================================
    function refinementItemIdIsInProductAvailableRefinements(availableProductRefinements, refinementItemId) {

        for (var i = availableProductRefinements.length - 1; i >= 0; --i) {
            if (availableProductRefinements[i].Id == refinementItemId)
                return true;
        }
        return false;
    }
          
    // Helper methods
    // ===============================================================
    function buildGroupRefinementElementIdForm(refinementGroupId) {
        return 'RefGrp-' + refinementGroupId;
    }

    function buildRefinementItemElementIdForm(refinementGroupId, refinementItemId) {
        return 'RefGrp-' + refinementGroupId + '-' + refinementItemId;
    }
    
    function serviceFailed(result) {
        alert('Service call failed: ' + result.status + '' + result.statusText);
    }

    // Methods to store, retrieve and update the refinement selections
    // ===============================================================
    function removeRefinementFromFilterSelection(refinementGroupId, refinementItemId) {

        var refinementSelectionGroup;
        
        for (var i = refinementSelections.length - 1; i >= 0; --i) {

            if (refinementSelections[i].GroupId == refinementGroupId) {
                refinementSelectionGroup = refinementSelections[i];                
            }
        }

        refinementSelectionGroup.SelectedRefinements.
                         splice(findIndexOf(refinementSelectionGroup.SelectedRefinements, refinementItemId), 1);

    }

    function findIndexOf(refinementGroupId, refinementItemId) {

        for (var i = refinementGroupId.length - 1; i >= 0; --i) {
            if (refinementGroupId[i] == refinementItemId)
                return i;
        }
        return -1;
    }

    function saveRefinementToFilterSelection(refinementGroupId, refinementItemId) {

        var refinementSelectionGroup = new Object();
        var foundExistingGroup = false;

        if (refinementSelections.length == 0) {

            refinementSelectionGroup.GroupId = refinementGroupId;
            refinementSelections[0] = refinementSelectionGroup;
            refinementSelectionGroup.SelectedRefinements = [];
        }
        else { 
        
         for (var i = refinementSelections.length - 1; i >= 0; --i) {

             if (refinementSelections[i].GroupId == refinementGroupId) {
                 refinementSelectionGroup = refinementSelections[i];
                 foundExistingGroup = true;
             }

         }
         if (foundExistingGroup == false) {
             refinementSelectionGroup.GroupId = refinementGroupId;
             refinementSelections[refinementSelections.length] = refinementSelectionGroup;
             refinementSelectionGroup.SelectedRefinements = [];
         }
     }

     refinementSelectionGroup.SelectedRefinements[refinementSelectionGroup.SelectedRefinements.length] = refinementItemId    
    }
        
    
    // Method to build the paging links after a refine selection.
    // ===============================================================
    function buildPageLinksFor(spanId, index, totalPages) {

        var i = 1;
        var html = '';
        for (i = 1; i <= totalPages; i++) {

            if (i == index)
                html = html + "<a class='selected' href='JavaScript:displayPage(" + i + ")'>" + i + "</a>&nbsp;";
            else
                html = html + "<a class='notselected' href='JavaScript:displayPage(" + i + ")'>" + i + "</a>&nbsp;";
        }


        $(spanId).html(html);
    }

    // Helper methods to determine the state of a refinment.
    // ===============================================================
    function setAsSelectedButDisabled(elementName) {
        $('#' + elementName).removeClass().addClass('selecteddisabledItem');
    }

    function setAsSelected(elementName) {
        $('#' + elementName).removeClass().addClass('selectedItem');
    }

    function setAsAvailable(elementName) {
        $('#' + elementName).removeClass().addClass('availableItem');
    }

    function setAsDisabled(elementName) {
        $('#' + elementName).removeClass().addClass('disabledItem');
    }

    function isSelected(elementName) {
        return ($('#' + elementName).attr("class") == "selectedItem");
    }

    function isAvailable(elementName) {
        return ($('#' + elementName).attr("class") == "availableItem");
    }

    function isDisabled(elementName) {
        return ($('#' + elementName).attr("class") == "disabledItem");
    }

    function isSelectedButDisabled(elementName) {
        return ($('#' + elementName).attr("class") == "selecteddisabledItem");
    }
               
</script>

<div id="productResults">
<div class="productsTitle">
<h2><%= Html.ActionLink("Home", "Index", "Home")%> > <%=Html.Encode(Model.SelectedCategoryName) %></h2>
</div>

<div style="margin-bottom: 41px;">
<span class="item-displayoptions-sort">Sort by
            <select class="item-sortdropdown" id="ddlSortBy">                
                <option value="1">Price - High to Low</option>
                <option value="2">Price - Low to High</option>                
            </select>
            </span>
<span class="item-displayoptions-pages">products found <span id="numberOfProductsFound"><%=Html.Encode(Model.NumberOfTitlesFound) %></span>
<span id="pageLinksTop"><%=Html.BuildPageLinksFrom(Model.CurrentPage, Model.TotalNumberOfPages, x => "JavaScript:displayPage("+ x +")")%></span>
</span>
</div>

        <div style="clear: both;"></div>
        
            <div id="overlay" class="overlay"></div>
            <div id="items">           
                    <ul class="items-list">
                <%
                    foreach (ProductSummaryDto product in Model.Products)
                    {
                %>      
                        <li class="item-detail">                            
                            <a class="item-productimage-link" href="<%=Url.Action("Detail", "Product", new { id = product.Id }, null) %>"><img class="item-productimage" src="<%=Html.Resolve("/Content/images/Products/" + product.Id.ToString() + ".jpg") %>" /></a>
                            <div class="item-productname"><%= Html.ActionLink(Html.Encode(product.BrandName) + " " + Html.Encode(product.Name), "Detail", "Product", new { id = product.Id }, null)%></div>
                            <div class="item-price"><%=product.Price %></div>
                        </li>
                <%        
                    }
                %>
                    </ul>            
            </div>
            
                
        <div style="clear: both;"></div>
    
    
    <span class="item-displayoptions-pages">
    <span id="pageLinksBottom"><%=Html.BuildPageLinksFrom(Model.CurrentPage, Model.TotalNumberOfPages, x => "JavaScript:displayPage("+ x +")")%></span>   
    </span>  
            
    <p>&nbsp;</p>

   <script type="text/html" id="productItemTemplate">    
       <ul class="items-list">        
			{#foreach $T.items as record}						                
              <li class="item-detail">
              <a class="item-productimage-link" href="<%=Html.Resolve("/Product/Detail/") %>{$T.record.Id}"><img class="item-productimage" src="<%=Html.Resolve("/Content/images/Products/{$T.record.Id}.jpg") %>" /></a>
              <div class="item-productname"><a href="<%=Html.Resolve("/Product/Detail/") %>{$T.record.Id}">{$T.record.BrandName} {$T.record.Name}</a></div>
              <div class="item-price">{$T.record.Price}</div>
              </li>
			{#/for}	
         </ul>   			   
	</script> 
    <%=Html.Hidden("categoryId", Html.Encode(Model.SelectedCategory.ToString()))%>       
    </div>
    
    <div id="dialog-noproducts" title="No products found matching your refinement">
	    <p>Your <span id="selectType"></span> selection caused no results to be returned - please widen your search criteria.</p>
    </div>          
</asp:Content>
