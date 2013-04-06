<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CustomerLogin_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.GUI.ECommerce.Customer.CustomerLogin_UC" %>

    <asp:UpdatePanel ID="upnlLogin" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Login ID="loginCustomer" runat="server" CssClass="user-login" InstructionText="Please enter your user name and password for login">
                <CheckBoxStyle CssClass="chk-login" />
                <FailureTextStyle CssClass="fail-login" />
                <HyperLinkStyle CssClass="hyp-login" />
                <InstructionTextStyle CssClass="inst-login" />
                <LabelStyle CssClass="lbl-login" />
                <LoginButtonStyle CssClass="loginbtn-login" />
                <TextBoxStyle CssClass="txt-login" />
                <TitleTextStyle CssClass="title-login" />
                <ValidatorTextStyle CssClass="valt-login" />
            </asp:Login>
        </ContentTemplate>
    </asp:UpdatePanel>
