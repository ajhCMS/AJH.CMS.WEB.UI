<%@ Page Title="Forms" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmForm.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmForm" %>

<%@ Register Src="ManageForm_UC.ascx" TagName="ManageForm_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Form
    </h2>
    <controls:ManageForm_UC ID="ucManageForm" runat="server" />
</asp:Content>
