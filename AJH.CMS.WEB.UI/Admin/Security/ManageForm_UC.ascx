<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageForm_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageForm_UC" %>
<asp:UpdatePanel ID="upnlForm" runat="server" UpdateMode="Conditional">
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
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Form)Container.DataItem).ID%>' CommandName="EditForm"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="70%" />
                            <HeaderStyle Width="70%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code" HeaderText="Code" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlFormItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlFormItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditForm" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCode" runat="server" Text="Code" AssociatedControlID="txtCode"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" MaxLength="1000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"
                            ValidationGroup="AddEditForm" Text="*" Display="Dynamic" ErrorMessage="Code"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUrl" runat="server" Text="Url" AssociatedControlID="txtUrl"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" MaxLength="2000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtUrl"
                            ValidationGroup="AddEditForm" Text="*" Display="Dynamic" ErrorMessage="Url"></asp:RequiredFieldValidator>
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
                            ValidationGroup="AddEditForm" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditForm"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditForm"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryForm" runat="server" ValidationGroup="AddEditForm"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
