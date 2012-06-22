<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SWFUpload_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Controls.SWFUpload.SWFUpload_UC" %>
<div class="flash-upload">
    <div class="flash-uploadprogress" id="fsUploadProgress" runat="server">
        <span class="legend">
            <%=this.ProgressTitle%></span>
    </div>
    <div class="flash-uploadstatus" id="divStatus" runat="server">
        0 Files Uploaded</div>
    <div class="flash-uploadbutton">
        <span id="spanButtonPlaceHolder" runat="server"></span>
        <input id="btnCancel" runat="server" type="button" value="Cancel All Uploads" disabled="disabled"
            style="margin-left: 2px; font-size: 8pt; height: 29px;" />
    </div>
    <div id="dvEditMode" class="flash-EditMode" runat="server" visible="false">
        <asp:Image ID="imgFile" runat="server" Visible="false" />
        <asp:LinkButton ID="lbtnRemove" runat="server" Text="Remove"></asp:LinkButton>
    </div>
    <asp:CustomValidator ID="cvFlashUpload" runat="server" ClientValidationFunction="FlashUploadValidator"></asp:CustomValidator>
    <asp:HiddenField ID="hdnFilesName" runat="server" />
</div>
