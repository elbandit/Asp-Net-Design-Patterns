<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DeliveryAddressView>" %>
<%@ Import Namespace="Agathas.Storefront.Services.ViewModels" %>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
                                   
            <%= Html.Hidden("Id", Model.Id) %>                
            <p>
                <label for="Name">Name:</label><br />
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="AddressLine1">AddressLine1:</label><br />
                <%= Html.TextBox("AddressAddressLine1", Model.AddressAddressLine1) %>
                <%= Html.ValidationMessage("AddressAddressLine1", "*") %>
            </p>
            <p>
                <label for="AddressLine2">AddressLine2:</label><br />
                <%= Html.TextBox("AddressAddressLine2", Model.AddressAddressLine2) %>
                <%= Html.ValidationMessage("AddressAddressLine2", "*") %>
            </p>
            <p>
                <label for="City">City:</label><br />
                <%= Html.TextBox("AddressCity", Model.AddressCity) %>
                <%= Html.ValidationMessage("AddressCity", "*") %>
            </p>
            <p>
                <label for="State">State:</label><br />
                <%= Html.TextBox("AddressState", Model.AddressState) %>
                <%= Html.ValidationMessage("AddressState", "*") %>
            </p>
            <p>
                <label for="Country">Country:</label><br />
                <%= Html.TextBox("AddressCountry", Model.AddressCountry) %>
                <%= Html.ValidationMessage("AddressCountry", "*") %>
            </p>
            <p>
                <label for="ZipCode">ZipCode:</label><br />
                <%= Html.TextBox("AddressZipCode", Model.AddressZipCode) %>
                <%= Html.ValidationMessage("AddressZipCode", "*") %>
            </p>                  
    


