<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ProductDetailsXSL_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.ProductDetailsXSL_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<asp:Label ID="lblCombination" runat="server" Text="Combination"></asp:Label>
<asp:DropDownList ID="ddlCombinations" runat="server" AutoPostBack="true" EnableViewState="true">
</asp:DropDownList>
<asp:Xml ID="xmlGroup" runat="server" EnableViewState="false"></asp:Xml>
<asp:Xml ID="xmlProduct" runat="server" EnableViewState="false" Visible="false"></asp:Xml>