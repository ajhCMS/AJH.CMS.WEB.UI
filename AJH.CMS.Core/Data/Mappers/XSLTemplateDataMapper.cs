using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class XSLTemplateDataMapper
    {
        #region Constant

        internal const string CN_XSLTEMPLATE_ID = "XSLTEMPLATE_ID";
        internal const string CN_XSLTEMPLATE_NAME = "XSLTEMPLATE_NAME";
        internal const string CN_XSLTEMPLATE_DESCRIPTION = "XSLTEMPLATE_DESCRIPTION";
        internal const string CN_XSLTEMPLATE_DETAILS = "XSLTEMPLATE_DETAILS";
        internal const string CN_XSLTEMPLATE_MODULE_ID = "XSLTEMPLATE_MODULE_ID";
        internal const string CN_XSLTEMPLATE_IS_DELETED = "XSLTEMPLATE_IS_DELETED";
        internal const string CN_XSLTEMPLATE_PORTAL_ID = "XSLTEMPLATE_PORTAL_ID";
        internal const string CN_XSLTEMPLATE_LANGUAGE_ID = "XSLTEMPLATE_LANGUAGE_ID";
        internal const string CN_XSLTEMPLATE_CREATION_DAY = "XSLTEMPLATE_CREATION_DAY";
        internal const string CN_XSLTEMPLATE_CREATION_SEC = "XSLTEMPLATE_CREATION_SEC";
        internal const string CN_XSLTEMPLATE_CREATED_BY = "XSLTEMPLATE_CREATED_BY";

        internal const string PN_XSLTEMPLATE_ID = "P_XSLTEMPLATE_ID";
        internal const string PN_XSLTEMPLATE_NAME = "P_XSLTEMPLATE_NAME";
        internal const string PN_XSLTEMPLATE_DESCRIPTION = "P_XSLTEMPLATE_DESCRIPTION";
        internal const string PN_XSLTEMPLATE_DETAILS = "P_XSLTEMPLATE_DETAILS";
        internal const string PN_XSLTEMPLATE_MODULE_ID = "P_XSLTEMPLATE_MODULE_ID";
        internal const string PN_XSLTEMPLATE_IS_DELETED = "P_XSLTEMPLATE_IS_DELETED";
        internal const string PN_XSLTEMPLATE_PORTAL_ID = "P_XSLTEMPLATE_PORTAL_ID";
        internal const string PN_XSLTEMPLATE_LANGUAGE_ID = "P_XSLTEMPLATE_LANGUAGE_ID";
        internal const string PN_XSLTEMPLATE_CREATION_DAY = "P_XSLTEMPLATE_CREATION_DAY";
        internal const string PN_XSLTEMPLATE_CREATION_SEC = "P_XSLTEMPLATE_CREATION_SEC";
        internal const string PN_XSLTEMPLATE_CREATED_BY = "P_XSLTEMPLATE_CREATED_BY";

        internal const string SN_XSLTEMPLATE_ADD = "[SETUP].[XSLTemplateAdd]";
        internal const string SN_XSLTEMPLATE_DELETE = "[SETUP].[XSLTemplateDelete]";
        internal const string SN_XSLTEMPLATE_DELETE_LOGICAL = "[SETUP].[XSLTemplateDeleteLogical]";
        internal const string SN_XSLTEMPLATE_GET_ALL = "[SETUP].[XSLTemplateGetAll]";
        internal const string SN_XSLTEMPLATE_GET_BY_ID = "[SETUP].[XSLTemplateGetByID]";
        internal const string SN_XSLTEMPLATE_GET_BY_MODULE = "[SETUP].[XSLTemplateGetByModuleID]";
        internal const string SN_XSLTEMPLATE_GET_BY_PORTAL_LANGUAGE = "[SETUP].[XSLTemplateGetByPortalLanguage]";
        internal const string SN_XSLTEMPLATE_UPDATE = "[SETUP].[XSLTemplateUpdate]";

        #endregion

        #region XSLTemplateDataMapper

        internal static int Add(IEntity entity)
        {
            XSLTemplate xslTemplateEntity = (XSLTemplate)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(xslTemplateEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    xslTemplateEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_XSLTEMPLATE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return xslTemplateEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            XSLTemplate xslTemplateEntity = (XSLTemplate)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(xslTemplateEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = xslTemplateEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_ID, System.Data.SqlDbType.Int);
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

        internal static List<XSLTemplate> GetXSLTemplates()
        {
            List<XSLTemplate> colXSLTemplates = null;
            XSLTemplate xslTemplate = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colXSLTemplates = new List<XSLTemplate>();
                    while (sqlDataReader.Read())
                    {
                        xslTemplate = GetXSLTemplate(colXSLTemplates, sqlDataReader);
                        FillFromReader(xslTemplate, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colXSLTemplates;
        }

        internal static List<XSLTemplate> GetXSLTemplates(int ModuleID, int PortalID, int LanguageID)
        {
            List<XSLTemplate> colXSLTemplates = null;
            XSLTemplate xslTemplate = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_GET_BY_MODULE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colXSLTemplates = new List<XSLTemplate>();
                    while (sqlDataReader.Read())
                    {
                        xslTemplate = GetXSLTemplate(colXSLTemplates, sqlDataReader);
                        FillFromReader(xslTemplate, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colXSLTemplates;
        }

        internal static List<XSLTemplate> GetXSLTemplates(int PortalID, int LanguageID)
        {
            List<XSLTemplate> colXSLTemplates = null;
            XSLTemplate xslTemplate = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XSLTEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colXSLTemplates = new List<XSLTemplate>();
                    while (sqlDataReader.Read())
                    {
                        xslTemplate = GetXSLTemplate(colXSLTemplates, sqlDataReader);
                        FillFromReader(xslTemplate, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colXSLTemplates;
        }

        internal static XSLTemplate GetXSLTemplateById(int XSLTemplateID)
        {
            XSLTemplate xslTemplate = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_XSLTEMPLATE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_XSLTEMPLATE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = XSLTemplateID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (xslTemplate == null)
                            xslTemplate = new XSLTemplate();
                        FillFromReader(xslTemplate, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return xslTemplate;
        }

        #endregion

        #region GetFromReader

        internal static XSLTemplate GetXSLTemplate(List<XSLTemplate> xslTemplates, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_ID);
            int value = reader.GetInt32(colIndex);

            XSLTemplate xslTemplate = xslTemplates.Where(c => c.ID == value).FirstOrDefault();
            if (xslTemplate == null)
            {
                xslTemplate = new XSLTemplate();
                xslTemplates.Add(xslTemplate);
            }
            return xslTemplate;
        }

        internal static void FillFromReader(XSLTemplate xslTemplate, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            xslTemplate.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_DETAILS);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_ID);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.ModuleID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_NAME);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XSLTEMPLATE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                xslTemplate.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}