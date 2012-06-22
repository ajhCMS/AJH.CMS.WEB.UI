<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageCMSControl_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageCMSControl_UC" %>
<asp:UpdatePanel ID="upnlCMSControl" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" NotificationOperationDone="true"
                    ImageUrl="~/App_Themes/image/delete.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleCMSControl" runat="server" Text="CMSControls"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvCMSControl" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.CMSControl)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.CMSControl)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.CMSControl)Container.DataItem).ID%>'
                                    CommandName="EditCMSControl"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="100%" />
                            <HeaderStyle Width="100%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlCMSControlItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlCMSControlItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditCMSControl" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblModule" runat="server" Text="Module" AssociatedControlID="ddlModule"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlModule" runat="server">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddModule" runat="server" TargetControlID="ddlModule"
                            PromptValue="-1" PromptText="[Select]" Category="Modules" LoadingText="[Loading...]"
                            ServicePath="~/Admin/Services/Module/ModuleService.asmx" ServiceMethod="GetDropDownModules" />
                        <asp:RequiredFieldValidator ID="rfvModule" runat="server" ControlToValidate="ddlModule"
                            ValidationGroup="AddEditCMSControl" Text="*" Display="Dynamic" InitialValue="-1"
                            ErrorMessage="Module"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="AddEditCMSControl" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUserControlPath" runat="server" Text="UserControlPath" AssociatedControlID="txtUserControlPath"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserControlPath" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserControlPath" runat="server" ControlToValidate="txtUserControlPath"
                            ValidationGroup="AddEditCMSControl" Text="*" Display="Dynamic" ErrorMessage="UserControlPath"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditCMSControl"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditCMSControl"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryCMSControl" runat="server" ValidationGroup="AddEditCMSControl"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
