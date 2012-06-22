<%@ Page Title="Page" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmPage.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmPage" %>

<%@ Register Src="ManagePage_UC.ascx" TagName="ManagePage_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Page
    </h2>
    <controls:ManagePage_UC ID="ucManagePage" runat="server" />
</asp:Content>
