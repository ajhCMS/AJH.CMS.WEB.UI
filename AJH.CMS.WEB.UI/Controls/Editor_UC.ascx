<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Editor_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Controls.Editor_UC" %>
<telerik:RadEditor ID="txtContent" runat="server" NewLineBr="true" DocumentManager-MaxUploadFileSize="8388608"
    FlashManager-MaxUploadFileSize="8388608" ImageManager-MaxUploadFileSize="8388608"
    MediaManager-MaxUploadFileSize="8388608" SilverlightManager-MaxUploadFileSize="8388608"
    TemplateManager-MaxUploadFileSize="8388608" AutoResizeHeight="true" EnableEmbeddedBaseStylesheet="true">
</telerik:RadEditor>
<asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtContent"
    Enabled="false" Display="Dynamic"></asp:RequiredFieldValidator>