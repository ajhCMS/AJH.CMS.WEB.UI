using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class CombinationProductDataMapper
    {
        #region Constants

        internal const string CN_COMBINATION_ID = "COMBINATION_ID";
        internal const string CN_COMBINATION_PRODUCT_ID = "COMBINATION_PRODUCT_ID";
        internal const string CN_COMBINATION_PRODUCT_REFERENCE = "COMBINATION_PRODUCT_REFERENCE";
        internal const string CN_COMBINATION_PRODUCT_EAN13_ID = "COMBINATION_PRODUCT_EAN13";
        internal const string CN_COMBINATION_PRODUCT_UPC = "COMBINATION_PRODUCT_UPC";
        internal const string CN_COMBINATION_PRODUCT_SUPPLIER = "COMBINATION_PRODUCT_SUPPLIER_REFERENCE";
        internal const string CN_COMBINATION_PRODUCT_WHOLESALE_PRICE = "COMBINATION_PRODUCT_WHOLESALE_PRICE";
        internal const string CN_COMBINATION_PRODUCT_IMPACT_ON_PRICE = "COMBINATION_PRODUCT_IMPACT_ON_PRICE";
        internal const string CN_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT = "COMBINATION_PRODUCT_IMPACT_ON_WEIGHT";
        internal const string CN_COMBINATION_PRODUCT_INITIAL_STOCK = "COMBINATION_PRODUCT_INITIAL_STOCK";
        internal const string CN_COMBINATION_PRODUCT_MINIMUM_QUANTITY = "COMBINATION_PRODUCT_MINIMUM_QUANTITY";
        internal const string CN_COMBINATION_PRODUCT_IS_DEFAULT = "COMBINATION_PRODUCT_IS_DEFAULT";
        internal const string CN_COMBINATION_PRODUCT_IS_DELETED = "COMBINATION_IS_DELETED";
        internal const string CN_COMBINATION_PRODUCT_COLOR = "COMBINATION_PRODUCT_COLOR";
        internal const string CN_COMBINATION_PRODUCT_LOCATION = "COMBINATION_PRODUCT_LOCATION";


        internal const string PN_COMBINATION_ID = "P_COMBINATION_ID";
        internal const string PN_GROUP_ID = "P_GROUP_ID";
        
        internal const string PN_COMBINATION_PRODUCT_ID = "P_COMBINATION_PRODUCT_ID";
        internal const string PN_COMBINATION_PRODUCT_REFERENCE_NAME = "P_COMBINATION_PRODUCT_REFERENCE";
        internal const string PN_COMBINATION_PRODUCT_EAN13_NAME = "P_COMBINATION_PRODUCT_EAN13";
        internal const string PN_COMBINATION_PRODUCT_UPC_NAME = "P_COMBINATION_PRODUCT_UPC";
        internal const string PN_COMBINATION_PRODUCT_SUPPLIER_REFERENCE = "P_COMBINATION_PRODUCT_SUPPLIER_REFERENCE";
        internal const string PN_COMBINATION_PRODUCT_WHOLESALE_PRICE = "P_COMBINATION_PRODUCT_WHOLESALE_PRICE";
        internal const string PN_COMBINATION_PRODUCT_IMPACT_ON_PRICE = "P_COMBINATION_PRODUCT_IMPACT_ON_PRICE";
        internal const string PN_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT = "P_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT";
        internal const string PN_COMBINATION_PRODUCT_INITIAL_STOCK = "P_COMBINATION_PRODUCT_INITIAL_STOCK";
        internal const string PN_COMBINATION_PRODUCT_MINIMUM_QUANTITY = "P_COMBINATION_PRODUCT_MINIMUM_QUANTITY";
        internal const string PN_COMBINATION_PRODUCT_IS_DEFAULT = "P_COMBINATION_PRODUCT_IS_DEFAULT";
        internal const string PN_COMBINATION_PRODUCT_COLOR = "P_COMBINATION_PRODUCT_COLOR";
        internal const string PN_COMBINATION_PRODUCT_LOCATION = "P_COMBINATION_PRODUCT_LOCATION";
        internal const string PN_COMBINATION_IMAGE_ID = "P_COMBINATION_IMAGE_ID";


        internal const string SN_COMBINATION_PRODUCT_ADD = "[ECOMMERCE].[CombinationProductAdd]";
        internal const string SN_COMBINATION_PRODUCT_UPDATE = "[ECOMMERCE].[CombinationProductUpdate]";
        internal const string SN_COMBINATION_PRODUCT_DELETE = "[ECOMMERCE].[CombinationProductDelete]";
        internal const string SN_COMBINATION_PRODUCT_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[CombinationProductAddOtherLang]";
        internal const string SN_COMBINATION_PRODUCT_DELETE_LOGICAL = "[ECOMMERCE].[CombinationProductDeleteLogical]";
        internal const string SN_COMBINATION_PRODUCT_GET_BY_ID = "[ECOMMERCE].[CombinationProductGetByID]";
        internal const string SN_COMBINATION_PRODUCT_GET_ALL = "[ECOMMERCE].[CombinationProductGetAll]";
        internal const string SN_COMBINATION_PRODUCT_GET_BY_PRODUCT_ID = "[ECOMMERCE].[CombinationProductGetByProductID]";

        internal const string SN_COMBINATION_IMAGE_ADD = "[ECOMMERCE].[CombinationImageAdd]";
        internal const string SN_COMBINATION_IMAGE_DELETE = "[ECOMMERCE].[CombinationImageDelete]";

        internal const string SN_COMBINATION_ATTRIBUTE_ADD = "[ECOMMERCE].[CombinationAttributeAdd]";
        internal const string SN_COMBINATION_ATTRIBUTE_DELETE = "[ECOMMERCE].[CombinationAttributeDelete]";


        #endregion

        #region CombinationProductDataMapper

        internal static int Add(IEntity entity)
        {
            CombinationProduct combinationProductEntity = (CombinationProduct)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = combinationProductEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_REFERENCE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductReference;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_EAN13_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductEAN13;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_UPC_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductUPC;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_SUPPLIER_REFERENCE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.SupplierRefernce;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_WHOLESALE_PRICE, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.WholesalePrice;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IMPACT_ON_PRICE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ImpactOnPrice;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ImpactOnWeight;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_INITIAL_STOCK, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.InitialStock;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_MINIMUM_QUANTITY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.MinimumQuantity;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IS_DEFAULT, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.IsDefault;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_COLOR, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.Color;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_LOCATION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.Location;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    combinationProductEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_COMBINATION_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return combinationProductEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            CombinationProduct combinationProductEntity = (CombinationProduct)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_REFERENCE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductReference;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_EAN13_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductEAN13;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_UPC_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ProductUPC;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_SUPPLIER_REFERENCE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.SupplierRefernce;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_WHOLESALE_PRICE, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.WholesalePrice;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IMPACT_ON_PRICE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ImpactOnPrice;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ImpactOnWeight;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_INITIAL_STOCK, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.InitialStock;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_MINIMUM_QUANTITY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.MinimumQuantity;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_IS_DEFAULT, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.IsDefault;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_COLOR, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.Color;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_LOCATION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.Location;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.LanguageID;
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
            CombinationProduct combinationProductEntity = (CombinationProduct)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_PRODUCT_LOCATION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.Location;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationProductEntity.LanguageID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
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

        internal static List<CombinationProduct> GetCombinationProducts(int languageID)
        {
            List<CombinationProduct> colCombinationProducts = null;
            CombinationProduct CombinationProducte = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCombinationProducts = new List<CombinationProduct>();
                    while (sqlDataReader.Read())
                    {
                        CombinationProducte = GetCombinationProduct(colCombinationProducts, sqlDataReader);
                        FillFromReader(CombinationProducte, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCombinationProducts;
        }

        internal static List<CombinationProduct> GetCombinationProductsByProductId(int productID, int languageID)
        {
            List<CombinationProduct> colCombinationProducts = null;
            CombinationProduct CombinationProducte = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_GET_BY_PRODUCT_ID, sqlConnection);
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
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCombinationProducts = new List<CombinationProduct>();
                    while (sqlDataReader.Read())
                    {
                        CombinationProducte = GetCombinationProduct(colCombinationProducts, sqlDataReader);
                        FillFromReader(CombinationProducte, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCombinationProducts;
        }

        internal static CombinationProduct GetCombinationProduct(int id, int languageID)
        {
            CombinationProduct CombinationProduct = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_PRODUCT_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.CombinationProduct;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        CombinationProduct = new Entities.CombinationProduct();
                        FillFromReader(CombinationProduct, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return CombinationProduct;
        }

        internal static void AddCombinationImage(int combinationId, int imageId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_IMAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = imageId;
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

        internal static void DeleteCombinationImage(int combinationId, int imageId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_IMAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_COMBINATION_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = imageId;
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

        internal static void AddCombinationAttribute(int combinationId, int attributeId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_ATTRIBUTE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(AttributeDataMapper.PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeId;
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

        internal static void DeleteCombinationAttribute(int combinationId, int attributeId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_COMBINATION_ATTRIBUTE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationId;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(AttributeDataMapper.PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeId;
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

        internal static CombinationProduct GetCombinationProduct(List<CombinationProduct> CombinationProducts, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_COMBINATION_ID);
            int value = reader.GetInt32(colIndex);

            CombinationProduct CombinationProduct = CombinationProducts.Where(c => c.ID == value).FirstOrDefault();
            if (CombinationProduct == null)
            {
                CombinationProduct = new CombinationProduct();
                CombinationProducts.Add(CombinationProduct);
            }
            return CombinationProduct;
        }

        internal static void FillFromReader(CombinationProduct combinationProduct, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_COMBINATION_ID);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ProductID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_REFERENCE);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ProductReference = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_EAN13_ID);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ProductEAN13 = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_UPC);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ProductUPC = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_SUPPLIER);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.SupplierRefernce = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_WHOLESALE_PRICE);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.WholesalePrice = reader.GetDecimal(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_IMPACT_ON_PRICE);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ImpactOnPrice = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_IMPACT_ON_WEIGHT);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.ImpactOnWeight = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_INITIAL_STOCK);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.InitialStock = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_MINIMUM_QUANTITY);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.MinimumQuantity = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_IS_DEFAULT);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.IsDefault = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_COLOR);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.Color = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_COMBINATION_PRODUCT_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.IsDefault = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.Location = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.Location = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                combinationProduct.LanguageID = reader.GetInt32(colIndex);
        }

        #endregion
    }
}