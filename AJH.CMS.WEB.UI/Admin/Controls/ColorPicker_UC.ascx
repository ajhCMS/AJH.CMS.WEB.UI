<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ColorPicker_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ColorPicker_UC" %>
<script language="javascript" type="text/javascript">
    function SetBackgroundColor(sender) {
        document.getElementById('<%=txtColor.ClientID%>').style.backgroundColor = "#" + sender.get_selectedColor();
    }
</script>
<div>
    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
    <ajax:ColorPickerExtender ID="cpeColor" runat="server" TargetControlID="txtColor"
        OnClientColorSelectionChanged="SetBackgroundColor">
    </ajax:ColorPickerExtender>
    <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="txtColor"
        Enabled="false" Text="*" Display="Dynamic" ErrorMessage="Color"></asp:RequiredFieldValidator>
</div>
