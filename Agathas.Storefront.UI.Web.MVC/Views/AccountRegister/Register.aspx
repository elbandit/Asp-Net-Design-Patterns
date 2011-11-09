<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.Account" %>
<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Model.HasIssue) { %>
    <p>
    <div style="color: #D63301; background-color: #FFCCBA; padding:15px 10px 15px 50px;" >
        <%=Html.Encode(Model.Message)%>    
    </div>
    </p>
    <% } %>

    <h2>Associate an existing acount with us</h2>
    <% Html.RenderPartial("~/Views/Shared/RpxLogin.ascx", Model.CallBackSettings); %> 

    <h2>Don't have an internet account? Create an account with us</h2>           
    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>                   
                <p>
                    <label for="email">Email:</label><br />
                    <%= Html.TextBox("EmailAddress") %>
                    <%= Html.ValidationMessage("EmailAddress") %>
                </p>
                <p>
                    <label for="password">Password:</label><br />
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <label for="confirmPassword">Confirm password:</label><br />
                    <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                <p>
                    <label for="email">First Name:</label><br />
                    <%= Html.TextBox("NameFirstName")%>
                    <%= Html.ValidationMessage("NameFirstName")%>
                </p>
                <p>
                    <label for="email">Second Name:</label><br />
                    <%= Html.TextBox("NameSecondName")%>
                    <%= Html.ValidationMessage("NameSecondName")%>
                </p>
                <p>
                    <input type="submit" value="Register" />
                </p>           
        </div>
    <% } %>
</asp:Content>
