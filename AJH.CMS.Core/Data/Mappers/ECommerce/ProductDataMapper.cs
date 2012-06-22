using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class ProductDataMapper
    {
        #region Constants

        internal const string CN_PRODUCT_ID = "PRODUCT_ID";
        internal const string CN_PRODUCT_SUPPLIER_ID = "PRODUCT_SUPPLIER_ID";
        internal const string CN_PRODUCT_EAN13_OR_JAN = "PRODUCT_EAN13_OR_JAN";
        internal const string CN_PRODUCT_UPC = "PRODUCT_UPC";
        internal const string CN_PRODUCT_LOCATION = "PRODUCT_LOCATION";
        internal const string CN_PRODUCT_IS_DOWNLODABLE = "PRODUCT_IS_DOWNLODABLE";
        internal const string CN_PRODUCT_DISPLAY_ON_SALE_ICON = "PRODUCT_DISPLAY_ON_SALE_ICON";
        internal const string CN_PRODUCT_INITIAL_STOCK = "PRODUCT_INITIAL_STOCK";
        internal const string CN_PRODUCT_MINIMUM_QUANTITY = "PRODUCT_MINIMUM_QUANTITY";
        internal const string CN_PRODUCT_ADDITIONAL_SHIPPING_COST = "PRODUCT_ADDITIONAL_SHIPPING_COST";
        internal const string CN_PRODUCT_MANUFACTURER_ID = "PRODUCT_MANUFACTURER_ID";
        internal const string CN_PRODUCT_IS_ENABLED = "PRODUCT_IS_ENABLED";
        internal const string CN_PRODUCT_IS_DELETED = "PRODUCT_IS_DELETED";
        internal const string CN_PRODUCT_PORTAL_ID = "PRODUCT_PORTAL_ID";
        internal const string CN_PRODUCT_TAX_ID = "PRODUCT_TAX_ID";
        internal const string CN_PRODUCT_NAME = "PRODUCT_NAME";
        internal const string CN_PRODUCT_DISPLAY_TEXT_IN_STOCK = "PRODUCT_DISPLAY_TEXT_IN_STOCK";
        internal const string CN_PRODUCT_DISPLAY_TEXT_BACK_ORDER = "PRODUCT_DISPLAY_TEXT_BACK_ORDER";
        internal const string CN_PRODUCT_DESCRIPTION = "PRODUCT_DESCRIPTION";
        internal const string CN_PRODUCT_SHORT_DESCRIPTION = "PRODUCT_SHORT_DESCRIPTION";
        internal const string CN_PRODUCT_SIZE_CHART = "PRODUCT_SIZE_CHART";
        internal const string CN_PRODUCT_TAGS = "PRODUCT_TAGS";


        internal const string PN_PRODUCT_ID = "P_PRODUCT_ID";
        internal const string PN_PRODUCT_SUPPLIER_ID = "P_PRODUCT_SUPPLIER_ID";
        internal const string PN_PRODUCT_EAN13_OR_JAN = "P_PRODUCT_EAN13_OR_JAN";
        internal const string PN_PRODUCT_UPC = "P_PRODUCT_UPC";
        internal const string PN_PRODUCT_LOCATION = "P_PRODUCT_LOCATION";
        internal const string PN_PRODUCT_IS_DOWNLODABLE = "P_PRODUCT_IS_DOWNLODABLE";
        internal const string PN_PRODUCT_DISPLAY_ON_SALE_ICON = "P_PRODUCT_DISPLAY_ON_SALE_ICON";
        internal const string PN_PRODUCT_INITIAL_STOC = "P_PRODUCT_INITIAL_STOCK";
        internal const string PN_PRODUCT_MINIMUM_QUANTITY = "P_PRODUCT_MINIMUM_QUANTITY";
        internal const string PN_PRODUCT_ADDITIONAL_SHIPPING_COST = "P_PRODUCT_ADDITIONAL_SHIPPING_COST";
        internal const string PN_PRODUCT_MANUFACTURER_ID = "P_PRODUCT_MANUFACTURER_ID";
        internal const string PN_PRODUCT_IS_ENABLED = "P_PRODUCT_IS_ENABLED";
        internal const string PN_PRODUCT_PORTAL_ID = "P_PRODUCT_PORTAL_ID";
        internal const string PN_PRODUCT_TAX_ID = "P_PRODUCT_TAX_ID";

        internal const string PN_PRODUCT_NAME = "P_PRODUCT_NAME";
        internal const string PN_PRODUCT_DISPLAY_TEXT_IN_STOCK = "P_PRODUCT_DISPLAY_TEXT_IN_STOCK";
        internal const string PN_PRODUCT_DISPLAY_TEXT_BACK_ORDER = "P_PRODUCT_DISPLAY_TEXT_BACK_ORDER";
        internal const string PN_PRODUCT_DESCRIPTION = "P_PRODUCT_DESCRIPTION";
        internal const string PN_PRODUCT_SHORT_DESCRIPTION = "P_PRODUCT_SHORT_DESCRIPTION";
        internal const string PN_PRODUCT_SIZE_CHART = "P_PRODUCT_SIZE_CHART";
        internal const string PN_PRODUCT_TAGS = "P_PRODUCT_TAGS";


        internal const string SN_PRODUCT_ADD = "[ECOMMERCE].[ProductAdd]";
        internal const string SN_PRODUCT_UPDATE = "[ECOMMERCE].[ProductUpdate]";
        internal const string SN_PRODUCT_DELETE = "[ECOMMERCE].[ProductDelete]";
        internal const string SN_PRODUCT_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[ProductAddOtherLang]";
        internal const string SN_PRODUCT_DELETE_LOGICAL = "[ECOMMERCE].[ProductDeleteLogical]";
        internal const string SN_PRODUCT_GET_BY_ID = "[ECOMMERCE].[ProductGetByID]";
        internal const string SN_PRODUCT_GET_ALL = "[ECOMMERCE].[ProductGetAll]";


        #endregion

        #region ProductDataMapper

        internal static int Add(IEntity entity)
        {
            Product productEntity = (Product)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = productEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.SupplierID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_EAN13_OR_JAN, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Ean13OrJan;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_UPC, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.UPC;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_LOCATION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Location;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_IS_DOWNLODABLE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.IsDownloadable;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_ON_SALE_ICON, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayOnSaleIcon;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_INITIAL_STOC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.InitialStock;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_MINIMUM_QUANTITY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.MinimumQuantity;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_ADDITIONAL_SHIPPING_COST, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.AdditionalShippingCost;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_MANUFACTURER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ManufacturarID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.TaxID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Product;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_IN_STOCK, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInStockText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_BACK_ORDER, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInBackOrderText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SIZE_CHART, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.SizeChart;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_TAGS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Tags;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    productEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PRODUCT_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return productEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Product productEntity = (Product)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SUPPLIER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.SupplierID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_EAN13_OR_JAN, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Ean13OrJan;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_UPC, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.UPC;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_LOCATION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Location;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_IS_DOWNLODABLE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.IsDownloadable;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_ON_SALE_ICON, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayOnSaleIcon;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_INITIAL_STOC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.InitialStock;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_MINIMUM_QUANTITY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.MinimumQuantity;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_ADDITIONAL_SHIPPING_COST, System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.AdditionalShippingCost;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_MANUFACTURER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ManufacturarID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_IS_ENABLED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.IsEnabled;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_TAX_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.TaxID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Product; ;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_IN_STOCK, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInStockText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_BACK_ORDER, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInBackOrderText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SIZE_CHART, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.SizeChart;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_TAGS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Tags;
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
            Product productEntity = (Product)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Product;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_IN_STOCK, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInStockText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DISPLAY_TEXT_BACK_ORDER, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.DisplayTextInBackOrderText;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SHORT_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.ShortDescription;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_SIZE_CHART, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.SizeChart;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_TAGS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productEntity.Tags;
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
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
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

        internal static List<Product> GetProducts(int portalID, int languageID)
        {
            List<Product> colProducts = null;
            Product Product = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Product;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colProducts = new List<Product>();
                    while (sqlDataReader.Read())
                    {
                        Product = GetProduct(colProducts, sqlDataReader);
                        FillFromReader(Product, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colProducts;
        }

        internal static Product GetProduct(int id, int portalID, int languageID)
        {
            Product product = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Product;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PORTAL_ID, System.Data.SqlDbType.Int);
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
                        product = new Product();
                        FillFromReader(product, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return product;
        }

        #endregion

        #region GetFromReader

        internal static Product GetProduct(List<Product> Products, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_ID);
            int value = reader.GetInt32(colIndex);

            Product Product = Products.Where(c => c.ID == value).FirstOrDefault();
            if (Product == null)
            {
                Product = new Product();
                Products.Add(Product);
            }
            return Product;
        }

        internal static void FillFromReader(Product Product, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                Product.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_SUPPLIER_ID);
            if (!reader.IsDBNull(colIndex))
                Product.SupplierID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_EAN13_OR_JAN);
            if (!reader.IsDBNull(colIndex))
                Product.Ean13OrJan = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_UPC);
            if (!reader.IsDBNull(colIndex))
                Product.UPC = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_LOCATION);
            if (!reader.IsDBNull(colIndex))
                Product.Location = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_IS_DOWNLODABLE);
            if (!reader.IsDBNull(colIndex))
                Product.IsDownloadable = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_DISPLAY_ON_SALE_ICON);
            if (!reader.IsDBNull(colIndex))
                Product.DisplayOnSaleIcon = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_INITIAL_STOCK);
            if (!reader.IsDBNull(colIndex))
                Product.InitialStock = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_MINIMUM_QUANTITY);
            if (!reader.IsDBNull(colIndex))
                Product.MinimumQuantity = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_ADDITIONAL_SHIPPING_COST);
            if (!reader.IsDBNull(colIndex))
                Product.AdditionalShippingCost = reader.GetDecimal(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_MANUFACTURER_ID);
            if (!reader.IsDBNull(colIndex))
                Product.ManufacturarID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                Product.IsEnabled = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                Product.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_TAX_ID);
            if (!reader.IsDBNull(colIndex))
                Product.TaxID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                Product.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_MESSAGE1);
            if (!reader.IsDBNull(colIndex))
                Product.DisplayTextInStockText = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_MESSAGE2);
            if (!reader.IsDBNull(colIndex))
                Product.DisplayTextInBackOrderText = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC);
            if (!reader.IsDBNull(colIndex))
                Product.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DESC2);
            if (!reader.IsDBNull(colIndex))
                Product.ShortDescription = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_DETAILS);
            if (!reader.IsDBNull(colIndex))
                Product.SizeChart = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_KEYWORD);
            if (!reader.IsDBNull(colIndex))
                Product.Tags = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                Product.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_IS_ENABLED);
            if (!reader.IsDBNull(colIndex))
                Product.IsDeleted = reader.GetBoolean(colIndex);

        }

        #endregion
    }
}