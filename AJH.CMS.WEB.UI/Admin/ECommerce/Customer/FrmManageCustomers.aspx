<%@ Page Title="Customers" Language="C#" AutoEventWireup="false" MasterPageFile="~/Admin/CMSAdmin.Master"
    CodeBehind="FrmManageCustomers.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmManageCustomers" %>
    
<%@ Register src="ManageCustomer_UC.ascx" tagname="ManageCustomer_UC" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Customers
    </h2>
    <uc1:ManageCustomer_UC ID="ManageCustomer_UC1" runat="server" />
</asp:Content>

