<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmMenu.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmMenu" %>

<%@ Register Src="ManageMenu_UC.ascx" TagName="ManageMenu_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Menu
    </h2>
    <controls:ManageMenu_UC ID="ucManageMenu" runat="server" />
</asp:Content>
