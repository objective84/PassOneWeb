<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="CredentialsList.aspx.cs" Inherits="PassOne.CredentialsList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    

    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=PassOneContext" DefaultContainerName="PassOneContext" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Credentials" EntityTypeFilter="Credential">
    </asp:EntityDataSource>

    <asp:ListBox ID="CredentialsListBox" runat="server" DataSourceID="EntityDataSource1" DataTextField="Title" DataValueField="Id" Height="181px" Width="109px" OnSelectedIndexChanged="CredentialsListBox_SelectedIndexChanged"></asp:ListBox>

    <br/>
    <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
<%--    <asp:Button ID="Button2" runat="server" Text="Button" />--%>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="EntityDataSource1" Height="50px" Width="125px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <Fields>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
    </asp:DetailsView>
    </asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent1">
    <%--<asp:Label ID="WebsiteLabel" runat="server" Text="Website: " style="vertical-align:top"></asp:Label >
    <asp:LinkButton ID="WebsiteValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>

    <asp:Label ID="UrlLabel" runat="server" Text="URL: " style="vertical-align:top; margin: 6px 8px 8px 8px" ></asp:Label>
    <asp:LinkButton ID="UrlValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="UsernameLabel" runat="server" Text="URL: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="UsernameValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <asp:Label ID="EmailLabel" runat="server" Text="URL: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="EmailValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <br/>

    <asp:Label ID="PasswordLabel" runat="server" Text="URL: " style="vertical-align:top"></asp:Label>
    <asp:LinkButton ID="PasswordValue" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>
    
    <br/>
    <asp:LinkButton ID="ShowPasswordButton" runat="server" style="vertical-align:top" onclick="Edit_Click"></asp:LinkButton>--%>
    </asp:Content>
