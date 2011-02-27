<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.InstagramUser>>" %>
<div class="following clearfix">
    <h3 class="textshadow">Followed by</h3>
    <% foreach (var item in Model) { %>
        <img src="<%= item.profile_picture %>" class="shadow_2" />
    <% } %>
</div>
