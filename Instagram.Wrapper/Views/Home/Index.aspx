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
        <div class="user_badge clearfix">
            <img src="<%= Model.profile_picture %>" class="shadow_2" /><h3>Welcome back <%= Model.username %></h3>
            <div class="meta">
                
                following: <%= Model.counts.follows %><br />
                followed by: <%= Model.counts.followed_by %><br /></div>
        </div>

    </div>
    <div id="center">
        <% Html.RenderPartial("UserFeed", ViewData["UserFeed"]); %>    
    </div>
    <% } %>
</asp:Content>
