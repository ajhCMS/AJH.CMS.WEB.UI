<%@ Page Title="Preferences" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master"
    AutoEventWireup="false" CodeBehind="FrmPreference.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmPreference" %>

<%@ Register Src="~/Admin/ECommerce/Preference/ManagePreference_UC.ascx" TagName="ucPreferences"
    TagPrefix="controls" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Preferences
    </h2>
    <controls:ucPreferences ID="ucPreferences" runat="server"></controls:ucPreferences>
</asp:Content>
