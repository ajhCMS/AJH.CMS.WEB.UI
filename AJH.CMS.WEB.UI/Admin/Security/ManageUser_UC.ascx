<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageUser_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageUser_UC" %>
<asp:UpdatePanel ID="upnlUser" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnActive" NotificationOperationDone="true" runat="server"
                    ToolTip="Activate" ImageUrl="~/App_Themes/image/active.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtnInActive" NotificationOperationDone="true" runat="server"
                    ToolTip="Deactivate" ImageUrl="~/App_Themes/image/deactive.png"></asp:ImageButton>
                <asp:ImageButton ID="ibtnDelete" NotificationOperationDone="true" runat="server"
                    ImageUrl="~/App_Themes/image/delete.png" ToolTip="Delete"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleUser" runat="server" Text="Users"></asp:Label>
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
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.User)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.User)Container.DataItem).ID%>' CommandName="EditUser"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="70%" />
                            <HeaderStyle Width="70%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                                <asp:Label ID="lblIsActive" runat="server" Text='<%# GetUserStatus(((AJH.CMS.Core.Entities.User)Container.DataItem).IsActive)%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70%" />
                            <HeaderStyle Width="70%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlUserItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlUserItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="AddEditUser" Text="*" Display="Dynamic" ErrorMessage="Email"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email" AssociatedControlID="txtConfirmEmail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmEmail" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:CompareValidator ID="cvConfirmEmail" runat="server" ControlToCompare="txtConfirmEmail"
                            Operator="Equal" ControlToValidate="txtEmail" Display="Dynamic" Text="*" Type="String"
                            ValidationGroup="AddEditUser" ErrorMessage="Your email and confirmation email do not match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="AddEditUser" Text="*" Display="Dynamic" ErrorMessage="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmPassword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword"
                            Operator="Equal" ControlToValidate="txtPassword" Display="Dynamic" Text="*" Type="String"
                            ValidationGroup="AddEditUser" ErrorMessage="Your password and confirmation password do not match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIsActive" runat="server" Text="Is Active" AssociatedControlID="chkIsActive"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditUser"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditUser"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryUser" runat="server" ValidationGroup="AddEditUser"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
