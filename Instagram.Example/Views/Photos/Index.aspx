<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Your photo's
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Photo's<% Html.RenderPartial("SubNav", ViewData["SubNavItems"]); %></h2>
    <% Html.RenderPartial("UserFeed", ViewData["Photos"]); %>
    
</asp:Content>
