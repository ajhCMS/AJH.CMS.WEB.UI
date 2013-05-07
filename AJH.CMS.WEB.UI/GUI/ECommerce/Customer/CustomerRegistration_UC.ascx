<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CustomerRegistration_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.GUI.ECommerce.Customer.CustomerRegistration_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<asp:UpdatePanel ID="upnlUser" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dv-problem">
        </div>
        <asp:Panel ID="pnlCustomer" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail (Username)" meta:resourceKey="lblEmail"
                            AssociatedControlID="txtEmail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="E-mail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword" meta:resourceKey="lblPassword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" meta:resourceKey="lblConfirmPassword" runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmPassword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword"
                            Operator="Equal" ControlToValidate="txtPassword" Display="Dynamic" Text="*" Type="String"
                            ValidationGroup="AddEditCustomer" ErrorMessage="Your password and confirmation password do not match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGender" meta:resourceKey="lblGender" runat="server" Text="Gender" AssociatedControlID="rblGender"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblfName" meta:resourceKey="lblfName" runat="server" Text="First Name" AssociatedControlID="txtfname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfname" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="txtfname"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="First Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbllName" meta:resourceKey="lbllName" runat="server" Text="Last Name" AssociatedControlID="txtlname"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlname" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtlname" runat="server" ControlToValidate="txtlname"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Last Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDate" meta:resourceKey="lblDate" runat="server" Text="BirthDate" AssociatedControlID="ucAjaxDate"></asp:Label>
                    </td>
                    <td class="ajaxdate-cntrl">
                        <controls:AjaxDate_UC ID="ucAjaxDate" runat="server" IsRequired="true" Format="dd MMM yyyy" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblZip" meta:resourceKey="lblZip" runat="server" Text="Zip Code" AssociatedControlID="txtZip"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" meta:resourceKey="lblCountry" runat="server" Text="Country" AssociatedControlID="ddlCountry"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" meta:resourceKey="lblCity" runat="server" Text="City" AssociatedControlID="txtCity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress1" meta:resourceKey="lblAddress1" runat="server" Text="Address" AssociatedControlID="txtAddress1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="txtAddress1"
                            ValidationGroup="AddEditCustomer" Text="*" Display="Dynamic" ErrorMessage="Address"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress2" meta:resourceKey="lblAddress2" runat="server" Text="Address (Line 2)" AssociatedControlID="txtAddress2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2"  runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress3" meta:resourceKey="lblAddress3" runat="server" Text="Address (Line 3)" AssociatedControlID="txtAddress3"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress3" runat="server" MaxLength="500" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" meta:resourceKey="lblMobile" runat="server" Text="Mobile Phone" AssociatedControlID="txtMobile"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHomePhone" meta:resourceKey="lblHomePhone" runat="server" Text="Home Phone" AssociatedControlID="txtHoemPhone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHoemPhone" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" meta:resourceKey="lblStatus" runat="server" Text="Status" AssociatedControlID="rblstauts"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblstauts" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNewsLetter" meta:resourceKey="lblNewsLetter" runat="server" Text="Newsletter" AssociatedControlID="rblnewsletter"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblnewsletter" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOptIn" meta:resourceKey="lblOptIn" runat="server" Text="Opt-In" AssociatedControlID="rblOptIn"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblOptIn" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <div class="footer-buttons">
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditCustomer"
                    Text="Save" NotificationOperationDone="true" />
            </div>
            <asp:ValidationSummary ID="valsummaryArticle" runat="server" ValidationGroup="AddEditCustomer"
                HeaderText="Please review the following field(s):" DisplayMode="BulletList" ShowMessageBox="true"
                ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
