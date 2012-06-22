<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="AJH.CMS.WEB.UI.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/GUI/ECommerce/Catalog/CatalogXSL_UC.ascx" TagName="ucCatalogXsl"
    TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/fileprogress.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/handlers.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/swfupload.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Controls/SWFUpload/script/swfupload.queue.js")%>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smanager1" runat="server">
    </asp:ScriptManager>
    <div>
        <%--  <controls:ucCatalogXsl ID="ucCatalog" runat="server" ContainerValue="1" XSLTemplateID="233" />--%>
        <controls:SWFUpload_UC ID="ucSWFUpload" ValidationGroup="AddEditCatalog" ErrorText="*"
            ErrorMessage="Please wait while the upload finish" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
            ProgressTitle="Files Upload" TotalFilesQueueLimit="1" TotalFilesUploadLimit="1"
            IsImage="true" UploadFileSizeLimit="5 MB" FileTypeDescription="Images" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
            ButtonText="Upload" />
    </div>
    </form>
</body>
</html>
