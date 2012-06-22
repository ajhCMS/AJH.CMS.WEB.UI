<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactUs_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.ContactUs_UC" %>
<asp:UpdatePanel ID="upnlContactUs" runat="server">
    <ContentTemplate>
        <div id="dvMessage" runat="server" visible="false">
            Thank you, your submission has been received.
        </div>
        <asp:Panel ID="pnlContactUs" runat="server" DefaultButton="btnSend" Visible="true">
            <table class="contactus-tbl">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" MaxLength="100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompany" MaxLength="100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" MaxLength="200" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            Text="*" ErrorMessage="Please enter Email in the format of example@example.root"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SendContactUs"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" MaxLength="100" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                            ErrorMessage="Phone" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDivision" runat="server" Text="Division"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDivision" runat="server">
                            <asp:ListItem Text="GENERAL" Value="GENERAL"></asp:ListItem>
                            <asp:ListItem Text="OIL & GAS DIVISION" Value="OIL & GAS DIVISION"></asp:ListItem>
                            <asp:ListItem Text="SAFETY (PPE) DIVISION" Value="SAFETY (PPE) DIVISION"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" MaxLength="100" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Subject" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMessage" MaxLength="500" TextMode="MultiLine" Height="100px"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                            ErrorMessage="Message" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="contactus-footer">
                <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn" Width="60px" ValidationGroup="SendContactUs" />
            </div>
            <asp:ValidationSummary ID="valSumContactUs" runat="server" DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" ValidationGroup="SendContactUs" HeaderText="Please review the following field(s):" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
