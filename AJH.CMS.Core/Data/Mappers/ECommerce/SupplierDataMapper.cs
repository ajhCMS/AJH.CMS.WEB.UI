using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class SupplierDataMapper
    {
        #region Constants

        internal const string CN_ATTRIBUTE_GROUP_ID = "ATTRIBUTE_GROUP_ID";

        internal const string CN_SUPPLIER_ID = "SUPPLIER_ID";
        internal const string CN_SUPPLIER_LOGO_IMAGE = "SUPPLIER_LOGO_IMAGE";
        internal const string CN_SUPPLIER_IS_ENABLED = "SUPPLIER_IS_ENABLED";
        internal const string CN_SUPPLIER_PARENT_OBJ_ID = "SUPPLIER_PARENT_OBJ_ID";
        internal const string CN_SUPPLIER_NAME = "SUPPLIER_NAME";
        internal const string CN_SUPPLIER_DESCRIPTION = "SUPPLIER_DESCRIPTION";
        internal const string CN_SUPPLIER_META_TITLE = "SUPPLIER_META_TITLE";
        internal const string CN_SUPPLIER_META_DESCRIPTION = "SUPPLIER_META_DESCRIPTION";
        internal const string CN_SUPPLIER_META_KEYWORDS = "SUPPLIER_META_KEYWORDS";
        internal const string CN_SUPPLIER_IS_DELETED = "SUPPLIER_IS_DELETED";
        internal const string CN_SUPPLIER_PORTAL_ID = "SUPPLIER_PORTAL_ID";

        internal const string PN_SUPPLIER_ID = "P_SUPPLIER_ID";
        internal const string PN_SUPPLIER_LOGO_IMAGE = "P_SUPPLIER_LOGO_IMAGE";
        internal const string PN_SUPPLIER_IS_ENABLED = "P_SUPPLIER_IS_ENABLED";
        internal const string PN_SUPPLIER_PARENT_OBJ_ID = "P_SUPPLIER_PARENT_OBJ_ID";
        internal const string PN_SUPPLIER_NAME = "P_SUPPLIER_NAME";
        internal const string PN_SUPPLIER_DESCRIPTION = "P_SUPPLIER_DESCRIPTION";
        internal const string PN_SUPPLIER_META_TITLE = "P_SUPPLIER_META_TITLE";
        internal const string PN_SUPPLIER_META_DESCRIPTION = "P_SUPPLIER_META_DESCRIPTION";
        internal const string PN_SUPPLIER_META_KEYWORDS = "P_SUPPLIER_META_KEYWORDS";
        internal const string PN_SUPPLIER_PORTAL_ID = "P_SUPPLIER_PORTAL_ID";


        internal const string SN_SUPPLIER_ADD = "[ECOMMERCE].[SupplierAdd]";
        internal const string SN_SUPPLIER_UPDATE = "[ECOMMERCE].[SupplierUpdate]";
        internal const string SN_SUPPLIER_DELETE = "[ECOMMERCE].[SupplierDelete]";
        internal const string SN_SUPPLIER_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[SupplierAddOtherLang]";
        internal const string SN_SUPPLIER_DELETE_LOGICAL = "[ECOMMERCE].[SupplierDeleteLogical]";
        internal const string SN_SUPPLIER_GET_BY_ID = "[ECOMMERCE].[SupplierGetByID]";
        internal const string SN_SUPPLIER_GET_ALL = "[ECOMMERCE].[SupplierGetAll]";

        #endregion

        #region SupplierDataMapper

        internal static int Add(IEntity entity)
        {
            Supplier SupplierEntity = (Supplier)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = SupplierEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_LOGO_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.LogoImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.ParentSupplierID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = SupplierEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    SupplierEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_SUPPLIER_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return SupplierEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Supplier supplierEntity = (Supplier)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_LOGO_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.LogoImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.ParentSupplierID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.LanguageID;
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
            Supplier supplierEntity = (Supplier)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_TITLE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_META_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = supplierEntity.LanguageID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
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

        internal static List<Supplier> GetSuppliers(int portalID, int languageID)
        {
            List<Supplier> colSuppliers = null;
            Supplier Supplier = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Supplier;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colSuppliers = new List<Supplier>();
                    while (sqlDataReader.Read())
                    {
                        Supplier = GetSupplier(colSuppliers, sqlDataReader);
                        FillFromReader(Supplier, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colSuppliers;
        }

        internal static Supplier GetSupplier(int id, int portalID, int languageID)
        {
            Supplier Supplier = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_SUPPLIER_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_SUPPLIER_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Supplier;
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
                        Supplier = new Entities.Supplier();
                        FillFromReader(Supplier, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Supplier;
        }

        #endregion

        #region GetFromReader

        internal static Supplier GetSupplier(List<Supplier> Suppliers, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_SUPPLIER_ID);
            int value = reader.GetInt32(colIndex);

            Supplier Supplier = Suppliers.Where(c => c.ID == value).FirstOrDefault();
            if (Supplier == null)
            {
                Supplier = new Supplier();
                Suppliers.Add(Supplier);
            }
            return Supplier;
        }

        internal static void FillFromReader(Supplier Supplier, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_SUPPLIER_ID);
            if (!reader.IsDBNull(colIndex))
                Supplier.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_SUPPLIER_LOGO_IMAGE);
            if (!reader.IsDBNull(colIndex))
                Supplier.LogoImage = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_SUPPLIER_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                Supplier.IsEnabled = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_SUPPLIER_PARENT_OBJ_ID);
            if (!reader.IsDBNull(colIndex))
                Supplier.ParentSupplierID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_SUPPLIER_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                Supplier.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_SUPPLIER_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                Supplier.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                Supplier.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                Supplier.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC);
            if (!reader.IsDBNull(colIndex))
                Supplier.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME2);
            if (!reader.IsDBNull(colIndex))
                Supplier.MetaTitle = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC2);
            if (!reader.IsDBNull(colIndex))
                Supplier.MetaDescription = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_KEYWORD);
            if (!reader.IsDBNull(colIndex))
                Supplier.MetaKeywords = reader.GetString(colIndex);
        }

        #endregion
    }
}