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
using System.IO;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageCatalog_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageCatalog_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.trvCatalog.SelectedNodeChanged += new EventHandler(trvCatalog_SelectedNodeChanged);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
            this.ibtnRefreshCatalogs.Click += new ImageClickEventHandler(ibtnRefreshCatalogs_Click);
            this.btnSaveProductCatalog.Click += new EventHandler(btnSaveProductCatalog_Click);
            this.ibtnDeleteProduct.Click += new ImageClickEventHandler(ibtnDeleteProduct_Click);
            this.gvAllProducts.PageIndexChanging += new GridViewPageEventHandler(gvAllProducts_PageIndexChanging);
            this.gvCatalogProducts.PageIndexChanging += new GridViewPageEventHandler(gvCatalogProducts_PageIndexChanging);
        }

        void gvCatalogProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalogProducts.PageIndex = e.NewPageIndex;
            FillCatalogProducts((Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID])), ucPortalLanguage.SelectedLanguageID);
            upnlProductCatalog.Update();
        }

        void gvAllProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllProducts.PageIndex = e.NewPageIndex;
            FillAllProducts((Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID])), ucPortalLanguage.SelectedLanguageID);
            upnlProductCatalog.Update();
        }

        void ibtnDeleteProduct_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                for (int i = 0; i < gvCatalogProducts.Rows.Count; i++)
                {
                    CheckBox chkItem = (CheckBox)gvCatalogProducts.Rows[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)gvCatalogProducts.Rows[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int productId = Convert.ToInt32(hdnID.Value);
                            CatalogManager.DeleteProductCatalog(productId, Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]));
                        }
                    }
                }
                FillAllProducts((Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID])), ucPortalLanguage.SelectedLanguageID);
                FillCatalogProducts(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), ucPortalLanguage.SelectedLanguageID);
                upnlProductCatalog.Update();
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

        void btnSaveProductCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvAllProducts.Rows.Count; i++)
                {
                    CheckBox chkItem = (CheckBox)gvAllProducts.Rows[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)gvAllProducts.Rows[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int productId = Convert.ToInt32(hdnID.Value);
                            CatalogManager.AddProductCatalog(productId, Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]));
                        }
                    }
                }
                FillAllProducts((Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID])), ucPortalLanguage.SelectedLanguageID);
                FillCatalogProducts(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), ucPortalLanguage.SelectedLanguageID);
                upnlProductCatalog.Update();
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

        #region ibtnRefreshCatalogs_Click
        void ibtnRefreshCatalogs_Click(object sender, ImageClickEventArgs e)
        {
            string catalogXmlFilePath = CMSWebHelper.GetCatalogPath();
            if (File.Exists(catalogXmlFilePath))
                File.Delete(catalogXmlFilePath);
            ExitMode();
            upnlCatalogItem.Update();
        }
        #endregion

        #region btnSaveOtherLanguage_Click
        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CatalogID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :

                    Catalog catalog =
                        CatalogManager.GetCatalog(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), CMSContext.LanguageID);

                    if (catalog != null)
                    {
                        catalog.IsDisplayed = cbIsDisplayed.Checked;
                        catalog.IsGalleryOnly = cbIsGalleryOnly.Checked;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            catalog.Image = files[0];
                        else
                            catalog.Image = string.Empty;

                        int parentCatalogId = -1;
                        int.TryParse(ddlParentCatalog.SelectedValue, out parentCatalogId);
                        if (parentCatalogId > 0)
                            catalog.ParentCalalogID = parentCatalogId;

                        CatalogManager.Update(catalog);

                        //SaveLanguage Info Only :
                        Catalog langCatalog = new Catalog
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]),
                            Name = txtName.Text,
                            Description = txtDescription.Text,
                            MetaTitle = txtMetaTitle.Text,
                            MetaDescription = txtMetaDescription.Text,
                            MetaKeywords = txtMetaKeywords.Text,
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Catalog,
                        };

                        CatalogManager.AddOtherLanguage(langCatalog);
                        BeginAddMode();
                        FillCatalogTree();
                        upnlCatalog.Update();
                        upnlCatalogItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlCatalog.Update();
                }
            }
        }
        #endregion

        #region ucPortalLanguage_OnSelectLanguage
        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CatalogID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlCatalogItem.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlCatalog.Update();

                }
            }
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CatalogID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    Catalog catalog =
                        CatalogManager.GetCatalog(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), CMSContext.LanguageID);

                    if (catalog != null)
                    {
                        catalog.Name = txtName.Text;
                        catalog.IsDisplayed = cbIsDisplayed.Checked;
                        catalog.IsGalleryOnly = cbIsGalleryOnly.Checked;
                        catalog.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        catalog.ModuleID = (int)CMSEnums.ECommerceModule.Catalog;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            catalog.Image = files[0];
                        else
                            catalog.Image = string.Empty;

                        int parentCatalogId = -1;
                        int.TryParse(ddlParentCatalog.SelectedValue, out parentCatalogId);
                        if (parentCatalogId > 0)
                            catalog.ParentCalalogID = parentCatalogId;

                        catalog.Description = txtDescription.Text;
                        catalog.MetaTitle = txtMetaTitle.Text;
                        catalog.MetaDescription = txtMetaDescription.Text;
                        catalog.MetaKeywords = txtMetaKeywords.Text;

                        CatalogManager.Update(catalog);
                        FillCatalogTree();
                        upnlCatalog.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlCatalog.Update();
                }

            }
        }
        #endregion

        #region trvCatalog_SelectedNodeChanged
        void trvCatalog_SelectedNodeChanged(object sender, EventArgs e)
        {
            int CatalogID = 0;
            int.TryParse(trvCatalog.SelectedValue, out CatalogID);
            if (CatalogID > 0)
            {
                ViewState[CMSViewStateManager.CatalogID] = CatalogID;
                BeginEditMode();
                upnlCatalogItem.Update();
            }
            if (trvCatalog.SelectedNode != null)
            {
                trvCatalog.SelectedNode.Selected = false;
            }
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlCatalog.Update();
            upnlCatalogItem.Update();
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CatalogID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Catalog catalog = new Catalog();

                catalog.IsDeleted = false;
                catalog.LanguageID = CMSContext.LanguageID;
                catalog.PortalID = CMSContext.PortalID;
                catalog.Description = txtDescription.Text;

                List<string> files = ucSWFUpload.GetFilesName();
                if (files.Count > 0)
                    catalog.Image = files[0];
                else
                    catalog.Image = string.Empty;

                catalog.IsDisplayed = cbIsDisplayed.Checked;
                catalog.IsGalleryOnly = cbIsGalleryOnly.Checked;
                catalog.MetaDescription = txtMetaDescription.Text;
                catalog.MetaKeywords = txtMetaKeywords.Text;
                catalog.MetaTitle = txtMetaTitle.Text;
                catalog.ModuleID = (int)CMSEnums.ECommerceModule.Catalog;
                catalog.Name = txtName.Text;

                int parentCatalogId = -1;
                int.TryParse(ddlParentCatalog.SelectedValue, out parentCatalogId);
                if (parentCatalogId > 0)
                    catalog.ParentCalalogID = parentCatalogId;

                CatalogManager.Add(catalog);

                BeginAddMode();

                FillCatalogTree();
                upnlCatalog.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlCatalog.Update();
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvCatalog.CheckedNodes.Count; i++)
            {
                int CatalogID = Convert.ToInt32(trvCatalog.CheckedNodes[i].Value);
                CatalogManager.DeleteLogical(CatalogID);
            }
            FillCatalogTree();
            ExitMode();
            upnlCatalogItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlCatalogItem.Update();
        }
        #endregion

        #region ManageCatalog_UC_Load
        void ManageCatalog_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillCatalogTree();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + trvCatalog.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnDeleteProduct.OnClientClick = "return ConfirmOperation('" + gvCatalogProducts.ClientID + "','Are you sure to delete this item(s)?');";
            btnSaveProductCatalog.OnClientClick = "return ConfirmOperation('" + gvAllProducts.ClientID + "','Are you sure to add this product(s) to the selected catalog?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.CatalogID);
            pnlCatalogItem.Visible = true;


            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMetaDescription.Text = string.Empty;
            txtMetaKeywords.Text = string.Empty;
            txtMetaTitle.Text = string.Empty;
            cbIsGalleryOnly.Checked = false;
            cbIsDisplayed.Checked = false;
            ucSWFUpload.BeginAddMode();

            cddlParentCatalog.SelectedValue = "0";

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlCatalogItem.Visible = true;


            pnlCatalogItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CatalogID] != null)
            {
                Catalog catalog =
                    CatalogManager.GetCatalog(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), CMSContext.LanguageID);
                if (catalog != null)
                {
                    pnlCatalogItem.Visible = true;

                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = catalog.LanguageID;
                    txtName.Text = catalog.Name;
                    cbIsDisplayed.Checked = catalog.IsDisplayed;
                    cbIsGalleryOnly.Checked = catalog.IsGalleryOnly;
                    ucSWFUpload.BeginEditMode(catalog.Image);

                    cddlParentCatalog.Category = catalog.ID.ToString();
                    if (catalog.ParentCalalogID > 0)
                        cddlParentCatalog.SelectedValue = catalog.ParentCalalogID.ToString();

                    txtDescription.Text = catalog.Description;
                    txtMetaTitle.Text = catalog.MetaTitle;
                    txtMetaDescription.Text = catalog.MetaDescription;
                    txtMetaKeywords.Text = catalog.MetaKeywords;

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                    //Fill all Products:
                    FillAllProducts(catalog.ID, ucPortalLanguage.SelectedLanguageID);
                    FillCatalogProducts(catalog.ID, ucPortalLanguage.SelectedLanguageID);

                    upnlProductCatalog.Update();
                }
            }
        }
        #endregion

        #region BeginEditModeOtherLanguage
        private void BeginEditModeOtherLanguage()
        {
            Catalog catalog =
                CatalogManager.GetCatalog(Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]), ucPortalLanguage.SelectedLanguageID);
            if (catalog != null)
            {
                pnlCatalogItem.Visible = true;

                ucPortalLanguage.Visible = true;
                txtName.Text = catalog.Name;
                cbIsDisplayed.Checked = catalog.IsDisplayed;
                cbIsGalleryOnly.Checked = catalog.IsGalleryOnly;
                ucSWFUpload.BeginEditMode(catalog.Image);

                cddlParentCatalog.Category = catalog.ID.ToString();
                if (catalog.ParentCalalogID > 0)
                    cddlParentCatalog.SelectedValue = catalog.ParentCalalogID.ToString();

                txtDescription.Text = catalog.Description;
                txtMetaTitle.Text = catalog.MetaTitle;
                txtMetaDescription.Text = catalog.MetaDescription;
                txtMetaKeywords.Text = catalog.MetaKeywords;

                btnSave.Visible = false;
                if (string.IsNullOrEmpty(catalog.Name))
                {
                    btnSaveOtherLanguage.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;
                }
                FillAllProducts(catalog.ID, ucPortalLanguage.SelectedLanguageID);
                FillCatalogProducts(catalog.ID, ucPortalLanguage.SelectedLanguageID);
                upnlProductCatalog.Update();
            }

        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlCatalogItem.Visible = false;

        }
        #endregion

        #region FillCatalogTree
        private void FillCatalogTree()
        {
            List<Catalog> catalogs = CatalogManager.GetCatalogs(CMSContext.PortalID, CMSContext.LanguageID);
            List<Catalog> parentcatalogs = catalogs.Where(m => m.ParentCalalogID == 0).ToList();

            trvCatalog.Nodes.Clear();
            foreach (AJH.CMS.Core.Entities.Catalog Catalog in parentcatalogs)
            {
                TreeNode oNode = GetNodesChilds(Catalog, catalogs);
                trvCatalog.Nodes.Add(oNode);
            }
            trvCatalog.ExpandAll();
            pnlView.Visible = true;
        }
        #endregion

        #region GetNodesChilds
        private TreeNode GetNodesChilds(Catalog catalog, List<Catalog> Catalogs)
        {
            TreeNode oNode;
            oNode = new TreeNode(catalog.ID + ": " + catalog.Name, Convert.ToString(catalog.ID));

            if (ViewState[CMSViewStateManager.CatalogID] != null)
            {
                int CatalogSelected = Convert.ToInt32(ViewState[CMSViewStateManager.CatalogID]);
                if (CatalogSelected > 0 && oNode.Value == CatalogSelected.ToString())
                {
                    oNode.Selected = true;
                }
            }

            List<Catalog> CatalogChilds = Catalogs.Where(m => m.ParentCalalogID == catalog.ID).ToList();
            if (CatalogChilds.Count > 0)
            {
                foreach (AJH.CMS.Core.Entities.Catalog CatalogChild in CatalogChilds)
                {
                    oNode.ChildNodes.Add(GetNodesChilds(CatalogChild, Catalogs));
                }
            }
            return oNode;
        }
        #endregion

        #region Fill All Products
        private void FillAllProducts(int catalogId, int languageId)
        {
            List<Product> allProducts = ProductManager.GetProducts(CMSContext.PortalID, languageId);
            List<Product> catalogProducts = ProductManager.GetProductsByCatalogID(catalogId, CMSContext.PortalID, languageId);

            if (catalogProducts != null && catalogProducts.Count > 0)
                if (allProducts != null && allProducts.Count > 0)
                {
                    List<int> catalogProductsIds = catalogProducts.Select(cp => cp.ID).ToList();

                    allProducts = allProducts.Where(ap => !catalogProductsIds.Contains(ap.ID)).ToList();
                }


            gvAllProducts.DataSource = allProducts;
            gvAllProducts.DataBind();
        }
        #endregion

        #region Fill Catalog Products
        private void FillCatalogProducts(int catalogId, int languageId)
        {
            List<Product> catalogProducts = ProductManager.GetProductsByCatalogID(catalogId, CMSContext.PortalID, languageId);
            gvCatalogProducts.DataSource = catalogProducts;
            gvCatalogProducts.DataBind();
        }

        #endregion

        #endregion
    }
}