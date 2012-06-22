<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PortalLanguages_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.PortalLanguages_UC" %>
<input id="hdnPortalLanguageSelect" runat="server" type="hidden" />
<asp:DataList ID="dlstPortalLanguages" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow" RepeatColumns="10">
    <ItemTemplate>
        <asp:ImageButton ID="ibtnLanguageFlag" runat="server" ImageUrl='<%#AJH.CMS.WEB.UI.Utilities.CMSWebHelper.GetLanguageImageThumbnail(DataBinder.Eval(Container,"DataItem.Image").ToString())%>'
            CommandName="PortalLanguageSelect" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>'
            Width="50" Height="25" />
    </ItemTemplate>
</asp:DataList>
<asp:CustomValidator ID="cvPortalLanguageSelect" runat="server" ClientValidationFunction="PortalLanguageSelectValidation"
    Text="*" ErrorMessage="Select Language"></asp:CustomValidator>