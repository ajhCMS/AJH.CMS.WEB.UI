<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Career_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Career_UC" %>
<div id="dvMessage" runat="server" visible="false">
    <asp:Label ID="lblTitle" runat="server" meta:resourcekey="lblTitle"></asp:Label>
</div>
<asp:Panel ID="pnlContactUs" runat="server" DefaultButton="btnSend" meta:resourcekey="pnlContactUsResource1">
    <table class="contactus-tbl">
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"
                    meta:resourcekey="lblNameResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" meta:resourcekey="txtNameResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="E-mail address" AssociatedControlID="txtEmail"
                    meta:resourcekey="lblEmailResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" MaxLength="200" runat="server" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email" Text="*" ValidationGroup="SendCareer" meta:resourcekey="rfvEmailResource1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    Text="*" ErrorMessage="Please enter Email in the format of example@example.root"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SendCareer"
                    meta:resourcekey="revEmailResource1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number" AssociatedControlID="txtContactNumber"
                    meta:resourcekey="lblContactNumberResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContactNumber" MaxLength="100" runat="server" meta:resourcekey="txtContactNumberResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtContactNumber"
                    ErrorMessage="Contact Number" Text="*" ValidationGroup="SendCareer" meta:resourcekey="rfvPhoneResource1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDepatment" runat="server" Text="Depatment" AssociatedControlID="ddlDepatment"
                    meta:resourcekey="lblDepatmentResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDepatment" runat="server" meta:resourcekey="ddlDepatmentResource1">
                    <asp:ListItem  Value="SALES" meta:resourcekey="lstitmsales"></asp:ListItem>
                    <asp:ListItem  Value="SUPERVISOR" meta:resourcekey="lstitmSupervisor"></asp:ListItem>
                    <asp:ListItem Value="STOCK KEEPER" meta:resourcekey="lstitmStockKeeper"></asp:ListItem>
                    <asp:ListItem  Value="CASHIER" meta:resourcekey="lstitmCashier"></asp:ListItem>
                    <asp:ListItem  Value="SALES REPRESENTATIVE" meta:resourcekey="lstitmSalesRep"></asp:ListItem>
                    <asp:ListItem  Value="ROASTING MAN" meta:resourcekey="lstitmRoastingMan"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCoverLetter" runat="server" Text="Cover Letter" AssociatedControlID="txtCoverLetter"
                    meta:resourcekey="lblCoverLetterResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCoverLetter" MaxLength="500" TextMode="MultiLine" Height="100px"
                    runat="server" meta:resourcekey="txtCoverLetterResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCoverLetter" runat="server" ControlToValidate="txtCoverLetter"
                    ErrorMessage="Cover Letter" Text="*" ValidationGroup="SendCareer" meta:resourcekey="rfvCoverLetterResource1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResume" runat="server" Text="Upload your resume" AssociatedControlID="fupResume"
                    meta:resourcekey="lblResumeResource1"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fupResume" runat="server" meta:resourcekey="fupResumeResource1" />
                <asp:RequiredFieldValidator ID="rfvResume" runat="server" ControlToValidate="fupResume"
                    ErrorMessage="Resume" Text="*" ValidationGroup="SendCareer" meta:resourcekey="rfvResumeResource1"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <div class="contactus-footer">
        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn" Width="60px" ValidationGroup="SendCareer"
            meta:resourcekey="btnSendResource1" />
    </div>
    <asp:ValidationSummary ID="valSumContactUs" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="SendCareer" HeaderText="Please review the following field(s):"
        meta:resourcekey="valSumContactUsResource1" />
</asp:Panel>
