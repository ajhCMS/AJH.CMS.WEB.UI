<%@ Page Title="Article" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmArticle.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmArticle" %>

<%@ Register Src="ManageArticle_UC.ascx" TagName="ManageArticle_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Article
    </h2>
    <controls:ManageArticle_UC ID="ucManageArticle" runat="server" />
</asp:Content>
