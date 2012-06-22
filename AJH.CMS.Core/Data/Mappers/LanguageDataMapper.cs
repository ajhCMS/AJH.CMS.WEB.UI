using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class LanguageDataMapper
    {
        #region Constant

        internal const string CN_LANGUAGE_ID = "LANGUAGE_ID";
        internal const string CN_LANGUAGE_NAME = "LANGUAGE_NAME";
        internal const string CN_LANGUAGE_CULTURE = "LANGUAGE_CULTURE";
        internal const string CN_LANGUAGE_IMAGE = "LANGUAGE_IMAGE";
        internal const string CN_PORTAL_ID = "PORTAL_ID";

        internal const string PN_LANGUAGE_ID = "P_LANGUAGE_ID";
        internal const string PN_LANGUAGE_NAME = "P_LANGUAGE_NAME";
        internal const string PN_LANGUAGE_CULTURE = "P_LANGUAGE_CULTURE";
        internal const string PN_LANGUAGE_IMAGE = "P_LANGUAGE_IMAGE";
        internal const string PN_PORTAL_ID = "P_PORTAL_ID";

        internal const string SN_LANGUAGE_ADD = "[SETUP].[LanguageAdd]";
        internal const string SN_LANGUAGE_UPDATE = "[SETUP].[LanguageUpdate]";
        internal const string SN_LANGUAGE_DELETE = "[SETUP].[LanguageDelete]";
        internal const string SN_LANGUAGE_GET_BY_ID = "[SETUP].[LanguageGetByID]";
        internal const string SN_LANGUAGE_GET_ALL = "[SETUP].[LanguageGetAll]";
        internal const string SN_PORTAL_LANGUAGE_ADD = "[SETUP].[PortalLanguageAdd]";
        internal const string SN_PORTAL_LANGUAGE_DELETE = "[SETUP].[PortalLanguageDelete]";
        internal const string SN_LANGUAGE_GET_BY_PORTAL_ID = "[SETUP].[LanguageGetByPortalID]";

        #endregion

        #region LanguageDataMapper

        internal static int Add(Language language)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = language.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_CULTURE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Culture;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    language.ID = Convert.ToInt32(sqlCommand.Parameters[PN_LANGUAGE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return language.ID;
        }

        internal static void Update(Language language)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_CULTURE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Culture;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = language.Image;
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
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Language> GetLanguages()
        {
            List<Language> colLanguages = null;
            Language language = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colLanguages = new List<Language>();
                    while (sqlDataReader.Read())
                    {
                        language = GetLanguage(colLanguages, sqlDataReader);
                        FillFromReader(language, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colLanguages;
        }

        internal static List<Language> GetLanguages(int portalID)
        {
            List<Language> colLanguages = null;
            Language language = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_GET_BY_PORTAL_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colLanguages = new List<Language>();
                    while (sqlDataReader.Read())
                    {
                        language = GetLanguage(colLanguages, sqlDataReader);
                        FillFromReader(language, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colLanguages;
        }

        internal static Language GetLanguage(int languageID)
        {
            Language Language = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (Language == null)
                            Language = new Language();
                        FillFromReader(Language, sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Language;
        }

        internal static void AddPortalLanguage(int portalID, int languageID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PORTAL_LANGUAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
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

        internal static void DeletePortalLanguage(int portalID, int languageID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PORTAL_LANGUAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
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

        #endregion

        #region GetFromReader

        internal static Language GetLanguage(List<Language> languages, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_LANGUAGE_ID);
            int value = reader.GetInt32(colIndex);

            Language language = languages.Where(c => c.ID == value).FirstOrDefault();
            if (language == null)
            {
                language = new Language();
                languages.Add(language);
            }
            return language;
        }

        internal static void FillFromReader(Language language, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                language.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_NAME);
            if (!reader.IsDBNull(colIndex))
                language.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_IMAGE);
            if (!reader.IsDBNull(colIndex))
                language.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_CULTURE);
            if (!reader.IsDBNull(colIndex))
                language.Culture = reader.GetString(colIndex);
        }

        #endregion
    }
}