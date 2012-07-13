using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageMenu_UC : System.Web.UI.UserControl
    {
        #region Properties

        private int SelectedParentMenuObjID
        {
            set
            {
                ViewState[CMSViewStateManager.SelectedParentMenuObjID] = value;
            }
            get
            {
                int selectedParentMenuObjID = -1;
                if (ViewState[CMSViewStateManager.SelectedParentMenuObjID] != null)
                    selectedParentMenuObjID = Convert.ToInt32(ViewState[CMSViewStateManager.SelectedParentMenuObjID]);

                return selectedParentMenuObjID;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageMenu_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnSearchCategory.Click += new ImageClickEventHandler(ibtnSearchCategory_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.trvMenu.SelectedNodeChanged += new EventHandler(trvMenu_SelectedNodeChanged);
            this.ddlMenuType.SelectedIndexChanged += new EventHandler(ddlMenuType_SelectedIndexChanged);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnGenerateXmlFiles.Click += new ImageClickEventHandler(ibtnGenerateXmlFiles_Click);
            this.ibtnPageURL.Click += new ImageClickEventHandler(ibtnPageURL_Click);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
            this.btnUpdateOtherLanguage.Click += new EventHandler(btnUpdateOtherLanguage_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.ibtnPublish.Click += new ImageClickEventHandler(ibtnPublish_Click);
            this.ibtnUnPublish.Click += new ImageClickEventHandler(ibtnUnPublish_Click);
        }
        #endregion

        #region ibtnPageURL_Click
        void ibtnPageURL_Click(object sender, ImageClickEventArgs e)
        {
            int PageId = Convert.ToInt32(cddPage.SelectedValue);
            if (PageId > 0)
            {
                AJH.CMS.Core.Entities.Page page = PageManager.GetPage(PageId);
                if (page != null)
                {
                    txtPageURL.Text = CMSWebHelper.GetPageUrl(page);
                }
            }
        }
        #endregion

        #region ibtnGenerateXmlFiles_Click
        void ibtnGenerateXmlFiles_Click(object sender, ImageClickEventArgs e)
        {
            int categoryID = 0;
            int.TryParse(ddlSearchCategory.SelectedValue, out categoryID);
            if (categoryID > 0)
            {
                string menuCategoryPath = CMSWebHelper.GetMenuPathByCategory(categoryID);
                File.Delete(menuCategoryPath);
                MenuManager.GetMenuCategoryXMLPath(menuCategoryPath, categoryID, CMSContext.LanguageID);
                ExitMode();
                upnlMenuItem.Update();
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvMenu.CheckedNodes.Count; i++)
            {
                int MenuID = Convert.ToInt32(trvMenu.CheckedNodes[i].Value);
                MenuManager.DeleteLogical(MenuID);
            }
            FillMenuTree();
            ExitMode();
            upnlMenuItem.Update();
        }
        #endregion

        #region ddlMenuType_SelectedIndexChanged
        void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MenuType = 0;
            int.TryParse(ddlMenuType.SelectedValue, out MenuType);

            txtPageURL.Text = string.Empty;
            cddPage.SelectedValue = "-1";
            txtURL.Text = string.Empty;

            trDetails.Visible = false;
            trURL.Visible = false;
            trPage.Visible = false;
            switch ((CMSEnums.MenuType)MenuType)
            {
                case CMSEnums.MenuType.Page:
                    trPage.Visible = true;
                    rfvPage.Visible = rfvPage.Enabled = true;
                    rfvPageURL.Visible = rfvPageURL.Enabled = true;
                    break;
                case CMSEnums.MenuType.Static:
                    trDetails.Visible = true;
                    trPage.Visible = true;
                    rfvPage.Visible = rfvPage.Enabled = false;
                    rfvPageURL.Visible = rfvPageURL.Enabled = false;
                    break;
                case CMSEnums.MenuType.URL:
                    trURL.Visible = true;
                    break;
            }
        }
        #endregion

        #region trvMenu_SelectedNodeChanged
        void trvMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            int MenuId = 0;
            int.TryParse(trvMenu.SelectedValue, out MenuId);
            if (MenuId > 0)
            {
                ViewState[CMSViewStateManager.MenuID] = MenuId;
                BeginEditMode();
                upnlMenuItem.Update();
            }
            if (trvMenu.SelectedNode != null)
            {
                trvMenu.SelectedNode.Selected = false;
            }
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlMenuItem.Update();
        }
        #endregion

        #region ibtnSearchCategory_Click
        void ibtnSearchCategory_Click(object sender, ImageClickEventArgs e)
        {
            int CategoryID = 0;
            int.TryParse(cddSearchCategory.SelectedValue, out CategoryID);
            if (CategoryID > 0)
            {
                ViewState[CMSViewStateManager.CategoryID] = CategoryID;
                FillMenuTree();
            }
            else
            {
                ExitTree();
            }
            ExitMode();
            upnlMenu.Update();
            upnlMenuItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.MenuID] != null)
            {
                try
                {
                    CMS.Core.Entities.Menu menu = MenuManager.GetMenu(Convert.ToInt32(ViewState[CMSViewStateManager.MenuID]));
                    if (menu != null)
                    {
                        menu.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        menu.Description = txtDescription.Text;
                        menu.Details = txtDetails.Text;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            menu.Image = files[0];
                        else
                            menu.Image = string.Empty;

                        menu.IsDeleted = false;
                        menu.KeyWords = string.Empty;
                        menu.LanguageID = CMSContext.LanguageID;
                        menu.MenuType = (CMSEnums.MenuType)Convert.ToInt32(ddlMenuType.SelectedValue);
                        menu.Name = txtName.Text;
                        menu.Order = Convert.ToInt32(txtOrderNumber.Text);
                        menu.ParentID = Convert.ToInt32(cddParentMenu.SelectedValue);
                        menu.PortalID = CMSContext.PortalID;
                        menu.SEOName = string.Empty;

                        switch (menu.MenuType)
                        {
                            case CMSEnums.MenuType.Page:
                                menu.PageID = Convert.ToInt32(cddPage.SelectedValue);
                                menu.URL = txtPageURL.Text;
                                break;
                            case CMSEnums.MenuType.Static:
                                int PageId = Convert.ToInt32(cddPage.SelectedValue);
                                if (PageId > 0)
                                {
                                    menu.PageID = PageId;
                                }
                                string PageURL = txtPageURL.Text;
                                if (string.IsNullOrEmpty(PageURL))
                                {
                                    //Get Default Value
                                    PageURL = CMSConfig.CMSPage.GetMenuDetailsPage();
                                }
                                menu.URL = PageURL;
                                break;
                            case CMSEnums.MenuType.URL:
                                menu.PageID = 0;
                                menu.URL = txtURL.Text;
                                break;
                        }

                        MenuManager.Update(menu);
                        FillMenuTree();
                        upnlMenu.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlMenu.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Menu menu = new Core.Entities.Menu();
                    menu.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                    menu.CreationDate = DateTime.Now;
                    menu.Description = txtDescription.Text;
                    menu.Details = txtDetails.Text;
                    menu.ID = 0;

                    List<string> files = ucSWFUpload.GetFilesName();
                    if (files.Count > 0)
                        menu.Image = files[0];
                    else
                        menu.Image = string.Empty;

                    menu.IsDeleted = false;
                    menu.KeyWords = string.Empty;
                    menu.LanguageID = CMSContext.LanguageID;
                    menu.MenuType = (CMSEnums.MenuType)Convert.ToInt32(ddlMenuType.SelectedValue);
                    menu.Name = txtName.Text;
                    menu.Order = Convert.ToInt32(txtOrderNumber.Text);
                    menu.ParentID = Convert.ToInt32(cddParentMenu.SelectedValue);
                    menu.PortalID = CMSContext.PortalID;
                    menu.SEOName = string.Empty;
                    menu.CreatedBy = CMSContext.UserID;

                    switch (menu.MenuType)
                    {
                        case CMSEnums.MenuType.Page:
                            menu.PageID = Convert.ToInt32(cddPage.SelectedValue);
                            menu.URL = txtPageURL.Text;
                            break;
                        case CMSEnums.MenuType.Static:
                            int PageId = Convert.ToInt32(cddPage.SelectedValue);
                            if (PageId > 0)
                            {
                                menu.PageID = PageId;
                            }
                            string PageURL = txtPageURL.Text;
                            if (string.IsNullOrEmpty(PageURL))
                            {
                                //Get Default Value
                                PageURL = CMSConfig.CMSPage.GetMenuDetailsPage();
                            }
                            menu.URL = PageURL;
                            break;
                        case CMSEnums.MenuType.URL:
                            menu.PageID = 0;
                            menu.URL = txtURL.Text;
                            break;
                    }
                    MenuManager.Add(menu);

                    //Publish Menu
                    if (cbIsPublished.Checked)
                        PublishManager.Add(PrepareNewPublish(menu.ID));

                    BeginAddMode();
                    FillMenuTree();
                    upnlMenu.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlMenu.Update();
                }
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.MenuID] != null)
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

        #region ManageMenu_UC_Load
        void ManageMenu_UC_Load(object sender, EventArgs e)
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

        #region ucPortalLanguage_OnSelectLanguage
        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ucPortalLanguage.SelectedLanguageID > 0)
            {
                if (ucPortalLanguage.SelectedLanguageID == CMSContext.LanguageID)
                    BeginEditMode();
                else
                    BeginEditModeOtherLanguage();
            }
            else
                BeginAddMode();
        }
        #endregion

        #region btnUpdateOtherLanguage_Click
        void btnUpdateOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Menu menu =
                         MenuManager.GetMenu(SelectedParentMenuObjID, ucPortalLanguage.SelectedLanguageID);

                    if (menu != null)
                    {
                        menu.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        menu.Description = txtDescription.Text;
                        menu.Details = txtDetails.Text;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            menu.Image = files[0];
                        else
                            menu.Image = string.Empty;

                        menu.IsDeleted = false;
                        menu.KeyWords = string.Empty;
                        
                        menu.MenuType = (CMSEnums.MenuType)Convert.ToInt32(ddlMenuType.SelectedValue);
                        menu.Name = txtName.Text;
                        menu.Order = Convert.ToInt32(txtOrderNumber.Text);
                        menu.ParentID = Convert.ToInt32(cddParentMenu.SelectedValue);
                        menu.PortalID = CMSContext.PortalID;

                        menu.SEOName = string.Empty;

                        switch (menu.MenuType)
                        {
                            case CMSEnums.MenuType.Page:
                                menu.PageID = Convert.ToInt32(cddPage.SelectedValue);
                                menu.URL = txtPageURL.Text;
                                break;
                            case CMSEnums.MenuType.Static:
                                int PageId = Convert.ToInt32(cddPage.SelectedValue);
                                if (PageId > 0)
                                {
                                    menu.PageID = PageId;
                                }
                                string PageURL = txtPageURL.Text;
                                if (string.IsNullOrEmpty(PageURL))
                                {
                                    //Get Default Value
                                    PageURL = CMSConfig.CMSPage.GetMenuDetailsPage();
                                }
                                menu.URL = PageURL;
                                break;
                            case CMSEnums.MenuType.URL:
                                menu.PageID = 0;
                                menu.URL = txtURL.Text;
                                break;
                        }

                        MenuManager.Update(menu);
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlMenu.Update();
                }
            }
        }
        #endregion

        #region btnSaveOtherLanguage_Click
        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Menu menu = new Core.Entities.Menu();
                    menu.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                    menu.CreationDate = DateTime.Now;
                    menu.Description = txtDescription.Text;
                    menu.Details = txtDetails.Text;
                    menu.ID = 0;

                    List<string> files = ucSWFUpload.GetFilesName();
                    if (files.Count > 0)
                        menu.Image = files[0];
                    else
                        menu.Image = string.Empty;

                    menu.IsDeleted = false;
                    menu.KeyWords = string.Empty;
                    menu.LanguageID = CMSContext.LanguageID;
                    menu.MenuType = (CMSEnums.MenuType)Convert.ToInt32(ddlMenuType.SelectedValue);
                    menu.Name = txtName.Text;
                    menu.Order = Convert.ToInt32(txtOrderNumber.Text);
                    menu.ParentID = Convert.ToInt32(cddParentMenu.SelectedValue);
                    menu.PortalID = CMSContext.PortalID;
                    menu.SEOName = string.Empty;
                    menu.CreatedBy = CMSContext.UserID;

                    switch (menu.MenuType)
                    {
                        case CMSEnums.MenuType.Page:
                            menu.PageID = Convert.ToInt32(cddPage.SelectedValue);
                            menu.URL = txtPageURL.Text;
                            break;
                        case CMSEnums.MenuType.Static:
                            int PageId = Convert.ToInt32(cddPage.SelectedValue);
                            if (PageId > 0)
                            {
                                menu.PageID = PageId;
                            }
                            string PageURL = txtPageURL.Text;
                            if (string.IsNullOrEmpty(PageURL))
                            {
                                //Get Default Value
                                PageURL = CMSConfig.CMSPage.GetMenuDetailsPage();
                            }
                            menu.URL = PageURL;
                            break;
                        case CMSEnums.MenuType.URL:
                            menu.PageID = 0;
                            menu.URL = txtURL.Text;
                            break;
                    }

                    if (SelectedParentMenuObjID > 0)
                        menu.ParentObjectID = SelectedParentMenuObjID;

                    if (ucPortalLanguage.SelectedLanguageID > 0)
                        menu.LanguageID = ucPortalLanguage.SelectedLanguageID;

                    MenuManager.Add(menu);

                    if (SelectedParentMenuObjID <= 0)
                        SelectedParentMenuObjID = menu.ID;

                    BeginAddModeOtherLanguage();

                    FillMenuTree();
                    upnlMenu.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlMenu.Update();
                }
            }
        }
        #endregion

        #region ibtnUnPublish_Click
        void ibtnUnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvMenu.CheckedNodes.Count; i++)
            {
                int MenuID = Convert.ToInt32(trvMenu.CheckedNodes[i].Value);
                PublishManager.DeleteByObjectIDAndModuleId(MenuID, (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu);
            }
            FillMenuTree();
            ExitMode();
            upnlMenuItem.Update();
        }
        #endregion

        #region ibtnPublish_Click
        void ibtnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trvMenu.CheckedNodes.Count; i++)
            {
                int menuID = Convert.ToInt32(trvMenu.CheckedNodes[i].Value);
                PublishManager.Add(PrepareNewPublish(menuID));
            }
            FillMenuTree();
            ExitMode();
            upnlMenuItem.Update();

        }
        #endregion

        #endregion

        #region Methods

        #region FillMenuTree
        private void FillMenuTree()
        {
            int CategoryMenuId = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
            //Menu Which Parent Ob Id  = 0 (Language Parent Id = 0)
            List<AJH.CMS.Core.Entities.Menu> menus = MenuManager.GetMenusParentObjByCategory(CategoryMenuId);
            List<AJH.CMS.Core.Entities.Menu> parentMenus = menus.Where(m => m.ParentID == 0).ToList();

            trvMenu.Nodes.Clear();
            foreach (AJH.CMS.Core.Entities.Menu menu in parentMenus)
            {
                TreeNode oNode = GetNodesChilds(menu, menus);
                oNode.ImageUrl = CMSWebHelper.GetPublishedImage(menu.IsPublished);
                trvMenu.Nodes.Add(oNode);
            }
            trvMenu.ExpandAll();
            pnlView.Visible = true;
        }
        #endregion

        #region GetNodesChilds
        private TreeNode GetNodesChilds(AJH.CMS.Core.Entities.Menu menu, List<AJH.CMS.Core.Entities.Menu> menus)
        {
            TreeNode oNode;
            oNode = new TreeNode(menu.ID + ": " + menu.Name, Convert.ToString(menu.ID));
            //oNode.ImageUrl = GetPublishImage(menu.ID);

            oNode.ImageUrl = CMSWebHelper.GetPublishedImage(menu.IsPublished);

            if (ViewState[CMSViewStateManager.MenuID] != null)
            {
                int MenuSelected = Convert.ToInt32(ViewState[CMSViewStateManager.MenuID]);
                if (MenuSelected > 0 && oNode.Value == MenuSelected.ToString())
                {
                    oNode.Selected = true;
                }
            }

            List<AJH.CMS.Core.Entities.Menu> menuChilds = menus.Where(m => m.ParentID == menu.ID).ToList();
            if (menuChilds.Count > 0)
            {
                foreach (AJH.CMS.Core.Entities.Menu menuChild in menuChilds)
                {
                    oNode.ChildNodes.Add(GetNodesChilds(menuChild, menus));
                }
            }
            return oNode;
        }
        #endregion

        #region ExitTree
        void ExitTree()
        {
            ViewState.Remove(CMSViewStateManager.CategoryID);
            pnlView.Visible = false;
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlMenuItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            cddSearchCategory.Category = CMSConfig.ConstantManager.CategoryCategory + (int)CMSEnums.Modules.Menu;

            ibtnDelete.OnClientClick = "return ConfirmOperation('" + trvMenu.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnPublish.OnClientClick = "return ConfirmOperation('" + trvMenu.ClientID + "','Are you sure to publish this item(s)?');";
            ibtnUnPublish.OnClientClick = "return ConfirmOperation('" + trvMenu.ClientID + "','Are you sure to unpublish this item(s)?');";

            ddlMenuType.DataSource = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.MenuType));
            ddlMenuType.DataTextField = "Key";
            ddlMenuType.DataValueField = "Value";
            ddlMenuType.DataBind();
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                ViewState.Remove(CMSViewStateManager.SelectedParentMenuObjID);
                ViewState.Remove(CMSViewStateManager.MenuID);
                pnlMenuItem.Visible = true;
                txtDescription.Text = string.Empty;
                txtDetails.Text = string.Empty;
                txtName.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                txtPageURL.Text = string.Empty;

                trURL.Visible = false;
                trDetails.Visible = true;
                trPage.Visible = true;
                rfvPage.Visible = rfvPage.Enabled = false;
                rfvPageURL.Visible = rfvPageURL.Enabled = false;

                ucSWFUpload.BeginAddMode();

                ucPortalLanguage.Visible = false;
                ucPortalLanguage.SelectedLanguageID = -1;

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnSaveOtherLanguage.Visible = true;
                btnUpdateOtherLanguage.Visible = false;

                pnlMenuItem.DefaultButton = btnSave.ID;

                trIsPublished.Visible = true;
                cbIsPublished.Checked = false;

                cddParentMenu.SelectedValue = cddParentMenu.PromptValue;
                cddParentMenu.Category = CMSConfig.ConstantManager.CategoryMenu + ViewState[CMSViewStateManager.CategoryID];
                ddlMenuType.SelectedValue = ((int)CMSEnums.MenuType.Static).ToString();
                cddPage.SelectedValue = cddPage.PromptValue;
            }
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.MenuID] != null)
            {
                ucPortalLanguage.SelectedLanguageID = -1;

                CMS.Core.Entities.Menu menu = MenuManager.GetMenu(Convert.ToInt32(ViewState[CMSViewStateManager.MenuID]));
                if (menu != null)
                {
                    SelectedParentMenuObjID = menu.ID;

                    pnlMenuItem.Visible = true;
                    txtDescription.Text = menu.Description;
                    txtDetails.Text = menu.Details;
                    txtName.Text = menu.Name;
                    txtOrderNumber.Text = menu.Order.ToString();
                    txtURL.Text = menu.URL;
                    txtPageURL.Text = menu.URL;
                    ucSWFUpload.BeginEditMode(menu.Image);

                    trDetails.Visible = false;
                    trURL.Visible = false;
                    trPage.Visible = false;
                    switch (menu.MenuType)
                    {
                        case CMSEnums.MenuType.Page:
                            trPage.Visible = true;
                            rfvPage.Visible = rfvPage.Enabled = true;
                            rfvPageURL.Visible = rfvPageURL.Enabled = true;
                            break;
                        case CMSEnums.MenuType.Static:
                            trDetails.Visible = true;
                            trPage.Visible = true;
                            rfvPage.Visible = rfvPage.Enabled = false;
                            rfvPageURL.Visible = rfvPageURL.Enabled = false;
                            break;
                        case CMSEnums.MenuType.URL:
                            trURL.Visible = true;
                            break;
                    }

                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = menu.LanguageID;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnUpdateOtherLanguage.Visible = false;
                    btnSaveOtherLanguage.Visible = false;

                    pnlMenuItem.DefaultButton = btnUpdate.ID;

                    trIsPublished.Visible = false;

                    cddParentMenu.SelectedValue = menu.ParentID.ToString();
                    cddParentMenu.Category = CMSConfig.ConstantManager.CategoryMenu + ViewState[CMSViewStateManager.CategoryID] + CMSConfig.ConstantManager.BreakItem + CMSConfig.ConstantManager.CurrentMenu + SelectedParentMenuObjID;
                    ddlMenuType.SelectedValue = ((int)menu.MenuType).ToString();
                    cddPage.SelectedValue = menu.PageID.ToString();
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlSearchCategory.UniqueID] != null)
                cddSearchCategory.SelectedValue = Request.Params[ddlSearchCategory.UniqueID];
            if (Request.Params[ddlParentMenu.UniqueID] != null)
                cddParentMenu.SelectedValue = Request.Params[ddlParentMenu.UniqueID];
            if (Request.Params[ddlPage.UniqueID] != null)
                cddPage.SelectedValue = Request.Params[ddlPage.UniqueID];
        }
        #endregion

        #region BeginAddModeOtherLanguage
        void BeginAddModeOtherLanguage()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                ViewState.Remove(CMSViewStateManager.MenuID);
                pnlMenuItem.Visible = true;
                txtDescription.Text = string.Empty;
                txtDetails.Text = string.Empty;
                txtName.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                txtPageURL.Text = string.Empty;

                trURL.Visible = false;
                trDetails.Visible = true;
                trPage.Visible = true;
                rfvPage.Visible = rfvPage.Enabled = false;
                rfvPageURL.Visible = rfvPageURL.Enabled = false;

                ucSWFUpload.BeginAddMode();

                ucPortalLanguage.Visible = true;

                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnSaveOtherLanguage.Visible = true;
                btnUpdateOtherLanguage.Visible = false;

                pnlMenuItem.DefaultButton = btnSaveOtherLanguage.ID;

                trIsPublished.Visible = false;

                cddParentMenu.SelectedValue = cddParentMenu.PromptValue;
                cddParentMenu.Category = CMSConfig.ConstantManager.CategoryMenu + ViewState[CMSViewStateManager.CategoryID] + CMSConfig.ConstantManager.BreakItem + CMSConfig.ConstantManager.CurrentMenu + SelectedParentMenuObjID;
                ddlMenuType.SelectedValue = ((int)CMSEnums.MenuType.Static).ToString();
                cddPage.SelectedValue = cddPage.PromptValue;
            }
        }
        #endregion

        #region BeginEditModeOtherLanguage
        void BeginEditModeOtherLanguage()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                CMS.Core.Entities.Menu menu =
                         MenuManager.GetMenu(SelectedParentMenuObjID, ucPortalLanguage.SelectedLanguageID);

                if (menu != null)
                {
                    pnlMenuItem.Visible = true;
                    txtDescription.Text = menu.Description;
                    txtDetails.Text = menu.Details;
                    txtName.Text = menu.Name;
                    txtOrderNumber.Text = menu.Order.ToString();
                    txtURL.Text = menu.URL;
                    txtPageURL.Text = menu.URL;
                    ucSWFUpload.BeginEditMode(menu.Image);

                    trDetails.Visible = false;
                    trURL.Visible = false;
                    trPage.Visible = false;
                    switch (menu.MenuType)
                    {
                        case CMSEnums.MenuType.Page:
                            trPage.Visible = true;
                            rfvPage.Visible = rfvPage.Enabled = true;
                            rfvPageURL.Visible = rfvPageURL.Enabled = true;
                            break;
                        case CMSEnums.MenuType.Static:
                            trDetails.Visible = true;
                            trPage.Visible = true;
                            rfvPage.Visible = rfvPage.Enabled = false;
                            rfvPageURL.Visible = rfvPageURL.Enabled = false;
                            break;
                        case CMSEnums.MenuType.URL:
                            trURL.Visible = true;
                            break;
                    }

                    btnSave.Visible = false;
                    btnUpdateOtherLanguage.Visible = true;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = false;

                    pnlMenuItem.DefaultButton = btnUpdateOtherLanguage.ID;

                    trIsPublished.Visible = false;

                    cddParentMenu.SelectedValue = menu.ParentID.ToString();
                    cddParentMenu.Category = CMSConfig.ConstantManager.CategoryMenu + ViewState[CMSViewStateManager.CategoryID] + CMSConfig.ConstantManager.BreakItem + CMSConfig.ConstantManager.CurrentMenu + SelectedParentMenuObjID;
                    ddlMenuType.SelectedValue = ((int)menu.MenuType).ToString();
                    cddPage.SelectedValue = menu.PageID.ToString();
                }
                else
                {
                    BeginAddModeOtherLanguage();
                }
            }
        }
        #endregion

        #region PrepareNewPublish
        private Publish PrepareNewPublish(int menuID)
        {
            Publish publish = new Publish
            {
                CreatedBy = CMSContext.UserID,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                LanguageID = CMSContext.LanguageID,
                ModuleID = AJH.CMS.Core.Enums.CMSEnums.Modules.Menu,
                ObjectID = menuID,
                PortalID = CMSContext.PortalID,
                PublishType = CMSEnums.PublishType.PublishNow,
            };

            return publish;

        }

        #endregion

        #endregion
    }
}