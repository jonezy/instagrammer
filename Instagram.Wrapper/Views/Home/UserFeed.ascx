<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Instagram.Wrapper.Models.UserFeed>>" %>
<%@ Import Namespace="Instagram.Wrapper.Models" %>
<div class="user_feed">
<h2>Your feed</h2>
<% foreach (var item in Model) { %>
    <div class="feed_entry class="clearfix">
        <a rel="prettyPhoto[feedGallery]" href="<%= item.images.standard_resolution.url %>"><img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="" /></a>
        <div class="feed_entry_caption"><% if(item.caption != null && !string.IsNullOrEmpty(item.caption.text)) %> <%= item.caption.text %></div>
    </div>
<% } %>
</div>