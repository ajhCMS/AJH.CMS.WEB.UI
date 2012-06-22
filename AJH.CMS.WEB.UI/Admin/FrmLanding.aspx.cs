using System;
using System.Collections.Generic;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FrmLanding : CMSAdminPageBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FrmLanding_Load);
        }
        #endregion

        #region FrmLanding_Load
        void FrmLanding_Load(object sender, EventArgs e)
        {
            LoadMenus();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadMenus
        void LoadMenus()
        {
            ucAdminXmlXsl.AttributeKeyValue = new List<string>();
            ucAdminXmlXsl.AttributeKeyValue.Add(CMSConfig.QueryString.ModuleID);
            ucAdminXmlXsl.AttributeDataValue = new List<string>();
            ucAdminXmlXsl.AttributeDataValue.Add(Request.QueryString[CMSConfig.QueryString.ModuleID]);
            ucAdminXmlXsl.KeyControlValue = CMSConfig.ConstantManager.KeyControlValueDashboard + Request.QueryString[CMSConfig.QueryString.ModuleID];
            ucAdminXmlXsl.LoadXml();
        }
        #endregion

        #endregion
    }
}