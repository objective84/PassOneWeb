<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Register.aspx.cs" Inherits="PassOne.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="FirstNameLabel" runat="server" Text="First Name: "></asp:Label>
    <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
    <br/>
    
    <asp:Label ID="LastNameLabel" runat="server" Text="Last Name:  "></asp:Label>
    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
    <br/>
    
    <asp:Label ID="UsernameLabel" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    <br/>
    
    <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
    <br/>
    
    <asp:Label ID="ConfirmLabel" runat="server" Text="Confirm Password: "></asp:Label>
    <asp:TextBox ID="ConfirmTextBox" runat="server"></asp:TextBox>
    <br/>
    
    <asp:LinkButton ID="CancelLinkButton" runat="server" Font-Size="Small">Cancel</asp:LinkButton>
    <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
</asp:Content>
