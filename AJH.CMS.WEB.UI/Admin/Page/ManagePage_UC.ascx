<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManagePage_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManagePage_UC" %>
<asp:UpdatePanel ID="upnlPage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlView" runat="server">
            <div class="grid-actions">
                <asp:ImageButton ID="ibtnDelete" ImageUrl="~/App_Themes/image/delete.png" runat="server"
                    ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/image/add.png"></asp:ImageButton>
            </div>
            <div class="grid-headers">
                <asp:Label ID="lblGrdTitlePage" runat="server" Text="Pages"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvPage" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Page)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Design">
                            <ItemTemplate>
                                <a href='<%# GetDesignPagePath(((AJH.CMS.Core.Entities.Page)Container.DataItem).ID)%>'
                                    runat="server">
                                    <img src="~/App_Themes/Image/builder.png" alt="Build" runat="server" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Page)Container.DataItem).Name%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Page)Container.DataItem).ID%>' CommandName="EditPage"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlPageItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlPageItem" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text="Title" AssociatedControlID="txtTitle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Title"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text="Type" AssociatedControlID="ddlPageType"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPageType" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddPageType" runat="server" TargetControlID="ddlPageType"
                            PromptValue="-1" PromptText="[Select]" Category="PageType" LoadingText="[Loading...]"
                            ServicePath="~/Admin/Services/Page/PageService.asmx" ServiceMethod="GetDropDownPageType" />
                        <asp:RequiredFieldValidator ID="rfvPageType" runat="server" ControlToValidate="ddlPageType"
                            ValidationGroup="AddEditPage" InitialValue="-1" Text="*" Display="Dynamic" ErrorMessage="Type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTemplate" runat="server" Text="Template" AssociatedControlID="ddlTemplate"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                        <ajax:CascadingDropDown ID="cddTemplate" runat="server" TargetControlID="ddlTemplate"
                            PromptValue="-1" PromptText="[Select]" Category="Template" LoadingText="[Loading...]"
                            ServicePath="~/Admin/Services/Template/TemplateService.asmx" ServiceMethod="GetDropDownTemplates" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTemplate"
                            ValidationGroup="AddEditPage" InitialValue="-1" Text="*" Display="Dynamic" ErrorMessage="Template"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblKeyword" runat="server" Text="Keyword" AssociatedControlID="txtKeyword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyword" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="txtKeyword"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="Keyword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSEOName" runat="server" Text="SEOName" AssociatedControlID="txtSEOName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSEOName" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSEOName" runat="server" ControlToValidate="txtSEOName"
                            ValidationGroup="AddEditPage" Text="*" Display="Dynamic" ErrorMessage="SEOName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text="Exit" />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text="Reset" />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditPage"
                    Text="Save" NotificationOperationDone="true" />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditPage"
                    Text="Update" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryPage" runat="server" ValidationGroup="AddEditPage"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
