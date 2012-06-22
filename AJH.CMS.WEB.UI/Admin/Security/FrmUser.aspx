<%@ Page Title="Users" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmUser.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmUser" %>

<%@ Register Src="ManageUser_UC.ascx" TagName="ManageUser_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        User
    </h2>
    <controls:ManageUser_UC ID="ucManageUser" runat="server" />
</asp:Content>
