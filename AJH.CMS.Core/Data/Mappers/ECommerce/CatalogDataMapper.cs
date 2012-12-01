using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class CatalogDataMapper
    {
        #region Constants

        internal const string CN_CATALOG_ID = "CATALOG_ID";
        internal const string CN_CATALOG_IS_DISPLAYED = "CATALOG_IS_DISPLAYED";
        internal const string CN_CATALOG_IS_GALLERY_ONLY = "CATALOG_IS_GALLERY_ONLY";
        internal const string CN_CATALOG_IMAGE = "CATALOG_IMAGE";
        internal const string CN_CATALOG_PARENT_CATALOG_ID = "CATALOG_PARENT_CATALOG_ID";
        internal const string CN_CATALOG_IS_DELETED = "CATALOG_IS_DELETED";
        internal const string CN_CATALOG_PORTAL_ID = "CATALOG_PORTAL_ID";
        internal const string CN_PRODUCT_ORDER = "PRODUCT_ORDER";
        internal const string CN_CATALOG_ORDER = "CATALOG_ORDER";
        internal const string CN_CATALOG_IS_PUBLISHED = "CATALOG_IS_PUBLISHED";


        internal const string PN_CATALOG_ID = "P_CATALOG_ID";
        internal const string PN_CATALOG_PORTAL_ID = "P_CATALOG_PORTAL_ID";
        internal const string PN_CATALOG_IS_DISPLAYED = "P_CATALOG_IS_DISPLAYED";
        internal const string PN_CATALOG_IS_GALLERY_ONLY = "P_CATALOG_IS_GALLERY_ONLY";
        internal const string PN_CATALOG_IMAGE = "P_CATALOG_IMAGE";
        internal const string PN_CATALOG_PARENT_CATALOG_ID = "P_CATALOG_PARENT_CATALOG_ID";
        internal const string PN_CATALOG_LANGUAGE_ID = "P_CATALOG_LANGUAGE_ID";
        internal const string PN_PRODUCT_ORDER = "P_PRODUCT_ORDER";
        internal const string PN_CATALOG_ORDER = "P_CATALOG_ORDER";
        internal const string PN_CATALOG_IS_PUBLISHED = "P_CATALOG_IS_PUBLISHED";


        internal const string SN_CATALOG_ADD = "[ECOMMERCE].[CatalogAdd]";
        internal const string SN_CATALOG_UPDATE = "[ECOMMERCE].[CatalogUpdate]";
        internal const string SN_CATALOG_DELETE = "[ECOMMERCE].[CatalogDelete]";
        internal const string SN_CATALOG_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[CatalogAddOtherLang]";
        internal const string SN_CATALOG_DELETE_LOGICAL = "[ECOMMERCE].[CatalogDeleteLogical]";
        internal const string SN_CATALOG_GET_BY_ID = "[ECOMMERCE].[CatalogGetByID]";
        internal const string SN_CATALOG_GET_ALL = "[ECOMMERCE].[CatalogGetAll]";
        internal const string SN_CATALOG_GET_BY_PRODUCT_ID = "[ECOMMERCE].[CatalogGetByProductID]";
        internal const string SN_PRODUCT_CATALOG_ADD = "[ECOMMERCE].[ProductCatalogAdd]";
        internal const string SN_PRODUCT_CATALOG_DELETE = "[ECOMMERCE].[ProductCatalogDelete]";
        internal const string SN_PRODUCT_CATALOG_DELETE_BY_PRODUCT_ID = "[ECOMMERCE].[ProductCatalogDeleteByProductID]";

        #endregion

        #region CatalogDataMapper

        internal static int Add(IEntity entity)
        {
            Catalog CatalogEntity = (Catalog)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = CatalogEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_DISPLAYED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsDisplayed;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_GALLERY_ONLY, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsGalleryOnly;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PARENT_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ParentCalalogID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_KEYWORD, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_PUBLISHED, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsPublished;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    CatalogEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_CATALOG_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return CatalogEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Catalog CatalogEntity = (Catalog)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_DISPLAYED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsDisplayed;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_GALLERY_ONLY, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsGalleryOnly;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PARENT_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ParentCalalogID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_KEYWORD, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaKeywords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IS_PUBLISHED, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.IsPublished;
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
            Catalog CatalogEntity = (Catalog)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_NAME2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaTitle;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_DESC2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_KEYWORD, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogEntity.MetaKeywords;
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
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

        internal static void AddProductCatalog(int prodcutId, int catalogId, int productOrder)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_CATALOG_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(ProductDataMapper.PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = prodcutId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = catalogId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productOrder;
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

        internal static void DeleteProductCatalog(int prodcutId, int catalogId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_CATALOG_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(ProductDataMapper.PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = prodcutId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = catalogId;
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

        internal static void DeleteProductCatalogByProductID(int prodcutId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_CATALOG_DELETE_BY_PRODUCT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(ProductDataMapper.PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = prodcutId;
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

        internal static List<Catalog> GetCatalogs(int portalID, int languageID)
        {
            List<Catalog> colCatalogs = null;
            Catalog Cataloge = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Catalog;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCatalogs = new List<Catalog>();
                    while (sqlDataReader.Read())
                    {
                        Cataloge = GetCatalog(colCatalogs, sqlDataReader);
                        FillFromReader(Cataloge, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCatalogs;
        }

        internal static Catalog GetCatalog(int id, int languageID)
        {
            Catalog Catalog = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Catalog;
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
                        if (Catalog == null)
                            Catalog = new Catalog();

                        FillFromReader(Catalog, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return Catalog;
        }

        internal static List<Catalog> GetCatalogsByProductID(int productID, int portalID, int languageID)
        {
            List<Catalog> colCatalogs = null;
            Catalog cataloge = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_GET_BY_PRODUCT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(ProductDataMapper.PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Catalog;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCatalogs = new List<Catalog>();
                    while (sqlDataReader.Read())
                    {
                        cataloge = GetCatalog(colCatalogs, sqlDataReader);
                        FillFromReaderByProduct(cataloge, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCatalogs;
        }

        #endregion

        #region GetFromReader

        internal static Catalog GetCatalog(List<Catalog> Catalogs, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATALOG_ID);
            int value = reader.GetInt32(colIndex);

            Catalog catalog = Catalogs.Where(c => c.ID == value).FirstOrDefault();
            if (catalog == null)
            {
                catalog = new Catalog();
                Catalogs.Add(catalog);
            }
            return catalog;
        }

        internal static void FillFromReader(Catalog catalog, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATALOG_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IS_DISPLAYED);
            if (!reader.IsDBNull(colIndex))
                catalog.IsDisplayed = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IS_GALLERY_ONLY);
            if (!reader.IsDBNull(colIndex))
                catalog.IsGalleryOnly = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_PARENT_CATALOG_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.ParentCalalogID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                catalog.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC);
            if (!reader.IsDBNull(colIndex))
                catalog.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME2);
            if (!reader.IsDBNull(colIndex))
                catalog.MetaTitle = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC2);
            if (!reader.IsDBNull(colIndex))
                catalog.MetaDescription = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_KEYWORD);
            if (!reader.IsDBNull(colIndex))
                catalog.MetaKeywords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                catalog.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_ORDER);
            if (!reader.IsDBNull(colIndex))
                catalog.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IS_PUBLISHED);
            if (!reader.IsDBNull(colIndex))
                catalog.IsPublished = reader.GetBoolean(colIndex);

        }

        internal static void FillFromReaderByProduct(Catalog catalog, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATALOG_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                catalog.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_PARENT_CATALOG_ID);
            if (!reader.IsDBNull(colIndex))
                catalog.ParentCalalogID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IS_PUBLISHED);
            if (!reader.IsDBNull(colIndex))
                catalog.IsPublished = reader.GetBoolean(colIndex);
        }

        #endregion
    }
}