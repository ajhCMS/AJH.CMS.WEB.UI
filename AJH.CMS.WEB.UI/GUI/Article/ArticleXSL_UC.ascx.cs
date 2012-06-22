using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class ArticleXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ArticleXSL_UC_Load);
        }
        #endregion

        #region ArticleXSL_UC
        void ArticleXSL_UC_Load(object sender, EventArgs e)
        {
            LoadArticle();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadArticle
        void LoadArticle()
        {
            if (base.XSLTemplateID > 0 && base.ContainerValue > 0)
            {
                int PageSize = 10;
                if (!string.IsNullOrEmpty(Attributes["PageSize"]))
                {
                    PageSize = Convert.ToInt32(Attributes["PageSize"]);
                }
                int TotalCount = 0;
                string articleXML = ArticleManager.GetArticlesPublishXML(base.ContainerValue, 1, PageSize, ref TotalCount);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlArticle.DocumentContent = articleXML;
                xmlArticle.TransformSource = xslPath;
                xmlArticle.TransformArgumentList = arguments;
                xmlArticle.DataBind();
            }
        }
        #endregion

        #region GetDateTime
        public string GetDateTime(string TotalDays, string TotalSeconds, string DateFormat)
        {
            int _TotalDays = 0;
            int _TotalSeconds = 0;
            int.TryParse(TotalDays, out _TotalDays);
            int.TryParse(TotalSeconds, out _TotalSeconds);

            DateTime dateTime = CMSCoreHelper.GetDateTime(_TotalDays, _TotalSeconds);
            return dateTime.ToString(DateFormat);
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Category> articleCategories = CategoryManager.GetCategorys(ModuleID, PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < articleCategories.Count; i++)
            {
                items.Add(articleCategories[i].ID.ToString(), articleCategories[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}