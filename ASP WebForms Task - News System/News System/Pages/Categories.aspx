<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="News_System.Pages.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteSubtutle" runat="server">
    <h4>Categories</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:ListView runat="server" ID="categoriesListView"
        ItemType="News_System.Category"
        SelectMethod="GetCategories"
        DataKeyNames="CategoryID" UpdateMethod="UpdateCategory"
        DeleteMethod="DeleteCategory" InsertMethod="InsertCategory"
        InsertItemPosition="LastItem" EnableViewState="false">
        <LayoutTemplate>
            <div class="outerContainer">
                <table id="articleTamplate">
                    <tr>
                        <th>
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="ID" CommandArgument="CategoryID" CommandName="Sort"></asp:LinkButton></th>
                        <th>
                            <asp:LinkButton ID="LinkButton3" runat="server" Text="Name" CommandArgument="Name" CommandName="Sort"></asp:LinkButton></th>
                        <th>&nbsp;</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.CategoryID %></td>
                <td><%# Item.Name %></td>
                <td>
                    <asp:Button ID="Button1" CommandName="Edit" Text="Edit" runat="server" />
                    <asp:Button ID="Button2" CommandName="Delete" Text="Delete" runat="server" />
                </td>
            </tr>
        </ItemTemplate>

        <EditItemTemplate>
            <tr>
                <td>
                    <input name="categoryid" value="<%#: Item.CategoryID %>" disabled="disabled"/>
                    <input type="hidden" name="ID" value="<%#: Item.CategoryID%>" />
                </td>
                <td>
                    <input name="name"  value="<%#: Item.Name %>"/>
                </td>
                <td>
                    <asp:Button ID="Button3" CommandName="Update" Text="Update" runat="server" />
                    <asp:Button ID="Button4" CommandName="Cancel" Text="Cancel" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="categoryid" placeholder="ID" disabled="disabled"/>
                    <input type="hidden" name="ID" value="0" />
                </td>
                <td>
                    <input name="name" placeholder="Content" /></td>
                <td>
                    <asp:Button ID="Button4" CommandName="Insert" Text="Add" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <asp:DataPager runat="server" PagedControlID="categoriesListView" ID="categoriesPager" PageSize="5">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" />
        </Fields>
    </asp:DataPager>
</asp:Content>
