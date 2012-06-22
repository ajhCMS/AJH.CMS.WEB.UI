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
    public partial class ManageSupplier_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageSupplier_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.trvSupplier.SelectedNodeChanged += new EventHandler(trvSupplier_SelectedNodeChanged);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
        }

        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.SupplierID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :

                    Supplier Supplier =
                        SupplierManager.GetSupplier(Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]),CMSContext.PortalID, CMSContext.LanguageID);

                    if (Supplier != null)
                    {
                        Supplier.IsEnabled = cbIsEnabled.Checked;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            Supplier.LogoImage = files[0];
                        else
                            Supplier.LogoImage = string.Empty;

                        int parentSupplierId = -1;
                        int.TryParse(ddlParentSupplier.SelectedValue, out parentSupplierId);
                        if (parentSupplierId > 0)
                            Supplier.ParentSupplierID = parentSupplierId;

                        SupplierManager.Update(Supplier);

                        //SaveLanguage Info Only :
                        Supplier langSupplier = new Supplier
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]),
                            Name = txtName.Text,
                            Description = txtDescription.Text,
                            MetaTitle = txtMetaTitle.Text,
                            MetaDescription = txtMetaDescription.Text,
                            MetaKeywords = txtMetaKeywords.Text,
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Supplier,
                        };

                        SupplierManager.AddOtherLanguage(langSupplier);
                        BeginAddMode();
                        FillSupplierTree();
                        upnlSupplier.Update();
                        upnlSupplierItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlSupplier.Update();
                }
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.SupplierID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlSupplierItem.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlSupplier.Update();

                }
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.SupplierID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    Supplier Supplier =
                        SupplierManager.GetSupplier(Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]),CMSContext.PortalID, CMSContext.LanguageID);

                    if (Supplier != null)
                    {
                        Supplier.Name = txtName.Text;
                        Supplier.IsEnabled = cbIsEnabled.Checked;
                        Supplier.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        Supplier.ModuleID = (int)CMSEnums.ECommerceModule.Supplier;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            Supplier.LogoImage = files[0];
                        else
                            Supplier.LogoImage = string.Empty;

                        int parentSupplierId = -1;
                        int.TryParse(ddlParentSupplier.SelectedValue, out parentSupplierId);
                        if (parentSupplierId > 0)
                            Supplier.ParentSupplierID = parentSupplierId;

                        Supplier.Description = txtDescription.Text;
                        Supplier.MetaTitle = txtMetaTitle.Text;
                        Supplier.MetaDescription = txtMetaDescription.Text;
                        Supplier.MetaKeywords = txtMetaKeywords.Text;

                        SupplierManager.Update(Supplier);
                        FillSupplierTree();
                        upnlSupplier.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlSupplier.Update();
                }

            }
        }

        #region trvSupplier_SelectedNodeChanged
        void trvSupplier_SelectedNodeChanged(object sender, EventArgs e)
        {
            int SupplierID = 0;
            int.TryParse(trvSupplier.SelectedValue, out SupplierID);
            if (SupplierID > 0)
            {
                ViewState[CMSViewStateManager.SupplierID] = SupplierID;
                BeginEditMode();
                upnlSupplierItem.Update();
            }
            if (trvSupplier.SelectedNode != null)
            {
                trvSupplier.SelectedNode.Selected = false;
            }
        }
        #endregion

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlSupplier.Update();
            upnlSupplierItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.SupplierID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier();
                supplier.IsDeleted = false;
                supplier.LanguageID = CMSContext.LanguageID;
                supplier.PortalID = CMSContext.PortalID;

                supplier.Name = txtName.Text;
                supplier.Description = txtDescription.Text;
                supplier.IsEnabled = cbIsEnabled.Checked;

                int parentSupplierId = -1;
                int.TryParse(ddlParentSupplier.SelectedValue, out parentSupplierId);
                if (parentSupplierId > 0)
                    supplier.ParentSupplierID = parentSupplierId;

                List<string> files = ucSWFUpload.GetFilesName();
                if (files.Count > 0)
                    supplier.LogoImage = files[0];
                else
                    supplier.LogoImage = string.Empty;

                supplier.MetaTitle = txtMetaTitle.Text;
                supplier.MetaDescription = txtMetaDescription.Text;
                supplier.MetaKeywords = txtMetaKeywords.Text;

                supplier.ModuleID = (int)CMSEnums.ECommerceModule.Supplier;
                SupplierManager.Add(supplier);

                BeginAddMode();

                FillSupplierTree();
                upnlSupplier.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlSupplier.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvSupplier.CheckedNodes.Count; i++)
            {
                int SupplierID = Convert.ToInt32(trvSupplier.CheckedNodes[i].Value);
                SupplierManager.DeleteLogical(SupplierID);
            }
            FillSupplierTree();
            ExitMode();
            upnlSupplierItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlSupplierItem.Update();
        }
        #endregion

        #region ManageSupplier_UC_Load
        void ManageSupplier_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillSupplierTree();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + trvSupplier.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.SupplierID);
            pnlSupplierItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMetaDescription.Text = string.Empty;
            txtMetaKeywords.Text = string.Empty;
            txtMetaTitle.Text = string.Empty;
            cbIsEnabled.Checked = false;
            ucSWFUpload.BeginAddMode();

            cddlParentSupplier.SelectedValue = "0";

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlSupplierItem.Visible = true;

            pnlSupplierItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.SupplierID] != null)
            {
                Supplier Supplier =
                    SupplierManager.GetSupplier(Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]), CMSContext.PortalID, CMSContext.LanguageID);
                if (Supplier != null)
                {
                    pnlSupplierItem.Visible = true;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = Supplier.LanguageID;
                    txtName.Text = Supplier.Name;
                    cbIsEnabled.Checked = Supplier.IsEnabled;
                    ucSWFUpload.BeginEditMode(Supplier.LogoImage);

                    cddlParentSupplier.Category = Supplier.ID.ToString();
                    if (Supplier.ParentSupplierID > 0)
                        cddlParentSupplier.SelectedValue = Supplier.ParentSupplierID.ToString();

                    txtDescription.Text = Supplier.Description;
                    txtMetaTitle.Text = Supplier.MetaTitle;
                    txtMetaDescription.Text = Supplier.MetaDescription;
                    txtMetaKeywords.Text = Supplier.MetaKeywords;

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
        }

        private void BeginEditModeOtherLanguage()
        {
            Supplier Supplier =
                SupplierManager.GetSupplier(Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]), CMSContext.PortalID, ucPortalLanguage.SelectedLanguageID);
            if (Supplier != null)
            {
                pnlSupplierItem.Visible = true;
                ucPortalLanguage.Visible = true;
                txtName.Text = Supplier.Name;
                cbIsEnabled.Checked = Supplier.IsEnabled;
                ucSWFUpload.BeginEditMode(Supplier.LogoImage);

                cddlParentSupplier.Category = Supplier.ID.ToString();
                if (Supplier.ParentSupplierID > 0)
                    cddlParentSupplier.SelectedValue = Supplier.ParentSupplierID.ToString();

                txtDescription.Text = Supplier.Description;
                txtMetaTitle.Text = Supplier.MetaTitle;
                txtMetaDescription.Text = Supplier.MetaDescription;
                txtMetaKeywords.Text = Supplier.MetaKeywords;

                btnSave.Visible = false;
                if (string.IsNullOrEmpty(Supplier.Name))
                {
                    btnSaveOtherLanguage.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlSupplierItem.Visible = false;
        }
        #endregion

        #region FillSupplierTree
        private void FillSupplierTree()
        {
            List<Supplier> Suppliers = SupplierManager.GetSuppliers(CMSContext.PortalID, CMSContext.LanguageID);
            List<Supplier> parentSuppliers = Suppliers.Where(m => m.ParentSupplierID == 0).ToList();

            trvSupplier.Nodes.Clear();
            foreach (AJH.CMS.Core.Entities.Supplier Supplier in parentSuppliers)
            {
                TreeNode oNode = GetNodesChilds(Supplier, Suppliers);
                trvSupplier.Nodes.Add(oNode);
            }
            trvSupplier.ExpandAll();
            pnlView.Visible = true;
        }
        #endregion

        #region GetNodesChilds
        private TreeNode GetNodesChilds(Supplier Supplier, List<Supplier> Suppliers)
        {
            TreeNode oNode;
            oNode = new TreeNode(Supplier.ID + ": " + Supplier.Name, Convert.ToString(Supplier.ID));
            //oNode.ImageUrl = GetPublishImage(menu.ID);

            if (ViewState[CMSViewStateManager.SupplierID] != null)
            {
                int SupplierSelected = Convert.ToInt32(ViewState[CMSViewStateManager.SupplierID]);
                if (SupplierSelected > 0 && oNode.Value == SupplierSelected.ToString())
                {
                    oNode.Selected = true;
                }
            }

            List<Supplier> SupplierChilds = Suppliers.Where(m => m.ParentSupplierID == Supplier.ID).ToList();
            if (SupplierChilds.Count > 0)
            {
                foreach (AJH.CMS.Core.Entities.Supplier SupplierChild in SupplierChilds)
                {
                    oNode.ChildNodes.Add(GetNodesChilds(SupplierChild, Suppliers));
                }
            }
            return oNode;
        }
        #endregion

        #endregion
    }
}