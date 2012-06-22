<%@ Page Title="HTML" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmHtmlBlock.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmHtmlBlock" %>

<%@ Register Src="ManageHtmlBlock_UC.ascx" TagName="ManageHtmlBlock_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        HTML
    </h2>
    <controls:ManageHtmlBlock_UC ID="ucManageHtmlBlock" runat="server" />
</asp:Content>
