using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageTax_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageTax_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.gvTax.RowCommand += new GridViewCommandEventHandler(gvTax_RowCommand);
            this.gvTax.PageIndexChanging += new GridViewPageEventHandler(gvTax_PageIndexChanging);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }

        void gvTax_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillTaxs(e.NewPageIndex);
            ExitMode();
            upnlTax.Update();
            upnlTaxItem.Update();
        }

        void gvTax_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditTax":
                    int TaxID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out TaxID);

                    if (TaxID > 0)
                    {
                        ViewState[CMSViewStateManager.TaxID] = TaxID;
                        BeginEditMode();
                        upnlTaxItem.Update();
                    }
                    break;
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.TaxID] != null)
            {
                try
                {
                    Tax Tax =
                        TaxManager.GetTax(Convert.ToInt32(ViewState[CMSViewStateManager.TaxID]), CMSContext.PortalID);

                    if (Tax != null)
                    {
                        Tax.Rate = Convert.ToDecimal(txtRate.Text);
                        Tax.IsEnabled = cbIsEnabled.Checked;
                        TaxManager.Update(Tax);
                        FillTaxs(-1);
                        upnlTax.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlTax.Update();
                }

            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlTax.Update();
            upnlTaxItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.TaxID] != null)
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
                Tax Tax = new Tax();
                Tax.Rate = Convert.ToDecimal(txtRate.Text);
                Tax.IsEnabled = cbIsEnabled.Checked;
                Tax.PortalID = CMSContext.PortalID;
                Tax.IsDeleted = false;

                TaxManager.Add(Tax);
                BeginAddMode();

                FillTaxs(-1);
                upnlTax.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlTax.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvTax.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvTax.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvTax.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int TaxID = Convert.ToInt32(hdnID.Value);
                        TaxManager.DeleteLogical(TaxID);
                    }
                }
            }
            FillTaxs(-1);
            ExitMode();
            upnlTaxItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlTaxItem.Update();
        }
        #endregion

        #region ManageTax_UC_Load
        void ManageTax_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillTaxs(-1);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvTax.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.TaxID);
            pnlTaxItem.Visible = true;
            txtRate.Text = string.Empty;
            cbIsEnabled.Checked = false;

            btnSave.Visible = true;
            btnUpdate.Visible = false;

            pnlTaxItem.Visible = true;
            pnlTaxItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.TaxID] != null)
            {
                Tax Tax =
                    TaxManager.GetTax(Convert.ToInt32(ViewState[CMSViewStateManager.TaxID]), CMSContext.PortalID);

                if (Tax != null)
                {
                    pnlTaxItem.Visible = true;
                    txtRate.Text = Tax.Rate.ToString();
                    cbIsEnabled.Checked = Tax.IsEnabled;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlTaxItem.Visible = false;
        }
        #endregion

        #region FillTaxs
        private void FillTaxs(int PageIndex)
        {
            if (PageIndex > -1)
                gvTax.PageIndex = PageIndex;

            List<CMS.Core.Entities.Tax> Taxs =
                TaxManager.GetTaxs(CMSContext.PortalID);

            gvTax.DataSource = Taxs;
            gvTax.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #endregion
    }
}