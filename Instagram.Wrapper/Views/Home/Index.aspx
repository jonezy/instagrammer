<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Instagram.Wrapper.Models.InstagramUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        string queryString = string.Format("?client_id={0}&redirect_uri={1}&response_type=code", "bfbdf77fbe934ffc8fbc710f6d15f75e", Server.UrlEncode("http://localhost/InstagramWrapper/OAuth/AccessRequest/"));

        if (Model.id == 0) {
    %>
        <h2>Please authenticate with instagram</h2>
        <p>You will be returned back to this page once you've granted this site access to your instagram account.</p>
        <a href="https://api.instagram.com/oauth/authorize/<%= queryString %>">Authenticate with instagram</a>
    <% } else { %>
    <div id="left">

        <% Html.RenderPartial("UserBadge", ViewData["UserData"]); %>
        <% Html.RenderPartial("RecentMedia", ViewData["RecentMedia"]); %>
        <% Html.RenderPartial("Following", ViewData["Following"]); %>
        <% Html.RenderPartial("FollowedBy", ViewData["FollowedBy"]); %>
    </div>
    <div id="center">
        <% Html.RenderPartial("UserFeed", ViewData["UserFeed"]); %>    
    </div>
    <% } %>
</asp:Content>
