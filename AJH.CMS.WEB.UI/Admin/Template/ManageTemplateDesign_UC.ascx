<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageTemplateDesign_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageTemplateDesign_UC" %>
<asp:UpdatePanel ID="upnlTemplateControl" runat="server" UpdateMode="Conditional">
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
                    <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddModule" runat="server" TargetControlID="ddlModule"
                        PromptValue="-1" PromptText="[Select]" Category="Modules" LoadingText="[Loading...]"
                        ServicePath="~/Admin/Services/Module/ModuleService.asmx" ServiceMethod="GetDropDownModules" />
                    <asp:RequiredFieldValidator ID="rfvModule" runat="server" ControlToValidate="ddlModule"
                        ValidationGroup="AddEditTemplateDesignControl" InitialValue="-1" Text="*" Display="Dynamic"
                        ErrorMessage="Module"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblCMSControl" runat="server" Text="CMSControl" AssociatedControlID="ddlCMSControl"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCMSControl" runat="server" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddCMSControl" runat="server" TargetControlID="ddlCMSControl"
                        ParentControlID="ddlModule" PromptValue="-1" PromptText="[Select]" Category="CMSControls"
                        LoadingText="[Loading...]" ServicePath="~/Admin/Services/CMSControl/CMSControlService.asmx"
                        ServiceMethod="GetDropDownCMSControls" />
                    <asp:RequiredFieldValidator ID="rfvCMSControl" runat="server" ControlToValidate="ddlCMSControl"
                        ValidationGroup="AddEditTemplateDesignControl" InitialValue="-1" Text="*" Display="Dynamic"
                        ErrorMessage="CMSControl"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContainerValue" runat="server" Text="Container Value" AssociatedControlID="ddlContainerValue"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlContainerValue" runat="server" AutoPostBack="false">
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
                    <asp:DropDownList ID="ddlXSLTemplate" runat="server" AutoPostBack="false">
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
                ValidationGroup="AddEditTemplateDesignControl" CssClass="btn-addcontrol" />
        </div>
        <asp:ValidationSummary ID="valsummaryTemplateDesignControl" runat="server" ValidationGroup="AddEditTemplateDesignControl"
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
                    <controls:Editor_UC ID="txtRegisterControl" runat="server" Width="100%" Height="70px"
                        EditModes="Html" ContentFilters="None"></controls:Editor_UC>
                </td>
                <td>
                    <asp:Label ID="lblUserControlTag" runat="server" AssociatedControlID="txtUserControlTag"
                        Text="User Control Tag"></asp:Label>
                </td>
                <td>
                    <controls:Editor_UC ID="txtUserControlTag" runat="server" Width="100%" Height="70px"
                        EditModes="Html" ContentFilters="None"></controls:Editor_UC>
                </td>
            </tr>
        </table>
        <div class="sep-tbl">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlTemplateStyle" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%">
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="lblStyle" runat="server" Text="Style" AssociatedControlID="ddlStyle"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStyle" runat="server" AutoPostBack="false">
                    </asp:DropDownList>
                    <ajax:CascadingDropDown ID="cddStyle" runat="server" TargetControlID="ddlStyle" PromptValue="-1"
                        PromptText="[Select]" Category="Styles" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Style/StyleService.asmx"
                        ServiceMethod="GetDropDownStyles" />
                    <asp:RequiredFieldValidator ID="rfvStyle" runat="server" ControlToValidate="ddlStyle"
                        ValidationGroup="AddEditTemplateDesignStyle" InitialValue="-1" Text="*" Display="Dynamic"
                        ErrorMessage="Style"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnAddStyle" Text="Add Style" runat="server" CausesValidation="true"
                ValidationGroup="AddEditTemplateDesignStyle" CssClass="btn-addstyle" />
        </div>
        <asp:ValidationSummary ID="valsummaryTemplateDesignStyle" runat="server" ValidationGroup="AddEditTemplateDesignStyle"
            HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
            ShowSummary="false" />
        <table width="100%">
            <colgroup width="130px">
            </colgroup>
            <colgroup>
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="lblStyleTag" runat="server" AssociatedControlID="txtStyleTag" Text="Style Tag"></asp:Label>
                </td>
                <td>
                    <controls:Editor_UC ID="txtStyleTag" runat="server" Width="100%" Height="100px" EditModes="Html"
                        ContentFilters="None" IsRequired="false"></controls:Editor_UC>
                </td>
            </tr>
        </table>
        <div class="sep-tbl">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlTemplateItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <controls:Editor_UC ID="txtDetails" runat="server" Width="100%" Height="400px" EditModes="Html"
                        ContentFilters="None" IsRequired="true" ValidationGroup="TemplateDesign" ErrorMessage="Details"
                        ErrorText="*"></controls:Editor_UC>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" NotificationOperationDone="true"
                ValidationGroup="TemplateDesign" CssClass="btn-update" />
        </div>
        <asp:ValidationSummary ID="valsummaryDesign" runat="server" ValidationGroup="TemplateDesign"
            HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
            ShowSummary="false" />
    </ContentTemplate>
</asp:UpdatePanel>
