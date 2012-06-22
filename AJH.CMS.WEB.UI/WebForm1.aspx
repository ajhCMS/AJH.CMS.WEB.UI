<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AJH.CMS.WEB.UI.WebForm1" %>

<%@ Register Src="GUI/Gallery/GalleryServiceXSL_UC.ascx" TagName="GalleryServiceXSL_UC"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scManager" EnableCdn="false" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Path="~/Scripts/jquery-1.7.1.min.js" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <uc1:GalleryServiceXSL_UC ID="GalleryServiceXSL_UC1" runat="server" ContainerValue="1" XSLTemplateID="2" />
    </div>
    </form>
</body>
</html>
