<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CallBackSettings>" %>
<%@ Import Namespace="Agathas.Storefront.Controllers.ViewModels.Account" %>
<%@ Import Namespace="Agathas.Storefront.UI.Web.MVC.Helpers" %>
<iframe src="http://aspnetdesignpatterns.rpxnow.com/openid/embed?token_url=<%=Server.UrlEncode(Html.Resolve("/" + Model.Controller +"/" + Model.Action + "/?returnUrl=" + Model.ReturnUrl))%>" scrolling="no" frameBorder="no" allowtransparency="true" style="width:400px;height:240px"></iframe> 