using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class PageDataMapper
    {
        #region Constant

        internal const string CN_PAGE_ID = "PAGE_ID";
        internal const string CN_PAGE_CREATION_DAY = "PAGE_CREATION_DAY";
        internal const string CN_PAGE_CREATION_SEC = "PAGE_CREATION_SEC";
        internal const string CN_PAGE_DESCRIPTION = "PAGE_DESCRIPTION";
        internal const string CN_PAGE_DETAILS = "PAGE_DETAILS";
        internal const string CN_PAGE_ICON = "PAGE_ICON";
        internal const string CN_PAGE_IS_DELETED = "PAGE_IS_DELETED";
        internal const string CN_PAGE_KEYWORDS = "PAGE_KEYWORDS";
        internal const string CN_PAGE_LANGUAGE_ID = "PAGE_LANGUAGE_ID";
        internal const string CN_PAGE_NAME = "PAGE_NAME";
        internal const string CN_PAGE_TYPE = "PAGE_TYPE";
        internal const string CN_PAGE_PORTAL_ID = "PAGE_PORTAL_ID";
        internal const string CN_PAGE_SEO_NAME = "PAGE_SEO_NAME";
        internal const string CN_PAGE_TITLE = "PAGE_TITLE";
        internal const string CN_PAGE_TEMPLATE_ID = "PAGE_TEMPLATE_ID";
        internal const string CN_PAGE_CREATED_BY = "PAGE_CREATED_BY";

        internal const string PN_PAGE_ID = "P_PAGE_ID";
        internal const string PN_PAGE_CREATION_DAY = "P_PAGE_CREATION_DAY";
        internal const string PN_PAGE_CREATION_SEC = "P_PAGE_CREATION_SEC";
        internal const string PN_PAGE_DESCRIPTION = "P_PAGE_DESCRIPTION";
        internal const string PN_PAGE_DETAILS = "P_PAGE_DETAILS";
        internal const string PN_PAGE_ICON = "P_PAGE_ICON";
        internal const string PN_PAGE_IS_DELETED = "P_PAGE_IS_DELETED";
        internal const string PN_PAGE_KEYWORDS = "P_PAGE_KEYWORDS";
        internal const string PN_PAGE_LANGUAGE_ID = "P_PAGE_LANGUAGE_ID";
        internal const string PN_PAGE_NAME = "P_PAGE_NAME";
        internal const string PN_PAGE_TYPE = "P_PAGE_TYPE";
        internal const string PN_PAGE_PORTAL_ID = "P_PAGE_PORTAL_ID";
        internal const string PN_PAGE_SEO_NAME = "P_PAGE_SEO_NAME";
        internal const string PN_PAGE_TITLE = "P_PAGE_TITLE";
        internal const string PN_PAGE_TEMPLATE_ID = "P_PAGE_TEMPLATE_ID";
        internal const string PN_PAGE_CREATED_BY = "P_PAGE_CREATED_BY";

        internal const string SN_PAGE_ADD = "[SETUP].[PageAdd]";
        internal const string SN_PAGE_DELETE = "[SETUP].[PageDelete]";
        internal const string SN_PAGE_DELETE_LOGICAL = "[SETUP].[PageDeleteLogical]";
        internal const string SN_PAGE_GET_ALL = "[SETUP].[PageGetAll]";
        internal const string SN_PAGE_GET_BY_ID = "[SETUP].[PageGetByID]";
        internal const string SN_PAGE_GET_BY_NAME = "[SETUP].[PageGetByName]";
        internal const string SN_PAGE_GET_BY_TEMPLATE = "[SETUP].[PageGetByTemplate]";
        internal const string SN_PAGE_GET_BY_PORTAL_LANGUAGE = "[SETUP].[PageGetByPortalLanguage]";
        internal const string SN_PAGE_UPDATE = "[SETUP].[PageUpdate]";

        #endregion

        #region PageDataMapper

        internal static int Add(IEntity entity)
        {
            Page pageEntity = (Page)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(pageEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PAGE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_ICON, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Icon;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TITLE, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Title;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)pageEntity.PageType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.TemplateID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    pageEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PAGE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return pageEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Page pageEntity = (Page)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(pageEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PAGE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_ICON, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Icon;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TITLE, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.Title;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)pageEntity.PageType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.TemplateID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = pageEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PAGE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PAGE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Page> GetPages()
        {
            List<Page> colPages = null;
            Page page = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPages = new List<Page>();
                    while (sqlDataReader.Read())
                    {
                        page = GetPage(colPages, sqlDataReader);
                        FillFromReader(page, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPages;
        }

        internal static List<Page> GetPages(int PortalID, int LanguageID)
        {
            List<Page> colPages = null;
            Page page = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PAGE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPages = new List<Page>();
                    while (sqlDataReader.Read())
                    {
                        page = GetPage(colPages, sqlDataReader);
                        FillFromReader(page, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPages;
        }

        internal static List<Page> GetPages(int TemplateID)
        {
            List<Page> colPages = null;
            Page page = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_GET_BY_TEMPLATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PAGE_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TemplateID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPages = new List<Page>();
                    while (sqlDataReader.Read())
                    {
                        page = GetPage(colPages, sqlDataReader);
                        FillFromReader(page, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPages;
        }

        internal static Page GetPage(int PageID)
        {
            Page page = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (page == null)
                            page = new Page();
                        FillFromReader(page, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return page;
        }

        internal static Page GetPage(string Name, int PortalID, int LanguageID)
        {
            Page page = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PAGE_GET_BY_NAME, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_PAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PAGE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (page == null)
                            page = new Page();
                        FillFromReader(page, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return page;
        }

        #endregion

        #region GetFromReader

        internal static Page GetPage(List<Page> pages, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PAGE_ID);
            int value = reader.GetInt32(colIndex);

            Page page = pages.Where(c => c.ID == value).FirstOrDefault();
            if (page == null)
            {
                page = new Page();
                pages.Add(page);
            }
            return page;
        }

        internal static void FillFromReader(Page page, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_PAGE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            page.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_PAGE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                page.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_DETAILS);
            if (!reader.IsDBNull(colIndex))
                page.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_ICON);
            if (!reader.IsDBNull(colIndex))
                page.Icon = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_ID);
            if (!reader.IsDBNull(colIndex))
                page.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                page.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_KEYWORDS);
            if (!reader.IsDBNull(colIndex))
                page.KeyWords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                page.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_NAME);
            if (!reader.IsDBNull(colIndex))
                page.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                page.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_SEO_NAME);
            if (!reader.IsDBNull(colIndex))
                page.SEOName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_TYPE);
            if (!reader.IsDBNull(colIndex))
                page.PageType = (CMSEnums.PageType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_TITLE);
            if (!reader.IsDBNull(colIndex))
                page.Title = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_TEMPLATE_ID);
            if (!reader.IsDBNull(colIndex))
                page.TemplateID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PAGE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                page.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}