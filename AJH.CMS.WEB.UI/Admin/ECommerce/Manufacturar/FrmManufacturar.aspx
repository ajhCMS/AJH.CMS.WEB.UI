<%@ Page Title="Manufacturar" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master"
    AutoEventWireup="false" CodeBehind="FrmManufacturar.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmManufacturar" %>

<%@ Register Src="~/Admin/ECommerce/Manufacturar/ManageManufacturar_UC.ascx" TagName="ManageManufacturar_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Manufacturar
    </h2>
    <controls:ManageManufacturar_UC ID="ucManufacturar" runat="server" />
</asp:Content>
