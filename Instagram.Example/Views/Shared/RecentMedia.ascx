<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.UserFeed>>" %>
<div class="recent_media">
<h3 class="textshadow">Your recent photo's</h3>
<% foreach (var item in Model) { %>
    <div class="feed_entry class="clearfix">
        <a rel="prettyPhoto[recentMediaGallery]" href="<%= item.images.standard_resolution.url %>">
            <img src="<%= item.images.thumbnail.url %>" width="<%= Convert.ToInt32(item.images.thumbnail.width) / 2 %>" height="<%= Convert.ToInt32(item.images.thumbnail.height) / 2 %>" alt="" /></a>
    </div>  
<% } %>  
</div>