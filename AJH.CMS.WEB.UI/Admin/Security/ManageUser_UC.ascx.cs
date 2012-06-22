using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageUser_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageUser_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnActive.Click += new ImageClickEventHandler(ibtnActive_Click);
            this.ibtnInActive.Click += new ImageClickEventHandler(ibtnInActive_Click);
            this.gvUser.RowCommand += new GridViewCommandEventHandler(gvUser_RowCommand);
            this.gvUser.PageIndexChanging += new GridViewPageEventHandler(gvUser_PageIndexChanging);
        }
        #endregion

        #region ibtnInActive_Click
        void ibtnInActive_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvUser.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvUser.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int UserID = Convert.ToInt32(hdnID.Value);
                        UserManager.UpdateActive(UserID, false);
                    }
                }
            }
            FillUsers(-1);
            ExitMode();
            upnlUserItem.Update();
        }
        #endregion

        #region ibtnActive_Click
        void ibtnActive_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvUser.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvUser.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int UserID = Convert.ToInt32(hdnID.Value);
                        UserManager.UpdateActive(UserID, true);
                    }
                }
            }
            FillUsers(-1);
            ExitMode();
            upnlUserItem.Update();
        }
        #endregion

        #region gvUser_PageIndexChanging
        void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillUsers(e.NewPageIndex);
            ExitMode();
            upnlUserItem.Update();
        }
        #endregion

        #region gvUser_RowCommand
        void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditUser":
                    int UserID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out UserID);

                    if (UserID > 0)
                    {
                        ViewState[CMSViewStateManager.UserID] = UserID;
                        BeginEditMode();
                        upnlUserItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvUser.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvUser.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int UserID = Convert.ToInt32(hdnID.Value);
                        UserManager.DeleteLogical(UserID);
                    }
                }
            }
            FillUsers(-1);
            ExitMode();
            upnlUserItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlUserItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.UserID] != null)
            {
                try
                {
                    CMS.Core.Entities.User user = UserManager.GetUser(Convert.ToInt32(ViewState[CMSViewStateManager.UserID]));
                    if (user != null)
                    {
                        user.IsDeleted = false;
                        user.Email = txtEmail.Text;
                        user.IsActive = chkIsActive.Checked;
                        user.LanguageID = CMSContext.LanguageID;
                        user.Password = txtPassword.Text;
                        user.PortalID = CMSContext.PortalID;
                        UserManager.Update(user);

                        FillUsers(-1);
                        upnlUser.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.Message;
                    upnlUser.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.User user = new Core.Entities.User();
                user.CreationDate = DateTime.Now;
                user.ID = 0;
                user.Email = txtEmail.Text;
                user.IsActive = chkIsActive.Checked;
                user.IsDeleted = false;
                user.LanguageID = CMSContext.LanguageID;
                user.Password = txtPassword.Text;
                user.PortalID = CMSContext.PortalID;
                UserManager.Add(user);

                BeginAddMode();
                FillUsers(-1);
                upnlUser.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;
                upnlUser.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.UserID] != null)
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

        #region ManageUser_UC_Load
        void ManageUser_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillUsers(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillUsers
        void FillUsers(int PageIndex)
        {
            if (PageIndex > -1)
                gvUser.PageIndex = PageIndex;
            gvUser.DataSource = UserManager.GetUsers();
            gvUser.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlUserItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvUser.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnActive.OnClientClick = "return ConfirmOperation('" + gvUser.ClientID + "','Are you sure to active this item(s)?');";
            ibtnInActive.OnClientClick = "return ConfirmOperation('" + gvUser.ClientID + "','Are you sure to inactive this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.UserID);
            pnlUserItem.Visible = true;
            txtConfirmEmail.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkIsActive.Checked = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlUserItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.UserID] != null)
            {
                CMS.Core.Entities.User user = UserManager.GetUser(Convert.ToInt32(ViewState[CMSViewStateManager.UserID]));
                if (user != null)
                {
                    pnlUserItem.Visible = true;
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtEmail.Text = user.Email;
                    txtConfirmEmail.Text = user.Email;
                    chkIsActive.Checked = user.IsActive;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlUserItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region GetUserStatus
        protected string GetUserStatus(bool IsActive)
        {
            if (IsActive)
            {
                return Resources.CMSSetupResource.Active;
            }
            else
            {
                return Resources.CMSSetupResource.InActive;
            }
        }
        #endregion

        #endregion
    }
}