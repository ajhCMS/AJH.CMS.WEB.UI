<%@ Page Title="Category" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmCategory.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmCategory" %>

<%@ Register Src="ManageCategory_UC.ascx" TagName="ManageCategory_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Category
    </h2>
    <controls:ManageCategory_UC ID="ucManageCategory" runat="server" />
</asp:Content>
