﻿<%@ Page Title="ProductSearch" Language="C#" MasterPageFile="~/Admin/CMSAdmin.Master"
    AutoEventWireup="false" CodeBehind="FrmProductSearch.aspx.cs" Inherits="AJH.CMS.WEB.UI.Admin.FrmProductSearch" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Product Search
    </h2>
    <asp:UpdatePanel ID="upnlProductSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="dvProblemsSearch" runat="server" class="dv-problem">
            </div>
            <asp:Panel ID="pnlSearch" runat="server" Visible="true">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblCatalog" runat="server" Text="Catalog"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCatalogs" runat="server" Width="254">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddlCatalogs" runat="server" TargetControlID="ddlCatalogs"
                                Category="Catalog" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                                ServicePath="~/Admin/Services/ECommerce/Catalog/CatalogService.asmx" ServiceMethod="GetDropDownCatalogs" />
                        </td>
                        <td>
                            <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" CssClass="btn" runat="server" Width="60px" CausesValidation="false"
                                Text="Search" />
                        </td>
                    </tr>
                </table>
                <div class="grid-actions">
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                        ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                    <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/image/add.png"
                        ToolTip="Add" CausesValidation="False"></asp:ImageButton>
                </div>
                <div class="grid-headers">
                    <asp:Label ID="lblGrdTitleProduct" runat="server" Text="Products"></asp:Label>
                </div>
                <div class="grid-items">
                    <asp:GridView ID="gvProduct" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                        CssClass="grd" Width="100%" DataKeyNames="ID">
                        <EmptyDataTemplate>
                            No Items found
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkItem" runat="server" />
                                    <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Product)Container.DataItem).ID%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblName" runat="server" Text='<%# ((AJH.CMS.Core.Entities.Product)Container.DataItem).Name%>'
                                        CommandArgument='<%# ((AJH.CMS.Core.Entities.Product)Container.DataItem).ID%>'
                                        CommandName="EditProduct"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="90%" />
                                <HeaderStyle Width="90%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
