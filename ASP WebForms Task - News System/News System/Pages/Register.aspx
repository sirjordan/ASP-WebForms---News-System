<%@ Page Title="Register New User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="News_System.Pages.LoginRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <asp:TextBox ID="userName" runat="server"></asp:TextBox>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Register!" />
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SiteSubtutle" runat="server">
    <h4>Register New User</h4>
</asp:Content>