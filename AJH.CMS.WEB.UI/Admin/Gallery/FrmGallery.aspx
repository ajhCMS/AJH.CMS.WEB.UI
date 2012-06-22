<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmGallery.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmGallery" %>

<%@ Register Src="ManageGallery_UC.ascx" TagName="ManageGallery_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Gallery
    </h2>
    <controls:ManageGallery_UC ID="ucManageGallery" runat="server" />
</asp:Content>
