using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageCMSControl_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageCMSControl_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvCMSControl.RowCommand += new GridViewCommandEventHandler(gvCMSControl_RowCommand);
            this.gvCMSControl.PageIndexChanging += new GridViewPageEventHandler(gvCMSControl_PageIndexChanging);
        }
        #endregion

        #region gvCMSControl_PageIndexChanging
        void gvCMSControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillCMSControls(e.NewPageIndex);
            ExitMode();
            upnlCMSControlItem.Update();
        }
        #endregion

        #region gvCMSControl_RowCommand
        void gvCMSControl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditCMSControl":
                    int CMSControlID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out CMSControlID);

                    if (CMSControlID > 0)
                    {
                        ViewState[CMSViewStateManager.CMSControlID] = CMSControlID;
                        BeginEditMode();
                        upnlCMSControlItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvCMSControl.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvCMSControl.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvCMSControl.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int CMSControlID = Convert.ToInt32(hdnID.Value);
                        CMSControlManager.DeleteLogical(CMSControlID);
                    }
                }
            }
            FillCMSControls(-1);
            ExitMode();
            upnlCMSControlItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlCMSControlItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CMSControlID] != null)
            {
                try
                {
                    CMS.Core.Entities.CMSControl cmsControl = CMSControlManager.GetCMSControl(Convert.ToInt32(ViewState[CMSViewStateManager.CMSControlID]));
                    if (cmsControl != null)
                    {
                        cmsControl.IsDeleted = false;
                        cmsControl.Name = txtName.Text;
                        cmsControl.Description = txtDescription.Text;
                        cmsControl.UserControlPath = txtUserControlPath.Text;
                        cmsControl.ModuleID = Convert.ToInt32(cddModule.SelectedValue);
                        CMSControlManager.Update(cmsControl);

                        FillCMSControls(-1);
                        upnlCMSControl.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlCMSControl.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.CMSControl cmsControl = new Core.Entities.CMSControl();
                cmsControl.CreationDate = DateTime.Now;
                cmsControl.ID = 0;
                cmsControl.IsDeleted = false;
                cmsControl.Name = txtName.Text;
                cmsControl.Description = txtDescription.Text;
                cmsControl.UserControlPath = txtUserControlPath.Text;
                cmsControl.ModuleID = Convert.ToInt32(cddModule.SelectedValue);
                cmsControl.CreatedBy = CMSContext.UserID;
                CMSControlManager.Add(cmsControl);

                BeginAddMode();
                FillCMSControls(-1);
                upnlCMSControl.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlCMSControl.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CMSControlID] != null)
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

        #region ManageCMSControl_UC_Load
        void ManageCMSControl_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillCMSControls(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillCMSControls
        void FillCMSControls(int PageIndex)
        {
            if (PageIndex > -1)
                gvCMSControl.PageIndex = PageIndex;
            gvCMSControl.DataSource = CMSControlManager.GetCMSControls();
            gvCMSControl.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlCMSControlItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvCMSControl.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.CMSControlID);
            pnlCMSControlItem.Visible = true;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUserControlPath.Text = string.Empty;
            cddModule.SelectedValue = cddModule.PromptValue;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlCMSControlItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CMSControlID] != null)
            {
                CMS.Core.Entities.CMSControl cmsControl = CMSControlManager.GetCMSControl(Convert.ToInt32(ViewState[CMSViewStateManager.CMSControlID]));
                if (cmsControl != null)
                {
                    pnlCMSControlItem.Visible = true;
                    txtName.Text = cmsControl.Name;
                    txtDescription.Text = cmsControl.Description;
                    txtUserControlPath.Text = cmsControl.UserControlPath;
                    cddModule.SelectedValue = cmsControl.ModuleID.ToString();

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlCMSControlItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlModule.UniqueID] != null)
                cddModule.SelectedValue = Request.Params[ddlModule.UniqueID];
        }
        #endregion

        #endregion
    }
}