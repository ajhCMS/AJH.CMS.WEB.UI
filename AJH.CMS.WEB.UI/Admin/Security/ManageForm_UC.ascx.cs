using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageForm_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageForm_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvForm.RowCommand += new GridViewCommandEventHandler(gvForm_RowCommand);
            this.gvForm.PageIndexChanging += new GridViewPageEventHandler(gvForm_PageIndexChanging);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region gvForm_PageIndexChanging
        void gvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillForms(e.NewPageIndex);
            ExitMode();
            upnlFormItem.Update();
        }
        #endregion

        #region gvForm_RowCommand
        void gvForm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditForm":
                    int FormID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out FormID);

                    if (FormID > 0)
                    {
                        ViewState[CMSViewStateManager.FormID] = FormID;
                        BeginEditMode();
                        upnlFormItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForm.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForm.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvForm.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int FormID = Convert.ToInt32(hdnID.Value);
                        FormManager.DeleteLogical(FormID);
                    }
                }
            }
            FillForms(-1);
            ExitMode();
            upnlFormItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlFormItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                try
                {
                    CMS.Core.Entities.Form form = FormManager.GetForm(Convert.ToInt32(ViewState[CMSViewStateManager.FormID]));
                    if (form != null)
                    {
                        form.Code = txtCode.Text;
                        form.Description = txtDescription.Text;
                        form.IsDeleted = false;
                        form.ModuleID = 0;
                        form.Name = txtName.Text;
                        form.Url = txtUrl.Text;
                        FormManager.Update(form);

                        FillForms(-1);
                        upnlForm.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.Message;
                    upnlForm.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Form form = new Core.Entities.Form();
                form.Code = txtCode.Text;
                form.Description = txtDescription.Text;
                form.ID = 0;
                form.IsDeleted = false;
                form.ModuleID = 0;
                form.Name = txtName.Text;
                form.Url = txtUrl.Text;
                FormManager.Add(form);

                BeginAddMode();
                FillForms(-1);
                upnlForm.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;
                upnlForm.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
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

        #region ManageForm_UC_Load
        void ManageForm_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillForms(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillForms
        void FillForms(int PageIndex)
        {
            if (PageIndex > -1)
                gvForm.PageIndex = PageIndex;
            gvForm.DataSource = FormManager.GetForms();
            gvForm.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlFormItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvForm.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.FormID);
            pnlFormItem.Visible = true;

            txtCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtUrl.Text = string.Empty;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlFormItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                CMS.Core.Entities.Form form = FormManager.GetForm(Convert.ToInt32(ViewState[CMSViewStateManager.FormID]));
                if (form != null)
                {
                    pnlFormItem.Visible = true;

                    txtCode.Text = form.Code;
                    txtDescription.Text = form.Description;
                    txtName.Text = form.Name;
                    txtUrl.Text = form.Url;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlFormItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #endregion
    }
}