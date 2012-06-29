<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ManageProducts_UC.ascx.cs"
    Inherits="AJH.CMS.WEB.UI.Admin.ManageProducts_UC" %>
<%@ Register Src="~/Controls/AjaxDate_UC.ascx" TagName="AjaxDate_UC" TagPrefix="controls" %>
<%@ Register Src="~/Controls/SWFUpload/SWFUpload_UC.ascx" TagName="SWFUpload_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/PortalLanguages_UC.ascx" TagName="PortalLanguages_UC"
    TagPrefix="controls" %>
<%@ Register Src="~/Admin/Controls/ColorPicker_UC.ascx" TagName="Color_Picker_UC"
    TagPrefix="controls" %>
<div id="tabvanilla" class="widget">
    <ul class="tabnav">
        <li id="liProduct" runat="server"><a href="#<%=dvProduct.ClientID %>">Product</a></li>
        <li id="liProductCatalog" runat="server"><a href="#<%=dvProductCatalog.ClientID %>">
            Product Catalog</a></li>
        <li id="liProductFeature" runat="server"><a href="#<%=dvProductFeature.ClientID %>">
            Product Feature</a></li>
        <li id="liProductImage" runat="server"><a href="#<%=dvProductImage.ClientID %>">Product
            Image</a></li>
        <li id="liProductPrice" runat="server"><a href="#<%=dvProductPrice.ClientID %>">Product
            Price</a></li>
        <li id="liCombinationProduct" runat="server"><a href="#<%=dvCombinationProduct.ClientID %>">
            Combination Prodcut</a></li>
    </ul>
    <div id="dvProduct" runat="server" class="tabdiv">
        <asp:UpdatePanel ID="upnlProduct" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="dvProductProblems" runat="server" class="dv-problem">
                </div>
                <controls:PortalLanguages_UC ID="ucPortalLanguage" runat="server" Visible="false"
                    ValidationGroup="AddEditProduct" />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text="Name" AssociatedControlID="txtName"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text="Description" AssociatedControlID="txtDescription"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Description"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDisplayTextInStock" runat="server" Text="DisplayText InStock" AssociatedControlID="txtDisplayTextInStock"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDisplayTextInStock" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDisplayTextInStock" runat="server" ControlToValidate="txtDisplayTextInStock"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="DisplayTextInStock"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDisplayTextWhenbackOrder" runat="server" Text="Display Text When Back Order"
                                AssociatedControlID="txtDisplayTextWhenbackOrder"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDisplayTextWhenbackOrder" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDisplayTextWhenbackOrder" runat="server" ControlToValidate="txtDisplayTextWhenbackOrder"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="DisplayTextWhenbackOrder"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblShortDescription" runat="server" Text="Short Description" AssociatedControlID="txtShortDescription"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtShortDescription" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtShortDescription"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Short Description"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTags" runat="server" Text="Tags" AssociatedControlID="txtTags"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTags" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTags" runat="server" ControlToValidate="txtTags"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Tags"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSupplier" runat="server" Text="Supplier" AssociatedControlID="ddlSupplier"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="254">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddlSupplier" runat="server" TargetControlID="ddlSupplier"
                                Category="Supplier" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                                ServicePath="~/Admin/Services/ECommerce/Supplier/SupplierService.asmx" ServiceMethod="GetDropDownSuppliers" />
                            <asp:RequiredFieldValidator ID="rfvSupplier" runat="server" ControlToValidate="ddlSupplier"
                                ValidationGroup="AddEditProduct" Text="*" InitialValue="-1" Display="Dynamic"
                                ErrorMessage="Supplier"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEAN13" runat="server" Text="EAN13" AssociatedControlID="txtEAN13"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEAN13" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEAN13" runat="server" ControlToValidate="txtEAN13"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="EAN13"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUpc" runat="server" Text="UPC" AssociatedControlID="txtUpc"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUpc" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUpc" runat="server" ControlToValidate="txtUpc"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="UPC"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" runat="server" Text="Location" AssociatedControlID="txtLocation"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocation" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Location"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIsDownloadable" runat="server" Text="Downloadable" AssociatedControlID="cbIsDownloadable"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsDownloadable" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDisplayOnSaleIcon" runat="server" Text="Display On Sale Icon" AssociatedControlID="cbDisplayOnSaleIcon"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbDisplayOnSaleIcon" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInitialStock" runat="server" Text="Initial Stock" AssociatedControlID="txtInitialStock"></asp:Label>
                        </td>
                        <td>
                            <ajax:NumericUpDownExtender ID="nInitialStock" runat="server" TargetControlID="txtInitialStock"
                                Width="100" Minimum="1">
                            </ajax:NumericUpDownExtender>
                            <asp:TextBox ID="txtInitialStock" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvInitialStock" runat="server" ControlToValidate="txtInitialStock"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Initial Stock"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMinimumQuantity" runat="server" Text="Minimum Quantity" AssociatedControlID="txtMinimumQuantity"></asp:Label>
                        </td>
                        <td>
                            <ajax:NumericUpDownExtender ID="nMinimumQuantity" runat="server" TargetControlID="txtMinimumQuantity"
                                Width="100" Minimum="1">
                            </ajax:NumericUpDownExtender>
                            <asp:TextBox ID="txtMinimumQuantity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMinimumQuantity" runat="server" ControlToValidate="txtMinimumQuantity"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Minimum Quantity"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAdditionalShippingCost" runat="server" Text="Additional Shipping Cost"
                                AssociatedControlID="txtAdditionalShippingCost"></asp:Label>
                        </td>
                        <td>
                            <ajax:NumericUpDownExtender ID="nAdditionalShippingCost" runat="server" TargetControlID="txtAdditionalShippingCost"
                                Width="100" Minimum="0">
                            </ajax:NumericUpDownExtender>
                            <asp:TextBox ID="txtAdditionalShippingCost" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAdditionalShippingCost" runat="server" ControlToValidate="txtAdditionalShippingCost"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Additional Shipping Cost"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblManufacturar" runat="server" Text="Manufacturar" AssociatedControlID="ddlManufacturar"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlManufacturar" runat="server" Width="254">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddlManufacturar" runat="server" TargetControlID="ddlManufacturar"
                                Category="Manufacturar" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                                ServicePath="~/Admin/Services/ECommerce/Manufacturar/ManufacturarService.asmx"
                                ServiceMethod="GetAllManufacturars" />
                            <asp:RequiredFieldValidator ID="rfvManufacturar" runat="server" ControlToValidate="ddlManufacturar"
                                ValidationGroup="AddEditProduct" Text="*" InitialValue="-1" Display="Dynamic"
                                ErrorMessage="Manufacturar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIsEnabled" runat="server" Text="Enabled" AssociatedControlID="cbIsEnabled"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsEnabled" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTax" runat="server" Text="Tax" AssociatedControlID="ddlTax"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTax" runat="server" Width="254">
                            </asp:DropDownList>
                            <ajax:CascadingDropDown ID="cddlTax" runat="server" TargetControlID="ddlTax" Category="Tax"
                                PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]" ServicePath="~/Admin/Services/ECommerce/Tax/TaxService.asmx"
                                ServiceMethod="GetAllTaxs" />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td>
                            <asp:Label ID="lblSizeChart" runat="server" Text="Details" AssociatedControlID="txtSizeChart"></asp:Label>
                        </td>
                        <td>
                            <CE:Editor ID="txtSizeChart" BreakElement="Br" runat="server" Width="100%" Height="500px"
                                EnableBrowserContextArticle="False" AutoConfigure="Simple">
                                <FrameStyle Height="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="#DDDDDD"
                                    Width="100%" CssClass="CuteEditorFrame" BackColor="White"></FrameStyle>
                            </CE:Editor>
                            <asp:RequiredFieldValidator ID="rfvSizeChart" runat="server" ControlToValidate="txtSizeChart"
                                ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="SizeChart"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="footer-buttons">
                                <asp:Button CssClass="btn" ID="btnExitProduct" runat="server" Width="60px" CausesValidation="false"
                                    Text="Exit" />
                                <asp:Button CssClass="btn" ID="btnResetProduct" runat="server" Width="60px" CausesValidation="false"
                                    Text="Reset" />
                                <asp:Button CssClass="btn" ID="btnSaveOtherLanguageProduct" runat="server" Width="160px"
                                    ValidationGroup="AddEditProduct" Text="Save Other Language" NotificationOperationDone="true" />
                                <asp:Button CssClass="btn" ID="btnSaveProduct" runat="server" Width="60px" ValidationGroup="AddEditProduct"
                                    Text="Save" NotificationOperationDone="true" />
                                <asp:Button CssClass="btn" ID="btnUpdateProduct" runat="server" Width="60px" ValidationGroup="AddEditProduct"
                                    Text="Update" NotificationOperationDone="true" />
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="valsumAddEditProduct" runat="server" ShowMessageBox="true"
                    ShowSummary="false" ValidationGroup="AddEditProduct" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="dvProductCatalog" runat="server" class="tabdiv">
        <asp:UpdatePanel ID="upnlProductCatalog" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="dvProductCatalogProblems" runat="server" class="dv-problem">
                </div>
                <asp:Panel ID="pnlConnectedProductCatalog" runat="server" Visible="true">
                    <div class="grid-headers">
                        <asp:Label ID="lblConnectedProductCatalog" runat="server" Text="Product Catalogs"></asp:Label>
                    </div>
                    <div class="grid-items">
                        <asp:TreeView ID="trvCatalog" ShowCheckBoxes="All" runat="server" AutoGenerateDataBindings="false"
                            PopulateNodesFromClient="true" ShowLines="true">
                        </asp:TreeView>
                    </div>
                    <div class="footer-buttons">
                        <asp:Button ID="btnSaveProductCatalog" CssClass="btn" runat="server" Width="60px"
                            Text="Save" NotificationOperationDone="true" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="dvProductFeature" runat="server" class="tabdiv">
        <asp:UpdatePanel ID="upnlProductFeature" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlProductFeature" runat="server" Visible="true">
                    <div class="grid-actions">
                        <asp:ImageButton ID="ibtnDeleteProductFeature" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                            ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                    </div>
                    <div class="grid-headers">
                        <asp:Label ID="lblProductFeature" runat="server" Text="Product Features"></asp:Label>
                    </div>
                    <div class="grid-items">
                        <asp:GridView ID="gvProductFeatures" runat="server" AllowPaging="true" PageSize="10"
                            AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                            <EmptyDataTemplate>
                                No Items found
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItem" runat="server" />
                                        <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Feature)Container.DataItem).ID%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Value" HeaderText="Value" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upnlProductFeatureDetails" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="dvProductFeatureProblems" runat="server" class="dv-problem">
                </div>
                <asp:Panel ID="pnlProductFeatureDetails" runat="server" Visible="true">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblFeature" runat="server" Text="Feature" AssociatedControlID="ddlFeature"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFeature" runat="server" Width="254">
                                </asp:DropDownList>
                                <ajax:CascadingDropDown ID="cddlFeature" runat="server" TargetControlID="ddlFeature"
                                    Category="Feature" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                                    ServicePath="~/Admin/Services/ECommerce/Feature/FeatureService.asmx" ServiceMethod="GetFilteredFeatures" />
                                <asp:RequiredFieldValidator ID="rfvFeature" runat="server" ControlToValidate="ddlFeature"
                                    ValidationGroup="AddEditFeatureValue" Display="Dynamic" ErrorMessage="Feature"
                                    InitialValue="-1">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblValue" runat="server" Text="Value" AssociatedControlID="txtValue"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nValue" runat="server" TargetControlID="txtValue"
                                    Width="100" Minimum="1" Maximum="100">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtValue" runat="server" MaxLength="4"></asp:TextBox>
                            </td>
                            <td>
                                <div class="footer-buttons">
                                    <asp:Button CssClass="btn" ID="btnSaveProductFeature" runat="server" Width="60px"
                                        ValidationGroup="AddEditFeatureValue" Text="Save" NotificationOperationDone="true" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="dvProductImage" runat="server" class="tabdiv">
        <asp:UpdatePanel ID="upnlProductImage" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlProductImages" runat="server">
                    <div class="grid-actions">
                        <asp:ImageButton ID="ibtnDeleteProductImage" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                            ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                        <asp:ImageButton ID="ibtnAddProductImage" runat="server" ImageUrl="~/App_Themes/image/add.png"
                            ToolTip="Add" CausesValidation="False"></asp:ImageButton>
                    </div>
                    <div class="grid-headers">
                        <asp:Label ID="lblProductImage" runat="server" Text="Prodcut Images"></asp:Label>
                    </div>
                    <div>
                        <asp:DataList ID="dlsProductImage" runat="server" RepeatLayout="Table" RepeatColumns="4"
                            CssClass="grd" RepeatDirection="Vertical" Width="100%">
                            <ItemTemplate>
                                <div class="glry-item">
                                    <div class="Gallery-img">
                                        <asp:CheckBox ID="chkItem" runat="server" />
                                        <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID%>' />
                                        <asp:Image ID="imgProductImage" ToolTip='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>'
                                            Width="70" Height="70" runat="server" ImageUrl='<%# GetProdcutImageFile(((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).Image)%>' />
                                    </div>
                                    <div class="Gallery-name">
                                        <%#((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID+": "+ ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="Gallery-item" />
                        </asp:DataList>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlProductImageDetails" runat="server" Visible="false">
                    <div id="dvProdcutImageProblems" runat="server" class="dv-problem">
                    </div>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblCaption" runat="server" Text="Caption" AssociatedControlID="txtCaption"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCaption" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCaption" runat="server" ControlToValidate="txtCaption"
                                    ValidationGroup="AddEditProductImage" Text="*" Display="Dynamic" ErrorMessage="Caption"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIsCoverImage" runat="server" Text="CoverImage" AssociatedControlID="cbIsCoverImage"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="cbIsCoverImage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImage" runat="server" Text="Image" AssociatedControlID="ucSWFUploadProductImage"></asp:Label>
                            </td>
                            <td>
                                <controls:SWFUpload_UC ID="ucSWFUploadProductImage" runat="server" UploadPage="~/Controls/SWFUpload/frmSWFUpload.ashx"
                                    ProgressTitle="Files Upload" TotalFilesQueueLimit="10" TotalFilesUploadLimit="10"
                                    UploadFileSizeLimit="20 MB" OnUploadComplete="" FileTypeDescription="Images"
                                    ValidationGroup="AddEditProductImage" FileTypes="*.gif; *.png; *.jpg; *.jpeg; *.bmp"
                                    ButtonImageUrl="~/App_Themes/Image/button_upload.png" ButtonTextLeftPadding="12"
                                    ButtonTextTopPadding="3" ButtonText="Click To Upload" />
                            </td>
                        </tr>
                    </table>
                    <div class="footer-buttons">
                        <asp:Button ID="btnExitProdcutImage" CssClass="btn" runat="server" Width="60px" Text="Exit"
                            NotificationOperationDone="false" CausesValidation="false" />
                        <asp:Button ID="btnSaveProdcutImage" CssClass="btn" runat="server" Width="60px" Text="Save"
                            NotificationOperationDone="true" ValidationGroup="AddEditProductImage" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="dvProductPrice" runat="server" class="tabdiv">
        Under Construction
    </div>
    <div id="dvCombinationProduct" runat="server" class="tabdiv">
        <asp:UpdatePanel ID="upnlCombinationProduct" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlCombinationProduct" runat="server" Visible="true">
                    <div class="grid-actions">
                        <asp:ImageButton ID="ibtnAddCombinationProduct" runat="server" ImageUrl="~/App_Themes/image/add.png"
                            ToolTip="Add" CausesValidation="False"></asp:ImageButton>
                        <asp:ImageButton ID="ibtnDeleteCombinationProduct" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                            ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                    </div>
                    <div class="grid-headers">
                        <asp:Label ID="lblCombinationProduct" runat="server" Text="Combination Product"></asp:Label>
                    </div>
                    <div class="grid-items">
                        <asp:GridView ID="gvCombinationProducts" runat="server" AllowPaging="true" PageSize="10"
                            AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                            <EmptyDataTemplate>
                                No Items found
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItem" runat="server" />
                                        <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.CombinationProduct)Container.DataItem).ID%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:TemplateField HeaderText="Product Reference">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEditCombination" runat="server" Text='<%#((AJH.CMS.Core.Entities.CombinationProduct)Container.DataItem).ProductReference%>'
                                            CommandArgument='<%# ((AJH.CMS.Core.Entities.CombinationProduct)Container.DataItem).ID%>'
                                            CommandName="EditCombination"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="50%" />
                                    <HeaderStyle Width="50%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Location" HeaderText="Location" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upnlCombinationProductDetails" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="dvCombinationProductProblems" runat="server" class="dv-problem">
                </div>
                <asp:Panel ID="pnlCombinationProductDetails" runat="server" Visible="true">
                    <controls:PortalLanguages_UC ID="ucCombinationProductLanguage" runat="server" Visible="false"
                        ValidationGroup="AddCombinationProduct" />
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblProductReference" runat="server" Text="ProductReference" AssociatedControlID="txtProductReference"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProductReference" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProductReference" runat="server" ControlToValidate="txtProductReference"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Product Reference"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationEan13" runat="server" Text="Ean13" AssociatedControlID="txtCombinationEan13"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCombinationEan13" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCombinationEan13" runat="server" ControlToValidate="txtCombinationEan13"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Ean13"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationUPC" runat="server" Text="UPC" AssociatedControlID="txtCombinationUPC"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCombinationUPC" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCombinationUPC" runat="server" ControlToValidate="txtCombinationUPC"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="UPC"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationSupplier" runat="server" Text="Supplier" AssociatedControlID="ddlCombinationSupplier"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCombinationSupplier" runat="server" Width="254">
                                </asp:DropDownList>
                                <ajax:CascadingDropDown ID="cddCombinationSupplier" runat="server" TargetControlID="ddlCombinationSupplier"
                                    Category="Supplier" PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]"
                                    ServicePath="~/Admin/Services/ECommerce/Supplier/SupplierService.asmx" ServiceMethod="GetAllSuppliers" />
                                <asp:RequiredFieldValidator ID="rfvlCombinationSupplier" runat="server" ControlToValidate="ddlCombinationSupplier"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Supplier"
                                    InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblWholesalePrice" runat="server" Text="Wholesale Price" AssociatedControlID="txtWholesalePrice"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nWholesalePrice" runat="server" TargetControlID="txtWholesalePrice"
                                    Width="100" Minimum="1">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtWholesalePrice" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvWholesalePrice" runat="server" ControlToValidate="txtWholesalePrice"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Wholesale Price"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImpactOnPrice" runat="server" Text="Impact On Price" AssociatedControlID="txtImpactOnPrice"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nImpactOnPrice" runat="server" TargetControlID="txtImpactOnPrice"
                                    Width="100" Minimum="1">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtImpactOnPrice" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvImpactOnPrice" runat="server" ControlToValidate="txtImpactOnPrice"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Wholesale Price"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImpactOnWeight" runat="server" Text="Impact On Weight" AssociatedControlID="txtImpactOnWeight"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nImpactOnWeight" runat="server" TargetControlID="txtImpactOnWeight"
                                    Width="100" Minimum="1">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtImpactOnWeight" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvImpactOnWeight" runat="server" ControlToValidate="txtImpactOnWeight"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Wholesale Price"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationInitialStock" runat="server" Text="Initial Stock" AssociatedControlID="txtCombinationInitialStock"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nCombinationInitialStock" runat="server" TargetControlID="txtCombinationInitialStock"
                                    Width="100" Minimum="1">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtCombinationInitialStock" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCombinationInitialStock" runat="server" ControlToValidate="txtCombinationInitialStock"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Wholesale Price"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationInitialQuantity" runat="server" Text="Quantity" AssociatedControlID="txtCombinationInitialQuantity"></asp:Label>
                            </td>
                            <td>
                                <ajax:NumericUpDownExtender ID="nCombinationInitialQuantity" runat="server" TargetControlID="txtCombinationInitialQuantity"
                                    Width="100" Minimum="1">
                                </ajax:NumericUpDownExtender>
                                <asp:TextBox ID="txtCombinationInitialQuantity" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCombinationInitialQuantity" runat="server" ControlToValidate="txtCombinationInitialQuantity"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Wholesale Price"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIsDefault" runat="server" Text="Default" AssociatedControlID="cbIsDefault"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="cbIsDefault" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationColor" runat="server" Text="Color" AssociatedControlID="ucColorPicker"></asp:Label>
                            </td>
                            <td>
                                <controls:Color_Picker_UC ID="ucColorPicker" runat="server"></controls:Color_Picker_UC>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCombinationLocation" runat="server" Text="Location" AssociatedControlID="txtCombinationLocation"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCombinationLocation" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCombinationLocation" runat="server" ControlToValidate="txtCombinationLocation"
                                    ValidationGroup="AddEditCombinationProduct" Text="*" Display="Dynamic" ErrorMessage="Location"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div class="footer-buttons">
                                    <asp:Button CssClass="btn" ID="btnSaveCombinationProduct" runat="server" Width="60px"
                                        ValidationGroup="AddEditCombinationProduct" Text="Save" NotificationOperationDone="true" />
                                    <asp:Button CssClass="btn" ID="btnUpdateCombinationProduct" runat="server" Width="60px"
                                        ValidationGroup="AddEditCombinationProduct" Text="Update" NotificationOperationDone="true" />
                                    <asp:Button CssClass="btn" ID="btnSaveCombinationProductOtherLanguage" runat="server"
                                        Width="160px" ValidationGroup="AddEditCombinationProduct" Text="Save Other Language"
                                        NotificationOperationDone="true" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCombinationAttributes" runat="server" Style="display: none;">
                    <asp:Panel ID="pnlConnectedCombinationAttribute" runat="server">
                        <div class="grid-actions">
                            <asp:ImageButton ID="ibtnDeleteConnectedCombinationAttribute" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                                ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                        </div>
                        <div class="grid-headers">
                            <asp:Label ID="lblConnectedCombinationAttribute" runat="server" Text="Combination Attributes"></asp:Label>
                        </div>
                        <div class="grid-items">
                            <asp:GridView ID="gvConnectedCombinationAttributes" runat="server" AllowPaging="true"
                                PageSize="10" AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                                <EmptyDataTemplate>
                                    No Items found
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkItem" runat="server" />
                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Attribute)Container.DataItem).ID%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlNotConnectedCombinationAttribute" runat="server">
                        <div class="grid-headers">
                            <asp:Label ID="lblNotConnectedCombinationAttribute" runat="server" Text="Product Attributes"></asp:Label>
                        </div>
                        <div>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGroup" runat="server" Text="Group" AssociatedControlID="ddlGroup"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGroup" runat="server" Width="254">
                                        </asp:DropDownList>
                                        <ajax:CascadingDropDown ID="cddGroup" runat="server" TargetControlID="ddlGroup" Category="Group"
                                            PromptValue="-1" PromptText="[Select]" LoadingText="[Loading...]" ServicePath="~/Admin/Services/ECommerce/Group/GroupService.asmx"
                                            ServiceMethod="GetAllGroups" />
                                        <asp:ImageButton ID="ibtnFillGroupAttributes" runat="server" ImageUrl="~/App_Themes/Image/ddl_enter.png"
                                            ToolTip="Search" CssClass="btn-search" />
                                        <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup"
                                            ValidationGroup="AddEditAttribute" InitialValue="-1" Text="*" Display="Dynamic"
                                            ErrorMessage="Group"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="grid-items">
                            <asp:GridView ID="gvNotConnectedCombinationAttributes" runat="server" AllowPaging="true"
                                PageSize="10" AutoGenerateColumns="false" CssClass="grd" Width="100%" DataKeyNames="ID">
                                <EmptyDataTemplate>
                                    No Items found
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkItem" runat="server" />
                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.Attribute)Container.DataItem).ID%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="footer-buttons">
                            <asp:Button ID="btnSaveCombinationAttribute" CssClass="btn" runat="server" Width="60px"
                                Text="Save" NotificationOperationDone="true" />
                        </div>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel ID="pnlCombinationImage" runat="server" Style="display: none;">
                    <div>
                        <div class="grid-actions">
                            <asp:ImageButton ID="ibtnDeleteCombinationImage" runat="server" ImageUrl="~/App_Themes/image/delete.png"
                                ToolTip="Delete" NotificationOperationDone="true"></asp:ImageButton>
                        </div>
                        <div class="grid-headers">
                            <asp:Label ID="lblConnectedCombinationImage" runat="server" Text="Combination Images"></asp:Label>
                        </div>
                        <div>
                            <asp:DataList ID="dlsConnectedCombinationImage" runat="server" RepeatLayout="Table"
                                RepeatColumns="4" CssClass="grd" RepeatDirection="Vertical" Width="100%">
                                <ItemTemplate>
                                    <div class="glry-item">
                                        <div class="Gallery-img">
                                            <asp:CheckBox ID="chkItem" runat="server" />
                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID%>' />
                                            <asp:Image ID="imgAllProdcutImage" ToolTip='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>'
                                                Width="70" Height="70" runat="server" ImageUrl='<%# GetProdcutImageFile(((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).Image)%>' />
                                        </div>
                                        <div class="Gallery-name">
                                            <%#((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID+": "+ ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle CssClass="Gallery-item" />
                            </asp:DataList>
                        </div>
                    </div>
                    <div>
                        <div class="grid-headers">
                            <asp:Label ID="lblAllProdcutImage" runat="server" Text="Prodcut Images"></asp:Label>
                        </div>
                        <div>
                            <asp:DataList ID="dlsAllProdcutImage" runat="server" RepeatLayout="Table" RepeatColumns="4"
                                CssClass="grd" RepeatDirection="Vertical" Width="100%">
                                <ItemTemplate>
                                    <div class="glry-item">
                                        <div class="Gallery-img">
                                            <asp:CheckBox ID="chkItem" runat="server" />
                                            <input type="hidden" id="hdnID" runat="server" value='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID%>' />
                                            <asp:Image ID="imgAllProdcutImage" ToolTip='<%# ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>'
                                                Width="70" Height="70" runat="server" ImageUrl='<%# GetProdcutImageFile(((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).Image)%>' />
                                        </div>
                                        <div class="Gallery-name">
                                            <%#((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ID+": "+ ((AJH.CMS.Core.Entities.ProductImage)Container.DataItem).ImageCaption%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle CssClass="Gallery-item" />
                            </asp:DataList>
                        </div>
                        <div class="footer-buttons">
                            <asp:Button ID="btnSaveCombinationImage" CssClass="btn" runat="server" Width="60px"
                                Text="Save" NotificationOperationDone="true" ValidationGroup="AddEditProductImage" />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
