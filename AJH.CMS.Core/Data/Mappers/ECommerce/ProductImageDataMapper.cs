using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class ProductImageDataMapper
    {
        #region Constants


        internal const string CN_PROD_IMAGE_ID = "PROD_IMAGE_ID";
        internal const string CN_PROD_PRODUCT_ID = "PROD_PRODUCT_ID";
        internal const string CN_PROD_IMAGE_IS_COVER_IMAGE = "PROD_IMAGE_IS_COVER_IMAGE";
        internal const string CN_PROD_IMAGE_CAPTION = "PROD_IMAGE_CAPTION";
        internal const string CN_PROD_IMAGE_NAME = "PROD_IMAGE_NAME";
        internal const string CN_PROD_IMAGE_IS_DELETED = "PROD_IMAGE_IS_DELETED";

        internal const string PN_PROD_IMAGE_ID = "P_PROD_IMAGE_ID";
        internal const string PN_PROD_PRODUCT_ID = "P_PROD_PRODUCT_ID";
        internal const string PN_PROD_IMAGE_IS_COVER_IMAGE = "P_PROD_IMAGE_IS_COVER_IMAGE";
        internal const string PN_PROD_IMAGE_CAPTION = "P_PROD_IMAGE_CAPTION";
        internal const string PN_PROD_IMAGE_NAME = "P_PROD_IMAGE_NAME";

        internal const string SN_PRODUCT_IMAGE_ADD = "[ECOMMERCE].[ProductImageAdd]";
        internal const string SN_PRODUCT_IMAGE_UPDATE = "[ECOMMERCE].[ProductImageUpdate]";
        internal const string SN_PRODUCT_IMAGE_DELETE = "[ECOMMERCE].[ProductImageDelete]";
        internal const string SN_PRODUCT_IMAGE_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[ProductImageAddOtherLang]";
        internal const string SN_PRODUCT_IMAGE_DELETE_LOGICAL = "[ECOMMERCE].[ProductImageDeleteLogical]";
        internal const string SN_PRODUCT_IMAGE_GET_BY_ID = "[ECOMMERCE].[ProductImageGetByID]";
        internal const string SN_PRODUCT_IMAGE_GET_ALL = "[ECOMMERCE].[ProductImageGetAll]";
        internal const string SN_PRODUCT_IMAGE_GET_BY_PRODUCT_ID = "[ECOMMERCE].[ProductImageGetByProductId]";
        internal const string SN_PRODUCT_IMAGE_GET_BY_COMBINATION_ID = "[ECOMMERCE].[ProductImageGetByCombinationId]";

        #endregion

        #region ProductImageDataMapper

        internal static int Add(ProductImage entity)
        {
            ProductImage ProductImageEntity = (ProductImage)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = ProductImageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_IS_COVER_IMAGE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.IsCoverImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_CAPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ImageCaption;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    ProductImageEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PROD_IMAGE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ProductImageEntity.ID;
        }

        internal static void AddOtherLanguage(ProductImage entity)
        {
            ProductImage ProductImageEntity = (ProductImage)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_CAPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ImageCaption;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.LanguageID;
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




        internal static void Update(ProductImage entity)
        {
            ProductImage ProductImageEntity = (ProductImage)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_IS_COVER_IMAGE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.IsCoverImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_CAPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.ImageCaption;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductImageEntity.LanguageID;
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

        internal static void Delete(int id, int languageID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
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

        internal static List<ProductImage> GetProductImages(int languageID)
        {
            List<ProductImage> colProductImages = null;
            ProductImage ProductImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colProductImages = new List<ProductImage>();
                    while (sqlDataReader.Read())
                    {
                        ProductImage = GetProductImage(colProductImages, sqlDataReader);
                        FillFromReader(ProductImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colProductImages;
        }

        internal static ProductImage GetProductImage(int id, int languageID)
        {
            ProductImage productImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PROD_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
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
                        productImage = new ProductImage();
                        FillFromReader(productImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return productImage;
        }

        internal static List<ProductImage> GetProductImagesByProductID(int productID, int languageID)
        {
            List<ProductImage> colProductImages = null;
            ProductImage ProductImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_GET_BY_PRODUCT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PROD_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colProductImages = new List<ProductImage>();
                    while (sqlDataReader.Read())
                    {
                        ProductImage = GetProductImage(colProductImages, sqlDataReader);
                        FillFromReader(ProductImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colProductImages;
        }

        internal static List<ProductImage> GetProductImagesByCombinationID(int combinationID, int languageID)
        {
            List<ProductImage> colProductImages = null;
            ProductImage ProductImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_IMAGE_GET_BY_COMBINATION_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(CombinationProductDataMapper.PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.ProductImage;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colProductImages = new List<ProductImage>();
                    while (sqlDataReader.Read())
                    {
                        ProductImage = GetProductImage(colProductImages, sqlDataReader);
                        FillFromReader(ProductImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colProductImages;
        }

        #endregion

        #region GetFromReader

        internal static ProductImage GetProductImage(List<ProductImage> ProductImages, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PROD_IMAGE_ID);
            int value = reader.GetInt32(colIndex);

            ProductImage ProductImage = ProductImages.Where(c => c.ID == value).FirstOrDefault();
            if (ProductImage == null)
            {
                ProductImage = new ProductImage();
                ProductImages.Add(ProductImage);
            }
            return ProductImage;
        }

        internal static void FillFromReader(ProductImage ProductImage, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PROD_IMAGE_ID);
            if (!reader.IsDBNull(colIndex))
                ProductImage.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PROD_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                ProductImage.ProductID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PROD_IMAGE_NAME);
            if (!reader.IsDBNull(colIndex))
                ProductImage.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PROD_IMAGE_IS_COVER_IMAGE);
            if (!reader.IsDBNull(colIndex))
                ProductImage.IsCoverImage = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                ProductImage.ImageCaption = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_PROD_IMAGE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                ProductImage.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                ProductImage.LanguageID = reader.GetInt32(colIndex);
        }

        #endregion
    }
}