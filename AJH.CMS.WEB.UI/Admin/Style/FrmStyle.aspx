<%@ Page Title="Style" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmStyle.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmStyle" %>

<%@ Register Src="ManageStyle_UC.ascx" TagName="ManageStyle_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Style
    </h2>
    <controls:ManageStyle_UC ID="ucManageStyle" runat="server" />
</asp:Content>
