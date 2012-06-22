using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class ManufacturarDataMapper
    {
        #region Constants

        internal const string CN_MANUFACTURARE_ID = "MANUFACTURARE_ID";
        internal const string CN_MANUFACTURARE_LOGO_IMAGE = "MANUFACTURARE_LOGO_IMAGE";
        internal const string CN_MANUFACTURARE_IS_ENABLED = "MANUFACTURARE_IS_ENABLED";
        internal const string CN_MANUFACTURARE_PORTAL_ID = "MANUFACTURARE_PORTAL_ID";
        internal const string CN_MANUFACTURARE_IS_DELETED = "MANUFACTURARE_IS_DELETED";

        internal const string PN_MANUFACTURARE_ID = "P_MANUFACTURARE_ID";
        internal const string PN_MANUFACTURARE_LOGO_IMAGE = "P_MANUFACTURARE_LOGO_IMAGE";
        internal const string PN_MANUFACTURARE_IS_ENABLED = "P_MANUFACTURARE_IS_ENABLED";
        internal const string PN_MANUFACTURARE_PORTAL_ID = "P_MANUFACTURARE_PORTAL_ID";
        internal const string PN_MANUFACTURARE_DESCRIPTION = "P_MANUFACTURARE_DESCRIPTION";
        internal const string PN_MANUFACTURARE_SHORT_DESCRIPTION = "P_MANUFACTURARE_SHORT_DESCRIPTION";
        internal const string PN_MANUFACTURARE_META_TITLE = "P_MANUFACTURARE_META_TITLE";
        internal const string PN_MANUFACTURARE_META_DESCRIPTION = "P_MANUFACTURARE_META_DESCRIPTION";
        internal const string PN_MANUFACTURARE_META_KEYWORDS = "P_MANUFACTURARE_META_KEYWORDS";

        internal const string SN_MANUFACTURAR_ADD = "[ECOMMERCE].[ManufacturareAdd]";
        internal const string SN_MANUFACTURAR_UPDATE = "[ECOMMERCE].[ManufacturareUpdate]";
        internal const string SN_MANUFACTURAR_DELETE = "[ECOMMERCE].[ManufacturareDelete]";
        internal const string SN_MANUFACTURAR_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[ManufacturareAddOtherLang]";
        internal const string SN_MANUFACTURAR_DELETE_LOGICAL = "[ECOMMERCE].[ManufacturareDeleteLogical]";
        internal const string SN_MANUFACTURAR_GET_BY_ID = "[ECOMMERCE].[ManufacturareGetByID]";
        internal const string SN_MANUFACTURAR_GET_ALL = "[ECOMMERCE].[ManufacturareGetAll]";

        #endregion

        #region ManufacturarDataMapper

        internal static int Add(IEntity entity)
        {
            Manufacturar ManufacturarEntity = (Manufacturar)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = ManufacturarEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_LOGO_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    ManufacturarEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_MANUFACTURARE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ManufacturarEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Manufacturar ManufacturarEntity = (Manufacturar)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_LOGO_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.LanguageID;
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

        internal static void AddOtherLanguage(IEntity entity)
        {
            Manufacturar ManufacturarEntity = (Manufacturar)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ManufacturarEntity.LanguageID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Manufacturar> GetManufacturars(int portalID, int languageID)
        {
            List<Manufacturar> colManufacturars = null;
            Manufacturar Manufacturar = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Manufacturar;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colManufacturars = new List<Manufacturar>();
                    while (sqlDataReader.Read())
                    {
                        Manufacturar = GetManufacturar(colManufacturars, sqlDataReader);
                        FillFromReader(Manufacturar, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colManufacturars;
        }

        internal static Manufacturar GetManufacturar(int id, int portalID, int languageID)
        {
            Manufacturar Manufacturar = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MANUFACTURAR_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_MANUFACTURARE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Manufacturar;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MANUFACTURARE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        Manufacturar = new Entities.Manufacturar();
                        FillFromReader(Manufacturar, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Manufacturar;
        }

        #endregion

        #region GetFromReader

        internal static Manufacturar GetManufacturar(List<Manufacturar> Manufacturars, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_ID);
            int value = reader.GetInt32(colIndex);

            Manufacturar Manufacturar = Manufacturars.Where(c => c.ID == value).FirstOrDefault();
            if (Manufacturar == null)
            {
                Manufacturar = new Manufacturar();
                Manufacturars.Add(Manufacturar);
            }
            return Manufacturar;
        }

        internal static void FillFromReader(Manufacturar manufacturar, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_ID);
            if (!reader.IsDBNull(colIndex))
                manufacturar.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_LOGO_IMAGE);
            if (!reader.IsDBNull(colIndex))
                manufacturar.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                manufacturar.IsEnabled = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                manufacturar.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_MANUFACTURARE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                manufacturar.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                manufacturar.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC);
            if (!reader.IsDBNull(colIndex))
                manufacturar.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC2);
            if (!reader.IsDBNull(colIndex))
                manufacturar.ShortDescription = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME2);
            if (!reader.IsDBNull(colIndex))
                manufacturar.MetaTitle = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DETAILS);
            if (!reader.IsDBNull(colIndex))
                manufacturar.MetaDescription = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_KEYWORD);
            if (!reader.IsDBNull(colIndex))
                manufacturar.MetaKeywords = reader.GetString(colIndex);

        }

        #endregion
    }
}