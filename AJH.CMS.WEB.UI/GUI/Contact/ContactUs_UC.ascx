<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactUs_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.ContactUs_UC" %>
<asp:UpdatePanel ID="upnlContactUs" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvMessage" runat="server" visible="false">
            <asp:Label ID="lblMsgconfirmation" runat="server" meta:resourcekey="lblMsgconfirmation"></asp:Label>
        </div>
        <asp:Panel ID="pnlContactUs" runat="server" DefaultButton="btnSend" Visible="true">
            <table class="contactus-tbl">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" meta:resourcekey="lblName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" MaxLength="100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" MaxLength="200" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            Text="*" meta:resourcekey="revEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="SendContactUs"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubject" runat="server" meta:resourcekey="lblSubject"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" MaxLength="100" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Subject" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" meta:resourcekey="lblMessage"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMessage" MaxLength="500" TextMode="MultiLine" Height="100px"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                            ErrorMessage="Message" Text="*" ValidationGroup="SendContactUs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSendCopyToYourSelf" runat="server" meta:resourcekey="lblSendCopyToYourSelf"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbSendCopyToYourSelf" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="contactus-footer">
                <asp:Button ID="btnSend" runat="server" CssClass="btn" Width="60px" ValidationGroup="SendContactUs"
                    meta:resourcekey="btnSend" />
            </div>
            <asp:ValidationSummary ID="valSumContactUs" runat="server" DisplayMode="BulletList"
                meta:resourcekey="valSumContactUs" ShowMessageBox="true" ShowSummary="false"
                ValidationGroup="SendContactUs" HeaderText="Please review the following field(s):" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
