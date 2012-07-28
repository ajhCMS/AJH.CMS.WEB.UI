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
    public partial class ManageArticle_UC : System.Web.UI.UserControl
    {
        #region Properties

        private int SelectedParentArticleObjID
        {
            set
            {
                ViewState[CMSViewStateManager.SelectedParentArticleObjID] = value;
            }
            get
            {
                int selectedParentArticleObjID = -1;
                if (ViewState[CMSViewStateManager.SelectedParentArticleObjID] != null)
                    selectedParentArticleObjID = Convert.ToInt32(ViewState[CMSViewStateManager.SelectedParentArticleObjID]);

                return selectedParentArticleObjID;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageArticle_UC_Load);
            this.ibtnSearchCategory.Click += new ImageClickEventHandler(ibtnSearchCategory_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ddlArticleType.SelectedIndexChanged += new EventHandler(ddlArticleType_SelectedIndexChanged);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvArticle.RowCommand += new GridViewCommandEventHandler(gvArticle_RowCommand);
            this.gvArticle.PageIndexChanging += new GridViewPageEventHandler(gvArticle_PageIndexChanging);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnUpdateOtherLanguage.Click += new EventHandler(btnUpdateOtherLanguage_Click);
            this.ibtnPublish.Click += new ImageClickEventHandler(ibtnPublish_Click);
            this.ibtnUnPublish.Click += new ImageClickEventHandler(ibtnUnPublish_Click);
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
                FillArticles(0);
            }
            else
            {
                ExitGrid();
            }
            ExitMode();
            upnlArticle.Update();
            upnlArticleItem.Update();
        }
        #endregion

        #region btnUpdateOtherLanguage_Click
        void btnUpdateOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Article article =
                    ArticleManager.GetArticle(SelectedParentArticleObjID, ucPortalLanguage.SelectedLanguageID);

                    if (article != null)
                    {
                        article.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                        article.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        article.Description = txtDescription.Text;
                        article.Details = txtDetails.Text;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            article.Image = files[0];
                        else
                            article.Image = string.Empty;

                        article.IsDeleted = false;
                        article.KeyWords = string.Empty;
                        article.ArticleType = (CMSEnums.ArticleType)Convert.ToInt32(cddArticleType.SelectedValue);
                        article.Name = txtName.Text;
                        article.Order = Convert.ToInt32(txtOrderNumber.Text);
                        article.Summary = txtSummary.Text;
                        article.PortalID = CMSContext.PortalID;
                        article.SEOName = string.Empty;
                        article.URL = txtURL.Text;

                        if (article.ArticleType == CMSEnums.ArticleType.Internal)
                        {
                            string articleURL = article.URL;
                            if (string.IsNullOrEmpty(articleURL))
                            {
                                //Get Default Value
                                articleURL = CMSConfig.CMSPage.GetNewsDetailsPage();
                            }

                            //NameValueCollection valueCollection = HttpUtility.ParseQueryString(articleURL);

                            string[] arrQueryString = articleURL.Split('?');
                            string queryString = string.Empty;

                            if (arrQueryString != null && arrQueryString.Length > 1)
                            {
                                queryString = arrQueryString[1];
                            }

                            if (string.IsNullOrEmpty(queryString))
                            {
                                //if (string.IsNullOrEmpty(valueCollection[CMSConfig.QueryString.ArticleID]))
                                //{
                                if (articleURL.Contains("?"))
                                {
                                    articleURL += "&" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                                }
                                else
                                {
                                    articleURL += "?" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                                }
                            }
                            //}
                            article.URL = articleURL;
                        }

                        ArticleManager.Update(article);
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlArticle.Update();
                }
            }

        }
        #endregion

        #region gvArticle_RowCommand
        void gvArticle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditArticle":
                    int ArticleID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out ArticleID);

                    if (ArticleID > 0)
                    {
                        ViewState[CMSViewStateManager.ArticleID] = ArticleID;
                        BeginEditMode();
                        upnlArticleItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region gvArticle_PageIndexChanging
        void gvArticle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillArticles(e.NewPageIndex);
            ExitMode();
            upnlArticleItem.Update();
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvArticle.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvArticle.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvArticle.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int ArticleID = Convert.ToInt32(hdnID.Value);
                        ArticleManager.DeleteLogical(ArticleID);
                    }
                }
            }
            FillArticles(-1);
            ExitMode();
            upnlArticleItem.Update();
        }
        #endregion

        #region ddlArticleType_SelectedIndexChanged
        void ddlArticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ArticleType = 0;
            int.TryParse(cddArticleType.SelectedValue, out ArticleType);

            trDetails.Visible = false;
            rfvURL.Enabled = rfvURL.Visible = true;

            switch ((CMSEnums.ArticleType)ArticleType)
            {
                case CMSEnums.ArticleType.External:
                    break;
                case CMSEnums.ArticleType.Internal:
                    trDetails.Visible = true;
                    rfvURL.Enabled = rfvURL.Visible = false;
                    break;
            }
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlArticleItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.ArticleID] != null)
            {
                try
                {
                    CMS.Core.Entities.Article article = ArticleManager.GetArticle(Convert.ToInt32(ViewState[CMSViewStateManager.ArticleID]));
                    if (article != null)
                    {
                        article.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                        article.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        article.Description = txtDescription.Text;
                        article.Details = txtDetails.Text;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            article.Image = files[0];
                        else
                            article.Image = string.Empty;

                        article.IsDeleted = false;
                        article.KeyWords = string.Empty;
                        article.ArticleType = (CMSEnums.ArticleType)Convert.ToInt32(cddArticleType.SelectedValue);
                        article.Name = txtName.Text;
                        article.Order = Convert.ToInt32(txtOrderNumber.Text);
                        article.Summary = txtSummary.Text;
                        article.PortalID = CMSContext.PortalID;
                        article.SEOName = string.Empty;
                        article.URL = txtURL.Text;

                        if (article.ArticleType == CMSEnums.ArticleType.Internal)
                        {
                            string articleURL = article.URL;
                            if (string.IsNullOrEmpty(articleURL))
                            {
                                //Get Default Value
                                articleURL = CMSConfig.CMSPage.GetNewsDetailsPage();
                            }

                            //NameValueCollection valueCollection = HttpUtility.ParseQueryString(articleURL);

                            string[] arrQueryString = articleURL.Split('?');
                            string queryString = string.Empty;

                            if (arrQueryString != null && arrQueryString.Length > 1)
                            {
                                queryString = arrQueryString[1];
                            }

                            if (string.IsNullOrEmpty(queryString))
                            {
                                //if (string.IsNullOrEmpty(valueCollection[CMSConfig.QueryString.ArticleID]))
                                //{
                                if (articleURL.Contains("?"))
                                {
                                    articleURL += "&" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                                }
                                else
                                {
                                    articleURL += "?" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                                }
                            }
                            //}
                            article.URL = articleURL;
                        }

                        ArticleManager.Update(article);

                        btnSaveOtherLanguage.Visible = false;
                        FillArticles(-1);
                        upnlArticle.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlArticle.Update();
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
                    CMS.Core.Entities.Article article = new Core.Entities.Article();
                    article.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                    article.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                    article.Description = txtDescription.Text;
                    article.Details = txtDetails.Text;
                    article.ID = 0;

                    List<string> files = ucSWFUpload.GetFilesName();
                    if (files.Count > 0)
                        article.Image = files[0];
                    else
                        article.Image = string.Empty;

                    article.IsDeleted = false;
                    article.KeyWords = string.Empty;
                    article.LanguageID = CMSContext.LanguageID;
                    article.ArticleType = (CMSEnums.ArticleType)Convert.ToInt32(cddArticleType.SelectedValue);
                    article.Name = txtName.Text;
                    article.Order = Convert.ToInt32(txtOrderNumber.Text);
                    article.Summary = txtSummary.Text;
                    article.PortalID = CMSContext.PortalID;
                    article.SEOName = string.Empty;
                    article.URL = txtURL.Text;
                    article.CreatedBy = CMSContext.UserID;
                    ArticleManager.Add(article);

                    if (article.ArticleType == CMSEnums.ArticleType.Internal)
                    {
                        string articleURL = article.URL;
                        if (string.IsNullOrEmpty(articleURL))
                        {
                            //Get Default Value
                            articleURL = CMSConfig.CMSPage.GetNewsDetailsPage();
                        }

                        //NameValueCollection valueCollection = HttpUtility.ParseQueryString(articleURL);

                        string[] arrQueryString = articleURL.Split('?');
                        string queryString = string.Empty;

                        if (arrQueryString != null && arrQueryString.Length > 1)
                        {
                            queryString = arrQueryString[1];
                        }

                        if (string.IsNullOrEmpty(queryString))
                        {
                            //if (string.IsNullOrEmpty(valueCollection[CMSConfig.QueryString.ArticleID]))
                            //{
                            if (articleURL.Contains("?"))
                            {
                                articleURL += "&" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                            }
                            else
                            {
                                articleURL += "?" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                            }
                        }
                        //}
                        article.URL = articleURL;
                        ArticleManager.Update(article);
                    }

                    //Publish Article :
                    if (cbIsPublished.Checked)
                        PublishManager.Add(PrepareNewPublish(article.ID));

                    BeginAddMode();

                    FillArticles(-1);
                    upnlArticle.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlArticle.Update();
                }
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.ArticleID] != null)
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

        #region ManageArticle_UC_Load
        void ManageArticle_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                ExitGrid();
                ExitMode();
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
                    CMS.Core.Entities.Article article = new Core.Entities.Article();
                    article.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                    article.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                    article.Description = txtDescription.Text;
                    article.Details = txtDetails.Text;
                    article.ID = 0;

                    List<string> files = ucSWFUpload.GetFilesName();
                    if (files.Count > 0)
                        article.Image = files[0];
                    else
                        article.Image = string.Empty;

                    article.IsDeleted = false;
                    article.KeyWords = string.Empty;

                    article.ArticleType = (CMSEnums.ArticleType)Convert.ToInt32(cddArticleType.SelectedValue);
                    article.Name = txtName.Text;
                    article.Order = Convert.ToInt32(txtOrderNumber.Text);
                    article.Summary = txtSummary.Text;
                    article.PortalID = CMSContext.PortalID;
                    article.SEOName = string.Empty;
                    article.URL = txtURL.Text;
                    article.CreatedBy = CMSContext.UserID;
                    article.LanguageID = CMSContext.LanguageID;

                    if (SelectedParentArticleObjID > 0)
                        article.ParentObjectID = SelectedParentArticleObjID;

                    if (ucPortalLanguage.SelectedLanguageID > 0)
                        article.LanguageID = ucPortalLanguage.SelectedLanguageID;

                    ArticleManager.Add(article);

                    if (SelectedParentArticleObjID <= 0)
                        SelectedParentArticleObjID = article.ID;

                    if (article.ArticleType == CMSEnums.ArticleType.Internal)
                    {
                        string articleURL = article.URL;
                        if (string.IsNullOrEmpty(articleURL))
                        {
                            //Get Default Value
                            articleURL = CMSConfig.CMSPage.GetNewsDetailsPage();
                        }

                        //NameValueCollection valueCollection = HttpUtility.ParseQueryString(articleURL);

                        string[] arrQueryString = articleURL.Split('?');
                        string queryString = string.Empty;

                        if (arrQueryString != null && arrQueryString.Length > 1)
                        {
                            queryString = arrQueryString[1];
                        }

                        if (string.IsNullOrEmpty(queryString))
                        {
                            //if (string.IsNullOrEmpty(valueCollection[CMSConfig.QueryString.ArticleID]))
                            //{
                            if (articleURL.Contains("?"))
                            {
                                articleURL += "&" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                            }
                            else
                            {
                                articleURL += "?" + CMSConfig.QueryString.ArticleID + "=" + article.ID;
                            }
                        }
                        //}
                        article.URL = articleURL;
                        ArticleManager.Update(article);
                    }

                    BeginAddModeOtherLanguage();

                    FillArticles(-1);
                    upnlArticle.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlArticle.Update();
                }
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

        #region ibtnUnPublish_Click
        void ibtnUnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvArticle.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvArticle.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvArticle.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int articleID = Convert.ToInt32(hdnID.Value);
                        PublishManager.DeleteByObjectIDAndModuleId(articleID, (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Article);
                    }
                }
            }
            FillArticles(-1);
            ExitMode();
            upnlArticleItem.Update();
        }
        #endregion

        #region ibtnPublish_Click
        void ibtnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvArticle.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvArticle.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvArticle.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int articleID = Convert.ToInt32(hdnID.Value);
                        PublishManager.Add(PrepareNewPublish(articleID));
                    }
                }
            }
            FillArticles(-1);
            ExitMode();
            upnlArticleItem.Update();
        }
        #endregion

        #endregion

        #region Methods

        #region FillArticles
        private void FillArticles(int PageIndex)
        {
            if (PageIndex > -1)
                gvArticle.PageIndex = PageIndex;

            List<CMS.Core.Entities.Article> articles = ArticleManager.GetParentArticles(Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]));
            gvArticle.DataSource = articles;
            gvArticle.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #region ExitGrid
        void ExitGrid()
        {
            ViewState.Remove(CMSViewStateManager.CategoryID);
            pnlView.Visible = false;
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlArticleItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            cddSearchCategory.Category = CMSConfig.ConstantManager.CategoryCategory + (int)CMSEnums.Modules.Article;

            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvArticle.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnPublish.OnClientClick = "return ConfirmOperation('" + gvArticle.ClientID + "','Are you sure to publish this item(s)?');";
            ibtnUnPublish.OnClientClick = "return ConfirmOperation('" + gvArticle.ClientID + "','Are you sure to unpublish this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                ViewState.Remove(CMSViewStateManager.SelectedParentArticleObjID);
                ucPortalLanguage.SelectedLanguageID = -1;
                ViewState.Remove(CMSViewStateManager.ArticleID);
                pnlArticleItem.Visible = true;
                txtDescription.Text = string.Empty;
                txtDetails.Text = string.Empty;
                txtName.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                txtSummary.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                rfvURL.Enabled = rfvURL.Visible = false;
                trDetails.Visible = true;
                cddArticleType.SelectedValue = ((int)CMSEnums.ArticleType.Internal).ToString();
                ucAjaxDate.SelectedDateTime = DateTime.Now;
                ucSWFUpload.BeginAddMode();

                ucPortalLanguage.Visible = false;

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnSaveOtherLanguage.Visible = true;
                btnUpdateOtherLanguage.Visible = false;

                trIsPublished.Visible = true;
                cbIsPublished.Checked = false;

                pnlArticleItem.DefaultButton = btnSave.ID;
            }
        }
        #endregion

        #region BeginAddModeOtherLanguage
        void BeginAddModeOtherLanguage()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                ViewState.Remove(CMSViewStateManager.ArticleID);
                pnlArticleItem.Visible = true;
                txtDescription.Text = string.Empty;
                txtDetails.Text = string.Empty;
                txtName.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                txtSummary.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtURL.Text = string.Empty;
                rfvURL.Enabled = rfvURL.Visible = false;
                trDetails.Visible = true;
                cddArticleType.SelectedValue = ((int)CMSEnums.ArticleType.Internal).ToString();
                ucAjaxDate.SelectedDateTime = DateTime.Now;
                ucSWFUpload.BeginAddMode();

                ucPortalLanguage.Visible = true;

                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnSaveOtherLanguage.Visible = true;
                btnUpdateOtherLanguage.Visible = false;
                trIsPublished.Visible = false;

                pnlArticleItem.DefaultButton = btnSaveOtherLanguage.ID;
            }
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.ArticleID] != null)
            {
                ucPortalLanguage.SelectedLanguageID = -1;

                CMS.Core.Entities.Article article = ArticleManager.GetArticle(Convert.ToInt32(ViewState[CMSViewStateManager.ArticleID]));
                if (article != null)
                {
                    pnlArticleItem.Visible = true;
                    SelectedParentArticleObjID = article.ID;
                    txtDescription.Text = article.Description;
                    txtDetails.Text = article.Details;
                    txtName.Text = article.Name;
                    txtOrderNumber.Text = article.Order.ToString();
                    txtURL.Text = article.URL;
                    txtSummary.Text = article.Summary;
                    cddArticleType.SelectedValue = ((int)article.ArticleType).ToString();
                    txtURL.Text = article.URL;
                    ucSWFUpload.BeginEditMode(article.Image);
                    ucAjaxDate.SelectedDateTime = article.CreationDate;

                    ucPortalLanguage.SelectedLanguageID = article.LanguageID;
                    ucPortalLanguage.Visible = true;

                    rfvURL.Enabled = rfvURL.Visible = true;
                    trDetails.Visible = false;

                    switch (article.ArticleType)
                    {
                        case CMSEnums.ArticleType.External:
                            break;
                        case CMSEnums.ArticleType.Internal:
                            trDetails.Visible = true;
                            rfvURL.Enabled = rfvURL.Visible = false;
                            break;
                    }

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdateOtherLanguage.Visible = false;

                    trIsPublished.Visible = false;

                    pnlArticleItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlSearchCategory.UniqueID] != null)
                cddSearchCategory.SelectedValue = Request.Params[ddlSearchCategory.UniqueID];
            if (Request.Params[ddlArticleType.UniqueID] != null)
                cddArticleType.SelectedValue = Request.Params[ddlArticleType.UniqueID];
        }
        #endregion

        #region BeginEditModeOtherLanguage
        void BeginEditModeOtherLanguage()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                //Get article By Parent Obj Id And LanguageId
                CMS.Core.Entities.Article article =
                    ArticleManager.GetArticle(SelectedParentArticleObjID, ucPortalLanguage.SelectedLanguageID);

                if (article != null)
                {
                    pnlArticleItem.Visible = true;
                    txtDescription.Text = article.Description;
                    txtDetails.Text = article.Details;
                    txtName.Text = article.Name;
                    txtOrderNumber.Text = article.Order.ToString();
                    txtURL.Text = article.URL;
                    txtSummary.Text = article.Summary;
                    cddArticleType.SelectedValue = ((int)article.ArticleType).ToString();
                    txtURL.Text = article.URL;
                    ucSWFUpload.BeginEditMode(article.Image);
                    ucAjaxDate.SelectedDateTime = article.CreationDate;

                    rfvURL.Enabled = rfvURL.Visible = true;
                    trDetails.Visible = false;

                    switch (article.ArticleType)
                    {
                        case CMSEnums.ArticleType.External:
                            break;
                        case CMSEnums.ArticleType.Internal:
                            trDetails.Visible = true;
                            rfvURL.Enabled = rfvURL.Visible = false;
                            break;
                    }

                    btnSave.Visible = false;
                    btnUpdateOtherLanguage.Visible = true;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = false;

                    trIsPublished.Visible = false;

                    pnlArticleItem.DefaultButton = btnUpdateOtherLanguage.ID;
                }
                else
                {
                    BeginAddModeOtherLanguage();
                }
            }
        }
        #endregion

        #region PrepareNewPublish
        private Publish PrepareNewPublish(int articleID)
        {
            Publish publish = new Publish
            {
                CreatedBy = CMSContext.UserID,
                LanguageID = CMSContext.LanguageID,
                ModuleID = AJH.CMS.Core.Enums.CMSEnums.Modules.Article,
                ObjectID = articleID,
                PortalID = CMSContext.PortalID,
                PublishType = CMSEnums.PublishType.PublishNow,
            };

            return publish;

        }
        #endregion

        #endregion
    }
}