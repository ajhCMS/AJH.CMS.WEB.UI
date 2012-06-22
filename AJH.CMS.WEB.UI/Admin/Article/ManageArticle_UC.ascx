<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageArticle_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageArticle_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlSearchArticle" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearchCategory" runat="server" Text="Category" AssociatedControlID="ddlSearchCategory"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchCategory" runat="server" Width="254">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddSearchCategory" runat="server" TargetControlID="ddlSearchCategory"
                        Category="ParentArticle" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                        ServicePath="~/Admin/Services/Category/CategoryService.asmx" ServiceMethod="GetDropDownCategories" />
                    <asp:ImageButton ID="ibtnSearchCategory" runat="server" ImageUrl="~/App_Themes/Image/ddl_enter.png"
                        ToolTip="Search" CssClass="btn-search" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlArticle" runat="server" UpdateMode="Conditional">
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
                <asp:Label ID="lblGrdTitleArticle" runat="server" Text="Articles"></asp:Label>
            </div>
             <div>
                <asp:GridView ID="gvArticle" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Article)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Published">
                            <ItemTemplate>
                                <asp:Image ID="imgPublished" runat="server" Height="25" Width="25" ImageUrl='<%#AJH.CMS.WEB.UI.Utilities.CMSWebHelper.GetPublishedImage(Convert.ToBoolean(DataBinder.Eval(Container,"DataItem.IsPublished")))%>' />
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            <HeaderStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Article)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Article)Container.DataItem).ID%>'
                                    CommandName="EditArticle"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlArticleItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlArticleItem" runat="server" Visible="false">
            <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                ValidationGroup="AddEditArticle" />
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditArticle" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
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
                        <asp:Label ID="lblArticleType" runat="server" Text="Type" AssociatedControlID="ddlArticleType"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlArticleType" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddArticleType" runat="server" TargetControlID="ddlArticleType"
                            Category="ArticleType" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Article/ArticleService.asmx"
                            ServiceMethod="GetDropDownArticleType" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Date" AssociatedControlID="txtOrderNumber"></asp:Label>
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
                            ValidationGroup="AddEditArticle" Text="*" Display="Dynamic" ErrorMessage="Order Number"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblURL" runat="server" Text="URL" AssociatedControlID="txtURL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtURL"
                            ValidationGroup="AddEditArticle" Text="*" Display="Dynamic" ErrorMessage="URL"></asp:RequiredFieldValidator>
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
                        <asp:Label ID="lblUpload" runat="server" Text="Upload" AssociatedControlID="ucSWFUpload"></asp:Label>
                    </td>
                    <td>
                        <controls:SWFUpload_UC ID="ucSWFUpload" ValidationGroup="AddEditArticle" ErrorText="*"
                            ErrorMessage="Please wait while the upload finish" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                            ProgressTitle="Files Upload" TotalFilesQueueLimit="1" TotalFilesUploadLimit="1"
                            IsImage="true" UploadFileSizeLimit="5 MB" FileTypeDescription="Images" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
                            ButtonText="Upload" />
                    </td>
                </tr>
                <tr runat="server" id="trDetails" visible="true">
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details" AssociatedControlID="txtDetails"></asp:Label>
                    </td>
                    <td>
                        <CE:Editor ID="txtDetails" BreakElement="Br" runat="server" Width="100%" Height="500px"
                            EnableBrowserContextArticle="False" AutoConfigure="Simple">
                            <FrameStyle Height="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="#DDDDDD"
                                Width="100%" CssClass="CuteEditorFrame" BackColor="White"></FrameStyle>
                        </CE:Editor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditArticle" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSaveOtherLanguage" runat="server" Width="160px"
                    ValidationGroup="AddEditArticle" Text="Save Other Language" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditArticle"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdateOtherLanguage" runat="server" Width="60px"
                    ValidationGroup="AddEditArticle" Text="Update" NotificationOperationDone="true"
                    Visible="false" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditArticle"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryArticle" runat="server" ValidationGroup="AddEditArticle"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
