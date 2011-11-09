<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountView>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.Account" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">    
    <h2>Log On</h2>
    <% if (Model.HasIssue) { %>
    <p>
    <div style="color: #D63301; background-color: #FFCCBA; padding:15px 10px 15px 50px;" >
        <%=Html.Encode(Model.Message)%>    
    </div>
    </p>
    <% } %>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register", "AccountRegister") %> if you don't have an account.
    </p>
        
    <h2>Login with your existing acount associated with this site</h2>
    <% Html.RenderPartial("~/Views/Shared/RpxLogin.ascx", Model.CallBackSettings); %> 

    <h2>Login with an account created with us</h2>        
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm()) { %>
        <div>           
                <p>
                    <label for="username">Username:</label><br />
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Password:</label><br />
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>               
                <p>
                    <input type="submit" value="Log On" />
                </p>            
        </div>
    <% } %>
</asp:Content>
