using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class CountriesDataMapper
    {
        #region Constants

        internal const string CN_COUNTRIES_ID = "COUNTRY_ID";
        internal const string CN_COUNTRIES_FNAME = "COUNTRY_NAME";

        internal const string SN_Countries_GET_ALL = "[ECOMMERCE].[GetAllCountries]";

        #endregion

        #region CatalogDataMapper
        internal static List<Countries> GetAllCountries()
        {
            List<Countries> colCountries = null;
            Countries oCountries = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_Countries_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCountries = new List<Countries>();
                    while (sqlDataReader.Read())
                    {
                        oCountries = GetCountries(colCountries, sqlDataReader);
                        FillFromReader(oCountries, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCountries;
        }
        #endregion


        #region GetFromReader

        internal static Countries GetCountries(List<Countries> oCountries, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_COUNTRIES_ID);
            int value = reader.GetInt32(colIndex);

            Countries _Countries = oCountries.Where(c => c.ID == value).FirstOrDefault();
            if (_Countries == null)
            {
                _Countries = new Countries();
                oCountries.Add(_Countries);
            }
            return _Countries;
        }

        internal static void FillFromReader(Countries oCountries, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_COUNTRIES_ID);
            if (!reader.IsDBNull(colIndex))
                oCountries.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COUNTRIES_FNAME);
            if (!reader.IsDBNull(colIndex))
                oCountries.COUNTRY_NAME = reader.GetString(colIndex);

            
        }

        #endregion
    }
}
