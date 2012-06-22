<%@ Page Title="Tax" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmTax.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmTax" %>

<%@ Register Src="~/Admin/ECommerce/Tax/ManageTax_UC.ascx" TagName="ManageTax_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Tax
    </h2>
    <controls:ManageTax_UC ID="ucManageTax" runat="server" />
</asp:Content>
