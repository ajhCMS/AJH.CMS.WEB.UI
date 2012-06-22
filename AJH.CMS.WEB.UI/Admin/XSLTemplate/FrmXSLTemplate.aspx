<%@ Page Title="XSLTemplate" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmXSLTemplate.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmXSLTemplate" %>

<%@ Register Src="ManageXSLTemplate_UC.ascx" TagName="ManageXSLTemplate_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        XSLTemplate
    </h2>
    <controls:ManageXSLTemplate_UC ID="ucManageXSLTemplate" runat="server" />
</asp:Content>
