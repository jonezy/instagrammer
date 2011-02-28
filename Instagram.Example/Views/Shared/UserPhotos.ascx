<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.UserFeed>>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_photos">
<% foreach (var item in Model) { %>
    <div class="user_photo clearfix">
        <img src="<%= item.images.low_resolution.url %>" width="<%= Convert.ToInt32(item.images.low_resolution.width)%>" height="<%= Convert.ToInt32(item.images.low_resolution.height) %>" alt="" />
        <div class="meta">
            caption: <%= item.caption != null ? item.caption.text : "N/A" %><br />
            location: <%= !string.IsNullOrEmpty(item.location.name) ? item.location.name : "N/A" %><br />
            taken: <%= Convert.ToDouble(item.created_time).ConvertFromUnixTimestamp() %><br />
            comments: <%= item.comments.count %><br />
            likes: <%= item.likes.count %><br />
            filter: <%= item.filter %>
        </div>
    </div>  
<% } %> 
</div>
