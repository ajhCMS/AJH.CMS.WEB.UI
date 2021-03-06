﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageMenu_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageMenu_UC" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlSearchMenu" runat="server" UpdateMode="Conditional">
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
                        Category="ParentMenu" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                        ServicePath="~/Admin/Services/Category/CategoryService.asmx" ServiceMethod="GetDropDownCategories" />
                    <asp:ImageButton ID="ibtnSearchCategory" runat="server" ImageUrl="~/App_Themes/Image/ddl_enter.png"
                        ToolTip="Search" CssClass="btn-search" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlMenu" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server" Visible="false">
            <div class="grid-top">
                <div class="grid-title">
                    <asp:Label ID="lblGrdTitleMenu" runat="server" Text="Menus"></asp:Label>
                </div>
                <div class="grid-actions">
                    <asp:ImageButton ID="ibtnUnPublish" runat="server" ImageUrl="~/App_Themes/image/ibtnnotpublish.png"
                        ToolTip="UnPublish" NotificationOperationDone="true"></asp:ImageButton>
                    <asp:ImageButton ID="ibtnPublish" runat="server" ImageUrl="~/App_Themes/image/ibtnpublish.png"
                        ToolTip="Publish" NotificationOperationDone="true"></asp:ImageButton>
                    <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" NotificationOperationDone="true"
                        ImageUrl="~/App_Themes/image/delete.png"></asp:ImageButton>
                    <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip="Add" CausesValidation="False"
                        ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
                    <asp:ImageButton ID="ibtnGenerateXmlFiles" runat="server" ToolTip="Generate Menu"
                        CausesValidation="False" NotificationOperationDone="true" ImageUrl="~/App_Themes/image/gen-menu.png"></asp:ImageButton>
                </div>
            </div>
            <div class="grid-items">
                <asp:TreeView ID="trvMenu" ShowCheckBoxes="All" runat="server" AutoGenerateDataBindings="false"
                    PopulateNodesFromClient="true" ShowLines="true">
                </asp:TreeView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlMenuItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlMenuItem" runat="server" Visible="false">
            <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                ValidationGroup="AddEditMenu" />
            <table class="Item-table">
                <colgroup width="150px">
                </colgroup>
                <colgroup>
                </colgroup>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPageTitle" runat="server" Text="Page Title" AssociatedControlID="txtPageTitle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageTitle" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPageTitle" runat="server" ControlToValidate="txtPageTitle"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="Page Title"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblParentMenu" runat="server" Text="Parent Menu" AssociatedControlID="ddlParentMenu"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlParentMenu" runat="server">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddParentMenu" runat="server" TargetControlID="ddlParentMenu"
                            Category="ParentMenu" PromptValue="0" PromptText="[Select]" LoadingText="[Loading...]"
                            ServicePath="~/Admin/Services/Menu/MenuService.asmx" ServiceMethod="GetDropDownMenuItems" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMenuType" runat="server" Text="Type" AssociatedControlID="ddlMenuType"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMenuType" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
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
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="Order Number"></asp:RequiredFieldValidator>
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
                        <controls:SWFUpload_UC ID="ucSWFUpload" ValidationGroup="AddEditMenu" ErrorText="*"
                            ErrorMessage="Please wait while the upload finish" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                            ProgressTitle="Files Upload" TotalFilesQueueLimit="1" TotalFilesUploadLimit="1"
                            IsImage="true" UploadFileSizeLimit="5 MB" FileTypeDescription="Images" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
                            ButtonText="Upload" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGalleryCategory" runat="server" Text="Gallery" AssociatedControlID="ddlGalleryCategory"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGalleryCategory" runat="server">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddGalleryCategory" runat="server" TargetControlID="ddlGalleryCategory"
                            Category="ParentGallery" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                            ServicePath="~/Admin/Services/Category/CategoryService.asmx" ServiceMethod="GetDropDownCategories" />
                    </td>
                </tr>
                <tr id="trPage" runat="server" visible="false">
                    <td>
                        <asp:Label ID="lblPage" runat="server" Text="Page URL" AssociatedControlID="ddlPage"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPage" runat="server">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddPage" runat="server" TargetControlID="ddlPage" Category="Page"
                            LoadingText="[Loading...]" ServicePath="~/Admin/Services/Page/PageService.asmx"
                            PromptValue="-1" PromptText="[Select]" ServiceMethod="GetDropDownPages" />
                        <asp:RequiredFieldValidator ID="rfvPage" runat="server" ControlToValidate="ddlPage"
                            ValidationGroup="AddEditMenu" InitialValue="-1" Text="*" Display="Dynamic" ErrorMessage="Page"></asp:RequiredFieldValidator>
                        <asp:ImageButton ID="ibtnPageURL" runat="server" ImageUrl="~/App_Themes/Image/ddl_enter.png"
                            ToolTip="Get Page URL" CssClass="btn-search" />
                        <asp:TextBox Width="250" TextMode="SingleLine" ID="txtPageURL" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPageURL" runat="server" ControlToValidate="txtPageURL"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="Page"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trURL" visible="false">
                    <td>
                        <asp:Label ID="lblURL" runat="server" Text="URL" AssociatedControlID="txtURL"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="txtURL" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtURL"
                            ValidationGroup="AddEditMenu" Text="*" Display="Dynamic" ErrorMessage="URL"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trDetails" visible="true">
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details" AssociatedControlID="txtDetails"></asp:Label>
                    </td>
                    <td>
                        <controls:Editor_UC ID="txtDetails" runat="server" Width="100%" Height="500px" EditModes="All"
                            ContentFilters="RemoveScripts" IsRequired="true" ErrorMessage="Details" ErrorText="*"
                            ValidationGroup="AddEditMenu">
                        </controls:Editor_UC>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSaveOtherLanguage" runat="server" Width="160px"
                    ValidationGroup="AddEditMenu" Text="Save Other Language" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditMenu"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdateOtherLanguage" runat="server" Width="60px"
                    ValidationGroup="AddEditMenu" Text="Update" NotificationOperationDone="true"
                    Visible="false" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditMenu"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryMenu" runat="server" ValidationGroup="AddEditMenu"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
