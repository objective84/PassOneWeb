<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditValue.aspx.cs" Inherits="PassOne.EditValue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="NewValueLabel" runat="server" 
            style="z-index: 1; left: 435px; top: 184px; position: absolute" 
            Text="Enter new value:"></asp:Label>
        <asp:TextBox ID="NewValueTextBox" runat="server" 
            style="z-index: 1; left: 421px; top: 209px; position: absolute" OnTextChanged="NewValueTextBox_TextChanged"></asp:TextBox>
    
    </div>
    <asp:Button ID="UpdateButton" runat="server" onclick="Button1_Click" 
        style="z-index: 1; left: 456px; top: 234px; position: absolute" Text="Update" />
    </form>
</body>
</html>
