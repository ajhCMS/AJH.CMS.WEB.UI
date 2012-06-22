using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class TemplateDataMapper
    {
        #region Constant

        internal const string CN_TEMPLATE_ID = "TEMPLATE_ID";
        internal const string CN_TEMPLATE_CREATION_DAY = "TEMPLATE_CREATION_DAY";
        internal const string CN_TEMPLATE_CREATION_SEC = "TEMPLATE_CREATION_SEC";
        internal const string CN_TEMPLATE_DESCRIPTION = "TEMPLATE_DESCRIPTION";
        internal const string CN_TEMPLATE_DETAILS = "TEMPLATE_DETAILS";
        internal const string CN_TEMPLATE_IMAGE = "TEMPLATE_IMAGE";
        internal const string CN_TEMPLATE_IS_DELETED = "TEMPLATE_IS_DELETED";
        internal const string CN_TEMPLATE_LANGUAGE_ID = "TEMPLATE_LANGUAGE_ID";
        internal const string CN_TEMPLATE_NAME = "TEMPLATE_NAME";
        internal const string CN_TEMPLATE_PORTAL_ID = "TEMPLATE_PORTAL_ID";
        internal const string CN_TEMPLATE_CREATED_BY = "TEMPLATE_CREATED_BY";

        internal const string PN_TEMPLATE_ID = "P_TEMPLATE_ID";
        internal const string PN_TEMPLATE_CREATION_DAY = "P_TEMPLATE_CREATION_DAY";
        internal const string PN_TEMPLATE_CREATION_SEC = "P_TEMPLATE_CREATION_SEC";
        internal const string PN_TEMPLATE_DESCRIPTION = "P_TEMPLATE_DESCRIPTION";
        internal const string PN_TEMPLATE_DETAILS = "P_TEMPLATE_DETAILS";
        internal const string PN_TEMPLATE_IMAGE = "P_TEMPLATE_IMAGE";
        internal const string PN_TEMPLATE_IS_DELETED = "P_TEMPLATE_IS_DELETED";
        internal const string PN_TEMPLATE_LANGUAGE_ID = "P_TEMPLATE_LANGUAGE_ID";
        internal const string PN_TEMPLATE_NAME = "P_TEMPLATE_NAME";
        internal const string PN_TEMPLATE_PORTAL_ID = "P_TEMPLATE_PORTAL_ID";
        internal const string PN_TEMPLATE_CREATED_BY = "P_TEMPLATE_CREATED_BY";

        internal const string SN_TEMPLATE_ADD = "[SETUP].[TemplateAdd]";
        internal const string SN_TEMPLATE_DELETE = "[SETUP].[TemplateDelete]";
        internal const string SN_TEMPLATE_DELETE_LOGICAL = "[SETUP].[TemplateDeleteLogical]";
        internal const string SN_TEMPLATE_GET_ALL = "[SETUP].[TemplateGetAll]";
        internal const string SN_TEMPLATE_GET_BY_ID = "[SETUP].[TemplateGetByID]";
        internal const string SN_TEMPLATE_GET_BY_PORTAL_LANGUAGE = "[SETUP].[TemplateGetByPortalLanguage]";
        internal const string SN_TEMPLATE_UPDATE = "[SETUP].[TemplateUpdate]";

        #endregion

        #region TemplateDataMapper

        internal static int Add(IEntity entity)
        {
            Template templateEntity = (Template)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(templateEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    templateEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_TEMPLATE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return templateEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Template templateEntity = (Template)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(templateEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = templateEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TEMPLATE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TEMPLATE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Template> GetTemplates()
        {
            List<Template> colTemplates = null;
            Template template = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colTemplates = new List<Template>();
                    while (sqlDataReader.Read())
                    {
                        template = GetTemplate(colTemplates, sqlDataReader);
                        FillFromReader(template, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colTemplates;
        }

        internal static List<Template> GetTemplates(int PortalID, int LanguageID)
        {
            List<Template> colTemplates = null;
            Template template = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TEMPLATE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TEMPLATE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colTemplates = new List<Template>();
                    while (sqlDataReader.Read())
                    {
                        template = GetTemplate(colTemplates, sqlDataReader);
                        FillFromReader(template, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colTemplates;
        }

        internal static Template GetTemplate(int TemplateID)
        {
            Template template = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TEMPLATE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_TEMPLATE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TemplateID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (template == null)
                            template = new Template();
                        FillFromReader(template, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return template;
        }

        #endregion

        #region GetFromReader

        internal static Template GetTemplate(List<Template> templates, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_TEMPLATE_ID);
            int value = reader.GetInt32(colIndex);

            Template template = templates.Where(c => c.ID == value).FirstOrDefault();
            if (template == null)
            {
                template = new Template();
                templates.Add(template);
            }
            return template;
        }

        internal static void FillFromReader(Template template, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_TEMPLATE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            template.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                template.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_DETAILS);
            if (!reader.IsDBNull(colIndex))
                template.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_ID);
            if (!reader.IsDBNull(colIndex))
                template.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_IMAGE);
            if (!reader.IsDBNull(colIndex))
                template.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                template.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                template.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_NAME);
            if (!reader.IsDBNull(colIndex))
                template.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                template.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TEMPLATE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                template.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}