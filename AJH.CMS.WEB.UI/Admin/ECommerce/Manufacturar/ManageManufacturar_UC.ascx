<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageManufacturar_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageManufacturar_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlManufacturar" runat="server" UpdateMode="Conditional">
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
                <asp:Label ID="lblGrdTitleManufacturar" runat="server" Text="Manufacturars"></asp:Label>
            </div>
            <div class="grid-items">
                <asp:GridView ID="gvManufacturar" runat="server" AllowPaging="true" PageSize="10"
                    AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Manufacturar)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblDescription" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Manufacturar)Container.DataItem).Description%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Manufacturar)Container.DataItem).ID%>'
                                    CommandName="EditManufacturar"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlManufacturarItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlManufacturarItem" runat="server" Visible="false">
            <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                ValidationGroup="AddEditManufacturar" />
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="AddEditManufacturar" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblShortDescription" runat="server" Text="Short Description" AssociatedControlID="txtShortDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtShortDescription" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtShortDescription"
                            ValidationGroup="AddEditManufacturar" Text="*" Display="Dynamic" ErrorMessage="Short Description"></asp:RequiredFieldValidator>
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
                <tr>
                    <td>
                        <asp:Label ID="lblUpload" runat="server" Text="Upload" AssociatedControlID="ucSWFUpload"></asp:Label>
                    </td>
                    <td>
                        <controls:SWFUpload_UC ID="ucSWFUpload" ValidationGroup="AddEditManufacturar" ErrorText="*"
                            ErrorMessage="Please wait while the upload finish" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                            ProgressTitle="Files Upload" TotalFilesQueueLimit="1" TotalFilesUploadLimit="1"
                            IsImage="true" UploadFileSizeLimit="5 MB" FileTypeDescription="Images" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
                            ButtonText="Upload" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMetaTitle" runat="server" Text="Meta Title" AssociatedControlID="txtMetaTitle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMetaTitle" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMetaTitle" runat="server" ControlToValidate="txtMetaTitle"
                            ValidationGroup="AddEditManufacturar" Text="*" Display="Dynamic" ErrorMessage="Meta Title"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMetaDescription" runat="server" Text="Meta Description" AssociatedControlID="txtMetaDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMetaDescription" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMetaDescription" runat="server" ControlToValidate="txtMetaDescription"
                            ValidationGroup="AddEditManufacturar" Text="*" Display="Dynamic" ErrorMessage="Meta Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMetaKeywords" runat="server" Text="Meta Keywords" AssociatedControlID="txtMetaKeywords"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMetaKeywords" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMetaKeywords" runat="server" ControlToValidate="txtMetaKeywords"
                            ValidationGroup="AddEditManufacturar" Text="*" Display="Dynamic" ErrorMessage="Meta Keywords"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSaveOtherLanguage" runat="server" Width="160px"
                    ValidationGroup="AddEditManufacturar" Text="Save Other Language" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditManufacturar"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditManufacturar"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryManufacturar" runat="server" ValidationGroup="AddEditManufacturar"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
