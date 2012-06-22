<%@ Page Title="PageDesign" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmPageDesign.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmPageDesign" %>

<%@ Register Src="ManagePageDesign_UC.ascx" TagName="ManagePageDesign_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Page Design
    </h2>
    <controls:ManagePageDesign_UC ID="ucManagePageDesign" runat="server" />
</asp:Content>
