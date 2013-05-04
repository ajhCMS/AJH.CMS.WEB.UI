<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="LoginStatus_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.GUI.ECommerce.Customer.LoginStatus_UC" %>

<asp:UpdatePanel ID="upnlLoginStatus" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div id="UserLogged" runat="server" visible="true" class="welcome-msg">
          <div class="username"><asp:Label ID="lblUserName" runat="server" Text="Welcome, "></asp:Label></div>
          <div class="username"><asp:LinkButton ID="lnkLogout" runat="server">Logout</asp:LinkButton></div>
      </div>
      
      <div id="LoginUser" runat="server" visible="false">
          <div class="username"><asp:LinkButton ID="lnkLogin" runat="server">Login</asp:LinkButton></div>
      </div>
    </ContentTemplate>
</asp:UpdatePanel>
