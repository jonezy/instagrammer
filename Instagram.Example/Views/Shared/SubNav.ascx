<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<SubNavItem>>" %>
<%@ Import Namespace="Instagrammer.Example" %>
<% if (Model != null) { %>
<div class="subnav">
<% 
    int count = 0;
    foreach (var item in Model) { %>
        <%= Html.ActionLink(item.LinkText, item.ActionName, item.ControllerName) %> <% if((count + 1) < Model.Count) { %> / <% } %> 
<% 	    count++;
    } %>
</div>    
<% } %>