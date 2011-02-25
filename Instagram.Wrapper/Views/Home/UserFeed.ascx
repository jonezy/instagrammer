<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Instagram.Wrapper.Models.UserFeed>>" %>
<%@ Import Namespace="Instagram.Wrapper.Models" %>
<h2>Latest photos</h2>
<div class="user_feed">
<% foreach (var item in Model) { %>
    <div class="feed_entry class="clearfix">
        <img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="" />
        <div class="feed_entry_caption"><% if(item.caption != null && !string.IsNullOrEmpty(item.caption.text)) %> <%= item.caption.text %></div>

    </div>
<% } %>
</div>