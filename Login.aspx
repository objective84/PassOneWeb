<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Login.aspx.cs" Inherits="PassOne.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="UsernameLabel" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    <br/>
    <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </asp:Content>
