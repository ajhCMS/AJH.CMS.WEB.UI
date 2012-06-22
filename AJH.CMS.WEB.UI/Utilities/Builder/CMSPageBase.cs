using System.IO;
using System.Web.UI;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public class CMSPageBase : Page
    {
        #region Properties
        public CMS.Core.Entities.Page _CurrentPage
        {
            get;
            set;
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            CMS.Core.Entities.Page currentPage = PageManager.GetCachePage(CMSConfig.ConstantManager.KeyCachePage, Path.GetFileNameWithoutExtension(Request.Url.AbsolutePath), CMSContext.PortalID, CMSContext.LanguageID);
            if (currentPage != null)
            {
                _CurrentPage = currentPage;
                this.Title = currentPage.Title;
            }
            else
            {
                _CurrentPage = null;
            }
        }
        #endregion

        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);
            this.Title = CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.Name + " - " + this.Title;
        }

        #endregion
    }
}