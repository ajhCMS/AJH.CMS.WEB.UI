using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageProducts_UC : System.Web.UI.UserControl
    {
        #region Properties

        private int SelecedProductId
        {
            get
            {
                int productId = -1;

                if (ViewState[CMSConfig.ConstantManager.ProductID] != null)
                    productId = Convert.ToInt32(ViewState[CMSConfig.ConstantManager.ProductID]);

                return productId;
            }
            set
            {
                ViewState[CMSConfig.ConstantManager.ProductID] = value;
            }
        }

        private int SelecedCombinationProductId
        {
            get
            {
                int combinationProductId = -1;

                if (ViewState[CMSConfig.ConstantManager.CombinationProductID] != null)
                    combinationProductId = Convert.ToInt32(ViewState[CMSConfig.ConstantManager.CombinationProductID]);

                return combinationProductId;
            }
            set
            {
                ViewState[CMSConfig.ConstantManager.CombinationProductID] = value;
            }
        }

        #endregion

        #region General Events

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(ManageProducts_UC_Load);

            #region Product event

            this.btnSaveProduct.Click += new EventHandler(btnSaveProduct_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguageProduct.Click += new EventHandler(btnSaveOtherLanguageProduct_Click);
            this.btnUpdateProduct.Click += new EventHandler(btnUpdateProduct_Click);

            #endregion

            #region Product Catalog Events

            this.btnSaveProductCatalog.Click += new EventHandler(btnSaveProductCatalog_Click);

            #endregion

            #region Product Feature Events

            this.btnSaveProductFeature.Click += new EventHandler(btnSaveProductFeature_Click);
            this.ibtnDeleteProductFeature.Click += new ImageClickEventHandler(ibtnDeleteProductFeature_Click);

            #endregion

            #region Prodcut Image Events

            this.ibtnAddProductImage.Click += new ImageClickEventHandler(ibtnAddProductImage_Click);
            this.ibtnDeleteProductImage.Click += new ImageClickEventHandler(ibtnDeleteProductImage_Click);
            this.btnSaveProdcutImage.Click += new EventHandler(btnSaveProdcutImage_Click);
            this.btnExitProdcutImage.Click += new EventHandler(btnExitProdcutImage_Click);

            #endregion

            #region Combination Product Events

            this.ibtnAddCombinationProduct.Click += new ImageClickEventHandler(ibtnAddCombinationProduct_Click);
            this.btnSaveCombinationProduct.Click += new EventHandler(btnSaveCombinationProduct_Click);
            this.ibtnDeleteCombinationProduct.Click += new ImageClickEventHandler(ibtnDeleteCombinationProduct_Click);
            this.gvCombinationProducts.RowCommand += new GridViewCommandEventHandler(gvCombinationProducts_RowCommand);
            this.ucCombinationProductLanguage.OnSelectLanguage += new EventHandler(ucCombinationProductLanguage_OnSelectLanguage);
            this.btnUpdateCombinationProduct.Click += new EventHandler(btnUpdateCombinationProduct_Click);
            this.btnSaveCombinationProductOtherLanguage.Click += new EventHandler(btnSaveCombinationProductOtherLanguage_Click);
            this.ibtnDeleteCombinationImage.Click += new ImageClickEventHandler(ibtnDeleteCombinationImage_Click);
            this.btnSaveCombinationImage.Click += new EventHandler(btnSaveCombinationImage_Click);
            this.ibtnFillGroupAttributes.Click += new ImageClickEventHandler(ibtnFillGroupAttributes_Click);
            this.ibtnDeleteConnectedCombinationAttribute.Click += new ImageClickEventHandler(ibtnDeleteConnectedCombinationAttribute_Click);
            this.btnSaveCombinationAttribute.Click += new EventHandler(btnSaveCombinationAttribute_Click);
            #endregion

            base.OnInit(e);
        }

        void ibtnFillGroupAttributes_Click(object sender, ImageClickEventArgs e)
        {
            gvNotConnectedCombinationAttributes.DataSource = new List<AJH.CMS.Core.Entities.Attribute>();

            int groupId = -1;
            int.TryParse(cddGroup.SelectedValue, out groupId);
            if (groupId > 0)
            {
                List<AJH.CMS.Core.Entities.Attribute> combinationAttributes = AttributeManager.GetAttributesByCombinationID(SelecedCombinationProductId, CMSContext.LanguageID);
                List<AJH.CMS.Core.Entities.Attribute> groupAttributes = AttributeManager.GetAttributesByGroupID(groupId, CMSContext.LanguageID);

                if (combinationAttributes != null && groupAttributes != null)
                {
                    List<int> combinationAttributesIds = combinationAttributes.Select(ca => ca.ID).ToList();

                    groupAttributes = groupAttributes.Where(ga => !combinationAttributesIds.Contains(ga.ID)).ToList();
                }
                gvNotConnectedCombinationAttributes.DataSource = groupAttributes;
            }

            gvNotConnectedCombinationAttributes.DataBind();

            upnlCombinationProductDetails.Update();
        }

        #endregion

        #region Product Events

        void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {

                if (SelecedProductId > 0)
                {
                    Product product = ProductManager.GetProduct(SelecedProductId, CMSContext.PortalID, ucPortalLanguage.SelectedLanguageID);
                    if (product != null)
                    {
                        product.Name = txtName.Text;
                        product.Description = txtDescription.Text;
                        product.DisplayTextInStockText = txtDisplayTextInStock.Text;
                        product.DisplayTextInBackOrderText = txtDisplayTextWhenbackOrder.Text;
                        product.ShortDescription = txtShortDescription.Text;
                        product.Tags = txtTags.Text;
                        product.SupplierID = Convert.ToInt32(cddlSupplier.SelectedValue);
                        product.Ean13OrJan = txtEAN13.Text;
                        product.UPC = txtUpc.Text;
                        product.Location = txtLocation.Text;
                        product.IsDownloadable = cbIsDownloadable.Checked;
                        product.DisplayOnSaleIcon = cbDisplayOnSaleIcon.Checked;
                        product.InitialStock = Convert.ToInt32(txtInitialStock.Text);
                        product.MinimumQuantity = Convert.ToInt32(txtMinimumQuantity.Text);
                        product.AdditionalShippingCost = Convert.ToDecimal(txtAdditionalShippingCost.Text);
                        product.ManufacturarID = Convert.ToInt32(cddlManufacturar.SelectedValue);
                        product.IsEnabled = cbIsEnabled.Checked;
                        product.TaxID = Convert.ToInt32(cddlTax.SelectedValue);
                        product.SizeChart = txtSizeChart.Text;
                        product.LanguageID = ucPortalLanguage.SelectedLanguageID;

                        ProductManager.Update(product);
                    }
                }
            }
            catch (Exception ex)
            {
                dvProductProblems.Visible = true;
                dvProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProduct.Update();
            }
        }

        void btnSaveOtherLanguageProduct_Click(object sender, EventArgs e)
        {
            //ToDO : to update product information and then add language part
            try
            {
                if (SelecedProductId > 0)
                {
                    Product product = new Product();
                    if (product != null)
                    {
                        product.Name = txtName.Text;
                        product.Description = txtDescription.Text;
                        product.DisplayTextInStockText = txtDisplayTextInStock.Text;
                        product.DisplayTextInBackOrderText = txtDisplayTextWhenbackOrder.Text;
                        product.ShortDescription = txtShortDescription.Text;
                        product.Tags = txtTags.Text;
                        product.Location = txtLocation.Text;
                        product.SizeChart = txtSizeChart.Text;
                        product.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        product.PortalID = CMSContext.PortalID;
                        product.ID = SelecedProductId;
                        ProductManager.AddOtherLanguage(product);
                    }
                }
            }
            catch (Exception ex)
            {
                dvProductProblems.Visible = true;
                dvProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProduct.Update();
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (SelecedProductId > 0)
            {
                BeginProductEditModeOtherLanguage(SelecedProductId, ucPortalLanguage.SelectedLanguageID);
                upnlProduct.Update();
            }
        }

        void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    DisplayTextInStockText = txtDisplayTextInStock.Text,
                    DisplayTextInBackOrderText = txtDisplayTextWhenbackOrder.Text,
                    ShortDescription = txtShortDescription.Text,
                    Tags = txtTags.Text,
                    SupplierID = Convert.ToInt32(cddlSupplier.SelectedValue),
                    Ean13OrJan = txtEAN13.Text,
                    UPC = txtUpc.Text,
                    Location = txtLocation.Text,
                    IsDownloadable = cbIsDownloadable.Checked,
                    DisplayOnSaleIcon = cbDisplayOnSaleIcon.Checked,
                    InitialStock = Convert.ToInt32(txtInitialStock.Text),
                    MinimumQuantity = Convert.ToInt32(txtMinimumQuantity.Text),
                    AdditionalShippingCost = Convert.ToDecimal(txtAdditionalShippingCost.Text),
                    ManufacturarID = Convert.ToInt32(cddlManufacturar.SelectedValue),
                    IsEnabled = cbIsEnabled.Checked,
                    TaxID = Convert.ToInt32(cddlTax.SelectedValue),
                    SizeChart = txtSizeChart.Text,

                    IsDeleted = false,
                    LanguageID = CMSContext.LanguageID,
                    PortalID = CMSContext.PortalID,
                    ModuleID = (int)CMSEnums.ECommerceModule.Product,
                };

                ProductManager.Add(product);
                // ViewState[CMSConfig.ConstantManager.ProductID] = product.ID;

                BeginProductAddMode();
            }
            catch (Exception ex)
            {
                dvProductProblems.Visible = true;
                dvProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProduct.Update();
                //upnlProductCatalog.Update();
                //upnlProductFeature.Update();
                //upnlProductImage.Update();
                //upnlCombinationProduct.Update();
            }
        }

        void ManageProducts_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();

            if (!IsPostBack)
            {
                Performsettings();
                ManageProductMode();
            }
        }

        #endregion

        #region Product Catalog Events

        void btnSaveProductCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = SelecedProductId;
                CatalogManager.DeleteProductCatalogByProductID(productId);

                TreeNodeCollection checkedNodes = trvCatalog.CheckedNodes;

                if (checkedNodes != null)
                {
                    foreach (TreeNode node in checkedNodes)
                    {
                        CatalogManager.AddProductCatalog(productId, Convert.ToInt32(node.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                dvProductCatalogProblems.Visible = true;
                dvProductCatalogProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProductCatalog.Update();
            }
        }

        #endregion

        #region Product Features Events

        void ibtnDeleteProductFeature_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvProductFeatures.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvProductFeatures.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvProductFeatures.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int featureId = Convert.ToInt32(hdnID.Value);
                        FeatureManager.DeleteProductFeature(featureId, SelecedProductId);
                    }
                }
            }
            FillProductFeatures(SelecedProductId);
            upnlProductFeature.Update();
        }

        void btnSaveProductFeature_Click(object sender, EventArgs e)
        {
            try
            {
                int featureId = -1;
                int.TryParse(cddlFeature.SelectedValue, out featureId);
                if (featureId > 0 && SelecedProductId > 0)
                {
                    FeatureManager.DeleteProductFeature(featureId, SelecedProductId);
                    FeatureManager.AddProductFeature(featureId,
                        SelecedProductId, Convert.ToInt32(txtValue.Text));

                    FillProductFeatures(SelecedProductId);
                }

            }
            catch (Exception ex)
            {
                dvProductFeatureProblems.Visible = true;
                dvProductFeatureProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProductFeature.Update();
            }

        }

        #endregion

        #region Product Image Events

        void btnSaveProdcutImage_Click(object sender, EventArgs e)
        {
            try
            {
                ProductImage productImage = null;
                List<string> imagesNames = ucSWFUploadProductImage.GetFilesName();

                if (imagesNames != null && imagesNames.Count > 0)
                {
                    for (int i = 0; i <= imagesNames.Count - 1; i++)
                    {
                        productImage = new ProductImage
                        {
                            Image = imagesNames[i],
                            ImageCaption = txtCaption.Text,
                            IsCoverImage = cbIsCoverImage.Checked,
                            LanguageID = CMSContext.LanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.ProductImage,
                            IsDeleted = false,
                            ProductID = SelecedProductId,
                        };

                        ProductImageManager.Add(productImage);
                    }
                }

                FillProdcutImages(SelecedProductId);
                BeginProductImageAddMode();
            }
            catch (Exception ex)
            {
                dvProdcutImageProblems.Visible = true;
                dvProdcutImageProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlProductImage.Update();
            }
        }

        void btnExitProdcutImage_Click(object sender, EventArgs e)
        {
            BeginProductImageAddMode();
            pnlProductImageDetails.Visible = false;
        }

        void ibtnDeleteProductImage_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < dlsProductImage.Items.Count; i++)
            {
                CheckBox chkItem = (CheckBox)dlsProductImage.Items[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)dlsProductImage.Items[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int imageId = Convert.ToInt32(hdnID.Value);
                        ProductImageManager.DeleteLogical(imageId);
                    }
                }
            }
            FillProdcutImages(SelecedProductId);
            upnlProductImage.Update();
        }

        void ibtnAddProductImage_Click(object sender, ImageClickEventArgs e)
        {
            pnlProductImageDetails.Visible = true;
            BeginProductImageAddMode();
        }

        #endregion

        #region Combination Product Events

        void ibtnAddCombinationProduct_Click(object sender, ImageClickEventArgs e)
        {
            BeginCombinationProductAddMode();
            upnlCombinationProductDetails.Update();
        }

        void btnSaveCombinationProduct_Click(object sender, EventArgs e)
        {
            try
            {
                CombinationProduct combinationProduct = new CombinationProduct();

                combinationProduct.Color = ucColorPicker.SelectedColor;
                combinationProduct.ImpactOnPrice = Convert.ToInt32(txtImpactOnPrice.Text);
                combinationProduct.ImpactOnWeight = Convert.ToInt32(txtImpactOnWeight.Text);
                combinationProduct.InitialStock = Convert.ToInt32(txtCombinationInitialStock.Text);
                combinationProduct.IsDefault = cbIsDefault.Checked;
                combinationProduct.IsDeleted = false;
                combinationProduct.LanguageID = CMSContext.LanguageID;
                combinationProduct.ModuleID = (int)CMSEnums.ECommerceModule.CombinationProduct;
                combinationProduct.ProductID = SelecedProductId;
                combinationProduct.Location = txtCombinationLocation.Text;
                combinationProduct.MinimumQuantity = Convert.ToInt32(txtCombinationInitialQuantity.Text);
                combinationProduct.PortalID = CMSContext.PortalID;
                combinationProduct.ProductEAN13 = txtCombinationEan13.Text;
                combinationProduct.ProductReference = txtProductReference.Text;
                combinationProduct.ProductUPC = txtCombinationUPC.Text;

                combinationProduct.SupplierRefernce = Convert.ToInt32(cddCombinationSupplier.SelectedValue);
                combinationProduct.WholesalePrice = Convert.ToDecimal(txtWholesalePrice.Text);

                CombinationProductManager.Add(combinationProduct);
                FillCombinationProduct(SelecedProductId);
            }
            catch (Exception ex)
            {
                dvCombinationProductProblems.Visible = true;
                dvCombinationProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlCombinationProduct.Update();
                upnlCombinationProductDetails.Update();
            }
        }

        void btnSaveCombinationProductOtherLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelecedCombinationProductId > 0)
                {
                    CombinationProduct combinationProduct =
                        CombinationProductManager.GetCombinationProduct(SelecedCombinationProductId, ucCombinationProductLanguage.SelectedLanguageID);

                    combinationProduct.Color = ucColorPicker.SelectedColor;
                    combinationProduct.ImpactOnPrice = Convert.ToInt32(txtImpactOnPrice.Text);
                    combinationProduct.ImpactOnWeight = Convert.ToInt32(txtImpactOnWeight.Text);
                    combinationProduct.InitialStock = Convert.ToInt32(txtCombinationInitialStock.Text);
                    combinationProduct.IsDefault = cbIsDefault.Checked;
                    combinationProduct.IsDeleted = false;
                    combinationProduct.LanguageID = ucCombinationProductLanguage.SelectedLanguageID;
                    combinationProduct.ModuleID = (int)CMSEnums.ECommerceModule.CombinationProduct;
                    combinationProduct.ProductID = SelecedProductId;

                    combinationProduct.MinimumQuantity = Convert.ToInt32(txtCombinationInitialQuantity.Text);
                    combinationProduct.PortalID = CMSContext.PortalID;
                    combinationProduct.ProductEAN13 = txtCombinationEan13.Text;
                    combinationProduct.ProductReference = txtProductReference.Text;
                    combinationProduct.ProductUPC = txtCombinationUPC.Text;

                    combinationProduct.SupplierRefernce = Convert.ToInt32(cddCombinationSupplier.SelectedValue);
                    combinationProduct.WholesalePrice = Convert.ToDecimal(txtWholesalePrice.Text);

                    CombinationProductManager.Update(combinationProduct);

                    CombinationProduct combinationProductOtherLanguage = new CombinationProduct();
                    combinationProductOtherLanguage.Location = txtCombinationLocation.Text;
                    combinationProductOtherLanguage.LanguageID = ucCombinationProductLanguage.SelectedLanguageID;
                    combinationProductOtherLanguage.ID = combinationProduct.ID;
                    combinationProductOtherLanguage.PortalID = CMSContext.PortalID;

                    CombinationProductManager.AddOtherLanguage(combinationProductOtherLanguage);

                    FillCombinationProduct(SelecedProductId);
                }
            }
            catch (Exception ex)
            {
                dvCombinationProductProblems.Visible = true;
                dvCombinationProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlCombinationProduct.Update();
                upnlCombinationProductDetails.Update();
            }

        }

        void gvCombinationProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditCombination":
                    {
                        BeginCombinationProductEditMode(Convert.ToInt32(e.CommandArgument));
                        SelecedCombinationProductId = Convert.ToInt32(e.CommandArgument);
                        upnlCombinationProductDetails.Update();

                        break;
                    }
                default:
                    break;
            }
        }

        void btnUpdateCombinationProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelecedCombinationProductId > 0)
                {
                    CombinationProduct combinationProduct =
                        CombinationProductManager.GetCombinationProduct(SelecedCombinationProductId, ucCombinationProductLanguage.SelectedLanguageID);

                    combinationProduct.Color = ucColorPicker.SelectedColor;
                    combinationProduct.ImpactOnPrice = Convert.ToInt32(txtImpactOnPrice.Text);
                    combinationProduct.ImpactOnWeight = Convert.ToInt32(txtImpactOnWeight.Text);
                    combinationProduct.InitialStock = Convert.ToInt32(txtCombinationInitialStock.Text);
                    combinationProduct.IsDefault = cbIsDefault.Checked;
                    combinationProduct.IsDeleted = false;
                    combinationProduct.LanguageID = ucCombinationProductLanguage.SelectedLanguageID;
                    combinationProduct.ModuleID = (int)CMSEnums.ECommerceModule.CombinationProduct;
                    combinationProduct.ProductID = SelecedProductId;
                    combinationProduct.Location = txtCombinationLocation.Text;
                    combinationProduct.MinimumQuantity = Convert.ToInt32(txtCombinationInitialQuantity.Text);
                    combinationProduct.PortalID = CMSContext.PortalID;
                    combinationProduct.ProductEAN13 = txtCombinationEan13.Text;
                    combinationProduct.ProductReference = txtProductReference.Text;
                    combinationProduct.ProductUPC = txtCombinationUPC.Text;

                    combinationProduct.SupplierRefernce = Convert.ToInt32(cddCombinationSupplier.SelectedValue);
                    combinationProduct.WholesalePrice = Convert.ToDecimal(txtWholesalePrice.Text);

                    CombinationProductManager.Update(combinationProduct);
                    FillCombinationProduct(SelecedProductId);
                }
            }
            catch (Exception ex)
            {
                dvCombinationProductProblems.Visible = true;
                dvCombinationProductProblems.InnerText = ex.ToString();
            }
            finally
            {
                upnlCombinationProduct.Update();
                upnlCombinationProductDetails.Update();
            }
        }

        void ucCombinationProductLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            BeginCombinationProductEditModeOtherLanguage(SelecedCombinationProductId, ucCombinationProductLanguage.SelectedLanguageID);
            upnlCombinationProductDetails.Update();
        }

        void ibtnDeleteCombinationProduct_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvCombinationProducts.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvCombinationProducts.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvCombinationProducts.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int combinationId = Convert.ToInt32(hdnID.Value);
                        CombinationProductManager.DeleteLogical(combinationId);
                    }
                }
            }
            FillCombinationProduct(SelecedProductId);
            upnlCombinationProduct.Update();
            upnlCombinationProductDetails.Update();
        }

        void ibtnDeleteCombinationImage_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < dlsConnectedCombinationImage.Items.Count; i++)
            {
                if (dlsConnectedCombinationImage.Items[i].ItemType == ListItemType.Item || dlsConnectedCombinationImage.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkItem = (CheckBox)dlsConnectedCombinationImage.Items[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)dlsConnectedCombinationImage.Items[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int combinationImageId = Convert.ToInt32(hdnID.Value);
                            CombinationProductManager.DeleteCombinationImage(SelecedCombinationProductId, combinationImageId);
                        }
                    }
                }
            }

            BeginCombinationProductEditMode(SelecedCombinationProductId);
            upnlCombinationProduct.Update();
            upnlCombinationProductDetails.Update();
        }

        void btnSaveCombinationAttribute_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvNotConnectedCombinationAttributes.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvNotConnectedCombinationAttributes.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvNotConnectedCombinationAttributes.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int attributeId = Convert.ToInt32(hdnID.Value);
                        CombinationProductManager.AddCombinationAttribute(SelecedCombinationProductId, attributeId);
                    }
                }
            }

            BeginCombinationProductEditMode(SelecedCombinationProductId);
            upnlCombinationProduct.Update();
            upnlCombinationProductDetails.Update();
        }

        void ibtnDeleteConnectedCombinationAttribute_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvConnectedCombinationAttributes.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvConnectedCombinationAttributes.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvConnectedCombinationAttributes.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int attributeId = Convert.ToInt32(hdnID.Value);
                        CombinationProductManager.DeleteCombinationAttribute(SelecedCombinationProductId, attributeId);
                    }
                }
            }

            BeginCombinationProductEditMode(SelecedCombinationProductId);
            upnlCombinationProduct.Update();
            upnlCombinationProductDetails.Update();
        }

        void btnSaveCombinationImage_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dlsAllProdcutImage.Items.Count; i++)
            {
                if (dlsAllProdcutImage.Items[i].ItemType == ListItemType.Item || dlsAllProdcutImage.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkItem = (CheckBox)dlsAllProdcutImage.Items[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)dlsAllProdcutImage.Items[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int combinationImageId = Convert.ToInt32(hdnID.Value);
                            CombinationProductManager.AddCombinationImage(SelecedCombinationProductId, combinationImageId);
                        }
                    }
                }
            }

            BeginCombinationProductEditMode(SelecedCombinationProductId);
            upnlCombinationProduct.Update();
            upnlCombinationProductDetails.Update();
        }

        #endregion

        #region Methods

        #region General Methods

        private void Performsettings()
        {
            ibtnDeleteProductImage.OnClientClick = "return ConfirmOperation('" + dlsProductImage.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnDeleteCombinationProduct.OnClientClick = "return ConfirmOperation('" + gvCombinationProducts.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnDeleteConnectedCombinationAttribute.OnClientClick = "return ConfirmOperation('" + gvConnectedCombinationAttributes.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnDeleteProductFeature.OnClientClick = "return ConfirmOperation('" + gvProductFeatures.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnDeleteCombinationImage.OnClientClick = "return ConfirmOperation('" + dlsConnectedCombinationImage.ClientID + "','Are you sure to delete this item(s)?');";
            btnSaveCombinationImage.OnClientClick = "return ConfirmOperation('" + dlsAllProdcutImage.ClientID + "','Are you sure to Add this item(s)?');";
            btnSaveCombinationAttribute.OnClientClick = "return ConfirmOperation('" + gvNotConnectedCombinationAttributes.ClientID + "','Are you sure to Add this item(s)?');";
        }

        #endregion

        #region Product Methods

        private void ManageProductMode()
        {
            if (string.IsNullOrEmpty(Request.QueryString[CMSConfig.QueryString.ProdcutID]))
            {
                BeginProductAddMode();
            }
            else
            {
                int productId = 0;
                int.TryParse(Request.QueryString[CMSConfig.QueryString.ProdcutID], out productId);

                if (productId > 0)
                {
                    ViewState[CMSConfig.ConstantManager.ProductID] = productId;
                    BeginProductEditMode(productId);
                }
                else
                    BeginProductAddMode();
            }
        }

        private void BeginProductAddMode()
        {
            SelecedProductId = -1;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDisplayTextInStock.Text = string.Empty;
            txtDisplayTextWhenbackOrder.Text = string.Empty;
            txtShortDescription.Text = string.Empty;
            txtTags.Text = string.Empty;
            cddlSupplier.SelectedValue = cddlSupplier.PromptValue;
            txtEAN13.Text = string.Empty;
            txtUpc.Text = string.Empty;
            txtLocation.Text = string.Empty;
            cbIsDownloadable.Checked = false;
            cbDisplayOnSaleIcon.Checked = false;
            txtInitialStock.Text = string.Empty;
            txtMinimumQuantity.Text = string.Empty;
            txtAdditionalShippingCost.Text = string.Empty;
            cddlManufacturar.SelectedValue = cddlManufacturar.PromptValue;
            cbIsEnabled.Checked = false;

            cddlTax.SelectedValue = cddlTax.PromptValue;
            txtSizeChart.Text = string.Empty;

            btnUpdateProduct.Visible = false;
            btnSaveProduct.Visible = true;
            btnSaveOtherLanguageProduct.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            liProductCatalog.Visible = false;
            liProductFeature.Visible = false;
            liProductImage.Visible = false;
            liProductPrice.Visible = false;
            liCombinationProduct.Visible = false;


            dvProductCatalog.Visible = false;
            dvProductFeature.Visible = false;
            dvProductImage.Visible = false;
            dvProductPrice.Visible = false;
            dvCombinationProduct.Visible = false;

        }

        private void BeginProductEditMode(int productID)
        {
            if (productID > 0)
            {
                Product product = ProductManager.GetProduct(productID, CMSContext.PortalID, CMSContext.LanguageID);
                if (product != null)
                {
                    txtName.Text = product.Name;
                    txtDescription.Text = product.Description;
                    txtDisplayTextInStock.Text = product.DisplayTextInStockText;
                    txtDisplayTextWhenbackOrder.Text = product.DisplayTextInBackOrderText;
                    txtShortDescription.Text = product.ShortDescription;
                    txtTags.Text = product.Tags;
                    cddlSupplier.SelectedValue = product.SupplierID.ToString();
                    txtEAN13.Text = product.Ean13OrJan;
                    txtUpc.Text = product.UPC;
                    txtLocation.Text = product.Location;
                    cbIsDownloadable.Checked = product.IsDownloadable;
                    cbDisplayOnSaleIcon.Checked = product.DisplayOnSaleIcon;
                    txtInitialStock.Text = product.InitialStock.ToString();
                    txtMinimumQuantity.Text = product.MinimumQuantity.ToString();
                    txtAdditionalShippingCost.Text = product.AdditionalShippingCost.ToString();

                    cddlManufacturar.SelectedValue = product.ManufacturarID.ToString();
                    cbIsEnabled.Checked = product.IsEnabled;
                    cddlTax.SelectedValue = product.TaxID.ToString();
                    txtSizeChart.Text = product.SizeChart;

                    btnUpdateProduct.Visible = true;
                    btnSaveProduct.Visible = false;
                    btnSaveOtherLanguageProduct.Visible = false;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = product.LanguageID;
                    /************************************************************************************************/

                    //Fill Product Catalog :
                    liProductCatalog.Visible = true;
                    dvProductCatalog.Visible = true;
                    FillCatalogTree(productID);

                    //Fill Product Feature:
                    liProductFeature.Visible = true;
                    dvProductFeature.Visible = true;
                    FillProductFeatures(productID);

                    //Fill Product Image:
                    liProductImage.Visible = true;
                    liProductPrice.Visible = true;
                    FillProdcutImages(productID);


                    //Fill Combination Product
                    liCombinationProduct.Visible = true;
                    dvCombinationProduct.Visible = true;
                    FillCombinationProduct(productID);

                    //for each One begin Edit Mode  :
                    dvProductImage.Visible = true;
                    dvProductPrice.Visible = true;
                }
            }
        }

        private void BeginProductEditModeOtherLanguage(int productID, int languageID)
        {
            if (productID > 0 && languageID > 0)
            {
                Product product = ProductManager.GetProduct(productID, CMSContext.PortalID, languageID);
                if (product != null)
                {
                    txtName.Text = product.Name;
                    txtDescription.Text = product.Description;
                    txtDisplayTextInStock.Text = product.DisplayTextInStockText;
                    txtDisplayTextWhenbackOrder.Text = product.DisplayTextInBackOrderText;
                    txtShortDescription.Text = product.ShortDescription;
                    txtTags.Text = product.Tags;
                    cddlSupplier.SelectedValue = product.SupplierID.ToString();
                    txtEAN13.Text = product.Ean13OrJan;
                    txtUpc.Text = product.UPC;
                    txtLocation.Text = product.Location;
                    cbIsDownloadable.Checked = product.IsDownloadable;
                    cbDisplayOnSaleIcon.Checked = product.DisplayOnSaleIcon;
                    txtInitialStock.Text = product.InitialStock.ToString();
                    txtMinimumQuantity.Text = product.MinimumQuantity.ToString();
                    txtAdditionalShippingCost.Text = product.AdditionalShippingCost.ToString();
                    cddlManufacturar.SelectedValue = product.ManufacturarID.ToString();
                    cbIsEnabled.Checked = product.IsEnabled;
                    cddlTax.SelectedValue = product.TaxID.ToString();
                    txtSizeChart.Text = product.SizeChart;


                    btnSaveProduct.Visible = false;
                    if (string.IsNullOrEmpty(product.Name))
                    {
                        btnSaveOtherLanguageProduct.Visible = true;
                        btnUpdateProduct.Visible = false;
                    }
                    else
                    {
                        btnSaveOtherLanguageProduct.Visible = false;
                        btnUpdateProduct.Visible = true;
                    }

                    ucPortalLanguage.Visible = true;


                    //for each One begin Edit Mode  :

                    liProductCatalog.Visible = true;
                    liProductFeature.Visible = true;
                    liProductImage.Visible = true;
                    liProductPrice.Visible = true;
                    liCombinationProduct.Visible = true;

                    dvProductCatalog.Visible = true;
                    dvProductFeature.Visible = true;
                    dvProductImage.Visible = true;
                    dvProductPrice.Visible = true;
                    dvCombinationProduct.Visible = true;

                }
            }
        }

        #endregion

        #region Product Catalog

        #region FillCatalogTree

        private void FillCatalogTree(int productID)
        {
            List<Catalog> catalogs = CatalogManager.GetCatalogs(CMSContext.PortalID, CMSContext.LanguageID);
            List<Catalog> parentcatalogs = catalogs.Where(m => m.ParentCalalogID == 0).ToList();

            List<Catalog> productCatalogs = CatalogManager.GetCatalogsByProductID(productID, CMSContext.PortalID, CMSContext.LanguageID);
            List<string> catalogsIds = null;

            if (productCatalogs != null && productCatalogs.Count > 0)
                catalogsIds = productCatalogs.Select(p => p.ID.ToString()).ToList();

            trvCatalog.Nodes.Clear();
            foreach (AJH.CMS.Core.Entities.Catalog Catalog in parentcatalogs)
            {
                TreeNode oNode = GetNodesChilds(Catalog, catalogs, catalogsIds);
                oNode.SelectAction = TreeNodeSelectAction.None;
                if (catalogsIds != null && catalogsIds.Contains(oNode.Value))
                    oNode.Checked = true;

                trvCatalog.Nodes.Add(oNode);
            }

            trvCatalog.ExpandAll();
        }

        private TreeNode GetNodesChilds(Catalog catalog, List<Catalog> Catalogs, List<string> toBecheckedNodes)
        {
            TreeNode oNode;
            oNode = new TreeNode(catalog.ID + ": " + catalog.Name, Convert.ToString(catalog.ID));
            oNode.SelectAction = TreeNodeSelectAction.None;

            if (toBecheckedNodes != null && toBecheckedNodes.Contains(oNode.Value))
                oNode.Checked = true;

            List<Catalog> CatalogChilds = Catalogs.Where(m => m.ParentCalalogID == catalog.ID).ToList();
            if (CatalogChilds.Count > 0)
            {
                foreach (AJH.CMS.Core.Entities.Catalog CatalogChild in CatalogChilds)
                {
                    if (toBecheckedNodes != null && toBecheckedNodes.Contains(oNode.Value))
                        oNode.Checked = true;
                    oNode.ChildNodes.Add(GetNodesChilds(CatalogChild, Catalogs, toBecheckedNodes));
                }
            }
            return oNode;
        }

        #endregion

        #endregion

        #region Product Feature Methods

        private void FillProductFeatures(int productID)
        {
            List<Feature> productFeatures = FeatureManager.GetFeaturesByProductId(productID, CMSContext.LanguageID);
            gvProductFeatures.DataSource = productFeatures;
            gvProductFeatures.DataBind();
        }

        #endregion

        #region Preoduct Image Methods

        private void FillProdcutImages(int productId)
        {
            List<ProductImage> productImages = ProductImageManager.GetProductImagesByProductID(productId, CMSContext.LanguageID);
            dlsProductImage.DataSource = productImages;
            dlsProductImage.DataBind();
        }

        private void BeginProductImageAddMode()
        {
            txtCaption.Text = string.Empty;
            cbIsCoverImage.Checked = false;
            ucSWFUploadProductImage.BeginAddMode();
        }

        #endregion

        #region Combination Product Methods

        private void FillCombinationProduct(int productID)
        {
            List<CombinationProduct> productCombinations =
                CombinationProductManager.GetCombinationProductsByProductId(productID, CMSContext.LanguageID);

            gvCombinationProducts.DataSource = productCombinations;
            gvCombinationProducts.DataBind();

            BeginCombinationProductAddMode();
        }

        private void BeginCombinationProductAddMode()
        {
            SelecedCombinationProductId = -1;
            txtProductReference.Text = string.Empty;
            txtCombinationEan13.Text = string.Empty;
            txtCombinationUPC.Text = string.Empty;
            cddCombinationSupplier.SelectedValue = "-1";
            txtWholesalePrice.Text = "1";
            txtImpactOnPrice.Text = "1";
            txtImpactOnWeight.Text = "1";
            txtCombinationInitialStock.Text = "1";
            txtCombinationInitialQuantity.Text = "1";
            cbIsDefault.Checked = false;
            ucColorPicker.SelectedColor = string.Empty;
            txtCombinationLocation.Text = string.Empty;
            ucCombinationProductLanguage.Visible = false;
            ucCombinationProductLanguage.SelectedLanguageID = -1;

            btnSaveCombinationProduct.Visible = true;
            btnUpdateCombinationProduct.Visible = false;
            btnSaveCombinationProductOtherLanguage.Visible = false;

            pnlCombinationAttributes.Style.Add(HtmlTextWriterStyle.Display, "none");
            pnlCombinationImage.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        private void BeginCombinationProductEditModeOtherLanguage(int combinationProductId, int languageId)
        {
            CombinationProduct combinationProduct = CombinationProductManager.GetCombinationProduct(combinationProductId, languageId);
            if (combinationProduct != null)
            {
                txtProductReference.Text = combinationProduct.ProductReference;
                txtCombinationEan13.Text = combinationProduct.ProductEAN13;
                txtCombinationUPC.Text = combinationProduct.ProductUPC;
                cddCombinationSupplier.SelectedValue = combinationProduct.SupplierRefernce.ToString();
                txtWholesalePrice.Text = combinationProduct.WholesalePrice.ToString();
                txtImpactOnPrice.Text = combinationProduct.ImpactOnPrice.ToString();
                txtImpactOnWeight.Text = combinationProduct.ImpactOnWeight.ToString();
                txtCombinationInitialStock.Text = combinationProduct.InitialStock.ToString();
                txtCombinationInitialQuantity.Text = combinationProduct.MinimumQuantity.ToString();
                cbIsDefault.Checked = combinationProduct.IsDefault;
                ucColorPicker.SelectedColor = combinationProduct.Color;
                txtCombinationLocation.Text = combinationProduct.Location;
                ucCombinationProductLanguage.Visible = true;

                btnSaveCombinationProduct.Visible = false;
                btnUpdateCombinationProduct.Visible = true;

                if (string.IsNullOrEmpty(combinationProduct.Location))
                {
                    btnSaveCombinationProductOtherLanguage.Visible = true;
                    btnUpdateCombinationProduct.Visible = false;
                }
                else
                {
                    btnSaveCombinationProductOtherLanguage.Visible = false;
                    btnUpdateCombinationProduct.Visible = true;
                }

                pnlCombinationAttributes.Style.Add(HtmlTextWriterStyle.Display, "block");
                pnlCombinationImage.Style.Add(HtmlTextWriterStyle.Display, "block");

                #region Combination Image
                //Fill Combination Images:  
                List<ProductImage> combinationImages = ProductImageManager.GetProductImagesByCombinationID(combinationProductId, CMSContext.LanguageID);
                dlsConnectedCombinationImage.DataSource = combinationImages;
                dlsConnectedCombinationImage.DataBind();

                //Fill Prodcut Images:
                List<ProductImage> productImages = ProductImageManager.GetProductImagesByProductID(combinationProduct.ProductID, CMSContext.LanguageID);

                //Fill Only Not already connected Prodcut Images :
                if (productImages != null && combinationImages != null)
                {
                    List<int> combinationImagesIds = combinationImages.Select(ci => ci.ID).ToList();
                    productImages = productImages.Where(pi => !combinationImagesIds.Contains(pi.ID)).ToList();
                }

                dlsAllProdcutImage.DataSource = productImages;
                dlsAllProdcutImage.DataBind();

                #endregion

                #region Combination Attribute

                List<AJH.CMS.Core.Entities.Attribute> combinationAttributes = AttributeManager.GetAttributesByCombinationID(combinationProductId, CMSContext.LanguageID);
                gvConnectedCombinationAttributes.DataSource = combinationAttributes;
                gvConnectedCombinationAttributes.DataBind();

                cddGroup.SelectedValue = cddGroup.PromptValue;
                gvNotConnectedCombinationAttributes.DataSource = new List<AJH.CMS.Core.Entities.Attribute>();
                gvNotConnectedCombinationAttributes.DataBind();

                #endregion
            }
        }

        private void BeginCombinationProductEditMode(int combinationProductId)
        {
            CombinationProduct combinationProduct = CombinationProductManager.GetCombinationProduct(combinationProductId, CMSContext.LanguageID);
            if (combinationProduct != null)
            {
                txtProductReference.Text = combinationProduct.ProductReference;
                txtCombinationEan13.Text = combinationProduct.ProductEAN13;
                txtCombinationUPC.Text = combinationProduct.ProductUPC;
                cddCombinationSupplier.SelectedValue = combinationProduct.SupplierRefernce.ToString();
                txtWholesalePrice.Text = combinationProduct.WholesalePrice.ToString();
                txtImpactOnPrice.Text = combinationProduct.ImpactOnPrice.ToString();
                txtImpactOnWeight.Text = combinationProduct.ImpactOnWeight.ToString();
                txtCombinationInitialStock.Text = combinationProduct.InitialStock.ToString();
                txtCombinationInitialQuantity.Text = combinationProduct.MinimumQuantity.ToString();
                cbIsDefault.Checked = combinationProduct.IsDefault;
                ucColorPicker.SelectedColor = combinationProduct.Color;
                txtCombinationLocation.Text = combinationProduct.Location;
                ucCombinationProductLanguage.Visible = true;
                ucCombinationProductLanguage.SelectedLanguageID = combinationProduct.LanguageID;

                btnSaveCombinationProduct.Visible = false;
                btnUpdateCombinationProduct.Visible = true;

                if (string.IsNullOrEmpty(combinationProduct.Location))
                {
                    btnSaveCombinationProductOtherLanguage.Visible = true;
                    btnUpdateCombinationProduct.Visible = false;
                }
                else
                {
                    btnSaveCombinationProductOtherLanguage.Visible = false;
                    btnUpdateCombinationProduct.Visible = true;
                }

                pnlCombinationAttributes.Style.Add(HtmlTextWriterStyle.Display, "block");
                pnlCombinationImage.Style.Add(HtmlTextWriterStyle.Display, "block");

                #region Combination Image
                //Fill Combination Images:  
                List<ProductImage> combinationImages = ProductImageManager.GetProductImagesByCombinationID(combinationProductId, CMSContext.LanguageID);
                dlsConnectedCombinationImage.DataSource = combinationImages;
                dlsConnectedCombinationImage.DataBind();

                //Fill Prodcut Images:
                List<ProductImage> productImages = ProductImageManager.GetProductImagesByProductID(combinationProduct.ProductID, CMSContext.LanguageID);

                //Fill Only Not already connected Prodcut Images :
                if (productImages != null && combinationImages != null)
                {
                    List<int> combinationImagesIds = combinationImages.Select(ci => ci.ID).ToList();
                    productImages = productImages.Where(pi => !combinationImagesIds.Contains(pi.ID)).ToList();
                }

                dlsAllProdcutImage.DataSource = productImages;
                dlsAllProdcutImage.DataBind();

                #endregion

                #region Combination Attribute

                List<AJH.CMS.Core.Entities.Attribute> combinationAttributes = AttributeManager.GetAttributesByCombinationID(combinationProductId, CMSContext.LanguageID);
                gvConnectedCombinationAttributes.DataSource = combinationAttributes;
                gvConnectedCombinationAttributes.DataBind();

                cddGroup.SelectedValue = cddGroup.PromptValue;
                gvNotConnectedCombinationAttributes.DataSource = new List<AJH.CMS.Core.Entities.Attribute>();
                gvNotConnectedCombinationAttributes.DataBind();

                #endregion

            }
        }

        public string GetProdcutImageFile(string imageName)
        {
            return CMSContext.VirtualUploadFolder + imageName;
        }

        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlTax.UniqueID] != null)
                cddlTax.SelectedValue = Request.Params[ddlTax.UniqueID];

            if (Request.Params[ddlManufacturar.UniqueID] != null)
                cddlManufacturar.SelectedValue = Request.Params[ddlManufacturar.UniqueID];

            if (Request.Params[ddlSupplier.UniqueID] != null)
                cddlSupplier.SelectedValue = Request.Params[ddlSupplier.UniqueID];

            if (Request.Params[ddlFeature.UniqueID] != null)
                cddlFeature.SelectedValue = Request.Params[ddlFeature.UniqueID];

            if (Request.Params[ddlCombinationSupplier.UniqueID] != null)
                cddCombinationSupplier.SelectedValue = Request.Params[ddlCombinationSupplier.UniqueID];

            if (Request.Params[ddlGroup.UniqueID] != null)
                cddGroup.SelectedValue = Request.Params[ddlGroup.UniqueID];

        }
        #endregion
        #endregion
    }
}