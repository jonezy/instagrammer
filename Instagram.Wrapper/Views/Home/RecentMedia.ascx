<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Instagram.Wrapper.Models.UserFeed>" %>

<div class="recent_media">
    <div class="feed_entry class="clearfix">
        <a rel="prettyPhoto[feedGallery]" href="<%= item.images.standard_resolution.url %>"><img src="<%= item.images.thumbnail.url %>" width="<%= item.images.thumbnail.width %>" height="<%= item.images.thumbnail.height %>" alt="" /></a>
    </div>    
</div>