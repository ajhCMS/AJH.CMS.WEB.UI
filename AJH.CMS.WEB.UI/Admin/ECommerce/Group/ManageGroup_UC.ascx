<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageGroup_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageGroup_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlGroup" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server" Visible="true">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                    ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/image/add.png"
                    ToolTip="Add" CausesValidation="False"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitleGroup" runat="server" Text="Groups"></asp:Label>
            </div>
            <div class="grid-items">
                <asp:GridView ID="gvGroup" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Group)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Color Group">
                            <ItemTemplate>
                                <asp:Image ID="imgIsColorGroup" runat="server" Height="25" Width="25" ImageUrl='<%#AJH.CMS.WEB.UI.Utilities.CMSWebHelper.GetPublishedImage(Convert.ToBoolean(DataBinder.Eval(Container,"DataItem.IsColorGroup")))%>' />
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            <HeaderStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Group)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Group)Container.DataItem).ID%>'
                                    CommandName="EditGroup"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlGroupItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlGroupItem" runat="server" Visible="false">
            <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                ValidationGroup="AddEditGroup" />
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditGroup" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPublicName" runat="server" Text="Public Name" AssociatedControlID="txtPublicName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPublicName"
                            ValidationGroup="AddEditGroup" Text="*" Display="Dynamic" ErrorMessage="Public Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIsColorGroup" runat="server" Text="Color Group" AssociatedControlID="cbIsColorGroup"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsColorGroup" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSaveOtherLanguage" runat="server" Width="160px"
                    ValidationGroup="AddEditGroup" Text="Save Other Language" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditGroup"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditGroup"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryGroup" runat="server" ValidationGroup="AddEditGroup"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
