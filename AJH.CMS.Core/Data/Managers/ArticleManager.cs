using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class ArticleManager
    {
        public static int Add(Article article)
        {
            if (article.ParentObjectID > 0)
            {
                Article article2 = GetArticle(article.ParentObjectID, article.LanguageID);
                if (article2 != null)
                    throw new Exception("Article is exists in the same language, please choose another language");
            }
            return ArticleDataMapper.Add(article);
        }

        public static void Update(Article article)
        {
            ArticleDataMapper.Update(article);
        }

        public static void Delete(int ID)
        {
            ArticleDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            ArticleDataMapper.DeleteLogical(ID);
        }

        public static List<Article> GetArticles()
        {
            return ArticleDataMapper.GetArticles();
        }

        public static List<Article> GetArticles(int CategoryID)
        {
            return ArticleDataMapper.GetArticles(CategoryID);
        }

        public static List<Article> GetParentArticles(int CategoryID)
        {
            return ArticleDataMapper.GetParentArticles(CategoryID);
        }

        public static List<Article> GetArticles(int PortalID, int LanguageID)
        {
            return ArticleDataMapper.GetArticles(PortalID, LanguageID);
        }

        public static Article GetArticle(int ID)
        {
            return ArticleDataMapper.GetArticle(ID);
        }

        public static Article GetArticle(int articleParentObjID, int languageID)
        {
            return ArticleDataMapper.GetArticle(articleParentObjID, languageID);
        }

        public static string GetArticlesPublishXML(int CategoryID, int PageNumber, int PageSize, ref int TotalCount)
        {
            int RowFrom = ((PageNumber - 1) * PageSize) + 1, RowTo = PageNumber * PageSize;
            return ArticleDataMapper.GetArticlesPublishXML(CategoryID, RowFrom, RowTo, ref TotalCount);
        }
    }
}