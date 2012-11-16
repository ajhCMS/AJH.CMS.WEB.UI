using System;
using System.IO;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageTemplateDesign_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageTemplateDesign_UC_Load);
            this.btnAddControl.Click += new EventHandler(btnAddControl_Click);
            this.btnAddStyle.Click += new EventHandler(btnAddStyle_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.TemplateID] != null)
            {
                Template template = TemplateManager.GetTemplate(Convert.ToInt32(ViewState[CMSViewStateManager.TemplateID]));
                if (template != null)
                {
                    template.Details = txtDetails.Text;
                    TemplateManager.Update(template);

                    string templateMasterPageCode = "<%@ Master Language=\"C#\" AutoEventWireup=\"false\" Inherits=\"AJH.CMS.WEB.UI.CMSMasterPageBase\" %>";
                    templateMasterPageCode += "\n\n";

                    StreamWriter streamWriter = new StreamWriter(CMSWebHelper.GetTemplateMasterPagePath(template.ID), false);
                    streamWriter.Write(templateMasterPageCode);
                    streamWriter.Write(txtDetails.Text);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
        #endregion

        #region btnAddStyle_Click
        void btnAddStyle_Click(object sender, EventArgs e)
        {
            Style style = StyleManager.GetStyle(Convert.ToInt32(cddStyle.SelectedValue));
            if (style != null)
            {
                string styleTag = "<link href=\"" + CMSWebHelper.GetStyleFileVirtualPath(style.ID) + "\" rel=\"stylesheet\" type=\"text/css\" />";
                txtStyleTag.Text = styleTag;
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

        #region ManageTemplateDesign_UC_Load
        void ManageTemplateDesign_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            if (!IsPostBack)
            {
                LoadTemplate();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region LoadTemplate
        void LoadTemplate()
        {
            int templateID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.TemplateID], out templateID);

            Template template = null;
            if (templateID > 0)
            {
                template = TemplateManager.GetTemplate(templateID);
            }
            if (template != null)
            {
                ViewState[CMSViewStateManager.TemplateID] = template.ID;
                if (String.IsNullOrEmpty(template.Details))
                {
                    txtDetails.Text = CMSWebHelper.GetInitialTemplateValue();
                }
                else
                {
                    txtDetails.Text = template.Details;
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
            if (Request.Params[ddlStyle.UniqueID] != null)
                cddStyle.SelectedValue = Request.Params[ddlStyle.UniqueID];
            if (Request.Params[ddlXSLTemplate.UniqueID] != null)
                cddXSLTemplate.SelectedValue = Request.Params[ddlXSLTemplate.UniqueID];
        }
        #endregion

        #endregion
    }
}