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
    public partial class ManageManufacturar_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageManufacturar_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.gvManufacturar.PageIndexChanging += new GridViewPageEventHandler(gvManufacturar_PageIndexChanging);
            this.gvManufacturar.RowCommand += new GridViewCommandEventHandler(gvManufacturar_RowCommand);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
        }

        void gvManufacturar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditManufacturar":
                    int ManufacturarID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out ManufacturarID);

                    if (ManufacturarID > 0)
                    {
                        ViewState[CMSViewStateManager.ManufacturarID] = ManufacturarID;
                        BeginEditMode();
                        upnlManufacturarItem.Update();
                    }
                    break;
            }
        }

        void gvManufacturar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillManufacturars(e.NewPageIndex);
            ExitMode();
            upnlManufacturar.Update();
            upnlManufacturarItem.Update();
        }

        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.ManufacturarID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :
                    Manufacturar Manufacturar =
                        ManufacturarManager.GetManufacturar(Convert.ToInt32(ViewState[CMSViewStateManager.ManufacturarID]), CMSContext.PortalID, CMSContext.LanguageID);

                    if (Manufacturar != null)
                    {
                        Manufacturar.IsEnabled = cbIsEnabled.Checked;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            Manufacturar.Image = files[0];
                        else
                            Manufacturar.Image = string.Empty;

                        ManufacturarManager.Update(Manufacturar);

                        //SaveLanguage Info Only :
                        Manufacturar langManufacturar = new Manufacturar
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.ManufacturarID]),
                            Description = txtDescription.Text,
                            ShortDescription = txtShortDescription.Text,
                            MetaTitle = txtMetaTitle.Text,
                            MetaDescription = txtMetaDescription.Text,
                            MetaKeywords = txtMetaKeywords.Text,
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Manufacturar,
                        };

                        ManufacturarManager.AddOtherLanguage(langManufacturar);
                        BeginAddMode();
                        FillManufacturars(-1);
                        upnlManufacturar.Update();
                        upnlManufacturarItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlManufacturar.Update();
                }
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.ManufacturarID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlManufacturarItem.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlManufacturar.Update();

                }
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.ManufacturarID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    Manufacturar Manufacturar =
                        ManufacturarManager.GetManufacturar(Convert.ToInt32(ViewState[CMSViewStateManager.ManufacturarID]), CMSContext.PortalID, CMSContext.LanguageID);

                    if (Manufacturar != null)
                    {
                        Manufacturar.IsEnabled = cbIsEnabled.Checked;
                        Manufacturar.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        Manufacturar.ModuleID = (int)CMSEnums.ECommerceModule.Manufacturar;

                        List<string> files = ucSWFUpload.GetFilesName();
                        if (files.Count > 0)
                            Manufacturar.Image = files[0];
                        else
                            Manufacturar.Image = string.Empty;

                        //int parentManufacturarId = -1;
                        //int.TryParse(ddlParentManufacturar.SelectedValue, out parentManufacturarId);
                        //if (parentManufacturarId > 0)
                        //    Manufacturar.ParentManufacturarID = parentManufacturarId;

                        Manufacturar.Description = txtDescription.Text;
                        Manufacturar.ShortDescription = txtShortDescription.Text;
                        Manufacturar.MetaTitle = txtMetaTitle.Text;
                        Manufacturar.MetaDescription = txtMetaDescription.Text;
                        Manufacturar.MetaKeywords = txtMetaKeywords.Text;

                        ManufacturarManager.Update(Manufacturar);
                        FillManufacturars(-1);
                        upnlManufacturar.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlManufacturar.Update();
                }

            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlManufacturar.Update();
            upnlManufacturarItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.ManufacturarID] != null)
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
                Manufacturar Manufacturar = new Manufacturar();
                Manufacturar.IsDeleted = false;
                Manufacturar.LanguageID = CMSContext.LanguageID;
                Manufacturar.PortalID = CMSContext.PortalID;

                Manufacturar.Description = txtDescription.Text;
                Manufacturar.ShortDescription = txtShortDescription.Text;
                Manufacturar.IsEnabled = cbIsEnabled.Checked;

                List<string> files = ucSWFUpload.GetFilesName();
                if (files.Count > 0)
                    Manufacturar.Image = files[0];
                else
                    Manufacturar.Image = string.Empty;

                Manufacturar.MetaTitle = txtMetaTitle.Text;
                Manufacturar.MetaDescription = txtMetaDescription.Text;
                Manufacturar.MetaKeywords = txtMetaKeywords.Text;

                Manufacturar.ModuleID = (int)CMSEnums.ECommerceModule.Manufacturar;
                ManufacturarManager.Add(Manufacturar);

                BeginAddMode();

                FillManufacturars(-1);
                upnlManufacturar.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlManufacturar.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvManufacturar.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvManufacturar.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvManufacturar.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int ManufacturarID = Convert.ToInt32(hdnID.Value);
                        ManufacturarManager.DeleteLogical(ManufacturarID);
                    }
                }
            }
            FillManufacturars(-1);
            ExitMode();
            upnlManufacturarItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlManufacturarItem.Update();
        }
        #endregion

        #region ManageManufacturar_UC_Load
        void ManageManufacturar_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillManufacturars(-1);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvManufacturar.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.ManufacturarID);
            pnlManufacturarItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtShortDescription.Text = string.Empty;
            txtMetaDescription.Text = string.Empty;
            txtMetaKeywords.Text = string.Empty;
            txtMetaTitle.Text = string.Empty;
            cbIsEnabled.Checked = false;
            ucSWFUpload.BeginAddMode();

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlManufacturarItem.Visible = true;

            pnlManufacturarItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.ManufacturarID] != null)
            {
                Manufacturar Manufacturar =
                    ManufacturarManager.GetManufacturar(Convert.ToInt32(ViewState[CMSViewStateManager.ManufacturarID]), CMSContext.PortalID, CMSContext.LanguageID);
                if (Manufacturar != null)
                {
                    pnlManufacturarItem.Visible = true;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = Manufacturar.LanguageID;
                    cbIsEnabled.Checked = Manufacturar.IsEnabled;
                    ucSWFUpload.BeginEditMode(Manufacturar.Image);

                    txtDescription.Text = Manufacturar.Description;
                    txtShortDescription.Text = Manufacturar.ShortDescription;
                    txtMetaTitle.Text = Manufacturar.MetaTitle;
                    txtMetaDescription.Text = Manufacturar.MetaDescription;
                    txtMetaKeywords.Text = Manufacturar.MetaKeywords;

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
        }

        private void BeginEditModeOtherLanguage()
        {
            Manufacturar Manufacturar =
                ManufacturarManager.GetManufacturar(Convert.ToInt32(ViewState[CMSViewStateManager.ManufacturarID]), CMSContext.PortalID, ucPortalLanguage.SelectedLanguageID);
            if (Manufacturar != null)
            {
                pnlManufacturarItem.Visible = true;
                ucPortalLanguage.Visible = true;
                cbIsEnabled.Checked = Manufacturar.IsEnabled;
                ucSWFUpload.BeginEditMode(Manufacturar.Image);

                txtDescription.Text = Manufacturar.Description;
                txtShortDescription.Text = Manufacturar.ShortDescription;
                txtMetaTitle.Text = Manufacturar.MetaTitle;
                txtMetaDescription.Text = Manufacturar.MetaDescription;
                txtMetaKeywords.Text = Manufacturar.MetaKeywords;

                btnSave.Visible = false;
                if (string.IsNullOrEmpty(Manufacturar.Description))
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
            pnlManufacturarItem.Visible = false;
        }
        #endregion

        #region FillManufacturars
        private void FillManufacturars(int PageIndex)
        {
            if (PageIndex > -1)
                gvManufacturar.PageIndex = PageIndex;

            List<CMS.Core.Entities.Manufacturar> Manufacturars =
                ManufacturarManager.GetManufacturars(CMSContext.PortalID, CMSContext.LanguageID);

            gvManufacturar.DataSource = Manufacturars;
            gvManufacturar.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #endregion
    }
}