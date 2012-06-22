using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageCategory_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageCategory_UC_Load);
            this.ibtnSearchModule.Click += new ImageClickEventHandler(ibtnSearchModule_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.trvCategory.SelectedNodeChanged += new EventHandler(trvCategory_SelectedNodeChanged);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region
        void ibtnSearchModule_Click(object sender, ImageClickEventArgs e)
        {
            int ModuleID = 0;
            int.TryParse(cddSearchModule.SelectedValue, out ModuleID);
            if (ModuleID > 0)
            {
                ViewState[CMSViewStateManager.ModuleID] = ModuleID;
                FillCategoryTree();
            }
            else
            {
                ExitTree();
            }
            ExitMode();
            upnlCategory.Update();
            upnlCategoryItem.Update();
        }
        #endregion

        #region trvCategory_SelectedNodeChanged
        void trvCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            int CategoryID = 0;
            int.TryParse(trvCategory.SelectedValue, out CategoryID);
            if (CategoryID > 0)
            {
                ViewState[CMSViewStateManager.CategoryID] = CategoryID;
                BeginEditMode();
                upnlCategoryItem.Update();
            }
            if (trvCategory.SelectedNode != null)
            {
                trvCategory.SelectedNode.Selected = false;
            }
        }
        #endregion

        #region gvCategory_RowCommand
        void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditCategory":
                    int CategoryID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out CategoryID);

                    if (CategoryID > 0)
                    {
                        ViewState[CMSViewStateManager.CategoryID] = CategoryID;
                        BeginEditMode();
                        upnlCategoryItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvCategory.CheckedNodes.Count; i++)
            {
                int CategoryID = Convert.ToInt32(trvCategory.CheckedNodes[i].Value);
                CategoryManager.DeleteLogical(CategoryID);
            }
            FillCategoryTree();
            ExitMode();
            upnlCategoryItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlCategoryItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Category category = CategoryManager.GetCategory(Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]));
                    if (category != null)
                    {
                        category.Description = txtDescription.Text;
                        category.IsDeleted = false;
                        category.LanguageID = CMSContext.LanguageID;
                        category.Name = txtName.Text;
                        category.Order = Convert.ToInt32(txtOrderNumber.Text);
                        category.PortalID = CMSContext.PortalID;
                        category.ParentID = Convert.ToInt32(cddParentCategory.SelectedValue);
                        CategoryManager.Update(category);

                        FillCategoryTree();
                        upnlCategory.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlCategory.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Category category = new Core.Entities.Category();
                category.CreationDate = DateTime.Now;
                category.Description = txtDescription.Text;
                category.ID = 0;
                category.IsDeleted = false;
                category.LanguageID = CMSContext.LanguageID;
                category.ModuleID = Convert.ToInt32(ViewState[CMSViewStateManager.ModuleID]);
                category.Name = txtName.Text;
                category.Order = Convert.ToInt32(txtOrderNumber.Text);
                category.PortalID = CMSContext.PortalID;
                category.ParentID = Convert.ToInt32(cddParentCategory.SelectedValue);
                category.CreatedBy = CMSContext.UserID;
                CategoryManager.Add(category);

                BeginAddMode();
                FillCategoryTree();
                upnlCategory.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlCategory.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
        }
        #endregion

        #region ManageCategory_UC_Load
        void ManageCategory_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                ExitTree();
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillCategoryTree
        private void FillCategoryTree()
        {
            int ModuleID = Convert.ToInt32(ViewState[CMSViewStateManager.ModuleID]);
            List<AJH.CMS.Core.Entities.Category> categories = CategoryManager.GetCategorys(ModuleID, CMSContext.PortalID, CMSContext.LanguageID);
            List<AJH.CMS.Core.Entities.Category> parentCategories = categories.Where(m => m.ParentID == 0).ToList();

            trvCategory.Nodes.Clear();
            foreach (AJH.CMS.Core.Entities.Category category in parentCategories)
            {
                TreeNode oNode = GetNodesChilds(category, categories);
                trvCategory.Nodes.Add(oNode);
            }
            trvCategory.ExpandAll();
            pnlView.Visible = true;
        }
        #endregion

        #region GetNodesChilds
        private TreeNode GetNodesChilds(AJH.CMS.Core.Entities.Category category, List<AJH.CMS.Core.Entities.Category> categories)
        {
            TreeNode oNode;
            oNode = new TreeNode(category.ID + ": " + category.Name, Convert.ToString(category.ID));
            //oNode.ImageUrl = GetPublishImage(menu.ID);

            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                int CategorySelected = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                if (CategorySelected > 0 && oNode.Value == CategorySelected.ToString())
                {
                    oNode.Selected = true;
                }
            }

            List<AJH.CMS.Core.Entities.Category> categoryChilds = categories.Where(m => m.ParentID == category.ID).ToList();
            if (categoryChilds.Count > 0)
            {
                foreach (AJH.CMS.Core.Entities.Category categoryChild in categoryChilds)
                {
                    oNode.ChildNodes.Add(GetNodesChilds(categoryChild, categories));
                }
            }
            return oNode;
        }
        #endregion

        #region ExitTree
        void ExitTree()
        {
            ViewState.Remove(CMSViewStateManager.ModuleID);
            pnlView.Visible = false;
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlCategoryItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + trvCategory.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.CategoryID);
            pnlCategoryItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtOrderNumber.Text = "0";
            cddParentCategory.Category = CMSConfig.ConstantManager.CategoryCategory + ViewState[CMSViewStateManager.ModuleID];
            cddParentCategory.SelectedValue = cddParentCategory.PromptValue;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlCategoryItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                CMS.Core.Entities.Category category = CategoryManager.GetCategory(Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]));
                if (category != null)
                {
                    pnlCategoryItem.Visible = true;
                    txtDescription.Text = category.Description;
                    txtName.Text = category.Name;
                    txtOrderNumber.Text = category.Order.ToString();
                    cddParentCategory.Category = CMSConfig.ConstantManager.CategoryCategory + ViewState[CMSViewStateManager.ModuleID] + CMSConfig.ConstantManager.BreakItem + CMSConfig.ConstantManager.CurrentCategory + category.ID;
                    cddParentCategory.SelectedValue = category.ParentID.ToString();

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlCategoryItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlParentCategory.UniqueID] != null)
                cddParentCategory.SelectedValue = Request.Params[ddlParentCategory.UniqueID];
            if (Request.Params[ddlSearchModule.UniqueID] != null)
                cddSearchModule.SelectedValue = Request.Params[ddlSearchModule.UniqueID];
        }
        #endregion

        #endregion
    }
}