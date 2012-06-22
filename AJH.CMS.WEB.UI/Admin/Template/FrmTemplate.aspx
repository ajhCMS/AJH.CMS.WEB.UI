<%@ Page Title="Template" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmTemplate.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmTemplate" %>

<%@ Register Src="ManageTemplate_UC.ascx" TagName="ManageTemplate_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Template
    </h2>
    <controls:ManageTemplate_UC ID="ucManageTemplate" runat="server" />
</asp:Content>
