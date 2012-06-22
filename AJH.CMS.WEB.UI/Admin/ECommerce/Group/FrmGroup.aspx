<%@ Page Title="Group" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmGroup.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmGroup" %>

<%@ Register Src="~/Admin/ECommerce/Group/ManageGroup_UC.ascx" TagName="ManageGroup_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Group
    </h2>
    <controls:ManageGroup_UC ID="ucManageGroup" runat="server" />
</asp:Content>
