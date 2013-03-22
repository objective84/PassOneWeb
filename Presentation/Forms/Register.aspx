<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PassOne.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="CancelLinkButton" runat="server" 
            style="z-index: 1; left: 529px; top: 295px; position: absolute">Cancel</asp:LinkButton>
    
    </div>
    <asp:Button ID="RegisterButton" runat="server" 
        style="z-index: 1; left: 593px; top: 293px; position: absolute" 
        Text="Register" OnClick="RegisterButton_Click" />
    <asp:Label ID="FirstNameLabel" runat="server" 
        style="z-index: 1; left: 456px; top: 111px; position: absolute" 
        Text="First Name"></asp:Label>
    <asp:TextBox ID="FirstNameTextBox" runat="server" 
        style="z-index: 1; left: 538px; top: 109px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="LastNameTextBox" runat="server" 
        style="z-index: 1; left: 538px; top: 145px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="UsernameTextBox" runat="server" 
        style="z-index: 1; left: 537px; top: 180px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="PasswordTextBox" runat="server" 
        style="z-index: 1; left: 537px; top: 217px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="ConfirmTextBox" runat="server" 
        style="z-index: 1; left: 536px; top: 257px; position: absolute"></asp:TextBox>
    <asp:Label ID="LastNameLabel" runat="server" 
        style="z-index: 1; left: 457px; top: 146px; position: absolute" 
        Text="Last Name"></asp:Label>
    <asp:Label ID="UsernameLabel" runat="server" 
        style="z-index: 1; left: 461px; top: 182px; position: absolute" Text="Username"></asp:Label>
    <asp:Label ID="PasswordLabel" runat="server" 
        style="z-index: 1; left: 461px; top: 219px; position: absolute" Text="Password"></asp:Label>
    <asp:Label ID="ConfirmLabel" runat="server" 
        style="z-index: 1; left: 410px; top: 258px; position: absolute" 
        Text="Confirm Password"></asp:Label>
    </form>
</body>
</html>
