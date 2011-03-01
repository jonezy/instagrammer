<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.UserFeed>>" %>
<div class="user_feed">
    <h2 class="textshadow_white">Your feed</h2>
    <%  if(Model != null) {
            foreach (var item in Model) {
    %>
        <div class="feed_entry class="clearfix">
            <div class="feed_entry_header"><%= item.user.username%> <span class="meta">l:<%= item.likes != null ? item.likes.count : "0"%> c:<%= item.comments != null ? item.comments.count : "0"%></span></div>
            <a rel="prettyPhoto[feedGallery]" href="<%= item.images.standard_resolution.url %>"><img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="taken by: <%= item.user.username %>" title="taken by: <%= item.user.username %>" /></a>
            <div class="feed_entry_caption"><% if (item.caption != null && !string.IsNullOrEmpty(item.caption.text)) %> <%= item.caption.text%></div>
        </div>
    <% 
            }
        } 
    %>
</div>