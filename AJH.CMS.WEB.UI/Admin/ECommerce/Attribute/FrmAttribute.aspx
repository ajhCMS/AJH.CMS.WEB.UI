<%@ Page Title="Attribute" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmAttribute.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmAttribute" %>

<%@ Register Src="~/Admin/ECommerce/Attribute/ManageAttribute_UC.ascx" TagName="ManageAttribute_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Attribute
    </h2>
    <controls:ManageAttribute_UC ID="ucManageAttribute" runat="server" />
</asp:Content>
