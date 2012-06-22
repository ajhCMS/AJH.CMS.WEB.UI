<%@ Page Title="Login" Language="C#" MasterPageFile="~/Admin/CMSLogin.Master" AutoEventWireup="false"
    CodeBehind="FrmLogin.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmLogin" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upnlLogin" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Login ID="loginUser" runat="server" CssClass="user-login" InstructionText="Please enter your user name and password for login">
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
</asp:Content>
