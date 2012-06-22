using System;
using System.IO;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManagePageDesign_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManagePageDesign_UC_Load);
            this.btnAddControl.Click += new EventHandler(btnAddControl_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.PageID] != null)
            {
                Page page = PageManager.GetPage(Convert.ToInt32(ViewState[CMSViewStateManager.PageID]));
                if (page != null)
                {
                    page.Details = txtDetails.Text;
                    PageManager.Update(page);

                    string pageCode = "<%@ Page Language=\"C#\" MasterPageFile=\"" + CMSWebHelper.GetTemplateMasterPageVirtualPath(page.TemplateID) + "\" AutoEventWireup=\"false\" Inherits=\"AJH.CMS.WEB.UI.CMSPageBase\" %>";
                    pageCode += "\n\n";

                    StreamWriter streamWriter = new StreamWriter(CMSWebHelper.GetPagePath(page), false);
                    streamWriter.Write(pageCode);
                    streamWriter.Write(txtDetails.Text);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
        #endregion

        #region btnAddControl_Click
        void btnAddControl_Click(object sender, EventArgs e)
        {
            CMSControl cmsControl = CMSControlManager.GetCMSControl(Convert.ToInt32(cddCMSControl.SelectedValue));
            if (cmsControl != null)
            {
                txtRegisterControl.Text = "<%@ Register Src=\"" + cmsControl.UserControlPath + "\" TagName=\"" + cmsControl.Name.Replace(" ", "") + "\" TagPrefix=\"controls\" %>";
                txtUserControlTag.Text = "<controls:" + cmsControl.Name.Replace(" ", "") + " ContainerValue=\"" + cddContainerValue.SelectedValue + "\" ModuleID=\"" + cmsControl.ModuleID + "\" XSLTemplateID=\"" + cddXSLTemplate.SelectedValue + "\" runat=\"server\" />";
            }
        }
        #endregion

        #region ManagePageDesign_UC_Load
        void ManagePageDesign_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            if (!IsPostBack)
            {
                LoadPage();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region LoadPage
        void LoadPage()
        {
            int pageID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.PageID], out pageID);

            Page page = null;
            if (pageID > 0)
            {
                page = PageManager.GetPage(pageID);
            }
            if (page != null)
            {
                ViewState[CMSViewStateManager.PageID] = page.ID;
                if (String.IsNullOrEmpty(page.Details))
                {
                    txtDetails.Text = CMSWebHelper.GetInitialPageValue();
                }
                else
                {
                    txtDetails.Text = page.Details;
                }
            }
            else
            {
                this.Visible = false;
            }
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlCMSControl.UniqueID] != null)
                cddCMSControl.SelectedValue = Request.Params[ddlCMSControl.UniqueID];
            if (Request.Params[ddlContainerValue.UniqueID] != null)
                cddContainerValue.SelectedValue = Request.Params[ddlContainerValue.UniqueID];
            if (Request.Params[ddlModule.UniqueID] != null)
                cddModule.SelectedValue = Request.Params[ddlModule.UniqueID];
            if (Request.Params[ddlXSLTemplate.UniqueID] != null)
                cddXSLTemplate.SelectedValue = Request.Params[ddlXSLTemplate.UniqueID];
        }
        #endregion

        #endregion
    }
}