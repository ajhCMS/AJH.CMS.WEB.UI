<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="AJH.CMS.WEB.UI.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/GUI/ECommerce/Catalog/CatalogXSL_UC.ascx" TagName="ucCatalogXsl"
    TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/GUI/ECommerce/Catalog/CatalogDetailsXSL_UC.ascx" TagName="ucCatalogDeatils"
    TagPrefix="controls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%-- <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/fileprogress.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/handlers.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/swfupload.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/swfupload.queue.js")%>' type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smanager1" runat="server">
    </asp:ScriptManager>
    <controls:ucCatalogDeatils runat="server" ContainerValue="-1" XSLTemplateID="9" />
    </form>
</body>
</html>
