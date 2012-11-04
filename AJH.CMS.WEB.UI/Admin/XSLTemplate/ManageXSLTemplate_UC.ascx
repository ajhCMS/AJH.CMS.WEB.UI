<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageXSLTemplate_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageXSLTemplate_UC" %>
<asp:UpdatePanel ID="upnlXSLTemplate" runat="server" UpdateMode="Conditional">
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
                <asp:Label ID="lblGrdTitleXSLTemplate" runat="server" Text="XslTemplates"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvXSLTemplate" runat="server" AllowPaging="true" PageSize="10"
                    AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.XSLTemplate)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.XSLTemplate)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.XSLTemplate)Container.DataItem).ID%>'
                                    CommandName="EditXSLTemplate"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlXSLTemplateItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlXSLTemplateItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditXSLTemplate" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
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
                            ValidationGroup="AddEditXSLTemplate" InitialValue="-1" Text="*" Display="Dynamic"
                            ErrorMessage="Module"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details" AssociatedControlID="txtDetails"></asp:Label>
                    </td>
                    <td>
                        <CE:Editor ID="txtDetails" BreakElement="Br" runat="server" Width="100%" Height="500px"
                            EnableBrowserContextMenu="False" AutoConfigure="Simple" ActiveTab="Code" ShowEditMode="false"
                            ShowPreviewMode="false" EnableStripScriptTags="false">
                        </CE:Editor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditXSLTemplate" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditXSLTemplate"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditXSLTemplate"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryXSLTemplate" runat="server" ValidationGroup="AddEditXSLTemplate"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
