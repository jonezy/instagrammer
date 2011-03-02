<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="textshadow_white">Your feed <% Html.RenderPartial("SubNav", ViewData["SubNavItems"]); %></h2>
    <% Html.RenderPartial("UserFeed", ViewData["UserFeed"]); %>    
</asp:Content>
