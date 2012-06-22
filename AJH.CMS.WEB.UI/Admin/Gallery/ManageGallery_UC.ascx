<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageGallery_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageGallery_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<script language="javascript" type="text/javascript">
    function UploadCompleteFlashUpload() {
        $('#' + '<%=btnAdd.ClientID %>').trigger('click');
    }
</script>
<asp:UpdatePanel ID="upnlSearchGallery" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearchCategory" runat="server" Text="Category" AssociatedControlID="ddlSearchCategory"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchCategory" runat="server" Width="254px">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddSearchCategory" runat="server" TargetControlID="ddlSearchCategory"
                        Category="ParentGallery" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                        ServicePath="~/Admin/Services/Category/CategoryService.asmx" ServiceMethod="GetDropDownCategories" />
                    <asp:ImageButton ID="ibtnSearchCategory" runat="server" ImageUrl="~/App_Themes/Image/ddl_enter.png"
                        ToolTip="Search" CssClass="btn-search" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGallery" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server" Visible="false">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnUnPublish" runat="server" ImageUrl="~/App_Themes/image/ibtnnotpublish.png"
                    ToolTip="UnPublish" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnPublish" runat="server" ImageUrl="~/App_Themes/image/ibtnpublish.png"
                    ToolTip="Publish" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                    ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/image/add.png"
                    ToolTip="Add" CausesValidation="False"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleGallery" runat="server" Text="Galleries"></asp:Label>
            </div>
            <div>
                <asp:DataList ID="dlsGallery" runat="server" RepeatLayout="Table" RepeatColumns="4"
                    CssClass="grd" RepeatDirection="Vertical" Width="100%">
                    <ItemTemplate>
                        <div class="glry-item">
                            <div class="gallery-img">
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Gallery)Container.DataItem).ID%>' />
                                <asp:Image ID="imgGallery" ToolTip='<%# ((AJH.CMS.Core.Entities.Gallery)Container.DataItem).Name%>'
                                    runat="server" ImageUrl='<%# GetGalleryFile((AJH.CMS.Core.Entities.Gallery)Container.DataItem)%>' />
                            </div>
                            <div class="gallery-name">
                                <asp:LinkButton ID="lblName" runat="server" Text='<%#((AJH.CMS.Core.Entities.Gallery)Container.DataItem).ID+": "+ ((AJH.CMS.Core.Entities.Gallery)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Gallery)Container.DataItem).ID%>'
                                    CommandName="EditGallery"></asp:LinkButton>
                            </div>
                            <div>
                                <asp:Image ID="imgPublished" runat="server" Height="25" Width="25" ImageUrl='<%#AJH.CMS.WEB.UI.Utilities.CMSWebHelper.GetPublishedImage(Convert.ToBoolean(DataBinder.Eval(Container,"DataItem.IsPublished")))%>' />
                            </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle CssClass="gallery-item" />
                </asp:DataList>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGalleryItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlGalleryItem" runat="server" Visible="false" DefaultButton="btnUpdate">
            <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                ValidationGroup="EditGallery" />
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="EditGallery" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSummary" runat="server" Text="Summary" AssociatedControlID="txtSummary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Date" AssociatedControlID="ucAjaxDate"></asp:Label>
                    </td>
                    <td class="ajaxdate-cntrl">
                        <controls:AjaxDate_UC ID="ucAjaxDate" runat="server" IsRequired="true" Format="dd MMM yyyy" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOrderNumber" runat="server" Text="Order Number" AssociatedControlID="txtOrderNumber"></asp:Label>
                    </td>
                    <td class="order-num">
                        <asp:TextBox ID="txtOrderNumber" runat="server" MaxLength="3"></asp:TextBox>
                        <ajax:NumericUpDownExtender ID="numOrderNumber" runat="server" Maximum="999" Minimum="0"
                            TargetControlID="txtOrderNumber" Width="80">
                        </ajax:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvOrderNumber" runat="server" ControlToValidate="txtOrderNumber"
                            ValidationGroup="EditGallery" Text="*" Display="Dynamic" ErrorMessage="Order Number"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trIsPublished" runat="server" visible="false">
                    <td>
                        <asp:Label ID="lblIsPublished" runat="server" Text="Published" AssociatedControlID="cbIsPublished"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsPublished" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details" AssociatedControlID="txtDetails"></asp:Label>
                    </td>
                    <td>
                        <CE:Editor ID="txtDetails" BreakElement="Br" runat="server" Width="100%" Height="500px"
                            enablebrowsercontextgallery="False" AutoConfigure="Simple">
                            <FrameStyle Height="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="#DDDDDD"
                                Width="100%" CssClass="CuteEditorFrame" BackColor="White"></FrameStyle>
                        </CE:Editor>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="EditGallery"
                    Text="Update" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnSaveOtherLanguage" runat="server" Width="160px"
                    ValidationGroup="EditGallery" Text="Save Other Language" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdateOtherLanguage" runat="server" Width="60px"
                    ValidationGroup="EditGallery" Text="Update" NotificationOperationDone="true"
                    Visible="false" />
            </div>
            <asp:ValidationSummary ID="valsummaryGallery" runat="server" ValidationGroup="EditGallery"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGalleryAdd" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlGalleryAdd" runat="server" Visible="false" DefaultButton="btnAdd">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblGalleryItemType" runat="server" Text="Type" AssociatedControlID="ddlGalleryItemType"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGalleryItemType" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddGalleryItemType" runat="server" TargetControlID="ddlGalleryItemType"
                            Category="GalleryItemType" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Gallery/GalleryService.asmx"
                            ServiceMethod="GetDropDownGalleryItemType" />
                    </td>
                </tr>
                <tr id="trMultiUpload" runat="server">
                    <td>
                    </td>
                    <td>
                        <controls:SWFUpload_UC ID="ucSWFUpload" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                            ProgressTitle="Files Upload" TotalFilesQueueLimit="10" TotalFilesUploadLimit="10"
                            UploadFileSizeLimit="20 MB" OnUploadComplete="UploadCompleteFlashUpload" FileTypeDescription="Images"
                            FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp" ButtonImageUrl="~/App_Themes/Image/button_upload.png"
                            ButtonTextLeftPadding="12" ButtonTextTopPadding="3" ButtonText="Click To Upload" />
                    </td>
                </tr>
                <tr runat="server" id="trAddName" visible="false">
                    <td>
                        <asp:Label ID="lblAddName" runat="server" Text="Name" AssociatedControlID="txtAddName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddName" runat="server" ControlToValidate="txtAddName"
                            ValidationGroup="AddGallery" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trAddURL" runat="server" visible="false">
                    <td>
                        <asp:Label ID="lblAddURL" runat="server" Text="URL" AssociatedControlID="txtAddURL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddURL" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddURL" runat="server" ControlToValidate="txtAddURL"
                            ValidationGroup="AddGallery" Text="*" Display="Dynamic" ErrorMessage="URL"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnAddExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnAddReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnAdd" runat="server" Width="60px" ValidationGroup="AddGallery"
                    Text="Save" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryAddGallery" runat="server" ValidationGroup="AddGallery"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
