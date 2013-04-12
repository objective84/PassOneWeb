<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="EditValue.aspx.cs" Inherits="PassOne.EditValue" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="NewValueLabel" runat="server" Text="Enter new value: "></asp:Label>
    <br/>
    <asp:TextBox ID="NewValueTextBox" runat="server"></asp:TextBox>
    <br/>
    <asp:Button ID="UpdateButton" runat="server" Text="Update" onclick="UpdateButton_Click" />
</asp:Content>