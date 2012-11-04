using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageHtmlBlock_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageHtmlBlock_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvHtmlBlock.RowCommand += new GridViewCommandEventHandler(gvHtmlBlock_RowCommand);
            this.gvHtmlBlock.PageIndexChanging += new GridViewPageEventHandler(gvHtmlBlock_PageIndexChanging);
        }
        #endregion

        #region gvHtmlBlock_PageIndexChanging
        void gvHtmlBlock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillHtmlBlocks(e.NewPageIndex);
            ExitMode();
            upnlHtmlBlockItem.Update();
        }
        #endregion

        #region gvHtmlBlock_RowCommand
        void gvHtmlBlock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditHtmlBlock":
                    int HtmlBlockID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out HtmlBlockID);

                    if (HtmlBlockID > 0)
                    {
                        ViewState[CMSViewStateManager.HtmlBlockID] = HtmlBlockID;
                        BeginEditMode();
                        upnlHtmlBlockItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvHtmlBlock.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvHtmlBlock.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvHtmlBlock.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int HtmlBlockID = Convert.ToInt32(hdnID.Value);
                        HtmlBlockManager.DeleteLogical(HtmlBlockID);
                    }
                }
            }
            FillHtmlBlocks(-1);
            ExitMode();
            upnlHtmlBlockItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlHtmlBlockItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.HtmlBlockID] != null)
            {
                try
                {
                    CMS.Core.Entities.HtmlBlock htmlBlock = HtmlBlockManager.GetHtmlBlock(Convert.ToInt32(ViewState[CMSViewStateManager.HtmlBlockID]));
                    if (htmlBlock != null)
                    {
                        htmlBlock.IsDeleted = false;
                        htmlBlock.LanguageID = CMSContext.LanguageID;
                        htmlBlock.Name = txtName.Text;
                        htmlBlock.Details = txtDetails.Text;
                        htmlBlock.PortalID = CMSContext.PortalID;
                        HtmlBlockManager.Update(htmlBlock);

                        FillHtmlBlocks(-1);
                        upnlHtmlBlock.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlHtmlBlock.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.HtmlBlock htmlBlock = new Core.Entities.HtmlBlock();
                htmlBlock.CreationDate = DateTime.Now;
                htmlBlock.ID = 0;
                htmlBlock.IsDeleted = false;
                htmlBlock.LanguageID = CMSContext.LanguageID;
                htmlBlock.Name = txtName.Text;
                htmlBlock.Details = txtDetails.Text;
                htmlBlock.PortalID = CMSContext.PortalID;
                htmlBlock.CreatedBy = CMSContext.CurrentUserID;
                HtmlBlockManager.Add(htmlBlock);

                BeginAddMode();
                FillHtmlBlocks(-1);
                upnlHtmlBlock.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlHtmlBlock.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.HtmlBlockID] != null)
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

        #region ManageHtmlBlock_UC_Load
        void ManageHtmlBlock_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillHtmlBlocks(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillHtmlBlocks
        void FillHtmlBlocks(int PageIndex)
        {
            if (PageIndex > -1)
                gvHtmlBlock.PageIndex = PageIndex;
            gvHtmlBlock.DataSource = HtmlBlockManager.GetHtmlBlocks(CMSContext.PortalID, CMSContext.LanguageID);
            gvHtmlBlock.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlHtmlBlockItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvHtmlBlock.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.HtmlBlockID);
            pnlHtmlBlockItem.Visible = true;
            txtName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlHtmlBlockItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.HtmlBlockID] != null)
            {
                CMS.Core.Entities.HtmlBlock htmlBlock = HtmlBlockManager.GetHtmlBlock(Convert.ToInt32(ViewState[CMSViewStateManager.HtmlBlockID]));
                if (htmlBlock != null)
                {
                    pnlHtmlBlockItem.Visible = true;
                    txtName.Text = htmlBlock.Name;
                    txtDetails.Text = htmlBlock.Details;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlHtmlBlockItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #endregion
    }
}