<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="CredentialsList.aspx.cs" Inherits="PassOne.CredentialsList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    

    <asp:ListBox ID="CredentialsListBox" runat="server" Height="342px" Width="111px" AutoPostBack="True" OnSelectedIndexChanged="CredentialsListBox_SelectedIndexChanged"></asp:ListBox>

    <br/>
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click"/>
    <asp:Button ID="NewButton" runat="server" Text="New" OnClick="Button1_Click"/>
    </asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent1">
    <asp:Label ID="WebsiteLabel" runat="server" Text="Website: " ></asp:Label >
    <asp:LinkButton ID="WebsiteValue" runat="server"  onclick="Edit_Click"></asp:LinkButton>

    <asp:Label ID="UrlLabel" runat="server" Text="URL:" style ="margin: 6px 8px 8px 8px" ></asp:Label>
    <asp:LinkButton ID="UrlValue" runat="server" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="UsernameLabel" runat="server" Text="Username: " ></asp:Label>
    <asp:LinkButton ID="UsernameValue" runat="server" onclick="Edit_Click"></asp:LinkButton>
    
    <asp:Label ID="EmailLabel" runat="server" Text="Email: " s></asp:Label>
    <asp:LinkButton ID="EmailValue" runat="server" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="PasswordLabel" runat="server" Text="Password: " ></asp:Label>
    <asp:LinkButton ID="PasswordValue" runat="server" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <asp:LinkButton ID="ShowPasswordButton" runat="server" onclick="ShowPassword_Click"></asp:LinkButton>
    </asp:Content>
