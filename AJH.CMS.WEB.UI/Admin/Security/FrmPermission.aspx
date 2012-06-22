<%@ Page Title="Permissions" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmPermission.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmPermission" %>

<%@ Register Src="ManagePermission_UC.ascx" TagName="ManagePermission_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Permission
    </h2>
    <controls:ManagePermission_UC ID="ucManagePermission" runat="server" />
</asp:Content>
