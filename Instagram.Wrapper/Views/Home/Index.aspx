<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Instagram.Wrapper.Models.InstagramUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <% 
        string queryString = string.Format("?client_id={0}&redirect_uri={1}&response_type=code", "bfbdf77fbe934ffc8fbc710f6d15f75e", Server.UrlEncode("http://localhost/InstagramWrapper/OAuth/AccessRequest/"));

        if (Model == null) {
    %>
    <a href="https://api.instagram.com/oauth/authorize/<%= queryString %>" target="_blank">Authenticate with instagram</a>
    <% } else { %>
    Welcome back <%= Model.full_name %>
    <% } %>
</asp:Content>
