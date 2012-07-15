<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManagePreference_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManagePreference_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<script language="javascript" type="text/javascript">
    function CheckAll() {
        var cbCheckAll = document.getElementById('<%=cbCheckAll.ClientID %>');
        if (cbCheckAll != null) {
            var allCheckBoxes = document.getElementsByTagName('input');
            if (allCheckBoxes != null) {
                for (var i = 0; i < allCheckBoxes.length - 1; i++) {
                    if (allCheckBoxes[i].type == 'checkbox')
                        allCheckBoxes[i].checked = cbCheckAll.checked;
                }
            }
        }
    }
</script>
<asp:UpdatePanel ID="upnlPreferenceItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:CheckBox ID="cbCheckAll" runat="server" onclick="CheckAll();" Text="Check All" />
        <asp:Panel ID="pnlPreferenceItem" runat="server">
            <div id="dvProblems" runat="server" class="dv-problem">
            </div>
            <asp:CheckBoxList ID="cblstPreferneces" runat="server">
                <asp:ListItem Text="Display Text In Stock" Value="trDisplayTextInStock"></asp:ListItem>
                <asp:ListItem Text="Display Text When Back Order" Value="trDisplayTextWhenBackOrder"></asp:ListItem>
                <asp:ListItem Text="Short Description" Value="trShortDescription"></asp:ListItem>
                <asp:ListItem Text="Tags" Value="trTags"></asp:ListItem>
                <asp:ListItem Text="Supplier" Value="trSupplier"></asp:ListItem>
                <asp:ListItem Text="EAN 13" Value="trEAN13"></asp:ListItem>
                <asp:ListItem Text="UPC" Value="trUPC"></asp:ListItem>
                <asp:ListItem Text="Location" Value="trLocation"></asp:ListItem>
                <asp:ListItem Text="Downloadable" Value="trDownloadable"></asp:ListItem>
                <asp:ListItem Text="Display On Sale Icon" Value="trDisplayOnSaleIcon"></asp:ListItem>
                <asp:ListItem Text="Initial Stock" Value="trInitialStock"></asp:ListItem>
                <asp:ListItem Text="Minimum Quantity" Value="trMinimumQuantity"></asp:ListItem>
                <asp:ListItem Text="Additional Shopping Cost" Value="trAdditionalShoppingCost"></asp:ListItem>
                <asp:ListItem Text="Manufacturar" Value="trManufacturar"></asp:ListItem>
                <asp:ListItem Text="Enabled" Value="trEnabled"></asp:ListItem>
                <asp:ListItem Text="Tax" Value="trTax"></asp:ListItem>
            </asp:CheckBoxList>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditPreference"
                    Text="Save" NotificationOperationDone="true" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
