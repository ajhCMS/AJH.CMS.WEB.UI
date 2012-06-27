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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smanager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference Path="~/Scripts/CMSPageSettings.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-1.7.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/jquery.mousewheel.js" />
                <asp:ScriptReference Path="~/Scripts/jScrollPane.js" />
                <asp:ScriptReference Path="~/Scripts/Global.js" />
                <asp:ScriptReference Path="~/Scripts/CMSAdmin.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-ui-personalized-1.5.2.packed.js" />
                <asp:ScriptReference Path="~/Scripts/sprinkle.js" />
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <%--<div id="tabvanilla" class="widget">
        <ul class="tabnav">
            <li id="liProduct" runat="server"><a href="#<%=dvProduct.ClientID %>">Product</a></li>
        </ul>
    </div>
    --%>
    <asp:UpdatePanel ID="upnl" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
              
            <controls:SWFUpload_UC ID="ucSWFUpload" ErrorText="*"
                ErrorMessage="Please wait while the upload finish" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                ProgressTitle="Files Upload" TotalFilesQueueLimit="1" TotalFilesUploadLimit="1"
                IsImage="true" UploadFileSizeLimit="5 MB" FileTypeDescription="Images" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
                ButtonText="Upload" />
                      </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
