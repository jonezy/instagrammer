<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<instagrammer.InstagramUser>" %>
<div class="user_badge clearfix">
    <img src="<%= Model.profile_picture %>" class="shadow_2" />
    <div class="meta">
        <h3>Welcome back <%= Model.username %></h3>
        following: <%= Model.counts.follows %><br />
        followed by: <%= Model.counts.followed_by %><br /></div>
</div>