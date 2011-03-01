<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.FeedItem>>" %>
<div class="recent_media">
<h3 class="textshadow">Your recent photo's</h3>
<%  if(Model != null) {
        foreach (var item in Model) { 
%>
    <div class="feed_entry class="clearfix">
        <a rel="prettyPhoto[recentMediaGallery]" href="<%= Url.Action("Details", "Photos", new { id = item.id, iframe="true", width="500", height="499" }) %>">
        <img src="<%= item.images.thumbnail.url %>" width="<%= Convert.ToInt32(item.images.thumbnail.width) / 2 %>" height="<%= Convert.ToInt32(item.images.thumbnail.height) / 2 %>" alt="<%= item.id %>" title="<%= item.id %>" /></a>
    </div>  
<%      
        }
    } 
%>  
</div>