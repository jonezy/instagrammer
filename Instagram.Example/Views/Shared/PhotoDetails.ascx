<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<instagrammer.UserFeed>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_photo clearfix">
    <img src="<%= Model.images.low_resolution.url %>" width="<%= Convert.ToInt32(Model.images.low_resolution.width)%>" height="<%= Convert.ToInt32(Model.images.low_resolution.height) %>" alt="" />
    <div class="meta">
        <h3><%= Model.caption != null ? Model.caption.text : "N/A" %></h3>
        <% if (Model.location != null) { %>
        location: <%= !string.IsNullOrEmpty(Model.location.name) ? Model.location.name : "N/A"%><br />
        <% } %>
        taken: <%= Convert.ToDouble(Model.created_time).ConvertFromUnixTimestamp() %><br />
        comments: <%= Model.comments.count %><br />
        likes: <%= Model.likes.count %><br />
        filter: <%= Model.filter %>
    </div>
</div> 