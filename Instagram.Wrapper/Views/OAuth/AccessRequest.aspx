<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Instagram.Wrapper.Models.OAuthToken>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AccessRequest
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AccessRequest</h2>
    Hi <%= Model.user.full_name %>
</asp:Content>
