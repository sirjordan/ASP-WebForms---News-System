<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="News_System.Pages.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteSubtutle" runat="server">
    <h4>Articles</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:ListView runat="server" ID="articlesListView"
        ItemType="News_System.Models.ArticleModel"
        SelectMethod="GetArticles"
        DataKeyNames="ID" UpdateMethod="UpdateArticle"
        DeleteMethod="DeleteArticle" InsertMethod="InsertArticle"
        InsertItemPosition="LastItem" EnableViewState="false" OnItemCreated="articlesListView_ItemCreated">
        <LayoutTemplate>
            <div class="outerContainer">
                <table id="articleTamplate">
                    <tr>
                        <th><asp:LinkButton ID="LinkButton2" runat="server" Text="Title" CommandArgument="Title" CommandName="Sort"></asp:LinkButton></th>
                        <th>Content</th>
                        <th>Author</th>
                        <th><asp:LinkButton ID="LinkButton3" runat="server" Text="PostDate" CommandArgument="PostDate" CommandName="Sort"></asp:LinkButton></th>
                        <th>Category</th>
                        <th>&nbsp;</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Title %></td>
                <td><%#  Item.Content.Length > 130 ? Item.Content.Substring(0, 129) + " ..." : Item.Content %></td>
                <td><%#: Item.Author %></td>
                <td><%#: Item.PostDate %></td>
                <td><%#: Item.Category %></td>
                <td>
                    <asp:Button ID="Button1" CommandName="Edit" Text="Edit" runat="server" />
                    <asp:Button ID="Button2" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%#: Item.Title %>" />
                    <input type="hidden" name="ID" value="<%#: Item.ID%>" />
                </td>
                <td>
                    <textarea name="content" rows="4" cols="30"><%#: Item.Content %></textarea>
                <td>
                    <input name="author" value="<%#: Item.Author %>" />
                </td>
                <td>
                    <input name="postDate" value="<%#: Item.PostDate %>" />
                </td>
                <td>
                    <input name="category" value="<%#: Item.Category %>" />
                </td>
                <td>
                    <asp:Button CommandName="Update" Text="Update" runat="server" />
                    <asp:Button ID="Button3" CommandName="Cancel" Text="Cancel" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="title" placeholder="Title" />
                    <input type="hidden" name="ID" value="0" />
                </td>
                <td>
                    <input name="content" placeholder="Content" /></td>
                <td>
                    <input name="author" runat="server" id="authorName" placeholder="<%# HttpContext.Current.User.Identity.Name %>"  disabled="disabled"/></td>
                <td>
                    <input name="postDate" placeholder="<%# DateTime.Now %>" runat="server" id="postDate" disabled="disabled"/></td>
                <td>
                    <asp:DropDownList runat="server" ID="categoryList"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button4" CommandName="Insert" Text="Add" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <asp:DataPager runat="server" PagedControlID="articlesListView" ID="articlesPager" PageSize="5" >
        <Fields>
            <asp:NumericPagerField ButtonType="Link" />
        </Fields>
    </asp:DataPager>
</asp:Content>
