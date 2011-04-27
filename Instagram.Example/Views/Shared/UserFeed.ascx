<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ApiResponse<instagrammer.FeedItem>>" %>
<%@ Import Namespace="instagrammer" %>

<div class="user_feed">
    <%  if(Model != null) {
            foreach (var item in Model.data) {
    %>
        <div class="feed_entry class="clearfix">
            <div class="feed_entry_header">
                <img src="<%= item.user.profile_picture %>" class="shadow_2" />
                <span class="user"><%= item.user.username%></span><br /> <% if (item.caption != null && !string.IsNullOrEmpty(item.caption.text)) %> <%= item.caption.text%><span class="meta"></span>
            </div>


            <a href="<%= Url.Action("Details", "Photos", new { id = item.id })%>">
                <img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="taken by: <%= item.user.username %>" title="taken by: <%= item.user.username %>" /></a>

            <div class="feed_entry_caption">
                <div class="clock"><%= Html.FormatReadableDate(Convert.ToDouble(item.created_time).ConvertFromUnixTimestamp()) %></div>
                <a href="#" class="like_action">
                    <div id="<%= item.id %>" class="likes <%= item.user_has_liked == "true" || item.user_has_liked == "1" ? "user_liked" : "" %>">
                    <%= item.likes != null ? item.likes.count : "0"%>
                </div></a>     
                <div class="comments"><%= item.comments != null ? item.comments.count : "0"%></div>
            </div>
        </div>
    <% 
            }
        } 
    %>
</div>
<%--
<% Html.RenderAction("Pager"); %>--%>