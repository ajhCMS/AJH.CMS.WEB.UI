using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class CategoryDataMapper
    {
        #region Constant

        internal const string CN_CATEGORY_ID = "CATEGORY_ID";
        internal const string CN_CATEGORY_NAME = "CATEGORY_NAME";
        internal const string CN_CATEGORY_DESCRIPTION = "CATEGORY_DESCRIPTION";
        internal const string CN_CATEGORY_MODULE_ID = "CATEGORY_MODULE_ID";
        internal const string CN_CATEGORY_IS_DELETED = "CATEGORY_IS_DELETED";
        internal const string CN_CATEGORY_PORTAL_ID = "CATEGORY_PORTAL_ID";
        internal const string CN_CATEGORY_PARENT_ID = "CATEGORY_PARENT_ID";
        internal const string CN_CATEGORY_LANGUAGE_ID = "CATEGORY_LANGUAGE_ID";
        internal const string CN_CATEGORY_CREATION_DAY = "CATEGORY_CREATION_DAY";
        internal const string CN_CATEGORY_CREATION_SEC = "CATEGORY_CREATION_SEC";
        internal const string CN_CATEGORY_ORDER = "CATEGORY_ORDER";
        internal const string CN_CATEGORY_CREATED_BY = "CATEGORY_CREATED_BY";
        internal const string CN_CATEGORY_IMAGE = "CATEGORY_IMAGE";

        internal const string PN_CATEGORY_ID = "P_CATEGORY_ID";
        internal const string PN_CATEGORY_NAME = "P_CATEGORY_NAME";
        internal const string PN_CATEGORY_DESCRIPTION = "P_CATEGORY_DESCRIPTION";
        internal const string PN_CATEGORY_MODULE_ID = "P_CATEGORY_MODULE_ID";
        internal const string PN_CATEGORY_IS_DELETED = "P_CATEGORY_IS_DELETED";
        internal const string PN_CATEGORY_PORTAL_ID = "P_CATEGORY_PORTAL_ID";
        internal const string PN_CATEGORY_PARENT_ID = "P_CATEGORY_PARENT_ID";
        internal const string PN_CATEGORY_LANGUAGE_ID = "P_CATEGORY_LANGUAGE_ID";
        internal const string PN_CATEGORY_CREATION_DAY = "P_CATEGORY_CREATION_DAY";
        internal const string PN_CATEGORY_CREATION_SEC = "P_CATEGORY_CREATION_SEC";
        internal const string PN_CATEGORY_ORDER = "P_CATEGORY_ORDER";
        internal const string PN_CATEGORY_CREATED_BY = "P_CATEGORY_CREATED_BY";
        internal const string PN_CATEGORY_IMAGE = "P_CATEGORY_IMAGE";

        internal const string SN_CATEGORY_ADD = "[SETUP].[CategoryAdd]";
        internal const string SN_CATEGORY_DELETE = "[SETUP].[CategoryDelete]";
        internal const string SN_CATEGORY_DELETE_LOGICAL = "[SETUP].[CategoryDeleteLogical]";
        internal const string SN_CATEGORY_GET_ALL = "[SETUP].[CategoryGetAll]";
        internal const string SN_CATEGORY_GET_BY_ID = "[SETUP].[CategoryGetByID]";
        internal const string SN_CATEGORY_GET_BY_MODULE = "[SETUP].[CategoryGetByModuleID]";
        internal const string SN_CATEGORY_GET_BY_PORTAL_LANGUAGE = "[SETUP].[CategoryGetByPortalLanguage]";
        internal const string SN_CATEGORY_UPDATE = "[SETUP].[CategoryUpdate]";
        internal const string SN_CATEGORY_GET_BY_CATEGORY_XML = "[SETUP].[CategoryGetByModuleXML]";

        #endregion

        #region CategoryDataMapper

        internal static int Add(IEntity entity)
        {
            Category categoryEntity = (Category)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(categoryEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    categoryEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_CATEGORY_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return categoryEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Category categoryEntity = (Category)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(categoryEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = categoryEntity.Image;
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATEGORY_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATEGORY_ID, System.Data.SqlDbType.Int);
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

        internal static List<Category> GetCategorys()
        {
            List<Category> colCategorys = null;
            Category category = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCategorys = new List<Category>();
                    while (sqlDataReader.Read())
                    {
                        category = GetCategory(colCategorys, sqlDataReader);
                        FillFromReader(category, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCategorys;
        }

        internal static List<Category> GetCategorys(int ModuleID, int PortalID, int LanguageID)
        {
            List<Category> colCategorys = null;
            Category category = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_GET_BY_MODULE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATEGORY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCategorys = new List<Category>();
                    while (sqlDataReader.Read())
                    {
                        category = GetCategory(colCategorys, sqlDataReader);
                        FillFromReader(category, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCategorys;
        }

        internal static List<Category> GetCategorys(int PortalID, int LanguageID)
        {
            List<Category> colCategorys = null;
            Category category = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATEGORY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCategorys = new List<Category>();
                    while (sqlDataReader.Read())
                    {
                        category = GetCategory(colCategorys, sqlDataReader);
                        FillFromReader(category, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCategorys;
        }

        internal static Category GetCategoryById(int CategoryID)
        {
            Category category = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_CATEGORY_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = CategoryID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (category == null)
                            category = new Category();
                        FillFromReader(category, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return category;
        }

        internal static string GetCategoryPublishXML(int ModuleID, int ParentID)
        {
            string categoryXML = string.Empty;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATEGORY_GET_BY_CATEGORY_XML, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CATEGORY_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATEGORY_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ModuleID;
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
                        categoryXML = sqlXML.Value;
                    }
                }
            }
            return categoryXML;
        }

        #endregion

        #region GetFromReader

        internal static Category GetCategory(List<Category> categorys, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATEGORY_ID);
            int value = reader.GetInt32(colIndex);

            Category category = categorys.Where(c => c.ID == value).FirstOrDefault();
            if (category == null)
            {
                category = new Category();
                categorys.Add(category);
            }
            return category;
        }

        internal static void FillFromReader(Category category, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_CATEGORY_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            category.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_CATEGORY_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                category.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                category.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                category.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                category.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                category.ModuleID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_NAME);
            if (!reader.IsDBNull(colIndex))
                category.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                category.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_PARENT_ID);
            if (!reader.IsDBNull(colIndex))
                category.ParentID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_ORDER);
            if (!reader.IsDBNull(colIndex))
                category.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                category.CreatedBy = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATEGORY_IMAGE);
            if (!reader.IsDBNull(colIndex))
                category.Image = reader.GetString(colIndex);
        }

        #endregion
    }
}