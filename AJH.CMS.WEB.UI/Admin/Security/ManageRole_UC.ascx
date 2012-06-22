<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageRole_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageRole_UC" %>
<script type="text/javascript" language="javascript">
    function HideRoleUserPopup() {
        $find('<%=mpeRoleUser.ClientID %>').hide();
        //Sys.callBaseMethod($('#' + '<%=cddUsers.ClientID %>'), 'dispose');
        //Sys.Application.disposeElement($('#' + '<%=cddUsers.ClientID %>'), false);
        //$('#' + '<%=upnlPopupRoleUser.ClientID %>')[0].innerHTML = '';

        return false;
    }
</script>
<asp:UpdatePanel ID="upnlRole" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnDelete" NotificationOperationDone="true" runat="server"
                    ImageUrl="~/App_Themes/image/delete.png" ToolTip="Delete"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleRole" runat="server" Text="Roles"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvRole" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Role)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Users">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnUsers" CssClass="roles-users" ImageUrl="~/App_Themes/Image/users.png" runat="server"
                                    ToolTip="Users" CommandArgument='<%# ((AJH.CMS.Core.Entities.Role)Container.DataItem).ID%>'
                                    CommandName="EditRoleUser" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Role)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Role)Container.DataItem).ID%>' CommandName="EditRole"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80%" />
                            <HeaderStyle Width="80%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlRoleItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlRoleItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditRole" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="1000" TextMode="MultiLine"
                            Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="AddEditRole" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditRole"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditRole"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryRole" runat="server" ValidationGroup="AddEditRole"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlRoleUser" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvRoleUser" runat="server" visible="false">
            <input id="hdnModal" runat="server" type="hidden" />
            <ajax:ModalPopupExtender ID="mpeRoleUser" runat="server" TargetControlID="hdnModal"
                PopupControlID="dvPopupRoleUser" BackgroundCssClass="modalBackground" DropShadow="true" />
            <div id="dvPopupRoleUser" runat="server" style="display: none" class="modalPopup">
                <asp:UpdatePanel ID="upnlPopupRoleUser" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <th>
                                    <div>
                                        <asp:ImageButton ID="ibtnRoleUserExit" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Image/close.png"
                                            OnClientClick="HideRoleUserPopup();return false;" />
                                    </div>
                                    <asp:Label ID="lblRoleUserTitle" runat="server" Text="Role User"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div id="dvProblemUser" runat="server" class="dv-problem">
                                    </div>
                                    <asp:Panel ID="pnlRoleUser" runat="server">
                                        <div class="grid-actions">
                                            <asp:ImageButton ID="ibtnRoleUserDelete" NotificationOperationDone="true" runat="server"
                                                ImageUrl="~/App_Themes/image/delete.png" ToolTip="Delete"></asp:ImageButton>
                                            <asp:ImageButton ID="ibtnRoleUserAdd" runat="server" ToolTip="Add" CausesValidation="False"
                                                ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
                                        </div>
                                        <div class="grid-headers">
                                            <asp:Label ID="lblUsers" runat="server" Text="Users"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:GridView ID="gvUser" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                                                CssClass="grd" Width="100%" DataKeyNames="ID">
                                                <EmptyDataTemplate>
                                                    No Items found
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkItem" runat="server" />
                                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.User)Container.DataItem).ID%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.User)Container.DataItem).Name%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="90%" />
                                                        <HeaderStyle Width="90%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlRoleUserAdd" runat="server" DefaultButton="btnRoleUserSave">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUser" runat="server" Text="User" AssociatedControlID="ddlUsers"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUsers" runat="server" Width="254px">
                                                    </asp:DropDownList>
                                                    <ajax:CascadingDropDown ID="cddUsers" runat="server" TargetControlID="ddlUsers" Category="RoleUser"
                                                        PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Security/UserService.asmx"
                                                        ServiceMethod="GetDropDownUsersNotInRole" />
                                                    <asp:RequiredFieldValidator ID="rfvUsers" runat="server" ControlToValidate="ddlUsers"
                                                        ValidationGroup="AddEditRoleUser" InitialValue="-1" Text="*" Display="Dynamic"
                                                        ErrorMessage="User"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="footer-buttons">
                                            <asp:Button CssClass="btn" ID="btnRoleUserExit" runat="server" Width="60px" CausesValidation="false"
                                                Text="Exit" />
                                            <asp:Button CssClass="btn" ID="btnRoleUserSave" runat="server" Width="60px" CausesValidation="true"
                                                ValidationGroup="AddEditRoleUser" Text="Save" NotificationOperationDone="true" />
                                        </div>
                                        <asp:ValidationSummary ID="valsummaryRoleUser" runat="server" ValidationGroup="AddEditRoleUser"
                                            HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                                            ShowSummary="false" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
