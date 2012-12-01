using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class TaxDataMapper
    {
        #region Constants

        internal const string CN_TAX_ID = "TAX_ID";
        internal const string CN_TAX_RATE = "TAX_RATE";
        internal const string CN_TAX_IS_ENABLED = "TAX_IS_ENABLED";
        internal const string CN_TAX_PORTAL_ID = "TAX_PORTAL_ID";
        internal const string CN_TAX_IS_DELETED = "TAX_IS_DELETED";

        internal const string PN_TAX_ID = "P_TAX_ID";
        internal const string PN_TAX_RATE = "P_TAX_RATE";
        internal const string PN_TAX_IS_ENABLED = "P_TAX_IS_ENABLED";
        internal const string PN_TAX_PORTAL_ID = "P_TAX_PORTAL_ID";

        internal const string SN_TAX_ADD = "[ECOMMERCE].[TaxAdd]";
        internal const string SN_TAX_UPDATE = "[ECOMMERCE].[TaxUpdate]";
        internal const string SN_TAX_DELETE = "[ECOMMERCE].[TaxDelete]";
        internal const string SN_TAX_DELETE_LOGICAL = "[ECOMMERCE].[TaxDeleteLogical]";
        internal const string SN_TAX_GET_BY_ID = "[ECOMMERCE].[TaxGetByID]";
        internal const string SN_TAX_GET_ALL = "[ECOMMERCE].[TaxGetAll]";

        #endregion

        #region TaxDataMapper

        internal static int Add(Tax taxEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = taxEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = taxEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_RATE, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = taxEntity.Rate;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = taxEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    taxEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_TAX_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return taxEntity.ID;
        }

        internal static void Update(Tax entity)
        {
            Tax TaxEntity = (Tax)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TaxEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TaxEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_RATE, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TaxEntity.Rate;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = TaxEntity.IsEnabled;
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

        internal static void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
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

        internal static void DeleteLogical(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
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

        internal static List<Tax> GetTaxes(int portalID)
        {
            List<Tax> colTaxs = null;
            Tax Tax = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter = new SqlParameter(PN_TAX_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colTaxs = new List<Tax>();
                    while (sqlDataReader.Read())
                    {
                        Tax = GetTax(colTaxs, sqlDataReader);
                        FillFromReader(Tax, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colTaxs;
        }

        internal static Tax GetTax(int id, int portalID)
        {
            Tax Tax = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_TAX_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_TAX_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        Tax = new Entities.Tax();
                        FillFromReader(Tax, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Tax;
        }

        #endregion

        #region GetFromReader

        internal static Tax GetTax(List<Tax> Taxs, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_TAX_ID);
            int value = reader.GetInt32(colIndex);

            Tax Tax = Taxs.Where(c => c.ID == value).FirstOrDefault();
            if (Tax == null)
            {
                Tax = new Tax();
                Taxs.Add(Tax);
            }
            return Tax;
        }

        internal static void FillFromReader(Tax Tax, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_TAX_ID);
            if (!reader.IsDBNull(colIndex))
                Tax.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TAX_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                Tax.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_TAX_RATE);
            if (!reader.IsDBNull(colIndex))
                Tax.Rate = reader.GetDecimal(colIndex);

            colIndex = reader.GetOrdinal(CN_TAX_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                Tax.IsEnabled = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_TAX_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                Tax.IsDeleted = reader.GetBoolean(colIndex);

        }

        #endregion
    }
}