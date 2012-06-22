<%@ Page Title="Supplier" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master"
    AutoEventWireup="false" CodeBehind="FrmSupplier.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmSupplier" %>

<%@ Register Src="~/Admin/ECommerce/Supplier/ManageSupplier_UC.ascx" TagName="ManageSupplier_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Supplier
    </h2>
    <controls:ManageSupplier_UC ID="ucSupplier" runat="server" />
</asp:Content>
