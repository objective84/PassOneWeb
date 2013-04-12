<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="CredentialsList.aspx.cs" Inherits="PassOne.CredentialsList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    

    <asp:ListBox ID="CredentialsListBox" runat="server" Height="342px" Width="111px" OnSelectedIndexChanged="CredentialsListBox_SelectedIndexChanged"></asp:ListBox>

    <br/>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Button ID="Button2" runat="server" Text="Button" />
    </asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent1">
    <asp:Label ID="WebsiteLabel" runat="server" Text="Website: " style="vertical-align:top"></asp:Label >
    <asp:LinkButton ID="WebsiteValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>

    <asp:Label ID="UrlLabel" runat="server" Text="URL: " style="vertical-align:top; margin: 6px 8px 8px 8px" ></asp:Label>
    <asp:LinkButton ID="UrlValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="UsernameLabel" runat="server" Text="Username: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="UsernameValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <asp:Label ID="EmailLabel" runat="server" Text="Email: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="EmailValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="PasswordLabel" runat="server" Text="Password: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="PasswordValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <asp:LinkButton ID="ShowPasswordButton" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    </asp:Content>
