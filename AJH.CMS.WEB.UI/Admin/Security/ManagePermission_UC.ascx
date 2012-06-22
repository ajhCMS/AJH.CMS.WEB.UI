<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManagePermission_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManagePermission_UC" %>
<script type="text/javascript" language="javascript">
    function HidePermissionRolePopup() {
        $find('<%=mpePermissionRole.ClientID %>').hide();
        //Sys.callBaseMethod($('#' + '<%=cddRoles.ClientID %>'), 'dispose');
        //Sys.Application.disposeElement($('#' + '<%=cddRoles.ClientID %>'), false);
        //$('#' + '<%=upnlPopupPermissionRole.ClientID %>')[0].innerHTML = '';

        return false;
    }

    function HidePermissionUserPopup() {
        $find('<%=mpePermissionUser.ClientID %>').hide();
        //Sys.callBaseMethod($('#' + '<%=cddUsers.ClientID %>'), 'dispose');
        //Sys.Application.disposeElement($('#' + '<%=cddUsers.ClientID %>'), false);
        //$('#' + '<%=upnlPopupPermissionRole.ClientID %>')[0].innerHTML = '';

        return false;
    }
</script>
<asp:UpdatePanel ID="upnlPermission" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server">
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleForm" runat="server" Text="Forms"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvForm" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).Name%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80%" />
                            <HeaderStyle Width="80%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Roles">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnRoles" CssClass="roles" ImageUrl="~/App_Themes/Image/roles.png" runat="server"
                                    ToolTip="Roles" CommandArgument='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).ID%>'
                                    CommandName="EditPermissionRole" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Users">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnUsers" CssClass="users" ImageUrl="~/App_Themes/Image/users.png" runat="server"
                                    ToolTip="Users" CommandArgument='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).ID%>'
                                    CommandName="EditPermissionUser" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlPermissionRole" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvPermissionRole" runat="server" visible="false">
            <input id="hdnModalRole" runat="server" type="hidden" />
            <ajax:ModalPopupExtender ID="mpePermissionRole" runat="server" TargetControlID="hdnModalRole"
                PopupControlID="dvPopupPermissionRole" BackgroundCssClass="modalBackground" DropShadow="true" />
            <div id="dvPopupPermissionRole" runat="server" style="display: none" class="modalPopup">
                <asp:UpdatePanel ID="upnlPopupPermissionRole" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <th>
                                    <div>
                                        <asp:ImageButton ID="ibtnPermissionRoleExit" runat="server" CausesValidation="False"
                                            ImageUrl="~/App_Themes/Image/close.png" OnClientClick="HidePermissionRolePopup();return false;" />
                                    </div>
                                    <asp:Label ID="lblPermissionRoleTitle" runat="server" Text="Permission Role"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div id="dvProblemRole" runat="server" class="dv-problem">
                                    </div>
                                    <asp:Panel ID="pnlPermissionRole" runat="server">
                                        <div class="grid-actions">
                                            <asp:ImageButton ID="ibtnPermissionRoleDelete" NotificationOperationDone="true" runat="server"
                                                ImageUrl="~/App_Themes/image/delete.png" ToolTip="Delete"></asp:ImageButton>
                                            <asp:ImageButton ID="ibtnPermissionRoleAdd" runat="server" ToolTip="Add" CausesValidation="False"
                                                ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
                                        </div>
                                        <div class="grid-headers">
                                            <asp:Label ID="lblRoles" runat="server" Text="Roles"></asp:Label>
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
                                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.FormRole)Container.DataItem).ID%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnName" runat="server" CommandArgument='<%# ((AJH.CMS.Core.Entities.FormRole)Container.DataItem).ID%>'
                                                                CommandName="EditRole" Text='<%# ((AJH.CMS.Core.Entities.FormRole)Container.DataItem).RoleName%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="90%" />
                                                        <HeaderStyle Width="90%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPermissionRoleAdd" runat="server">
                                        <table width="100%">
                                            <tr id="trRoles" runat="server" visible="false">
                                                <td>
                                                    <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="ddlRoles"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlRoles" runat="server" Width="254px">
                                                    </asp:DropDownList>
                                                    <ajax:CascadingDropDown ID="cddRoles" runat="server" TargetControlID="ddlRoles" Category="PermissionRole"
                                                        PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Security/RoleService.asmx"
                                                        ServiceMethod="GetDropDownRolesNotInForm" />
                                                    <asp:RequiredFieldValidator ID="rfvRoles" runat="server" ControlToValidate="ddlRoles"
                                                        ValidationGroup="AddEditPermissionRole" InitialValue="-1" Text="*" Display="Dynamic"
                                                        ErrorMessage="Role"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAccessTypeRole" runat="server" Text="Access Type" AssociatedControlID="rblAccessTypeRole"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblAccessTypeRole" runat="server" RepeatDirection="Vertical">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="footer-buttons">
                                            <asp:Button CssClass="btn" ID="btnPermissionRoleExit" runat="server" Width="60px"
                                                CausesValidation="false" Text="Exit" />
                                            <asp:Button CssClass="btn" ID="btnPermissionRoleUpdate" runat="server" Width="60px"
                                                CausesValidation="true" ValidationGroup="AddEditPermissionRole" Text="Update"
                                                NotificationOperationDone="true" />
                                            <asp:Button CssClass="btn" ID="btnPermissionRoleSave" runat="server" Width="60px"
                                                CausesValidation="true" ValidationGroup="AddEditPermissionRole" Text="Save" NotificationOperationDone="true" />
                                        </div>
                                        <asp:ValidationSummary ID="valsummaryPermissionRole" runat="server" ValidationGroup="AddEditPermissionRole"
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
<asp:UpdatePanel ID="upnlPermissionUser" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvPermissionUser" runat="server" visible="false">
            <input id="hdnModalUser" runat="server" type="hidden" />
            <ajax:ModalPopupExtender ID="mpePermissionUser" runat="server" TargetControlID="hdnModalUser"
                PopupControlID="dvPopupPermissionUser" BackgroundCssClass="modalBackground" DropShadow="true" />
            <div id="dvPopupPermissionUser" runat="server" style="display: none" class="modalPopup">
                <asp:UpdatePanel ID="upnlPopupPermissionUser" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <th>
                                    <div>
                                        <asp:ImageButton ID="ibtnPermissionUserExit" runat="server" CausesValidation="False"
                                            ImageUrl="~/App_Themes/Image/close.png" OnClientClick="HidePermissionUserPopup();return false;" />
                                    </div>
                                    <asp:Label ID="lblPermissionUserTitle" runat="server" Text="Permission User"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div id="dvProblemUser" runat="server" class="dv-problem">
                                    </div>
                                    <asp:Panel ID="pnlPermissionUser" runat="server">
                                        <div class="grid-actions">
                                            <asp:ImageButton ID="ibtnPermissionUserDelete" NotificationOperationDone="true" runat="server"
                                                ImageUrl="~/App_Themes/image/delete.png" ToolTip="Delete"></asp:ImageButton>
                                            <asp:ImageButton ID="ibtnPermissionUserAdd" runat="server" ToolTip="Add" CausesValidation="False"
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
                                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.FormUser)Container.DataItem).ID%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnName" runat="server" CommandArgument='<%# ((AJH.CMS.Core.Entities.FormUser)Container.DataItem).ID%>'
                                                                CommandName="EditUser" Text='<%# ((AJH.CMS.Core.Entities.FormUser)Container.DataItem).UserName%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="90%" />
                                                        <HeaderStyle Width="90%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPermissionUserAdd" runat="server">
                                        <table width="100%">
                                            <tr id="trUser" runat="server" visible="false">
                                                <td>
                                                    <asp:Label ID="lblUser" runat="server" Text="User" AssociatedControlID="ddlUsers"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUsers" runat="server" Width="254px">
                                                    </asp:DropDownList>
                                                    <ajax:CascadingDropDown ID="cddUsers" runat="server" TargetControlID="ddlUsers" Category="PermissionUser"
                                                        PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]" ServicePath="~/Admin/Services/Security/UserService.asmx"
                                                        ServiceMethod="GetDropDownUsersNotInForm" />
                                                    <asp:RequiredFieldValidator ID="rfvUsers" runat="server" ControlToValidate="ddlUsers"
                                                        ValidationGroup="AddEditPermissionUser" InitialValue="-1" Text="*" Display="Dynamic"
                                                        ErrorMessage="User"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAccessTypeUser" runat="server" Text="Access Type" AssociatedControlID="rblAccessTypeUser"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rblAccessTypeUser" runat="server" RepeatDirection="Vertical">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="footer-buttons">
                                            <asp:Button CssClass="btn" ID="btnPermissionUserExit" runat="server" Width="60px"
                                                CausesValidation="false" Text="Exit" />
                                            <asp:Button CssClass="btn" ID="btnPermissionUserUpdate" runat="server" Width="60px"
                                                CausesValidation="true" ValidationGroup="AddEditPermissionUser" Text="Update"
                                                NotificationOperationDone="true" />
                                            <asp:Button CssClass="btn" ID="btnPermissionUserSave" runat="server" Width="60px"
                                                CausesValidation="true" ValidationGroup="AddEditPermissionUser" Text="Save" NotificationOperationDone="true" />
                                        </div>
                                        <asp:ValidationSummary ID="valsummaryPermissionUser" runat="server" ValidationGroup="AddEditPermissionUser"
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
