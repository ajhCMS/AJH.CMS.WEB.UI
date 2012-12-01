using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class CatalogImageDataMapper
    {
        #region Constants

        internal const string CN_CATALOG_IMAGE_ID = "CATALOG_IMAGE_ID";
        internal const string CN_CATALOG_ID = "CATALOG_ID";
        internal const string CN_CATALOG_IMAGE_IS_COVER_IMAGE = "CATALOG_IMAGE_IS_COVER_IMAGE";
        internal const string CN_CATALOG_IMAGE_NAME = "CATALOG_IMAGE_NAME";
        internal const string CN_CATALOG_IMAGE_IS_DELETED = "CATALOG_IMAGE_IS_DELETED";

        internal const string PN_CATALOG_IMAGE_ID = "P_CATALOG_IMAGE_ID";
        internal const string PN_CATALOG_ID = "P_CATALOG_ID";
        internal const string PN_CATALOG_IMAGE_IS_COVER_IMAGE = "P_CATALOG_IMAGE_IS_COVER_IMAGE";
        internal const string PN_CATALOG_IMAGE_NAME = "P_CATALOG_IMAGE_NAME";
        internal const string PN_CATALOG_IMAGE_IS_DELETED = "P_CATALOG_IMAGE_IS_DELETED";

        internal const string SN_CATALOG_IMAGE_ADD = "[ECOMMERCE].[CatalogImageAdd]";
        internal const string SN_CATALOG_IMAGE_UPDATE = "[ECOMMERCE].[CatalogImageUpdate]";
        internal const string SN_CATALOG_IMAGE_DELETE = "[ECOMMERCE].[CatalogImageDelete]";
        internal const string SN_CATALOG_IMAGE_DELETE_LOGICAL = "[ECOMMERCE].[CatalogImageDeleteLogical]";
        internal const string SN_CATALOG_IMAGE_GET_BY_ID = "[ECOMMERCE].[CatalogImageGetByID]";
        internal const string SN_CATALOG_IMAGE_GET_BY_CATALOG_ID = "[ECOMMERCE].[CatalogImageGetByCatalogId]";

        #endregion

        #region CatalogImageDataMapper

        internal static int Add(CatalogImage entity)
        {
            CatalogImage CatalogImageEntity = (CatalogImage)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = CatalogImageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.CatalogID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_IS_COVER_IMAGE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.IsCoverImage;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    CatalogImageEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_CATALOG_IMAGE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return CatalogImageEntity.ID;
        }

        internal static void Update(CatalogImage entity)
        {
            CatalogImage CatalogImageEntity = (CatalogImage)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_IS_COVER_IMAGE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.IsCoverImage;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CatalogImageEntity.Image;
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_ID, System.Data.SqlDbType.Int);
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

        internal static List<CatalogImage> GetCatalogImagesByCatalogID(int catalogID)
        {
            List<CatalogImage> colCatalogImages = null;
            CatalogImage CatalogImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_GET_BY_CATALOG_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CATALOG_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = catalogID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCatalogImages = new List<CatalogImage>();
                    while (sqlDataReader.Read())
                    {
                        CatalogImage = GetCatalogImage(colCatalogImages, sqlDataReader);
                        FillFromReader(CatalogImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCatalogImages;
        }

        internal static CatalogImage GetCatalogImageByID(int id)
        {
            CatalogImage CatalogImage = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CATALOG_IMAGE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CATALOG_IMAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        CatalogImage = new CatalogImage();
                        FillFromReader(CatalogImage, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return CatalogImage;
        }

        #endregion

        #region GetFromReader

        internal static CatalogImage GetCatalogImage(List<CatalogImage> CatalogImages, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATALOG_IMAGE_ID);
            int value = reader.GetInt32(colIndex);

            CatalogImage CatalogImage = CatalogImages.Where(c => c.ID == value).FirstOrDefault();
            if (CatalogImage == null)
            {
                CatalogImage = new CatalogImage();
                CatalogImages.Add(CatalogImage);
            }
            return CatalogImage;
        }

        internal static void FillFromReader(CatalogImage CatalogImage, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CATALOG_IMAGE_ID);
            if (!reader.IsDBNull(colIndex))
                CatalogImage.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_ID);
            if (!reader.IsDBNull(colIndex))
                CatalogImage.CatalogID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IMAGE_NAME);
            if (!reader.IsDBNull(colIndex))
                CatalogImage.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IMAGE_IS_COVER_IMAGE);
            if (!reader.IsDBNull(colIndex))
                CatalogImage.IsCoverImage = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CATALOG_IMAGE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                CatalogImage.IsDeleted = reader.GetBoolean(colIndex);
        }

        #endregion
    }
}