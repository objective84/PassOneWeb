<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PassOne.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="UsernameLabel" runat="server" 
        style="z-index: 1; left: 509px; top: 202px; position: absolute" Text="Username"></asp:Label>
    <asp:TextBox ID="UsernameTextBox" runat="server" 
        style="z-index: 1; left: 581px; top: 202px; position: absolute"></asp:TextBox>
    <asp:Label ID="PasswordLabel" runat="server" 
        style="z-index: 1; left: 508px; top: 256px; position: absolute" Text="Password"></asp:Label>
    <asp:TextBox ID="PasswordTextBox" runat="server" 
        style="z-index: 1; left: 581px; top: 254px; position: absolute" TextMode="Password"></asp:TextBox>
    <asp:Button ID="RegisterButton" runat="server" onclick="Button1_Click" 
        style="z-index: 1; left: 582px; top: 301px; position: absolute" 
        Text="Register" />
    <asp:Button ID="LoginButton" runat="server" onclick="Button2_Click" 
        style="z-index: 1; left: 662px; top: 300px; position: absolute" Text="Login" />
    </form>
</body>
</html>
