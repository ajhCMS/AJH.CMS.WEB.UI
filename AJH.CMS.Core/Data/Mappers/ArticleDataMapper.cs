using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class ArticleDataMapper
    {
        #region Constant

        internal const string CN_ARTICLE_ID = "ARTICLE_ID";
        internal const string CN_ARTICLE_NAME = "ARTICLE_NAME";
        internal const string CN_ARTICLE_DESCRIPTION = "ARTICLE_DESCRIPTION";
        internal const string CN_ARTICLE_SUMMARY = "ARTICLE_SUMMARY";
        internal const string CN_ARTICLE_KEYWORDS = "ARTICLE_KEYWORDS";
        internal const string CN_ARTICLE_SEO_NAME = "ARTICLE_SEO_NAME";
        internal const string CN_ARTICLE_DETAILS = "ARTICLE_DETAILS";
        internal const string CN_ARTICLE_URL = "ARTICLE_URL";
        internal const string CN_ARTICLE_IMAGE = "ARTICLE_IMAGE";
        internal const string CN_ARTICLE_CATEGORY_ID = "ARTICLE_CATEGORY_ID";
        internal const string CN_ARTICLE_CREATION_DAY = "ARTICLE_CREATION_DAY";
        internal const string CN_ARTICLE_CREATION_SEC = "ARTICLE_CREATION_SEC";
        internal const string CN_ARTICLE_IS_DELETED = "ARTICLE_IS_DELETED";
        internal const string CN_ARTICLE_PORTAL_ID = "ARTICLE_PORTAL_ID";
        internal const string CN_ARTICLE_LANGUAGE_ID = "ARTICLE_LANGUAGE_ID";
        internal const string CN_ARTICLE_TYPE = "ARTICLE_TYPE";
        internal const string CN_ARTICLE_ORDER = "ARTICLE_ORDER";
        internal const string CN_ARTICLE_CREATED_BY = "ARTICLE_CREATED_BY";
        internal const string CN_ARTICLE_PARENT_OBJ_ID = "ARTICLE_PARENT_OBJ_ID";
        internal const string CN_ARTICLE_VIEW_COUNT = "ARTICLE_VIEW_COUNT";


        internal const string PN_ARTICLE_ID = "P_ARTICLE_ID";
        internal const string PN_ARTICLE_NAME = "P_ARTICLE_NAME";
        internal const string PN_ARTICLE_DESCRIPTION = "P_ARTICLE_DESCRIPTION";
        internal const string PN_ARTICLE_SUMMARY = "P_ARTICLE_SUMMARY";
        internal const string PN_ARTICLE_KEYWORDS = "P_ARTICLE_KEYWORDS";
        internal const string PN_ARTICLE_SEO_NAME = "P_ARTICLE_SEO_NAME";
        internal const string PN_ARTICLE_DETAILS = "P_ARTICLE_DETAILS";
        internal const string PN_ARTICLE_URL = "P_ARTICLE_URL";
        internal const string PN_ARTICLE_IMAGE = "P_ARTICLE_IMAGE";
        internal const string PN_ARTICLE_CATEGORY_ID = "P_ARTICLE_CATEGORY_ID";
        internal const string PN_ARTICLE_CREATION_DAY = "P_ARTICLE_CREATION_DAY";
        internal const string PN_ARTICLE_CREATION_SEC = "P_ARTICLE_CREATION_SEC";
        internal const string PN_ARTICLE_IS_DELETED = "P_ARTICLE_IS_DELETED";
        internal const string PN_ARTICLE_PORTAL_ID = "P_ARTICLE_PORTAL_ID";
        internal const string PN_ARTICLE_LANGUAGE_ID = "P_ARTICLE_LANGUAGE_ID";
        internal const string PN_ARTICLE_TYPE = "P_ARTICLE_TYPE";
        internal const string PN_ARTICLE_ORDER = "P_ARTICLE_ORDER";
        internal const string PN_ARTICLE_CREATED_BY = "P_ARTICLE_CREATED_BY";
        internal const string PN_ARTICLE_PARENT_OBJ_ID = "P_ARTICLE_PARENT_OBJ_ID";
        internal const string PN_ARTICLE_VIEW_COUNT = "P_ARTICLE_VIEW_COUNT";

        internal const string SN_ARTICLE_ADD = "[ARTICLE].[ArticleAdd]";
        internal const string SN_ARTICLE_UPDATE = "[ARTICLE].[ArticleUpdate]";
        internal const string SN_ARTICLE_DELETE = "[ARTICLE].[ArticleDelete]";
        internal const string SN_ARTICLE_GET_BY_ID = "[ARTICLE].[ArticleGetByID]";
        internal const string SN_ARTICLE_GET_ALL = "[ARTICLE].[ArticleGetAll]";
        internal const string SN_ARTICLE_GET_BY_CATEGORY = "[ARTICLE].[ArticleGetByCategory]";
        internal const string SN_ARTICLE_GET_PARENT_BY_CATEGORY = "[ARTICLE].[ArticleGetParentByCategory]";
        internal const string SN_ARTICLE_GET_BY_PORTAL_LANGUAGE = "[ARTICLE].[ArticleGetByPortalLanguage]";
        internal const string SN_ARTICLE_DELETE_LOGICAL = "[ARTICLE].[ArticleDeleteLogical]";
        internal const string SN_ARTICLE_GET_BY_CATEGORY_XML = "[ARTICLE].[ArticleGetByCategoryXML]";
        internal const string SN_ARTICLE_GET_BY_PARENT_OBJ_ID = "[ARTICLE].[ArticleGetByParentObjIdAndLanguageID]";


        #endregion

        #region ArticleDataMapper

        internal static int Add(IEntity entity)
        {
            Article articleEntity = (Article)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(articleEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_SUMMARY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)articleEntity.ArticleType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.ParentObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_VIEW_COUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.ViewCount;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    articleEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ARTICLE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return articleEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Article articleEntity = (Article)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(articleEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_SUMMARY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)articleEntity.ArticleType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.ParentObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_VIEW_COUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleEntity.ViewCount;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal static void Delete(int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal static void DeleteLogical(int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal static List<Article> GetArticles()
        {
            List<Article> colArticles = null;
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colArticles = new List<Article>();
                    while (sqlDataReader.Read())
                    {
                        article = GetArticle(colArticles, sqlDataReader);
                        FillFromReader(article, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colArticles;
        }

        internal static List<Article> GetArticles(int CategoryID)
        {
            List<Article> colArticles = null;
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ARTICLE_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colArticles = new List<Article>();
                    while (sqlDataReader.Read())
                    {
                        article = GetArticle(colArticles, sqlDataReader);
                        FillFromReader(article, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colArticles;
        }

        internal static List<Article> GetParentArticles(int CategoryID)
        {
            List<Article> colArticles = null;
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_PARENT_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ARTICLE_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colArticles = new List<Article>();
                    while (sqlDataReader.Read())
                    {
                        article = GetArticle(colArticles, sqlDataReader);
                        FillFromReader(article, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colArticles;
        }

        internal static List<Article> GetArticles(int PortalID, int LanguageID)
        {
            List<Article> colArticles = null;
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colArticles = new List<Article>();
                    while (sqlDataReader.Read())
                    {
                        article = GetArticle(colArticles, sqlDataReader);
                        FillFromReader(article, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colArticles;
        }

        internal static Article GetArticle(int ArticleID)
        {
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_ARTICLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ArticleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (article == null)
                            article = new Article();
                        FillFromReader(article, sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return article;
        }

        internal static Article GetArticle(int articleParentObjID, int languageID)
        {
            Article article = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_BY_PARENT_OBJ_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ARTICLE_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = articleParentObjID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (article == null)
                            article = new Article();
                        FillFromReader(article, sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return article;
        }

        internal static string GetArticlesPublishXML(int CategoryID, int languageId, int RowFrom, int RowTo, ref int TotalCount)
        {
            string articleXML = string.Empty;
            TotalCount = 0;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ARTICLE_GET_BY_CATEGORY_XML, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ARTICLE_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ARTICLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_ROW_FROM, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RowFrom;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_ROW_TO, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RowTo;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_TOTAL_COUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Article;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_TYPE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.PublishType.PublishNow;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    SqlXml sqlXML = null;
                    while (sqlDataReader.Read())
                    {
                        sqlXML = sqlDataReader.GetSqlXml(0);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();

                    if (!sqlXML.IsNull)
                    {
                        articleXML = sqlXML.Value;
                        TotalCount = Convert.ToInt32(sqlCommand.Parameters[CMSCoreBase.PN_TOTAL_COUNT].Value);
                    }
                }
            }
            return articleXML;
        }

        #endregion

        #region GetFromReader

        internal static Article GetArticle(List<Article> articles, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ARTICLE_ID);
            int value = reader.GetInt32(colIndex);

            Article article = articles.Where(c => c.ID == value).FirstOrDefault();
            if (article == null)
            {
                article = new Article();
                articles.Add(article);
            }
            return article;
        }

        internal static void FillFromReader(Article article, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ARTICLE_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                article.CategoryID = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_ARTICLE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            article.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_ARTICLE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                article.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_DETAILS);
            if (!reader.IsDBNull(colIndex))
                article.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_ID);
            if (!reader.IsDBNull(colIndex))
                article.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_IMAGE);
            if (!reader.IsDBNull(colIndex))
                article.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                article.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_KEYWORDS);
            if (!reader.IsDBNull(colIndex))
                article.KeyWords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                article.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_NAME);
            if (!reader.IsDBNull(colIndex))
                article.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_SUMMARY);
            if (!reader.IsDBNull(colIndex))
                article.Summary = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                article.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_SEO_NAME);
            if (!reader.IsDBNull(colIndex))
                article.SEOName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_URL);
            if (!reader.IsDBNull(colIndex))
                article.URL = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_TYPE);
            if (!reader.IsDBNull(colIndex))
                article.ArticleType = (CMSEnums.ArticleType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_ORDER);
            if (!reader.IsDBNull(colIndex))
                article.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                article.CreatedBy = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_PARENT_OBJ_ID);
            if (!reader.IsDBNull(colIndex))
                article.ParentObjectID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ARTICLE_VIEW_COUNT);
            if (!reader.IsDBNull(colIndex))
                article.ViewCount = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(PublishDataMapper.CN_PUBLISH_TYPE_ID);
            if (!reader.IsDBNull(colIndex))
                article.IsPublished = reader.GetInt32(colIndex) == (int)CMSEnums.PublishType.PublishNow;
        }

        #endregion
    }
}