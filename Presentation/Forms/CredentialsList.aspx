<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CredentialsList.aspx.cs" Inherits="PassOne.CredentialsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="DeleteButton" runat="server" onclick="DeleteButton_Click" 
            style="z-index: 1; left: 408px; top: 505px; position: absolute" Text="Delete" />
                <asp:Button ID="NewButton" runat="server" onclick="Button1_Click" 
            style="z-index: 1; left: 408px; top: 475px; position: absolute" Text="New" />
    
    <asp:Label ID="EmailLabel" runat="server" 
    style="z-index: 1; left: 721px; top: 272px; position: absolute" 
    Text="Email:"></asp:Label>
<asp:ListBox ID="CredentialsListBox" runat="server" 
            style="z-index: 1; left: 237px; top: 142px; position: absolute; height: 394px; width: 168px" AutoPostBack="True" 
            OnSelectedIndexChanged="CredentialsListBox_SelectedIndexChanged" >
</asp:ListBox>
    <asp:LinkButton ID="WebsiteEdit" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 522px; top: 169px; position: absolute; " 
    onclick="Edit_Click">Edit</asp:LinkButton>
<asp:LinkButton ID="UrlEdit" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 755px; top: 164px; position: absolute; height: 12px;" 
            onclick="Edit_Click">Edit</asp:LinkButton>
<asp:LinkButton ID="UsernameEdit" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 601px; top: 370px; position: absolute; right: 668px;" 
            onclick="Edit_Click">Edit</asp:LinkButton>
<asp:LinkButton ID="EmailEdit" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 754px; top: 289px; position: absolute; height: 12px;" 
            onclick="Edit_Click">Edit</asp:LinkButton>
<asp:LinkButton ID="PasswordEdit" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 522px; top: 291px; position: absolute; height: 12px;" 
            onclick="Edit_Click">Edit</asp:LinkButton>
    <asp:Label ID="UrlLabel" runat="server" 
        style="z-index: 1; left: 726px; top: 149px; position: absolute" 
        Text="URL:"></asp:Label>
    <asp:Label ID="WebsiteLabel" runat="server" 
        style="z-index: 1; left: 475px; top: 151px; position: absolute" 
        Text="Website:"></asp:Label>
    <asp:Label ID="UsernameLabel" runat="server" 
    style="z-index: 1; left: 465px; top: 274px; position: absolute; right: 888px" 
    Text="Username:"></asp:Label>
    <asp:Label ID="PasswordLabel" runat="server" 
        style="z-index: 1; left: 572px; top: 351px; position: absolute" 
        Text="Password:"></asp:Label>
    <asp:Label ID="WebsiteValue" runat="server" 
        style="z-index: 1; left: 534px; top: 152px; position: absolute; right: 1005px"></asp:Label>
    <asp:Label ID="UrlValue" runat="server" 
        style="z-index: 1; left: 764px; top: 148px; position: absolute"></asp:Label>
    <asp:Label ID="UsernameValue" runat="server" 
        style="z-index: 1; left: 536px; top: 274px; position: absolute; right: 1030px;"></asp:Label>
    <asp:Label ID="EmailValue" runat="server" 
        style="z-index: 1; left: 765px; top: 271px; position: absolute"></asp:Label>
<asp:Label ID="PasswordValue" runat="server" 
    style="z-index: 1; left: 642px; top: 352px; position: absolute" Visible="False"></asp:Label>
    </div>
        <asp:LinkButton ID="ShowPasswordButton" runat="server" Font-Size="XX-Small" 
    style="z-index: 1; left: 665px; top: 372px; position: absolute; " 
    onclick="ShowPassword_Click">Show Password</asp:LinkButton>
    </form>
</body>
</html>
