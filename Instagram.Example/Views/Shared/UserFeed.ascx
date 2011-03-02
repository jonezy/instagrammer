<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.FeedItem>>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_feed">
    <%  if(Model != null) {
            foreach (var item in Model) {
    %>
        <div class="feed_entry class="clearfix">
            <div class="feed_entry_header">
            <span class="meta">
            <div class="clock"><%= Html.FormatReadableDate(Convert.ToDouble(item.created_time).ConvertFromUnixTimestamp()) %></div>
                <div class="likes"><%= item.likes != null ? item.likes.count : "0"%></div>
                 <div class="comments"><%= item.comments != null ? item.comments.count : "0"%></div>
            </span>
            </div>
            <a rel="prettyPhoto[recentMediaGallery]" href="<%= Url.Action("Details", "Photos", new { id = item.id, iframe="true", width="740", height="350" }) %>">
                <img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="taken by: <%= item.user.username %>" title="taken by: <%= item.user.username %>" /></a>
            <div class="feed_entry_caption"><span class="user"><%= item.user.username%></span> <% if (item.caption != null && !string.IsNullOrEmpty(item.caption.text)) %> <%= item.caption.text%><span class="meta"></span></div>
        </div>
    <% 
            }
        } 
    %>
</div>