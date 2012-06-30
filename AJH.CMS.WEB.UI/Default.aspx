<%@ Page Language="C#" MasterPageFile="~/TemplateMasterPage1.Master" AutoEventWireup="false" Inherits="AJH.CMS.WEB.UI.CMSPageBase" %>

<%--#Region RegisterControls--%>
<%@ Register Src="~/GUI/ECommerce/Product/ProductXSL_UC.ascx" TagName="ProductXSL" TagPrefix="controls" %> 
<%--#Endregion RegisterControls--%>
<asp:Content ID="plcContent" ContentPlaceHolderID="plcHolder" runat="server">

<div class="page_right_content">

<controls:ProductXSL ContainerValue="13" ModuleID="9" XSLTemplateID="9" runat="server" /> 
</div>
</asp:Content>         