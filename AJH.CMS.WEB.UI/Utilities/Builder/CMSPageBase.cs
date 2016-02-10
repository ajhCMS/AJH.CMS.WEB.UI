using System.IO;
using System.Web.UI;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;
using System.Web.UI.HtmlControls;

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

                this.Page.MetaKeywords = currentPage.KeyWords;
                this.Page.MetaDescription = currentPage.Description;
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

            //Add Keywords Meta Tag
            HtmlMeta keywords = new HtmlMeta();
            keywords.HttpEquiv = "keywords";
            keywords.Name = "keywords";
            keywords.Content = this.Page.MetaKeywords;
            this.Page.Header.Controls.Add(keywords);

            //Add Description Meta Tag
            HtmlMeta description = new HtmlMeta();
            description.HttpEquiv = "description";
            description.Name = "description";
            description.Content = this.Page.MetaDescription;
            this.Page.Header.Controls.Add(description);
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(CMSContext.CurrentLanguageCulture);

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(CMSContext.CurrentLanguageCulture);
        }

        #endregion
    }
}