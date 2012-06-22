<%@ Page Title="Product" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmProduct.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmProduct" %>

<%@ Register Src="~/Admin/ECommerce/Product/ManageProducts_UC.ascx" TagName="ManageProduct_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Product
    </h2>
    <controls:ManageProduct_UC ID="ucManageProduct" runat="server" />
</asp:Content>
