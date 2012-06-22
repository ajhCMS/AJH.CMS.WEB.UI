<%@ Page Title="Landing" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master" AutoEventWireup="false"
    CodeBehind="FrmLanding.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmLanding" %>

<%@ Register Src="~/Admin/Controls/AdminXmlXsl_UC.ascx" TagName="AdminXmlXsl_UC"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <controls:AdminXmlXsl_UC ID="ucAdminXmlXsl" DocumentSource="~/Admin/AdminFiles/XmlFile/AdminMenuXML.xml"
        TransformSource="~/Admin/AdminFiles/XslFile/AdminDashboardXSL.xslt" runat="server" />
</asp:Content>
