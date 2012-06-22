using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageRole_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageRole_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvRole.RowCommand += new GridViewCommandEventHandler(gvRole_RowCommand);
            this.gvRole.PageIndexChanging += new GridViewPageEventHandler(gvRole_PageIndexChanging);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnRoleUserAdd.Click += new ImageClickEventHandler(ibtnRoleUserAdd_Click);
            this.ibtnRoleUserDelete.Click += new ImageClickEventHandler(ibtnRoleUserDelete_Click);
            this.gvUser.PageIndexChanging += new GridViewPageEventHandler(gvUser_PageIndexChanging);
            this.btnRoleUserExit.Click += new EventHandler(btnRoleUserExit_Click);
            this.btnRoleUserSave.Click += new EventHandler(btnRoleUserSave_Click);
        }
        #endregion

        #region gvUser_PageIndexChanging
        void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillUsers(e.NewPageIndex);
            UserExitMode();
        }
        #endregion

        #region btnRoleUserSave_Click
        void btnRoleUserSave_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
            {
                try
                {
                    int RoleID = Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]);
                    int UserID = 0;
                    int.TryParse(cddUsers.SelectedValue, out UserID);

                    if (RoleID > 0 && UserID > 0)
                    {
                        RoleManager.AddRoleUser(RoleID, UserID);
                    }
                    FillUsers(-1);
                    BeginUserAddMode();
                }
                catch (Exception ex)
                {
                    dvProblemUser.Visible = true;
                    dvProblemUser.InnerText = ex.Message;
                }
            }
        }
        #endregion

        #region btnRoleUserExit_Click
        void btnRoleUserExit_Click(object sender, EventArgs e)
        {
            UserExitMode();
        }
        #endregion

        #region ibtnRoleUserDelete_Click
        void ibtnRoleUserDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
            {
                int RoleID = Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]);
                for (int i = 0; i < gvRole.Rows.Count; i++)
                {
                    CheckBox chkItem = (CheckBox)gvRole.Rows[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)gvRole.Rows[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int UserID = Convert.ToInt32(hdnID.Value);
                            RoleManager.DeleteRoleUser(RoleID, UserID);
                        }
                    }
                }
                FillUsers(-1);
                UserExitMode();
            }
        }
        #endregion

        #region ibtnRoleUserAdd_Click
        void ibtnRoleUserAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginUserAddMode();
        }
        #endregion

        #region gvRole_PageIndexChanging
        void gvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillRoles(e.NewPageIndex);
            ExitMode();
            upnlRoleItem.Update();
        }
        #endregion

        #region gvRole_RowCommand
        void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RoleID = 0;
            switch (e.CommandName)
            {
                case "EditRole":
                    int.TryParse(e.CommandArgument.ToString(), out RoleID);

                    if (RoleID > 0)
                    {
                        ViewState[CMSViewStateManager.RoleID] = RoleID;
                        BeginEditMode();
                        upnlRoleItem.Update();
                    }
                    break;
                case "EditRoleUser":
                    int.TryParse(e.CommandArgument.ToString(), out RoleID);

                    if (RoleID > 0)
                    {
                        ExitMode();
                        ViewState[CMSViewStateManager.RoleID] = RoleID;
                        UserMode();
                        FillUsers(0);
                        upnlRoleItem.Update();
                        upnlRoleUser.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvRole.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvRole.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvRole.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int RoleID = Convert.ToInt32(hdnID.Value);
                        RoleManager.DeleteLogical(RoleID);
                    }
                }
            }
            FillRoles(-1);
            ExitMode();
            upnlRoleItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlRoleItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
            {
                try
                {
                    CMS.Core.Entities.Role role = RoleManager.GetRole(Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]));
                    if (role != null)
                    {
                        role.Description = txtDescription.Text;
                        role.IsDeleted = false;
                        role.Name = txtName.Text;
                        RoleManager.Update(role);

                        FillRoles(-1);
                        upnlRole.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.Message;
                    upnlRole.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Role role = new Core.Entities.Role();
                role.Description = txtDescription.Text;
                role.ID = 0;
                role.IsDeleted = false;
                role.Name = txtName.Text;
                RoleManager.Add(role);

                BeginAddMode();
                FillRoles(-1);
                upnlRole.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;
                upnlRole.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
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

        #region ManageRole_UC_Load
        void ManageRole_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            dvProblemUser.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillRoles(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlUsers.UniqueID] != null)
                cddUsers.SelectedValue = Request.Params[ddlUsers.UniqueID];
        }
        #endregion

        #region FillRoles
        void FillRoles(int PageIndex)
        {
            if (PageIndex > -1)
                gvRole.PageIndex = PageIndex;
            gvRole.DataSource = RoleManager.GetRoles();
            gvRole.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlRoleItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvRole.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.RoleID);
            pnlRoleItem.Visible = true;

            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlRoleItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
            {
                CMS.Core.Entities.Role role = RoleManager.GetRole(Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]));
                if (role != null)
                {
                    pnlRoleItem.Visible = true;

                    txtDescription.Text = role.Description;
                    txtName.Text = role.Name;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlRoleItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region FillUsers
        void FillUsers(int PageIndex)
        {
            if (ViewState[CMSViewStateManager.RoleID] != null)
            {
                if (PageIndex > -1)
                    gvUser.PageIndex = PageIndex;
                gvUser.DataSource = UserManager.GetUsers(Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]));
                gvUser.DataBind();
            }
        }
        #endregion

        #region UserMode
        void UserMode()
        {
            dvRoleUser.Visible = true;
            mpeRoleUser.Show();
            pnlRoleUserAdd.Visible = false;
            cddUsers.Category = CMSConfig.ConstantManager.RoleCategory + Convert.ToInt32(ViewState[CMSViewStateManager.RoleID]);
        }
        #endregion

        #region BeginUserAddMode
        void BeginUserAddMode()
        {
            pnlRoleUserAdd.Visible = true;
            cddUsers.SelectedValue = cddUsers.PromptValue;
        }
        #endregion

        #region UserExitMode
        void UserExitMode()
        {
            pnlRoleUserAdd.Visible = false;
        }
        #endregion

        #endregion
    }
}