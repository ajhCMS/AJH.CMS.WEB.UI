using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class StyleDataMapper
    {
        #region Constant

        internal const string CN_STYLE_ID = "STYLE_ID";
        internal const string CN_STYLE_NAME = "STYLE_NAME";
        internal const string CN_STYLE_DETAILS = "STYLE_DETAILS";
        internal const string CN_STYLE_FILE_NAME = "STYLE_FILE_NAME";
        internal const string CN_STYLE_IS_DELETED = "STYLE_IS_DELETED";
        internal const string CN_STYLE_PORTAL_ID = "STYLE_PORTAL_ID";
        internal const string CN_STYLE_LANGUAGE_ID = "STYLE_LANGUAGE_ID";
        internal const string CN_STYLE_CREATION_DAY = "STYLE_CREATION_DAY";
        internal const string CN_STYLE_CREATION_SEC = "STYLE_CREATION_SEC";
        internal const string CN_STYLE_CREATED_BY = "STYLE_CREATED_BY";

        internal const string PN_STYLE_ID = "P_STYLE_ID";
        internal const string PN_STYLE_NAME = "P_STYLE_NAME";
        internal const string PN_STYLE_DETAILS = "P_STYLE_DETAILS";
        internal const string PN_STYLE_FILE_NAME = "P_STYLE_FILE_NAME";
        internal const string PN_STYLE_IS_DELETED = "P_STYLE_IS_DELETED";
        internal const string PN_STYLE_PORTAL_ID = "P_STYLE_PORTAL_ID";
        internal const string PN_STYLE_LANGUAGE_ID = "P_STYLE_LANGUAGE_ID";
        internal const string PN_STYLE_CREATION_DAY = "P_STYLE_CREATION_DAY";
        internal const string PN_STYLE_CREATION_SEC = "P_STYLE_CREATION_SEC";
        internal const string PN_STYLE_CREATED_BY = "P_STYLE_CREATED_BY";

        internal const string SN_STYLE_ADD = "[SETUP].[StyleAdd]";
        internal const string SN_STYLE_DELETE = "[SETUP].[StyleDelete]";
        internal const string SN_STYLE_DELETE_LOGICAL = "[SETUP].[StyleDeleteLogical]";
        internal const string SN_STYLE_GET_ALL = "[SETUP].[StyleGetAll]";
        internal const string SN_STYLE_GET_BY_ID = "[SETUP].[StyleGetByID]";
        internal const string SN_STYLE_GET_BY_PORTAL_LANGUAGE = "[SETUP].[StyleGetByPortalLanguage]";
        internal const string SN_STYLE_UPDATE = "[SETUP].[StyleUpdate]";

        #endregion

        #region StyleDataMapper

        internal static int Add(IEntity entity)
        {
            Style styleEntity = (Style)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(styleEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_STYLE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_FILE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.FileName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    styleEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_STYLE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return styleEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Style styleEntity = (Style)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(styleEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_STYLE_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_FILE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.FileName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = styleEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_STYLE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_STYLE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Style> GetStyles()
        {
            List<Style> colStyles = null;
            Style style = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colStyles = new List<Style>();
                    while (sqlDataReader.Read())
                    {
                        style = GetStyle(colStyles, sqlDataReader);
                        FillFromReader(style, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colStyles;
        }

        internal static List<Style> GetStyles(int PortalID, int LanguageID)
        {
            List<Style> colStyles = null;
            Style style = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_STYLE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_STYLE_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colStyles = new List<Style>();
                    while (sqlDataReader.Read())
                    {
                        style = GetStyle(colStyles, sqlDataReader);
                        FillFromReader(style, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colStyles;
        }

        internal static Style GetStyleById(int StyleID)
        {
            Style style = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_STYLE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_STYLE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = StyleID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (style == null)
                            style = new Style();
                        FillFromReader(style, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return style;
        }

        #endregion

        #region GetFromReader

        internal static Style GetStyle(List<Style> styles, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_STYLE_ID);
            int value = reader.GetInt32(colIndex);

            Style style = styles.Where(c => c.ID == value).FirstOrDefault();
            if (style == null)
            {
                style = new Style();
                styles.Add(style);
            }
            return style;
        }

        internal static void FillFromReader(Style style, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_STYLE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            style.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_STYLE_DETAILS);
            if (!reader.IsDBNull(colIndex))
                style.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_FILE_NAME);
            if (!reader.IsDBNull(colIndex))
                style.FileName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_ID);
            if (!reader.IsDBNull(colIndex))
                style.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                style.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                style.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_NAME);
            if (!reader.IsDBNull(colIndex))
                style.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                style.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_STYLE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                style.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}