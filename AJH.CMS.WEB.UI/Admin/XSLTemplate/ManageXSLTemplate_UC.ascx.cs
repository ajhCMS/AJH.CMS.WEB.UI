using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageXSLTemplate_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageXSLTemplate_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvXSLTemplate.RowCommand += new GridViewCommandEventHandler(gvXSLTemplate_RowCommand);
            this.gvXSLTemplate.PageIndexChanging += new GridViewPageEventHandler(gvXSLTemplate_PageIndexChanging);
        }
        #endregion

        #region gvXSLTemplate_PageIndexChanging
        void gvXSLTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillXSLTemplate(e.NewPageIndex);
            ExitMode();
            upnlXSLTemplateItem.Update();
        }
        #endregion

        #region gvXSLTemplate_RowCommand
        void gvXSLTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditXSLTemplate":
                    int XSLTemplateID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out XSLTemplateID);

                    if (XSLTemplateID > 0)
                    {
                        ViewState[CMSViewStateManager.XSLTemplateID] = XSLTemplateID;
                        BeginEditMode();
                        upnlXSLTemplateItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvXSLTemplate.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvXSLTemplate.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvXSLTemplate.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int XSLTemplateID = Convert.ToInt32(hdnID.Value);
                        XSLTemplateManager.DeleteLogical(XSLTemplateID);
                    }
                }
            }
            FillXSLTemplate(-1);
            ExitMode();
            upnlXSLTemplateItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlXSLTemplateItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.XSLTemplateID] != null)
            {
                try
                {
                    CMS.Core.Entities.XSLTemplate xslTemplate = XSLTemplateManager.GetXSLTemplate(Convert.ToInt32(ViewState[CMSViewStateManager.XSLTemplateID]));
                    if (xslTemplate != null)
                    {
                        xslTemplate.IsDeleted = false;
                        xslTemplate.LanguageID = CMSContext.LanguageID;
                        xslTemplate.Name = txtName.Text;
                        xslTemplate.Details = txtDetails.Text;
                        xslTemplate.PortalID = CMSContext.PortalID;

                        ValidateXSL(xslTemplate.Details);

                        XSLTemplateManager.Update(xslTemplate);

                        string xslPath = CMSWebHelper.GetXSLTemplateFilePath(xslTemplate.ID);
                        File.Delete(xslPath);
                        XSLTemplateManager.GetXSLTemplatePath(xslPath, xslTemplate.ID);

                        FillXSLTemplate(-1);
                        upnlXSLTemplate.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlXSLTemplate.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.XSLTemplate xslTemplate = new Core.Entities.XSLTemplate();
                xslTemplate.CreationDate = DateTime.Now;
                xslTemplate.ID = 0;
                xslTemplate.IsDeleted = false;
                xslTemplate.LanguageID = CMSContext.LanguageID;
                xslTemplate.ModuleID = Convert.ToInt32(cddModule.SelectedValue);
                xslTemplate.Name = txtName.Text;
                xslTemplate.Details = txtDetails.Text;
                xslTemplate.PortalID = CMSContext.PortalID;
                xslTemplate.CreatedBy = CMSContext.CurrentUserID;

                ValidateXSL(xslTemplate.Details);

                XSLTemplateManager.Add(xslTemplate);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(xslTemplate.ID);
                File.Delete(xslPath);
                XSLTemplateManager.GetXSLTemplatePath(xslPath, xslTemplate.ID);

                BeginAddMode();
                FillXSLTemplate(-1);
                upnlXSLTemplate.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlXSLTemplate.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.XSLTemplateID] != null)
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

        #region ManageXSLTemplate_UC_Load
        void ManageXSLTemplate_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillXSLTemplate(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region FillXSLTemplate
        void FillXSLTemplate(int PageIndex)
        {
            if (PageIndex > -1)
                gvXSLTemplate.PageIndex = PageIndex;
            gvXSLTemplate.DataSource = XSLTemplateManager.GetXSLTemplates(CMSContext.PortalID, CMSContext.LanguageID);
            gvXSLTemplate.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlXSLTemplateItem.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvXSLTemplate.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.XSLTemplateID);
            pnlXSLTemplateItem.Visible = true;
            txtName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            cddModule.SelectedValue = cddModule.PromptValue;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlXSLTemplateItem.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.XSLTemplateID] != null)
            {
                CMS.Core.Entities.XSLTemplate xslTemplate = XSLTemplateManager.GetXSLTemplate(Convert.ToInt32(ViewState[CMSViewStateManager.XSLTemplateID]));
                if (xslTemplate != null)
                {
                    pnlXSLTemplateItem.Visible = true;
                    txtName.Text = xslTemplate.Name;
                    txtDetails.Text = xslTemplate.Details;
                    cddModule.SelectedValue = xslTemplate.ModuleID.ToString();

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlXSLTemplateItem.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlModule.UniqueID] != null)
                cddModule.SelectedValue = Request.Params[ddlModule.UniqueID];
        }
        #endregion

        #region ValidateXSL
        private void ValidateXSL(string content)
        {
            string fileName = CMSContext.PortalsPath + "\\" + Guid.NewGuid().ToString() + ".xslt";
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Close();
                fs.Close();

                XslCompiledTransform xslFile = new XslCompiledTransform();
                xslFile.Load(fileName);

                File.Delete(fileName);
            }
            catch (XsltException ex)
            {
                File.Delete(fileName);
                throw ex;
            }
            catch (Exception ex)
            {
                File.Delete(fileName);
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}