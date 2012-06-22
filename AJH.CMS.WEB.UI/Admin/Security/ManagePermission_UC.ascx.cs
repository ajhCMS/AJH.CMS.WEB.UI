using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManagePermission_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManagePermission_UC_Load);
            this.gvForm.RowCommand += new GridViewCommandEventHandler(gvForm_RowCommand);
            this.gvForm.PageIndexChanging += new GridViewPageEventHandler(gvForm_PageIndexChanging);
            this.gvRole.PageIndexChanging += new GridViewPageEventHandler(gvRole_PageIndexChanging);
            this.gvRole.RowCommand += new GridViewCommandEventHandler(gvRole_RowCommand);
            this.btnPermissionRoleExit.Click += new EventHandler(btnPermissionRoleExit_Click);
            this.btnPermissionRoleSave.Click += new EventHandler(btnPermissionRoleSave_Click);
            this.btnPermissionRoleUpdate.Click += new EventHandler(btnPermissionRoleUpdate_Click);
            this.ibtnPermissionRoleAdd.Click += new ImageClickEventHandler(ibtnPermissionRoleAdd_Click);
            this.ibtnPermissionRoleDelete.Click += new ImageClickEventHandler(ibtnPermissionRoleDelete_Click);
            this.gvUser.PageIndexChanging += new GridViewPageEventHandler(gvUser_PageIndexChanging);
            this.gvUser.RowCommand += new GridViewCommandEventHandler(gvUser_RowCommand);
            this.btnPermissionUserExit.Click += new EventHandler(btnPermissionUserExit_Click);
            this.btnPermissionUserSave.Click += new EventHandler(btnPermissionUserSave_Click);
            this.btnPermissionUserUpdate.Click += new EventHandler(btnPermissionUserUpdate_Click);
            this.ibtnPermissionUserAdd.Click += new ImageClickEventHandler(ibtnPermissionUserAdd_Click);
            this.ibtnPermissionUserDelete.Click += new ImageClickEventHandler(ibtnPermissionUserDelete_Click);
        }
        #endregion

        #region ibtnPermissionUserDelete_Click
        void ibtnPermissionUserDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvUser.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvUser.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int FormUserID = Convert.ToInt32(hdnID.Value);
                        FormUserManager.Delete(FormUserID);
                    }
                }
            }
            FillUsers(-1);
            UserExitMode();
        }
        #endregion

        #region ibtnPermissionUserAdd_Click
        void ibtnPermissionUserAdd_Click(object sender, ImageClickEventArgs e)
        {
            UserAddMode();
        }
        #endregion

        #region btnPermissionUserUpdate_Click
        void btnPermissionUserUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null && ViewState[CMSViewStateManager.FormUserID] != null)
            {
                try
                {
                    CMS.Core.Entities.FormUser formUser = FormUserManager.GetFormUser(Convert.ToInt32(ViewState[CMSViewStateManager.FormUserID]));
                    if (formUser != null)
                    {
                        formUser.AccessType = (CMSEnums.AccessType)Convert.ToInt32(rblAccessTypeUser.SelectedValue);
                        FormUserManager.Update(formUser);

                        FillUsers(-1);
                    }
                }
                catch (Exception ex)
                {
                    dvProblemUser.Visible = true;
                    dvProblemUser.InnerText = ex.Message;
                }
            }
        }
        #endregion

        #region btnPermissionUserSave_Click
        void btnPermissionUserSave_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                try
                {
                    CMS.Core.Entities.FormUser formUser = new FormUser();
                    formUser.AccessType = (CMSEnums.AccessType)Convert.ToInt32(rblAccessTypeUser.SelectedValue);
                    formUser.FormID = Convert.ToInt32(ViewState[CMSViewStateManager.FormID]);
                    formUser.ID = 0;
                    formUser.UserID = Convert.ToInt32(cddUsers.SelectedValue);
                    FormUserManager.Add(formUser);

                    FillUsers(-1);
                }
                catch (Exception ex)
                {
                    dvProblemUser.Visible = true;
                    dvProblemUser.InnerText = ex.Message;
                }
            }
        }
        #endregion

        #region btnPermissionUserExit_Click
        void btnPermissionUserExit_Click(object sender, EventArgs e)
        {
            UserExitMode();
        }
        #endregion

        #region gvUser_RowCommand
        void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditUser":
                    int FormUserID = Convert.ToInt32(e.CommandArgument);
                    ViewState[CMSViewStateManager.FormUserID] = FormUserID;
                    UserEditMode();
                    break;
            }
        }
        #endregion

        #region ibtnPermissionRoleDelete_Click
        void ibtnPermissionRoleDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvRole.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvRole.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvRole.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int FormRoleID = Convert.ToInt32(hdnID.Value);
                        FormRoleManager.Delete(FormRoleID);
                    }
                }
            }
            FillRoles(-1);
            RoleExitMode();
        }
        #endregion

        #region ibtnPermissionRoleAdd_Click
        void ibtnPermissionRoleAdd_Click(object sender, ImageClickEventArgs e)
        {
            RoleAddMode();
        }
        #endregion

        #region btnPermissionRoleUpdate_Click
        void btnPermissionRoleUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null && ViewState[CMSViewStateManager.FormRoleID] != null)
            {
                try
                {
                    CMS.Core.Entities.FormRole formRole = FormRoleManager.GetFormRole(Convert.ToInt32(ViewState[CMSViewStateManager.FormRoleID]));
                    if (formRole != null)
                    {
                        formRole.AccessType = (CMSEnums.AccessType)Convert.ToInt32(rblAccessTypeRole.SelectedValue);
                        FormRoleManager.Update(formRole);

                        FillRoles(-1);
                    }
                }
                catch (Exception ex)
                {
                    dvProblemRole.Visible = true;
                    dvProblemRole.InnerText = ex.Message;
                }
            }
        }
        #endregion

        #region btnPermissionRoleSave_Click
        void btnPermissionRoleSave_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                try
                {
                    CMS.Core.Entities.FormRole formRole = new FormRole();
                    formRole.AccessType = (CMSEnums.AccessType)Convert.ToInt32(rblAccessTypeRole.SelectedValue);
                    formRole.FormID = Convert.ToInt32(ViewState[CMSViewStateManager.FormID]);
                    formRole.ID = 0;
                    formRole.RoleID = Convert.ToInt32(cddRoles.SelectedValue);
                    FormRoleManager.Add(formRole);

                    FillRoles(-1);
                }
                catch (Exception ex)
                {
                    dvProblemRole.Visible = true;
                    dvProblemRole.InnerText = ex.Message;
                }
            }
        }
        #endregion

        #region btnPermissionRoleExit_Click
        void btnPermissionRoleExit_Click(object sender, EventArgs e)
        {
            RoleExitMode();
        }
        #endregion

        #region gvRole_RowCommand
        void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditRole":
                    int FormRoleID = Convert.ToInt32(e.CommandArgument);
                    ViewState[CMSViewStateManager.FormRoleID] = FormRoleID;
                    RoleEditMode();
                    break;
            }
        }
        #endregion

        #region gvRole_PageIndexChanging
        void gvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillRoles(e.NewPageIndex);
            RoleExitMode();
        }
        #endregion

        #region gvUser_PageIndexChanging
        void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillUsers(e.NewPageIndex);
            UserExitMode();
        }
        #endregion

        #region gvForm_PageIndexChanging
        void gvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillForms(e.NewPageIndex);
            ExitMode();
            upnlPermissionRole.Update();
            upnlPermissionUser.Update();
        }
        #endregion

        #region gvForm_RowCommand
        void gvForm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int FormID = 0;
            ExitMode();
            switch (e.CommandName)
            {
                case "EditPermissionRole":
                    int.TryParse(e.CommandArgument.ToString(), out FormID);

                    if (FormID > 0)
                    {
                        ViewState[CMSViewStateManager.FormID] = FormID;
                        RoleMode();
                        FillRoles(0);
                        upnlPermissionRole.Update();
                    }
                    break;
                case "EditPermissionUser":
                    int.TryParse(e.CommandArgument.ToString(), out FormID);

                    if (FormID > 0)
                    {
                        ViewState[CMSViewStateManager.FormID] = FormID;
                        UserMode();
                        FillUsers(0);
                        upnlPermissionUser.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ManagePermission_UC_Load
        void ManagePermission_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
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

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlRoles.UniqueID] != null)
                cddRoles.SelectedValue = Request.Params[ddlRoles.UniqueID];
            if (Request.Params[ddlUsers.UniqueID] != null)
                cddUsers.SelectedValue = Request.Params[ddlUsers.UniqueID];
        }
        #endregion

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
            mpePermissionRole.Hide();
            mpePermissionUser.Hide();

            dvPermissionRole.Visible = false;
            dvPermissionUser.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            rblAccessTypeRole.DataSource = rblAccessTypeUser.DataSource = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.AccessType));
            rblAccessTypeRole.DataTextField = rblAccessTypeUser.DataTextField = "key";
            rblAccessTypeRole.DataValueField = rblAccessTypeUser.DataValueField = "value";
            rblAccessTypeRole.DataBind();
            rblAccessTypeUser.DataBind();
        }
        #endregion

        #region FillUsers
        void FillUsers(int PageIndex)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                if (PageIndex > -1)
                    gvUser.PageIndex = PageIndex;
                gvUser.DataSource = FormUserManager.GetFormsUsers(Convert.ToInt32(ViewState[CMSViewStateManager.FormID]), -1);
                gvUser.DataBind();
            }
        }
        #endregion

        #region UserMode
        void UserMode()
        {
            dvPermissionUser.Visible = true;
            mpePermissionUser.Show();
            cddUsers.Category = CMSConfig.ConstantManager.FormCategory + Convert.ToInt32(ViewState[CMSViewStateManager.FormID]);
            UserExitMode();
        }
        #endregion

        #region UserEditMode
        void UserEditMode()
        {
            if (ViewState[CMSViewStateManager.FormUserID] != null)
            {
                FormUser formUser = FormUserManager.GetFormUser(Convert.ToInt32(ViewState[CMSViewStateManager.FormUserID]));
                if (formUser != null)
                {
                    cddUsers.SelectedValue = cddUsers.PromptValue.ToString();
                    rblAccessTypeUser.SelectedValue = ((int)formUser.AccessType).ToString();
                    trUser.Visible = false;

                    btnPermissionUserUpdate.Visible = true;
                    btnPermissionUserSave.Visible = false;
                    pnlPermissionUserAdd.DefaultButton = btnPermissionUserUpdate.ID;
                    pnlPermissionUserAdd.Visible = true;
                }
            }
        }
        #endregion

        #region UserAddMode
        void UserAddMode()
        {
            ViewState.Remove(CMSViewStateManager.FormUserID);
            cddUsers.SelectedValue = cddUsers.PromptValue.ToString();
            rblAccessTypeUser.SelectedValue = ((int)CMSEnums.AccessType.Deny).ToString();
            trUser.Visible = true;

            btnPermissionUserUpdate.Visible = false;
            btnPermissionUserSave.Visible = true;
            pnlPermissionUserAdd.DefaultButton = btnPermissionUserSave.ID;
            pnlPermissionUserAdd.Visible = true;
        }
        #endregion

        #region UserExitMode
        void UserExitMode()
        {
            UserAddMode();
            pnlPermissionUserAdd.Visible = false;
        }
        #endregion

        #region FillRoles
        void FillRoles(int PageIndex)
        {
            if (ViewState[CMSViewStateManager.FormID] != null)
            {
                if (PageIndex > -1)
                    gvRole.PageIndex = PageIndex;
                gvRole.DataSource = FormRoleManager.GetFormsRoles(Convert.ToInt32(ViewState[CMSViewStateManager.FormID]), -1);
                gvRole.DataBind();
            }
        }
        #endregion

        #region RoleMode
        void RoleMode()
        {
            dvPermissionRole.Visible = true;
            mpePermissionRole.Show();
            cddRoles.Category = CMSConfig.ConstantManager.FormCategory + Convert.ToInt32(ViewState[CMSViewStateManager.FormID]);
            RoleExitMode();
        }
        #endregion

        #region RoleExitMode
        void RoleExitMode()
        {
            RoleAddMode();
            pnlPermissionRoleAdd.Visible = false;
        }
        #endregion

        #region RoleEditMode
        void RoleEditMode()
        {
            if (ViewState[CMSViewStateManager.FormRoleID] != null)
            {
                FormRole formRole = FormRoleManager.GetFormRole(Convert.ToInt32(ViewState[CMSViewStateManager.FormRoleID]));
                if (formRole != null)
                {
                    cddRoles.SelectedValue = cddRoles.PromptValue.ToString();
                    rblAccessTypeRole.SelectedValue = ((int)formRole.AccessType).ToString();
                    trRoles.Visible = false;

                    btnPermissionRoleUpdate.Visible = true;
                    btnPermissionRoleSave.Visible = false;
                    pnlPermissionRoleAdd.DefaultButton = btnPermissionRoleUpdate.ID;
                    pnlPermissionRoleAdd.Visible = true;
                }
            }
        }
        #endregion

        #region RoleAddMode
        void RoleAddMode()
        {
            ViewState.Remove(CMSViewStateManager.FormRoleID);
            cddRoles.SelectedValue = cddRoles.PromptValue.ToString();
            rblAccessTypeRole.SelectedValue = ((int)CMSEnums.AccessType.Deny).ToString();
            trRoles.Visible = true;

            btnPermissionRoleUpdate.Visible = false;
            btnPermissionRoleSave.Visible = true;
            pnlPermissionRoleAdd.DefaultButton = btnPermissionRoleSave.ID;
            pnlPermissionRoleAdd.Visible = true;
        }
        #endregion

        #endregion
    }
}