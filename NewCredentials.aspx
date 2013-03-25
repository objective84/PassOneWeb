<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCredentials.aspx.cs" Inherits="PassOne.NewCredentials" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="WebsiteLabel" runat="server" 
            
            style="z-index: 1; left: 390px; top: 150px; position: absolute; bottom: 459px;" 
            Text="Website"></asp:Label>
        <asp:Label ID="UrlLabel" runat="server" 
            style="z-index: 1; left: 407px; top: 183px; position: absolute" Text="URL"></asp:Label>
    
    </div>
    <asp:Label ID="UsernameLabel" runat="server" 
        style="z-index: 1; left: 378px; top: 214px; position: absolute" 
        Text="Username"></asp:Label>
    <asp:Label ID="EmailLabel" runat="server" 
        style="z-index: 1; left: 403px; top: 249px; position: absolute" 
        Text="Email"></asp:Label>
    <asp:Label ID="PasswordLabel" runat="server" 
        style="z-index: 1; left: 378px; top: 283px; position: absolute" 
        Text="Password"></asp:Label>
    <asp:TextBox ID="WebsiteTextbox" runat="server" 
        style="z-index: 1; left: 457px; top: 149px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="UrlTextbox" runat="server" 
        style="z-index: 1; left: 457px; top: 183px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="UsernameTextbox" runat="server" 
        style="z-index: 1; left: 457px; top: 214px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="EmailTextbox" runat="server" 
        style="z-index: 1; left: 457px; top: 249px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="PasswordTextbox" runat="server" 
        style="z-index: 1; left: 457px; top: 284px; position: absolute"></asp:TextBox>
    <asp:Button ID="CreateButton" runat="server" onclick="Button1_Click" 
        style="z-index: 1; left: 529px; top: 315px; position: absolute" Text="Create" />
    </form>
</body>
</html>
