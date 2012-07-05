<%@ Page Language="C#" MasterPageFile="~/TemplateMasterPage2.Master" AutoEventWireup="false" Inherits="AJH.CMS.WEB.UI.CMSPageBase" %>

<%--#Region RegisterControls--%>
<%@ Register Src="~/GUI/ECommerce/Product/ProductDetailsXSL_UC.ascx" TagName="ProductDetails" TagPrefix="controls" %> 
<%--#Endregion RegisterControls--%>
<asp:Content ID="plcContent" ContentPlaceHolderID="plcHolder" runat="server">
<controls:ProductDetails ContainerValue="-1" ModuleID="9" XSLTemplateID="10" runat="server" />
</asp:Content>    