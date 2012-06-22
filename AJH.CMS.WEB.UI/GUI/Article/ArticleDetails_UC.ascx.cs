using System;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class ArticleDetails_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ArticleDetails_UC_Load);
        }
        #endregion

        #region ArticleDetails_UC_Load
        void ArticleDetails_UC_Load(object sender, EventArgs e)
        {
            LoadArticleDetails();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadArticleDetails
        void LoadArticleDetails()
        {
            int articleID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.ArticleID], out articleID);
            if (articleID > 0)
            {
                Article article = ArticleManager.GetArticle(articleID);
                if (article != null)
                {
                    dvArticleDetails.InnerHtml = article.Details;
                    this.Page.Title = article.Name;
                }
            }
        }
        #endregion

        #endregion
    }
}