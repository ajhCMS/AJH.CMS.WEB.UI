<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AjaxDate_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Controls.AjaxDate_UC" %>

<asp:TextBox runat="server" ID="txtDate" />
<asp:ImageButton runat="Server" ID="ibtnDate" ImageUrl="~/App_Themes/image/Calendar_scheduleHS.png"
    AlternateText="Click to show calendar" /><br />
<ajax:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate" />
<asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate"></asp:RequiredFieldValidator>