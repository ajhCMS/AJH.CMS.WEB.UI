<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Logout_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.Logout_UC" %>
    <div class="welcome-msg">
Welcome <span class="bold">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</span>! [
<asp:LinkButton ID="lbtnLogout" runat="server" Text="Log Out"></asp:LinkButton>
] 
</div>