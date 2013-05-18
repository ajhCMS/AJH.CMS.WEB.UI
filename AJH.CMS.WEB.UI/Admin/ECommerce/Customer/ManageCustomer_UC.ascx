<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageCustomer_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ECommerce.Customer.ManageCustomer_UC" %>
    <%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlCustomer" runat="server" UpdateMode="Conditional">
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
                <asp:Label ID="lblGrdTitleCustomer" runat="server" Text="Customers"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvCustomer" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Width="100%" DataKeyNames="ID">
                    <EmptyDataTemplate>
                        No Items found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#((AJH.CMS.Core.Entities.Customer)Container.DataItem).ID%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblName" runat="server" Text='<%#((AJH.CMS.Core.Entities.Customer)Container.DataItem).CUSTOMER_FNAME+" "+((AJH.CMS.Core.Entities.Customer)Container.DataItem).CUSTOMER_LNAME%>'
                                    CommandArgument='<%# ((AJH.CMS.Core.Entities.Customer)Container.DataItem).ID%>'
                                    CommandName="EditCustomer"></asp:LinkButton>
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
<asp:UpdatePanel ID="upnlCustomerItem" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlCustomer" runat="server" Visible="false">
            <table width="100%">
                
                <tr id="trEmail" runat="server">
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail (User Name)" AssociatedControlID="txtEmail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="E-mail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trPassword" runat="server">
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGender" runat="server" Text="Gender" AssociatedControlID="rblGender"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblfName" runat="server" Text="First Name" AssociatedControlID="txtfname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfname" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="txtfname"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="First Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbllName" runat="server" Text="Last Name" AssociatedControlID="txtlname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlname" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtlname" runat="server" ControlToValidate="txtlname"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Last Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="BirthDate" AssociatedControlID="ucAjaxDate"></asp:Label>
                    </td>
                    <td class="ajaxdate-cntrl">
                        <controls:AjaxDate_UC ID="ucAjaxDate" runat="server" IsRequired="true" Format="dd MMM yyyy" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblZip" runat="server" Text="Zip Code" AssociatedControlID="txtZip"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" Text="Country" AssociatedControlID="ddlCountry"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="txtCity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress1" runat="server" Text="Address" AssociatedControlID="txtAddress1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="txtAddress1"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Address"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress2" runat="server" Text="Address (Line 2)" AssociatedControlID="txtAddress2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress3" runat="server" Text="Address (Line 3)" AssociatedControlID="txtAddress3"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress3" runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" runat="server" Text="Mobile Phone" AssociatedControlID="txtMobile"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone" AssociatedControlID="txtHoemPhone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHoemPhone" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblEducation" runat="server" Text="Education" AssociatedControlID="txtEducation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEducation" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblPosition" runat="server" Text="Position" AssociatedControlID="txtposition"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtposition" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblLocation" runat="server" Text="Location" AssociatedControlID="txtLocation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status" AssociatedControlID="rblstauts"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblstauts" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNewsLetter" runat="server" Text="Newsletter" AssociatedControlID="rblnewsletter"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblnewsletter" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOptIn" runat="server" Text="Opt-In" AssociatedControlID="rblOptIn"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblOptIn" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
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
