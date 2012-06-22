<%@ Page Title="Feature" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmFeature.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmFeature" %>

<%@ Register Src="~/Admin/ECommerce/Feature/ManageFeature_UC.ascx" TagName="ManageFeature_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Feature
    </h2>
    <controls:ManageFeature_UC ID="ucManageFeature" runat="server" />
</asp:Content>
