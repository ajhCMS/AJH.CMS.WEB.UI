using System;
using System.Collections.Generic;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class CMSAdmin : System.Web.UI.MasterPage
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(CMSAdmin_Load);
        }
        #endregion

        #region CMSAdmin_Load
        void CMSAdmin_Load(object sender, EventArgs e)
        {
            LoadMenus();

            if (!IsPostBack)
            {
                lblLogoName.Text = CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.Name;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region PageTitle
        protected string PageTitle()
        {
            this.Page.Title = CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.Name + " - " + this.Page.Title;
            return this.Page.Title;
        }
        #endregion

        #region LoadMenus
        void LoadMenus()
        {
            ucTopMenu.KeyControlValue = CMSConfig.ConstantManager.KeyControlValueTopMenu;
            ucTopMenu.LoadXml();

            ucLeftMenu.AttributeKeyValue = new List<string>();
            ucLeftMenu.AttributeKeyValue.Add(CMSConfig.QueryString.ModuleID);
            ucLeftMenu.AttributeDataValue = new List<string>();
            ucLeftMenu.AttributeDataValue.Add(Request.QueryString[CMSConfig.QueryString.ModuleID]);
            ucLeftMenu.KeyControlValue = CMSConfig.ConstantManager.KeyControlValueLeftMenu + Request.QueryString[CMSConfig.QueryString.ModuleID];
            ucLeftMenu.LoadXml();
        }
        #endregion

        #endregion
    }
}