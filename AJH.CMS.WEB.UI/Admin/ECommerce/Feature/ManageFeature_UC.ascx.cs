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
    public partial class ManageFeature_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageFeature_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.gvFeature.RowCommand += new GridViewCommandEventHandler(gvFeature_RowCommand);
            this.gvFeature.PageIndexChanging += new GridViewPageEventHandler(gvFeature_PageIndexChanging);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
        }

        void gvFeature_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillFeatures(e.NewPageIndex);
            ExitMode();
            upnlFeature.Update();
            upnlFeatureItem.Update();
        }

        void gvFeature_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditFeature":
                    int FeatureID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out FeatureID);

                    if (FeatureID > 0)
                    {
                        ViewState[CMSViewStateManager.FeatureID] = FeatureID;
                        BeginEditMode();
                        upnlFeatureItem.Update();
                    }
                    break;
            }
        }

        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FeatureID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :

                    AJH.CMS.Core.Entities.Feature Feature =
                        FeatureManager.GetFeature(Convert.ToInt32(ViewState[CMSViewStateManager.FeatureID]), CMSContext.LanguageID);

                    if (Feature != null)
                    {
                        AJH.CMS.Core.Entities.Feature langFeature = new AJH.CMS.Core.Entities.Feature
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.FeatureID]),
                            Name = txtName.Text,
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Feature,
                        };

                        FeatureManager.AddOtherLanguage(langFeature);
                        BeginAddMode();
                        FillFeatures(-1);
                        upnlFeature.Update();
                        upnlFeatureItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlFeature.Update();
                }
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FeatureID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlFeatureItem.Update();

                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlFeature.Update();

                }
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FeatureID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    AJH.CMS.Core.Entities.Feature Feature =
                        FeatureManager.GetFeature(Convert.ToInt32(ViewState[CMSViewStateManager.FeatureID]), CMSContext.LanguageID);

                    if (Feature != null)
                    {
                        Feature.Name = txtName.Text;
                        Feature.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        Feature.ModuleID = (int)CMSEnums.ECommerceModule.Feature;

                        FeatureManager.Update(Feature);
                        FillFeatures(-1);
                        upnlFeature.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlFeature.Update();
                }

            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlFeature.Update();
            upnlFeatureItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.FeatureID] != null)
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
                AJH.CMS.Core.Entities.Feature Feature = new AJH.CMS.Core.Entities.Feature();

                Feature.IsDeleted = false;
                Feature.LanguageID = CMSContext.LanguageID;
                Feature.PortalID = CMSContext.PortalID;
                Feature.Name = txtName.Text;
                Feature.ModuleID = (int)CMSEnums.ECommerceModule.Feature;

                FeatureManager.Add(Feature);

                BeginAddMode();

                FillFeatures(-1);
                upnlFeature.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlFeature.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvFeature.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvFeature.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvFeature.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int FeatureID = Convert.ToInt32(hdnID.Value);
                        FeatureManager.DeleteLogical(FeatureID);
                    }
                }
            }
            FillFeatures(-1);
            ExitMode();
            upnlFeatureItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlFeatureItem.Update();
        }
        #endregion

        #region ManageFeature_UC_Load
        void ManageFeature_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillFeatures(-1);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvFeature.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.FeatureID);
            pnlFeatureItem.Visible = true;
            txtName.Text = string.Empty;

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlFeatureItem.Visible = true;

            pnlFeatureItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.FeatureID] != null)
            {
                AJH.CMS.Core.Entities.Feature Feature =
                    FeatureManager.GetFeature(Convert.ToInt32(ViewState[CMSViewStateManager.FeatureID]), CMSContext.LanguageID);
                if (Feature != null)
                {
                    pnlFeatureItem.Visible = true;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = Feature.LanguageID;

                    txtName.Text = Feature.Name;

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
        }

        private void BeginEditModeOtherLanguage()
        {
            AJH.CMS.Core.Entities.Feature Feature =
                FeatureManager.GetFeature(Convert.ToInt32(ViewState[CMSViewStateManager.FeatureID]), ucPortalLanguage.SelectedLanguageID);
            if (Feature != null)
            {
                pnlFeatureItem.Visible = true;
                ucPortalLanguage.Visible = true;
                txtName.Text = Feature.Name;
                btnSave.Visible = false;

                if (string.IsNullOrEmpty(Feature.Name))
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
            pnlFeatureItem.Visible = false;
        }
        #endregion

        #region FillFeatures
        private void FillFeatures(int PageIndex)
        {
            if (PageIndex > -1)
                gvFeature.PageIndex = PageIndex;

            List<CMS.Core.Entities.Feature> Features =
                FeatureManager.GetFeatures(CMSContext.LanguageID);

            gvFeature.DataSource = Features;
            gvFeature.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #endregion
    }
}