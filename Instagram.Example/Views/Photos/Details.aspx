<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ImageDetails
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (ViewData["PhotoDetails"] != null) { %>
        <% Html.RenderPartial("PhotoDetails", ViewData["PhotoDetails"]); %>
    <% } else {%>
        <div class="Message_Error">
            <p><%= ViewData["Error"] %></p>
        </div>
    <% } %>
</asp:Content>
