<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="AJH.CMS.WEB.UI.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/GUI/ECommerce/Product/ProductSitePath.ascx" TagName="ucSitePath"
    TagPrefix="controls" %>
<%@ Register Src="~/GUI/Article/ArticleXSL_UC.ascx" TagName="ucCatalogXSL" TagPrefix="controls" %>
<%@ Register Src="~/GUI/Contact/Career_UC.ascx" TagName="ucCareer" TagPrefix="controls" %>
<%@ Register Src="~/GUI/ECommerce/Catalog/CatalogXSL_UC.ascx" TagName="ucCatalogs"
    TagPrefix="controls" %>
<%@ Register Src="~/GUI/ECommerce/Catalog/CatalogSitePath.ascx" TagName="ucCatalogSitePath"
    TagPrefix="controls" %>
<%@ Register Src="~/GUI/ECommerce/Product/ProductDetailsXSL_UC.ascx" TagName="ucProductDetails"
    TagPrefix="controls" %>
<%@ Register Src="~/GUI/Menu/SitePathXSL_UC.ascx" TagName="ucSitePathhhh" TagPrefix="controls" %>
<%@ Register Src="~/GUI/Menu/MenuItemTemplateXSL_UC.ascx" TagName="ucSitePathhssssshh"
    TagPrefix="controls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sManager1" runat="server">
    </asp:ScriptManager>
    <controls:ucSitePathhssssshh ID="ucpp" runat="server" />
    </form>
</body>
</html>
