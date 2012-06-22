<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmRole.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmRole" %>

<%@ Register Src="ManageRole_UC.ascx" TagName="ManageRole_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Role
    </h2>
    <controls:ManageRole_UC ID="ucManageRole" runat="server" />
</asp:Content>
