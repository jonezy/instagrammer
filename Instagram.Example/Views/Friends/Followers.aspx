﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Followers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Followers<% Html.RenderPartial("SubNav", ViewData["SubNavItems"]); %></h2>
    <% Html.RenderPartial("FriendRecords", ViewData["Followers"]); %>
</asp:Content>
