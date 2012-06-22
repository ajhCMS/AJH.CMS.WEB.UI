<%@ Page Language="C#" MasterPageFile="~/TemplateMasterPage1.Master" AutoEventWireup="false" Inherits="AJH.CMS.WEB.UI.CMSPageBase" %>

<%--#Region RegisterControls--%>

<%@ Register Src="~/GUI/Menu/SitePathXSL_UC.ascx" TagName="MenuSitePath" TagPrefix="controls" %> 
<%--#Endregion RegisterControls--%>
<asp:Content ID="plcContent" ContentPlaceHolderID="plcHolder" runat="server">

<controls:MenuSitePath ContainerValue="-1" ModuleID="3" XSLTemplateID="-1" runat="server" /> 
</asp:Content>  