<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageTax_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageTax_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlTax" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server" Visible="true">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                    ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/image/add.png"
                    ToolTip="Add" CausesValidation="False"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleTax" runat="server" Text="Taxs"></asp:Label>
            </div>
            <div class="grid-items">
                <asp:GridView ID="gvTax" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Tax)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Tax)Container.DataItem).Rate%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Tax)Container.DataItem).ID%>' CommandName="EditTax"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="90%" />
                            <HeaderStyle Width="90%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlTaxItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlTaxItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblRate" runat="server" Text="Rate" AssociatedControlID="txtRate"></asp:Label>
                    </td>
                    <td>
                        <ajax:NumericUpDownExtender ID="nRate" runat="server" TargetControlID="txtRate" Width="100"
                            Minimum="1" Maximum="100">
                        </ajax:NumericUpDownExtender>
                        <asp:TextBox ID="txtRate" runat="server" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate"
                            ValidationGroup="AddEditTax" Text="*" Display="Dynamic" ErrorMessage="Rate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIsEnabled" runat="server" Text="Enabled" AssociatedControlID="cbIsEnabled"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsEnabled" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditTax"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditTax"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryTax" runat="server" ValidationGroup="AddEditTax"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
