using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class ProductPriceDataMapper
    {
        #region Constants


        internal const string CN_PRODUCT_PRICE_ID = "PRODUCT_PRICE_ID";
        internal const string CN_PRODUCT_PRICE_CURRENCY_ID = "PRODUCT_PRICE_CURRENCY_ID";
        internal const string CN_PRODUCT_PRICE_COUNTRY_ID = "PRODUCT_PRICE_COUNTRY_ID";
        internal const string CN_PRODUCT_PRICE_FROM_DAY = "PRODUCT_PRICE_FROM_DAY";
        internal const string CN_PRODUCT_PRICE_FROM_SEC = "PRODUCT_PRICE_FROM_SEC";
        internal const string CN_PRODUCT_PRICE_TO_DAY = "PRODUCT_PRICE_TO_DAY";
        internal const string CN_PRODUCT_PRICE_TO_SEC = "PRODUCT_PRICE_TO_SEC";
        internal const string CN_PRODUCT_PRICE_START_AT = "PRODUCT_PRICE_START_AT";
        internal const string CN_PRODUCT_PRICE_VALUE = "PRODUCT_PRICE_VALUE";
        internal const string CN_PRODUCT_PRICE_DISCOUNT_VALUE = "P_PRODUCT_PRICE_DISCOUNT_VALUE";
        internal const string CN_PRODUCT_PRICE_DISCOUNT_TYPE = "P_PRODUCT_PRICE_DISCOUNT_TYPE";
        internal const string CN_PRODUCT_PRICE_PRODUCT_ID = "PRODUCT_PRICE_PRODUCT_ID";
        internal const string CN_PRODUCT_PRICE_IS_DELETED = "PRODUCT_PRICE_IS_DELETED";



        internal const string PN_PRODUCT_PRICE_ID = "P_PRODUCT_PRICE_ID";
        internal const string PN_PRODUCT_PRICE_CURRENCY_ID = "P_PRODUCT_PRICE_CURRENCY_ID";
        internal const string PN_PRODUCT_PRICE_COUNTRY_ID = "P_PRODUCT_PRICE_COUNTRY_ID";
        internal const string PN_PRODUCT_PRICE_FROM_DAY = "P_PRODUCT_PRICE_FROM_DAY";
        internal const string PN_PRODUCT_PRICE_FROM_SEC = "P_PRODUCT_PRICE_FROM_SEC";
        internal const string PN_PRODUCT_PRICE_TO_DAY = "P_PRODUCT_PRICE_TO_DAY";
        internal const string PN_PRODUCT_PRICE_TO_SEC = "P_PRODUCT_PRICE_TO_SEC";
        internal const string PN_PRODUCT_PRICE_START_AT = "P_PRODUCT_PRICE_START_AT";
        internal const string PN_PRODUCT_PRICE_VALUE = "P_PRODUCT_PRICE_VALUE";
        internal const string PN_PRODUCT_PRICE_DISCOUNT_VALUE = "P_PRODUCT_PRICE_DISCOUNT_VALUE";
        internal const string PN_PRODUCT_PRICE_DISCOUNT_TYPE = "P_PRODUCT_PRICE_DISCOUNT_TYPE";
        internal const string PN_PRODUCT_PRICE_PRODUCT_ID = "P_PRODUCT_PRICE_PRODUCT_ID";

        internal const string SN_PRODUCT_PRICE_ADD = "[ECOMMERCE].[ProductPriceAdd]";
        internal const string SN_PRODUCT_PRICE_UPDATE = "[ECOMMERCE].[ProductPriceUpdate]";
        internal const string SN_PRODUCT_PRICE_DELETE = "[ECOMMERCE].[ProductPriceDelete]";
        internal const string SN_PRODUCT_PRICE_DELETE_LOGICAL = "[ECOMMERCE].[ProductPriceDeleteLogical]";
        internal const string SN_PRODUCT_PRICE_GET_BY_ID = "[ECOMMERCE].[ProductPriceGetByID]";
        internal const string SN_PRODUCT_PRICE_GET_ALL = "[ECOMMERCE].[ProductPriceGetAll]";

        #endregion

        #region ProductPriceDataMapper

        internal static int Add(ProductPrice productPriceEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_PRICE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = productPriceEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_CURRENCY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.CurrencyID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_COUNTRY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.CountryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_FROM_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.FromDay;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_FROM_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.FromSecond;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_TO_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.ToDay;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_TO_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.ToSecond;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_START_AT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.StartAt;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_VALUE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.Value;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_DISCOUNT_VALUE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.DiscountValue;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_DISCOUNT_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.DiscountType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productPriceEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    productPriceEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PRODUCT_PRICE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return productPriceEntity.ID;
        }

        internal static void Update(ProductPrice entity)
        {
            ProductPrice ProductPriceEntity = (ProductPrice)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_PRICE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = ProductPriceEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_CURRENCY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.CurrencyID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_COUNTRY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.CountryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_FROM_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.FromDay;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_FROM_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.FromSecond;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_TO_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.ToDay;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_TO_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.ToSecond;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_START_AT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.StartAt;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_VALUE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.Value;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_DISCOUNT_VALUE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.DiscountValue;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_DISCOUNT_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.DiscountType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductPriceEntity.ProductID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_PRICE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_ID, System.Data.SqlDbType.Int);
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

        internal static List<ProductPrice> GetProductPrices(int moduleID, int languageID)
        {
            List<ProductPrice> colProductPrices = null;
            ProductPrice ProductPrice = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_PRICE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = moduleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colProductPrices = new List<ProductPrice>();
                    while (sqlDataReader.Read())
                    {
                        ProductPrice = GetProductPrice(colProductPrices, sqlDataReader);
                        FillFromReader(ProductPrice, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colProductPrices;
        }

        internal static ProductPrice GetProductPrice(int id)
        {
            ProductPrice ProductPrice = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_PRICE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PRODUCT_PRICE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        FillFromReader(ProductPrice, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return ProductPrice;
        }

        #endregion

        #region GetFromReader

        internal static ProductPrice GetProductPrice(List<ProductPrice> ProductPrices, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_ID);
            int value = reader.GetInt32(colIndex);

            ProductPrice ProductPrice = ProductPrices.Where(c => c.ID == value).FirstOrDefault();
            if (ProductPrice == null)
            {
                ProductPrice = new ProductPrice();
                ProductPrices.Add(ProductPrice);
            }
            return ProductPrice;
        }

        internal static void FillFromReader(ProductPrice ProductPrice, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_ID);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_CURRENCY_ID);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.CurrencyID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_COUNTRY_ID);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.CountryID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_FROM_DAY);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.FromDay = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_FROM_SEC);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.FromSecond = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_TO_DAY);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.ToDay = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_TO_SEC);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.ToSecond = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_START_AT);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.StartAt = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_VALUE);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.Value = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_DISCOUNT_VALUE);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.DiscountValue = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_DISCOUNT_TYPE);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.DiscountType = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.DiscountType = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.DiscountType = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PRODUCT_PRICE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                ProductPrice.IsDeleted = reader.GetBoolean(colIndex);

        }

        #endregion
    }
}