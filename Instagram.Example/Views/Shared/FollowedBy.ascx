<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<instagrammer.InstagramUser>>" %>
<div class="following clearfix">
    <h3 class="textshadow">Followers <%= Html.ActionLink("(all)", "Followers", "Friends") %></h3>
    <% 
        if(Model != null) {
           foreach (var item in Model) { 
    %>
        <img src="<%= item.profile_picture %>" title="<%= item.username %>" alt="<%= item.username %>" class="shadow_2" />
    <%  
           }
        } 
    %>
</div>
