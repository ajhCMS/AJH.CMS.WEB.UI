<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Career_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Career_UC" %>
<div id="dvMessage" runat="server" visible="false">
    Thank you, your submission has been received.
</div>
<asp:Panel ID="pnlContactUs" runat="server" DefaultButton="btnSend" Visible="true">
    <table class="contactus-tbl">
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="E-mail address" AssociatedControlID="txtEmail"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" MaxLength="200" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email" Text="*" ValidationGroup="SendCareer"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    Text="*" ErrorMessage="Please enter Email in the format of example@example.root"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SendCareer"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number" AssociatedControlID="txtContactNumber"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContactNumber" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtContactNumber"
                    ErrorMessage="Contact Number" Text="*" ValidationGroup="SendCareer"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDepatment" runat="server" Text="Depatment" AssociatedControlID="ddlDepatment"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDepatment" runat="server">
                    <asp:ListItem Text="Department1" Value="Department 1"></asp:ListItem>
                    <asp:ListItem Text="Department2" Value="Department 2"></asp:ListItem>
                    <asp:ListItem Text="Department 3" Value="Department 2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCoverLetter" runat="server" Text="Cover Letter" AssociatedControlID="txtCoverLetter"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCoverLetter" MaxLength="500" TextMode="MultiLine" Height="100px"
                    runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCoverLetter" runat="server" ControlToValidate="txtCoverLetter"
                    ErrorMessage="Cover Letter" Text="*" ValidationGroup="SendCareer"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResume" runat="server" Text="Upload your resume" AssociatedControlID="fupResume"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fupResume" runat="server" />
                <asp:RequiredFieldValidator ID="rfvResume" runat="server" ControlToValidate="fupResume"
                    ErrorMessage="Resume" Text="*" ValidationGroup="SendCareer"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <div class="contactus-footer">
        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn" Width="60px" ValidationGroup="SendCareer" />
    </div>
    <asp:ValidationSummary ID="valSumContactUs" runat="server" DisplayMode="BulletList"
        ShowMessageBox="true" ShowSummary="false" ValidationGroup="SendCareer" HeaderText="Please review the following field(s):" />
</asp:Panel>
