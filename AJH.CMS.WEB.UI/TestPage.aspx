<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="AJH.CMS.WEB.UI.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/GUI/ECommerce/Product/ProductSitePath.ascx" TagName="ucSitePath"
    TagPrefix="controls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <controls:ucSitePath ID="ucSitePath" runat="server" />
    </form>
</body>
</html>
