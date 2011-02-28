<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<instagrammer.InstagramUser>" %>
<div class="user_badge clearfix">
    <img src="<%= Model.profile_picture %>" class="shadow_2" />
    <div class="meta clearfix">
        <h2>Welcome back <%= Model.username %></h2>
        <div class="left">
            aka: <%= Model.first_name %><%= Model.full_name%><br />
            pictures: <%= Model.counts.media %><br />
        </div>
        <div class="right">
            following: <%= Model.counts.follows %><br />
            followed by: <%= Model.counts.followed_by %><br />
        </div>
    </div>
</div>