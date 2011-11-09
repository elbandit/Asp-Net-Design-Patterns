<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Agathas.Storefront.UI.Web.MVC.Helpers" %>

<div id="prefooter">
    <span style="float: left; margin-left: 20px;">
        <table>
            <tr>
                <td>
                    <ul>
                        <li class="footer-list-header">Help:</li>
                        <li><a href="#">Neque porro quisquam est</a></li>
                        <li><a href="#">ipsum quia dolor sit amet</a></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">About:</li>
                        <li><a href="#">quisquam Nequeporro est</a></li>
                        <li><a href="#">dolor sit amet ipsum quia </a></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">Social:</li>
                       <li><a href="#">porro Neque quisquam est</a></li>
                        <li><a href="#">sit amet ipsum quia dolor</a></li>
                    </ul>
                </td>               
            </tr>
        </table>
    </span><span style="float: right; margin-top: 60px; margin-right: 10px;"><a href="<%=Html.Resolve("") %>">
        <img alt="Agatha's Clothing Store" src="<%=Html.Resolve("/Content/Images/Structure/sm_logo.png")%>" border="0" /></a></span>
</div>
<div id="footer">
    Case Study from the book <a href="http://www.amazon.com/gp/product/0470292784?ie=UTF8&tag=bloofsco-20&linkCode=as2&camp=1789&creative=390957&creativeASIN=0470292784">Wrox Professional ASP.NET Design Patterns - Scott Millett</a>.
</div>
