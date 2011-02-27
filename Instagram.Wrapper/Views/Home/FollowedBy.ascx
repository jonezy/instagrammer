<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Instagram.Wrapper.Models.InstagramUser>>" %>
<div class="following clearfix">
    <h3>Followed by</h3>
    <% foreach (var item in Model) { %>
        <img src="<%= item.profile_picture %>" class="shadow_2" />
    <% } %>
</div>
