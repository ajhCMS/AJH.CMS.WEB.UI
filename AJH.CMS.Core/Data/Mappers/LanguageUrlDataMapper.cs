using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class LanguageUrlDataMapper
    {
        #region Constant

        internal const string CN_LANGUAGE_URL_ID = "LANGUAGE_URL_ID";
        internal const string CN_LANGUAGE_URL_LANGUAGE_ID = "LANGUAGE_URL_LANGUAGE_ID";
        internal const string CN_LANGUAGE_URL_NAME = "LANGUAGE_URL_NAME";
        internal const string CN_LANGUAGE_URL_PORTAL_ID = "LANGUAGE_URL_PORTAL_ID";

        internal const string PN_LANGUAGE_URL_ID = "P_LANGUAGE_URL_ID";
        internal const string PN_LANGUAGE_ID = "P_LANGUAGE_ID";
        internal const string PN_LANGUAGE_URL_NAME = "P_LANGUAGE_URL_NAME";
        internal const string PN_LANGUAGE_URL_PORTAL_ID = "P_LANGUAGE_URL_PORTAL_ID";



        internal const string SN_LANGUAGE_URL_GET_ALL = "[SETUP].[LanguageUrlGetAll]";

        #endregion

        #region ArticleDataMapper

        internal static List<LanguageURL> GetLanguageURLs(int portalID)
        {
            List<LanguageURL> colLanguageURLs = null;
            LanguageURL LanguageURL = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_LANGUAGE_URL_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = PN_LANGUAGE_URL_PORTAL_ID;
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.DbType = System.Data.DbType.Int32;
                parameter.Value = portalID;

                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colLanguageURLs = new List<LanguageURL>();
                    while (sqlDataReader.Read())
                    {
                        LanguageURL = GetLanguageURL(colLanguageURLs, sqlDataReader);
                        FillFromReader(LanguageURL, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colLanguageURLs;
        }

        #endregion

        #region GetFromReader

        internal static LanguageURL GetLanguageURL(List<LanguageURL> LanguageURLs, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_LANGUAGE_URL_ID);
            int value = reader.GetInt32(colIndex);

            LanguageURL LanguageURL = LanguageURLs.Where(c => c.ID == value).FirstOrDefault();
            if (LanguageURL == null)
            {
                LanguageURL = new LanguageURL();
                LanguageURLs.Add(LanguageURL);
            }
            return LanguageURL;
        }

        internal static void FillFromReader(LanguageURL LanguageURL, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_LANGUAGE_URL_ID);
            if (!reader.IsDBNull(colIndex))
                LanguageURL.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_URL_NAME);
            if (!reader.IsDBNull(colIndex))
                LanguageURL.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_URL_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                LanguageURL.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_LANGUAGE_URL_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                LanguageURL.PortalID = reader.GetInt32(colIndex);

        }

        #endregion
    }
}