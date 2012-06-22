<%@ Page Title="Catalog" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmCatalog.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmCatalog" %>

<%@ Register Src="~/Admin/ECommerce/Catalog/ManageCatalog_UC.ascx" TagName="ManageCatalog_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Catalog
    </h2>
    <controls:ManageCatalog_UC ID="ucManageCatalog" runat="server" />
</asp:Content>
