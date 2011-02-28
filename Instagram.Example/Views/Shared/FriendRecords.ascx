<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.InstagramUser>>" %>
<div class="friends_records">
    <% foreach (var item in Model) { %>
       <div class="friend_record">
            <div class="feed_entry_header"><%= item.username %></div>
            <img src="<%= item.profile_picture %>" class="shadow_2" />
            <div class="feed_entry_caption"></div>
       </div>    
    <% } %>  
</div>