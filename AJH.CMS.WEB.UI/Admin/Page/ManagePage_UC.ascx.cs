using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManagePage_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManagePage_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvPage.RowCommand += new GridViewCommandEventHandler(gvPage_RowCommand);
            this.gvPage.PageIndexChanging += new GridViewPageEventHandler(gvPage_PageIndexChanging);
        }
        #endregion

        #region gvPage_PageIndexChanging
        void gvPage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillPages(e.NewPageIndex);
            ExitMode();
            upnlPageItem.Update();
        }
        #endregion

        #region gvPage_RowCommand
        void gvPage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditPage":
                    int PageID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out PageID);

                    if (PageID > 0)
                    {
                        ViewState[CMSViewStateManager.PageID] = PageID;
                        BeginEditMode();
                        upnlPageItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvPage.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvPage.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvPage.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int PageID = Convert.ToInt32(hdnID.Value);
                        PageManager.DeleteLogical(PageID);
                    }
                }
            }
            FillPages(-1);
            ExitMode();
            upnlPageItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlPageItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.PageID] != null)
            {
                try
                {
                    CMS.Core.Entities.Page page = PageManager.GetPage(Convert.ToInt32(ViewState[CMSViewStateManager.PageID]));
                    if (page != null)
                    {
                        page.Description = txtDescription.Text;
                        page.KeyWords = txtKeyword.Text;
                        page.LanguageID = CMSContext.LanguageID;
                        page.Name = txtName.Text;
                        page.PageType = (CMSEnums.PageType)Convert.ToInt32(cddPageType.SelectedValue);
                        page.PortalID = CMSContext.PortalID;
                        page.SEOName = txtSEOName.Text;
                        page.TemplateID = Convert.ToInt32(cddTemplate.SelectedValue);
                        page.Title = txtTitle.Text;
                        PageManager.Update(page);
                        FillPages(-1);
                        upnlPage.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.Message;
                    upnlPage.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Page page = new Core.Entities.Page();
                page.CreationDate = DateTime.Now;
                page.Description = txtDescription.Text;
                page.IsDeleted = false;
                page.KeyWords = txtKeyword.Text;
                page.LanguageID = CMSContext.LanguageID;
                page.Name = txtName.Text;
                page.PageType = (CMSEnums.PageType)Convert.ToInt32(cddPageType.SelectedValue);
                page.PortalID = CMSContext.PortalID;
                page.SEOName = txtSEOName.Text;
                page.TemplateID = Convert.ToInt32(cddTemplate.SelectedValue);
                page.Title = txtTitle.Text;
                page.CreatedBy = CMSContext.CurrentUserID;
                PageManager.Add(page);
                BeginAddMode();
                FillPages(-1);
                upnlPage.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;
                upnlPage.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.PageID] != null)
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

        #region ManagePage_UC_Load
        void ManagePage_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillPages(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillPages
        void FillPages(int PageIndex)
        {
            if (PageIndex > -1)
                gvPage.PageIndex = PageIndex;
            gvPage.DataSource = PageManager.GetPages(CMSContext.PortalID, CMSContext.LanguageID);
            gvPage.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlPageItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvPage.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.PageID);
            pnlPageItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtKeyword.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSEOName.Text = string.Empty;
            txtTitle.Text = string.Empty;
            cddPageType.SelectedValue = cddPageType.PromptValue;
            cddTemplate.SelectedValue = cddTemplate.PromptValue;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlPageItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.PageID] != null)
            {
                CMS.Core.Entities.Page page = PageManager.GetPage(Convert.ToInt32(ViewState[CMSViewStateManager.PageID]));
                if (page != null)
                {
                    pnlPageItem.Visible = true;

                    txtDescription.Text = page.Description;
                    txtKeyword.Text = page.KeyWords;
                    txtName.Text = page.Name;
                    txtSEOName.Text = page.SEOName;
                    txtTitle.Text = page.Title;
                    cddPageType.SelectedValue = ((int)page.PageType).ToString();
                    cddTemplate.SelectedValue = page.TemplateID.ToString();

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlPageItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlPageType.UniqueID] != null)
                cddPageType.SelectedValue = Request.Params[ddlPageType.UniqueID];
            if (Request.Params[ddlTemplate.UniqueID] != null)
                cddTemplate.SelectedValue = Request.Params[ddlTemplate.UniqueID];
        }
        #endregion

        #region GetDesignPagePath
        protected string GetDesignPagePath(int PageID)
        {
            return CMSConfig.CMSAdminPages.GetDesignPagePath(PageID);
        }
        #endregion

        #endregion
    }
}