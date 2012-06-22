using System;
using System.Reflection;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class CMSLogin : System.Web.UI.MasterPage
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(CMSLogin_Load);
        }
        #endregion

        #region CMSLogin_Load
        protected void CMSLogin_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                AssemblyName myAssemblyName = myAssembly.GetName();
                lblCMS.Text = myAssemblyName.Version.ToString();
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

        #endregion
    }
}