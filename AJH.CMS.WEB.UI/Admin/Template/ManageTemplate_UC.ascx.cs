using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageTemplate_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageTemplate_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvTemplate.RowCommand += new GridViewCommandEventHandler(gvTemplate_RowCommand);
            this.gvTemplate.PageIndexChanging += new GridViewPageEventHandler(gvTemplate_PageIndexChanging);
        }
        #endregion

        #region gvTemplate_PageIndexChanging
        void gvTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillTemplates(e.NewPageIndex);
            ExitMode();
            upnlTemplateItem.Update();
        }
        #endregion

        #region gvTemplate_RowCommand
        void gvTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditTemplate":
                    int TemplateID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out TemplateID);

                    if (TemplateID > 0)
                    {
                        ViewState[CMSViewStateManager.TemplateID] = TemplateID;
                        BeginEditMode();
                        upnlTemplateItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvTemplate.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvTemplate.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvTemplate.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int TemplateID = Convert.ToInt32(hdnID.Value);
                        TemplateManager.DeleteLogical(TemplateID);
                    }
                }
            }
            FillTemplates(-1);
            ExitMode();
            upnlTemplateItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlTemplateItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.TemplateID] != null)
            {
                try
                {
                    CMS.Core.Entities.Template template = TemplateManager.GetTemplate(Convert.ToInt32(ViewState[CMSViewStateManager.TemplateID]));
                    if (template != null)
                    {
                        template.Description = txtDescription.Text;
                        template.IsDeleted = false;
                        template.LanguageID = CMSContext.LanguageID;
                        template.Name = txtName.Text;
                        template.PortalID = CMSContext.PortalID;
                        TemplateManager.Update(template);
                        FillTemplates(-1);
                        upnlTemplate.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlTemplate.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Template template = new Core.Entities.Template();
                template.CreationDate = DateTime.Now;
                template.Description = txtDescription.Text;
                template.ID = 0;
                template.IsDeleted = false;
                template.LanguageID = CMSContext.LanguageID;
                template.Name = txtName.Text;
                template.PortalID = CMSContext.PortalID;
                template.CreatedBy = CMSContext.UserID;
                TemplateManager.Add(template);
                BeginAddMode();
                FillTemplates(-1);
                upnlTemplate.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlTemplate.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.TemplateID] != null)
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

        #region ManageTemplate_UC_Load
        void ManageTemplate_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillTemplates(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillTemplates
        void FillTemplates(int PageIndex)
        {
            if (PageIndex > -1)
                gvTemplate.PageIndex = PageIndex;
            gvTemplate.DataSource = TemplateManager.GetTemplates(CMSContext.PortalID, CMSContext.LanguageID);
            gvTemplate.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlTemplateItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvTemplate.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.TemplateID);
            pnlTemplateItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlTemplateItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.TemplateID] != null)
            {
                CMS.Core.Entities.Template template = TemplateManager.GetTemplate(Convert.ToInt32(ViewState[CMSViewStateManager.TemplateID]));
                if (template != null)
                {
                    pnlTemplateItem.Visible = true;
                    txtDescription.Text = template.Description;
                    txtName.Text = template.Name;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlTemplateItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region GetDesignTemplatePath
        protected string GetDesignTemplatePath(int TemplateID)
        {
            return CMSConfig.CMSAdminPages.GetDesignTemplatePagePath(TemplateID);
        }
        #endregion

        #endregion
    }
}