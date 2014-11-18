<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticlesByCategory.aspx.cs" Inherits="News_System.Pages.ArticlesByCategory" %>
<%@ Register TagPrefix="UC" TagName="Article" Src="~/Controls/ArticlesControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteSubtutle" runat="server">
    <h4>Articles in category <%= categoryString %></h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <UC:Article runat="server" Count="3"/>
</asp:Content>
