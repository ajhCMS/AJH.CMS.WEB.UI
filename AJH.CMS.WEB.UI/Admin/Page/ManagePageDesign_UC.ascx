<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManagePageDesign_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManagePageDesign_UC" %>
<asp:UpdatePanel ID="upnlPageControl" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%">
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="lblModule" runat="server" Text="Module" AssociatedControlID="ddlModule"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlModule" runat="server" Width="254" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddModule" runat="server" TargetControlID="ddlModule"
                        PromptValue="-1" PromptText="[Select]" Category="Modules" LoadingText="[Loading...]"
                        ServicePath="~/Admin/Services/Module/ModuleService.asmx" ServiceMethod="GetDropDownModules" />
                    <asp:RequiredFieldValidator ID="rfvModule" runat="server" ControlToValidate="ddlModule"
                        ValidationGroup="AddEditPageDesignControl" InitialValue="-1" Text="*" Display="Dynamic"
                        ErrorMessage="Module"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblCMSControl" runat="server" Text="CMSControl" AssociatedControlID="ddlCMSControl"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCMSControl" runat="server" Width="254" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddCMSControl" runat="server" TargetControlID="ddlCMSControl"
                        ParentControlID="ddlModule" PromptValue="-1" PromptText="[Select]" Category="CMSControls"
                        LoadingText="[Loading...]" ServicePath="~/Admin/Services/CMSControl/CMSControlService.asmx"
                        ServiceMethod="GetDropDownCMSControls" />
                    <asp:RequiredFieldValidator ID="rfvCMSControl" runat="server" ControlToValidate="ddlCMSControl"
                        ValidationGroup="AddEditPageDesignControl" InitialValue="-1" Text="*" Display="Dynamic"
                        ErrorMessage="CMSControl"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContainerValue" runat="server" Text="Container Value" AssociatedControlID="ddlContainerValue"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlContainerValue" runat="server" Width="254" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddContainerValue" runat="server" TargetControlID="ddlContainerValue"
                        ParentControlID="ddlCMSControl" PromptValue="-1" PromptText="[Select]" Category="ContainerValues"
                        LoadingText="[Loading...]" ServicePath="~/Admin/Services/CMSControl/CMSControlService.asmx"
                        ServiceMethod="GetDropDownContainerValues" />
                </td>
                <td>
                    <asp:Label ID="lblXSLTemplate" runat="server" Text="XSL Template" AssociatedControlID="ddlXSLTemplate"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlXSLTemplate" runat="server" Width="254" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddXSLTemplate" runat="server" TargetControlID="ddlXSLTemplate"
                        ParentControlID="ddlModule" PromptValue="-1" PromptText="[Select]" Category="XSLTemplates"
                        LoadingText="[Loading...]" ServicePath="~/Admin/Services/XSLTemplate/XSLTemplateService.asmx"
                        ServiceMethod="GetDropDownXSLTemplates" />
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnAddControl" Text="Add Control" runat="server" CausesValidation="true"
                ValidationGroup="AddEditPageDesignControl" CssClass="btn-addcontrol" />
        </div>
        <asp:ValidationSummary ID="valsummaryPageDesignControl" runat="server" ValidationGroup="AddEditPageDesignControl"
            HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
            ShowSummary="false" />
        <table width="100%">
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="lblRegisterControl" runat="server" AssociatedControlID="txtRegisterControl"
                        Text="Register Control"></asp:Label>
                </td>
                <td>
                    <CE:Editor ID="txtRegisterControl" BreakElement="Br" runat="server" Width="100%"
                        Height="100px" EnableBrowserContextMenu="False" AutoConfigure="Simple" ActiveTab="Code"
                        ShowEditMode="false" ShowPreviewMode="false" EnableStripScriptTags="false">
                    </CE:Editor>
                </td>
                <td>
                    <asp:Label ID="lblUserControlTag" runat="server" AssociatedControlID="txtUserControlTag"
                        Text="User Control Tag"></asp:Label>
                </td>
                <td>
                    <CE:Editor ID="txtUserControlTag" BreakElement="Br" runat="server" Width="270px"
                        Height="100px" EnableBrowserContextMenu="False" AutoConfigure="Simple" ActiveTab="Code"
                        ShowEditMode="false" ShowPreviewMode="false" EnableStripScriptTags="false">
                    </CE:Editor>
                </td>
            </tr>
        </table>
        <div class="sep-tbl">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlPageItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <CE:Editor ID="txtDetails" BreakElement="Br" runat="server" Width="100%" Height="600px"
                        EnableBrowserContextMenu="False" AutoConfigure="Simple" ActiveTab="Code" ShowEditMode="false"
                        ShowPreviewMode="false" EnableStripScriptTags="false">
                    </CE:Editor>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" NotificationOperationDone="true"
                CssClass="btn-update" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
