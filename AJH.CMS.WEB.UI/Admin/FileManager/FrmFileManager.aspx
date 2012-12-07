<%@ Page Title="File Manager" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmFileManager.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmFileManager" %>

<%@ Register Src="FileManager_UC.ascx" TagName="FileManager_UC" TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        File Manager
    </h2>
    <controls:FileManager_UC ID="ucFileManager" runat="server" />
</asp:Content>
