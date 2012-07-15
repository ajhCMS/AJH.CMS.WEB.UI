using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class PreferenceDataMapper
    {
        #region Constants

        internal const string CN_PREFERENCE_NAME = "PREFERENCE_NAME";
        internal const string CN_PREFERENCE_PORTAL_ID = "PREFERENCE_PORTAL_ID";
        internal const string CN_PREFERENCE_ID = "PREFERENCE_ID";
        internal const string CN_PREFERENCE_IS_ENABLED = "PREFERENCE_IS_ENABLED";

        internal const string PN_PREFERENCE_NAME = "P_PREFERENCE_NAME";
        internal const string PN_PREFERENCE_PORTAL_ID = "P_PREFERENCE_PORTAL_ID";
        internal const string PN_PREFERENCE_ID = "P_PREFERENCE_ID";
        internal const string PN_PREFERENCE_IS_ENABLED = "P_PREFERENCE_IS_ENABLED";

        internal const string SN_PREFERENCE_ADD = "[ECOMMERCE].[PreferenceAdd]";
        internal const string SN_PREFERENCE_UPDATE = "[ECOMMERCE].[PreferenceUpdate]";
        internal const string SN_PREFERENCE_GET_BY_PORTAL_ID = "[ECOMMERCE].[PreferenceGetByPortalID]";
        internal const string SN_PREFERENCE_GET_BY_NAME = "[ECOMMERCE].[PreferenceGetByName]";

        #endregion

        #region PreferenceDataMapper

        internal static int Add(Preference preference)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PREFERENCE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PREFERENCE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = preference.ID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlParameter = new SqlParameter(PN_PREFERENCE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = preference.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PREFERENCE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = preference.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PREFERENCE_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = preference.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    preference.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PREFERENCE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return preference.ID;
        }

        internal static void Update(int prefernceId, bool isEnabled)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PREFERENCE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PREFERENCE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = prefernceId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PREFERENCE_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = isEnabled;
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

        internal static List<AJH.CMS.Core.Entities.Preference> GetPreferences(int portalID)
        {
            List<AJH.CMS.Core.Entities.Preference> colPreferences = null;
            AJH.CMS.Core.Entities.Preference Preference = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PREFERENCE_GET_BY_PORTAL_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PREFERENCE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPreferences = new List<AJH.CMS.Core.Entities.Preference>();
                    while (sqlDataReader.Read())
                    {
                        Preference = GetPreference(colPreferences, sqlDataReader);
                        FillFromReader(Preference, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPreferences;
        }

        internal static AJH.CMS.Core.Entities.Preference GetPreference(string preferenceName)
        {
            Preference Preference = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PREFERENCE_GET_BY_NAME, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PREFERENCE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = preferenceName;
                sqlCommand.Parameters.Add(sqlParameter);



                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        Preference = new Entities.Preference();
                        FillFromReader(Preference, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Preference;
        }

        #endregion

        #region GetFromReader

        internal static AJH.CMS.Core.Entities.Preference GetPreference(List<AJH.CMS.Core.Entities.Preference> Preferences, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PREFERENCE_ID);
            int value = reader.GetInt32(colIndex);

            AJH.CMS.Core.Entities.Preference Preference = Preferences.Where(c => c.ID == value).FirstOrDefault();
            if (Preference == null)
            {
                Preference = new AJH.CMS.Core.Entities.Preference();
                Preferences.Add(Preference);
            }
            return Preference;
        }

        internal static void FillFromReader(Preference Preference, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PREFERENCE_ID);
            if (!reader.IsDBNull(colIndex))
                Preference.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PREFERENCE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                Preference.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PREFERENCE_NAME);
            if (!reader.IsDBNull(colIndex))
                Preference.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PREFERENCE_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                Preference.IsEnabled = reader.GetBoolean(colIndex);
        }

        #endregion
    }
}