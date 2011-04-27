<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<instagrammer.Pagination>" %>

<div class="pager bottom clearfix"><%= Html.ActionLink("Next", "Next", new { id = Model.next_max_id }, null )%><%= Html.ActionLink("<- back", "Index", "Photos", new { @class = "back" })%></div>