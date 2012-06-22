using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageStyle_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageStyle_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvStyle.RowCommand += new GridViewCommandEventHandler(gvStyle_RowCommand);
            this.gvStyle.PageIndexChanging += new GridViewPageEventHandler(gvStyle_PageIndexChanging);
        }
        #endregion

        #region gvStyle_PageIndexChanging
        void gvStyle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillStyles(e.NewPageIndex);
            ExitMode();
            upnlStyleItem.Update();
        }
        #endregion

        #region gvStyle_RowCommand
        void gvStyle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditStyle":
                    int StyleID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out StyleID);

                    if (StyleID > 0)
                    {
                        ViewState[CMSViewStateManager.StyleID] = StyleID;
                        BeginEditMode();
                        upnlStyleItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvStyle.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvStyle.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvStyle.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int StyleID = Convert.ToInt32(hdnID.Value);
                        StyleManager.DeleteLogical(StyleID);
                    }
                }
            }
            FillStyles(-1);
            ExitMode();
            upnlStyleItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlStyleItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.StyleID] != null)
            {
                try
                {
                    CMS.Core.Entities.Style style = StyleManager.GetStyle(Convert.ToInt32(ViewState[CMSViewStateManager.StyleID]));
                    if (style != null)
                    {
                        style.IsDeleted = false;
                        style.LanguageID = CMSContext.LanguageID;
                        style.Name = txtName.Text;
                        style.Details = txtDetails.Text;
                        style.PortalID = CMSContext.PortalID;
                        StyleManager.Update(style);

                        string StyleFilePath = CMSWebHelper.GetStyleFilePath(style.ID);
                        StyleManager.UpdateStyleFile(StyleFilePath, style);

                        FillStyles(-1);
                        upnlStyle.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlStyle.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.Style style = new Core.Entities.Style();
                style.CreationDate = DateTime.Now;
                style.ID = 0;
                style.IsDeleted = false;
                style.LanguageID = CMSContext.LanguageID;
                style.Name = txtName.Text;
                style.Details = txtDetails.Text;
                style.PortalID = CMSContext.PortalID;
                style.CreatedBy = CMSContext.UserID;
                StyleManager.Add(style);
                string StyleFileName = CMSWebHelper.GetStyleFileName(style.ID);
                style.FileName = StyleFileName;
                StyleManager.Update(style);

                string StyleFilePath = CMSWebHelper.GetStyleFilePath(style.ID);
                StyleManager.UpdateStyleFile(StyleFilePath, style);

                BeginAddMode();
                FillStyles(-1);
                upnlStyle.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlStyle.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.StyleID] != null)
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

        #region ManageStyle_UC_Load
        void ManageStyle_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillStyles(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillStyles
        void FillStyles(int PageIndex)
        {
            if (PageIndex > -1)
                gvStyle.PageIndex = PageIndex;
            gvStyle.DataSource = StyleManager.GetStyles(CMSContext.PortalID, CMSContext.LanguageID);
            gvStyle.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlStyleItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvStyle.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.StyleID);
            pnlStyleItem.Visible = true;
            txtName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlStyleItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.StyleID] != null)
            {
                CMS.Core.Entities.Style style = StyleManager.GetStyle(Convert.ToInt32(ViewState[CMSViewStateManager.StyleID]));
                if (style != null)
                {
                    pnlStyleItem.Visible = true;
                    txtName.Text = style.Name;
                    txtDetails.Text = style.Details;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlStyleItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #endregion
    }
}