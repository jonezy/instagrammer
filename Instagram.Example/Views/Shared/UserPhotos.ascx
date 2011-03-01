<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ApiResponse<FeedItem>>" %>
<%@ Import Namespace="instagrammer" %>

<div class="user_photos">
    <div class="pager top clearfix"><%= Html.ActionLink("Next", "Next", "Photos", new { id = Model.pagination.next_max_id }, null)%><%= Html.ActionLink("<- back", "Index", "Photos", new { @class = "back" })%></div>
        <% if(Model != null) {
            foreach (var item in Model.data) { %>
                <% Html.RenderPartial("PhotoDetails", item); %> 
        <%  }
           } %> 
    <div class="pager bottom clearfix"><%= Html.ActionLink("Next", "Next", "Photos", new { id = Model.pagination.next_max_id }, null )%><%= Html.ActionLink("<- back", "Index", "Photos", new { @class = "back" })%></div>
</div>
