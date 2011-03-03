<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FeedItem>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_photo clearfix">
    <img src="<%= Model.images.low_resolution.url %>" width="<%= Convert.ToInt32(Model.images.low_resolution.width)%>" height="<%= Convert.ToInt32(Model.images.low_resolution.height) %>" alt="" />
    <div class="meta">
        <h2 class="clearfix"><span class="title"><%= Model.caption != null ? Model.caption.text : "N/A" %></span><div class="clock photo_date"><%= Html.FormatReadableDate(Convert.ToDouble(Model.created_time).ConvertFromUnixTimestamp()) %></span></h2>
        
        <% if(Model.location != null || !string.IsNullOrEmpty(Model.filter)) { %>
            <span class="photo_data"><% if (Model.location != null && !string.IsNullOrEmpty(Model.location.name)) { %> taken at <strong><%= Model.location.name  %></strong> <% } %><% if( !string.IsNullOrEmpty(Model.filter)) { %>filtered with <strong><%= Model.filter %><% } %></strong></span>
        <% } %>

        <% if(Model.likes.count != "0") { %>
            <div class="likes_container clearfix">
                <div class="label"><div class="likes">(<%= Model.likes.count %>)</div></div>
                <div class="photo_likes"><span class="user"><%= Html.DelimetedListOfUsers(Model.likes.data) %></span></div>
            </div>
        <% } %>
        <% if (Model.comments.count != "0") { %>
        <div class="comment_container clearfix">
            <div class="label"><div class="comments">(<%= Model.comments.count %>)</div></div>
            
            <div class="photo_comments">
                <% foreach (var item in Model.comments.data) { %>
                    <div class="photo_comment"><span class="user"><%= item.from.username %></span>: <%= item.text %></div>
                <% } %>
            </div>
        </div>
        <% } %>

        

    </div>
    

</div> 