<%@ Page Title="News Sistem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="News_System.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-2.1.1.js"></script>
    <script src="../Scripts/article-details.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div id="Categories">
        <asp:Repeater ID="categoryRepeater" SelectMethod="GetCategories" runat="server" ItemType="News_System.Category">
            <ItemTemplate>
                <a <%#"href=\"ArticlesByCategory.aspx?Category=" + Item.Name + "\"" %> >
                    <h4 runat="server"><%# Item.Name %></h4>
                </a>
                <asp:Repeater ID="categoryLeatestPostTitles" runat="server" ItemType="News_System.Models.ArticleModel">
                    <ItemTemplate>
                        <div><%# Item.Title %></div>
                        <span>by: <%# Item.Author %></span>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Repeater SelectMethod="GetArticles" runat="server" ItemType="News_System.Models.ArticleModel">
        <ItemTemplate>
            <div class="article">
                <h3 class="articleTitle" data-info="<%# Item.ID %>"><%# Item.Title %></h3>
                <div class="articleContent"><%# Item.Content %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

<asp:Content ContentPlaceHolderID="SiteSubtutle" runat="server">
    <h4>Welcome</h4>
</asp:Content>

