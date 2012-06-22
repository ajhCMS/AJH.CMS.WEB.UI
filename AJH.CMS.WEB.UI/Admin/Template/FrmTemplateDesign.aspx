<%@ Page Title="TemplateDesign" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master"
    AutoEventWireup="false" CodeBehind="FrmTemplateDesign.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmTemplateDesign" %>

<%@ Register Src="ManageTemplateDesign_UC.ascx" TagName="ManageTemplateDesign_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Template Design
    </h2>
    <controls:ManageTemplateDesign_UC ID="ucManageTemplateDesign" runat="server" />
</asp:Content>
