<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FeedItem>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_photo clearfix">
    <img src="<%= Model.images.low_resolution.url %>" width="<%= Convert.ToInt32(Model.images.low_resolution.width)%>" height="<%= Convert.ToInt32(Model.images.low_resolution.height) %>" alt="" />
    <div class="meta">
        <h3><%= Model.caption != null ? Model.caption.text : "N/A" %><span class="photo_date"><%= Html.FormatReadableDate(Convert.ToDouble(Model.created_time).ConvertFromUnixTimestamp()) %></span></h3>
        <% if (Model.location != null && !string.IsNullOrEmpty(Model.location.name)) { %> l: <%= Model.location.name  %> <% } %>f: <%= Model.filter %><br /><br />

        comments: <%= Model.comments.count %><br />
        likes: <%= Html.DelimetedListOfUsers(Model.likes.data) %>
        

    </div>
</div> 