<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlesControl.ascx.cs" Inherits="News_System.Controls.ArticlesControl" %>
<script src="../Scripts/jquery-2.1.1.min.js"></script>
<script src="../Scripts/article-details.js"></script>
<asp:Repeater ID="Repeater1" SelectMethod="GetArticles" runat="server" ItemType="News_System.Models.ArticleModel">
    <ItemTemplate>
        <div class="article">
            <h3 class="articleTitle" data-info="<%# Item.ID %>"><%# Item.Title %></h3>
            <div class="articleContent"><%# Item.Content %></div>
        </div>
    </ItemTemplate>
</asp:Repeater>
