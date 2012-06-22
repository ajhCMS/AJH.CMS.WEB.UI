<%@ Page Title="Controls" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmCMSControl.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmCMSControl" %>

<%@ Register Src="ManageCMSControl_UC.ascx" TagName="ManageCMSControl_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Controls
    </h2>
    <controls:ManageCMSControl_UC ID="ucManageCMSControl" runat="server" />
</asp:Content>
