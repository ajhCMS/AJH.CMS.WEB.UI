using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageGroup_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageGroup_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.gvGroup.RowCommand += new GridViewCommandEventHandler(gvGroup_RowCommand);
            this.gvGroup.PageIndexChanging += new GridViewPageEventHandler(gvGroup_PageIndexChanging);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
        }

        void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGroups(e.NewPageIndex);
            ExitMode();
            upnlGroup.Update();
            upnlGroupItem.Update();
        }

        void gvGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditGroup":
                    int GroupID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out GroupID);

                    if (GroupID > 0)
                    {
                        ViewState[CMSViewStateManager.GroupID] = GroupID;
                        BeginEditMode();
                        upnlGroupItem.Update();
                    }
                    break;
            }
        }

        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.GroupID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :

                    Group group =
                        GroupManager.GetGroup(Convert.ToInt32(ViewState[CMSViewStateManager.GroupID]), CMSContext.LanguageID);

                    if (group != null)
                    {
                        group.IsColorGroup = cbIsColorGroup.Checked;

                        GroupManager.Update(group);
                        //SaveLanguage Info Only :
                        Group langGroup = new Group
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.GroupID]),
                            Name = txtName.Text,
                            PublicName = txtPublicName.Text,
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Group,
                        };

                        GroupManager.AddOtherLanguage(langGroup);
                        BeginAddMode();
                        FillGroups(-1);
                        upnlGroup.Update();
                        upnlGroupItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGroup.Update();
                }
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.GroupID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlGroupItem.Update();

                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGroup.Update();

                }
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.GroupID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    Group Group =
                        GroupManager.GetGroup(Convert.ToInt32(ViewState[CMSViewStateManager.GroupID]), ucPortalLanguage.SelectedLanguageID);

                    if (Group != null)
                    {
                        Group.Name = txtName.Text;
                        Group.PublicName = txtPublicName.Text;
                        Group.IsColorGroup = cbIsColorGroup.Checked;
                        Group.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        Group.ModuleID = (int)CMSEnums.ECommerceModule.Group;

                        GroupManager.Update(Group);
                        FillGroups(-1);
                        upnlGroup.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGroup.Update();
                }

            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlGroup.Update();
            upnlGroupItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.GroupID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Group Group = new Group();

                Group.IsDeleted = false;
                Group.LanguageID = CMSContext.LanguageID;
                Group.PortalID = CMSContext.PortalID;
                Group.Name = txtName.Text;
                Group.PublicName = txtPublicName.Text;

                Group.IsColorGroup = cbIsColorGroup.Checked;
                Group.ModuleID = (int)CMSEnums.ECommerceModule.Group;

                GroupManager.Add(Group);

                BeginAddMode();

                FillGroups(-1);
                upnlGroup.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlGroup.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvGroup.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvGroup.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvGroup.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int GroupID = Convert.ToInt32(hdnID.Value);
                        GroupManager.DeleteLogical(GroupID);
                    }
                }
            }
            FillGroups(-1);
            ExitMode();
            upnlGroupItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlGroupItem.Update();
        }
        #endregion

        #region ManageGroup_UC_Load
        void ManageGroup_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillGroups(-1);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            //cddSearchGroup.Category = CMSConfig.ConstantManager.CategoryCategory + (int)CMSEnums.ECommerceModule.Group;

            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvGroup.ClientID + "','Are you sure to delete this item(s)?');";

        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.GroupID);
            pnlGroupItem.Visible = true;
            txtName.Text = string.Empty;
            txtPublicName.Text = string.Empty;
            cbIsColorGroup.Checked = false;

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlGroupItem.Visible = true;

            pnlGroupItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.GroupID] != null)
            {
                Group Group =
                    GroupManager.GetGroup(Convert.ToInt32(ViewState[CMSViewStateManager.GroupID]), CMSContext.LanguageID);
                if (Group != null)
                {
                    pnlGroupItem.Visible = true;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = Group.LanguageID;

                    txtName.Text = Group.Name;
                    txtPublicName.Text = Group.PublicName;
                    cbIsColorGroup.Checked = Group.IsColorGroup;

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
        }

        private void BeginEditModeOtherLanguage()
        {
            Group Group =
                GroupManager.GetGroup(Convert.ToInt32(ViewState[CMSViewStateManager.GroupID]), ucPortalLanguage.SelectedLanguageID);

            if (Group != null)
            {
                pnlGroupItem.Visible = true;
                ucPortalLanguage.Visible = true;
                txtName.Text = Group.Name;
                txtPublicName.Text = Group.PublicName;
                cbIsColorGroup.Checked = Group.IsColorGroup;

                btnSave.Visible = false;
                if (string.IsNullOrEmpty(Group.Name))
                {
                    btnSaveOtherLanguage.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;
                }

            }
        }

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlGroupItem.Visible = false;
        }
        #endregion

        #region FillGroups
        private void FillGroups(int PageIndex)
        {
            if (PageIndex > -1)
                gvGroup.PageIndex = PageIndex;

            List<CMS.Core.Entities.Group> Groups =
                GroupManager.GetGroups(CMSContext.PortalID, CMSContext.LanguageID);

            gvGroup.DataSource = Groups;
            gvGroup.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #endregion
    }
}