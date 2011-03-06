<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FeedItem>" %>
<%@ Import Namespace="instagrammer" %>
<div class="user_photo clearfix" id="details_<%= Model.id %>">
    <img src="<%= Model.images.low_resolution.url %>" width="<%= Convert.ToInt32(Model.images.low_resolution.width)%>" height="<%= Convert.ToInt32(Model.images.low_resolution.height) %>" alt="" />
    <div class="meta">
        <h2 class="clearfix"><span class="title"><%= Model.caption != null ? Model.caption.text : "N/A" %></span><div class="clock photo_date"><%= Html.FormatReadableDate(Convert.ToDouble(Model.created_time).ConvertFromUnixTimestamp()) %></span></h2>
        
        <% if(Model.location != null || !string.IsNullOrEmpty(Model.filter)) { %>
            <span class="photo_data"><% if (Model.location != null && !string.IsNullOrEmpty(Model.location.name)) { %> taken at <strong><%= Model.location.name  %></strong> <% } %><% if( !string.IsNullOrEmpty(Model.filter)) { %>filtered with <strong><%= Model.filter %><% } %></strong></span>
        <% } %>


        <div class="likes_container clearfix">
            <div class="label">
             <a href="#" class="like_action "><div id="<%= Model.id %>" class="likes <%= Model.user_has_liked == "true" || Model.user_has_liked == "1" ? "user_liked" : "" %>">(<%= Model.likes != null ? Model.likes.count : "0"%>)</div></a>
            </div>
            <div class="photo_likes"><span class="user"><%= Html.DelimetedListOfUsers(Model.likes.data) %></span></div>
        </div>

        
        <div class="comment_container clearfix">
            <div class="label"><div class="comments">(<%= Model.comments.count %>)</div></div>
            
            <div class="photo_comments">
            <% 
                if (Model.comments.count != "0") {
                    foreach (var item in Model.comments.data) { %>
                    <div class="photo_comment"><span class="user"><%= item.from.username%></span>: <%= item.text%></div>
            <%      }
                } else {
            %>
                <div class="photo_comment"><em>no comments?? be the first to add one!!</em></div>
            <%  } %>
                
                <div class="comment_input_container">
               <%-- <% Html.BeginForm(new { id = "comment_form" }); %>--%>
                    <%= Html.TextArea( "name", null, new {id = "comment_" + Model.id, @class = "comment_input" } ) %>
                    <input type="submit" value="add comment" name="<%= Model.id %>" class="comment_submit" id="btnSubmit" />
                 <%--<% Html.EndForm(); %>--%>
                </div>
            </div>
        </div>

        

    </div>
    

</div> 