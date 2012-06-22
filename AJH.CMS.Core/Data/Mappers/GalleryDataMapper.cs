using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class GalleryDataMapper
    {
        #region Constant

        internal const string CN_GALLERY_ID = "GALLERY_ID";
        internal const string CN_GALLERY_NAME = "GALLERY_NAME";
        internal const string CN_GALLERY_DESCRIPTION = "GALLERY_DESCRIPTION";
        internal const string CN_GALLERY_SUMMARY = "GALLERY_SUMMARY";
        internal const string CN_GALLERY_KEYWORDS = "GALLERY_KEYWORDS";
        internal const string CN_GALLERY_SEO_NAME = "GALLERY_SEO_NAME";
        internal const string CN_GALLERY_DETAILS = "GALLERY_DETAILS";
        internal const string CN_GALLERY_URL = "GALLERY_URL";
        internal const string CN_GALLERY_FILE = "GALLERY_FILE";
        internal const string CN_GALLERY_CATEGORY_ID = "GALLERY_CATEGORY_ID";
        internal const string CN_GALLERY_CREATION_DAY = "GALLERY_CREATION_DAY";
        internal const string CN_GALLERY_CREATION_SEC = "GALLERY_CREATION_SEC";
        internal const string CN_GALLERY_IS_DELETED = "GALLERY_IS_DELETED";
        internal const string CN_GALLERY_PORTAL_ID = "GALLERY_PORTAL_ID";
        internal const string CN_GALLERY_LANGUAGE_ID = "GALLERY_LANGUAGE_ID";
        internal const string CN_GALLERY_TYPE = "GALLERY_TYPE";
        internal const string CN_GALLERY_ITEM_TYPE = "GALLERY_ITEM_TYPE";
        internal const string CN_GALLERY_ORDER = "GALLERY_ORDER";
        internal const string CN_GALLERY_CREATED_BY = "GALLERY_CREATED_BY";
        internal const string CN_GALLERY_PARENT_OBJ_ID = "GALLERY_PARENT_OBJ_ID";

        internal const string PN_GALLERY_ID = "P_GALLERY_ID";
        internal const string PN_GALLERY_NAME = "P_GALLERY_NAME";
        internal const string PN_GALLERY_DESCRIPTION = "P_GALLERY_DESCRIPTION";
        internal const string PN_GALLERY_SUMMARY = "P_GALLERY_SUMMARY";
        internal const string PN_GALLERY_KEYWORDS = "P_GALLERY_KEYWORDS";
        internal const string PN_GALLERY_SEO_NAME = "P_GALLERY_SEO_NAME";
        internal const string PN_GALLERY_DETAILS = "P_GALLERY_DETAILS";
        internal const string PN_GALLERY_URL = "P_GALLERY_URL";
        internal const string PN_GALLERY_FILE = "P_GALLERY_FILE";
        internal const string PN_GALLERY_CATEGORY_ID = "P_GALLERY_CATEGORY_ID";
        internal const string PN_GALLERY_CREATION_DAY = "P_GALLERY_CREATION_DAY";
        internal const string PN_GALLERY_CREATION_SEC = "P_GALLERY_CREATION_SEC";
        internal const string PN_GALLERY_IS_DELETED = "P_GALLERY_IS_DELETED";
        internal const string PN_GALLERY_PORTAL_ID = "P_GALLERY_PORTAL_ID";
        internal const string PN_GALLERY_LANGUAGE_ID = "P_GALLERY_LANGUAGE_ID";
        internal const string PN_GALLERY_TYPE = "P_GALLERY_TYPE";
        internal const string PN_GALLERY_ITEM_TYPE = "P_GALLERY_ITEM_TYPE";
        internal const string PN_GALLERY_ORDER = "P_GALLERY_ORDER";
        internal const string PN_GALLERY_CREATED_BY = "P_GALLERY_CREATED_BY";
        internal const string PN_GALLERY_PARENT_OBJ_ID = "P_GALLERY_PARENT_OBJ_ID";


        internal const string SN_GALLERY_ADD = "[GALLERY].[GalleryAdd]";
        internal const string SN_GALLERY_UPDATE = "[GALLERY].[GalleryUpdate]";
        internal const string SN_GALLERY_DELETE = "[GALLERY].[GalleryDelete]";
        internal const string SN_GALLERY_GET_BY_ID = "[GALLERY].[GalleryGetByID]";
        internal const string SN_GALLERY_GET_ALL = "[GALLERY].[GalleryGetAll]";
        internal const string SN_GALLERY_GET_BY_CATEGORY = "[GALLERY].[GalleryGetByCategory]";
        internal const string SN_GALLERY_GET_BY_PORTAL_LANGUAGE = "[GALLERY].[GalleryGetByPortalLanguage]";
        internal const string SN_GALLERY_DELETE_LOGICAL = "[GALLERY].[GalleryDeleteLogical]";
        internal const string SN_GALLERY_GET_BY_CATEGORY_XML = "[GALLERY].[GalleryGetByCategoryXML]";
        internal const string SN_GALLERY_GET_PARENT_OBJ_BY_CATEGORY = "[GALLERY].[GalleryGetParentObjByCategory]";
        internal const string SN_GALLERY_GET_BY_PARENT_OBJ_ID_AND_LANGUAGE_ID = "[GALLERY].[GalleryGetByParentObjIdAndLanguageID]";


        #endregion

        #region GalleryDataMapper

        internal static int Add(IEntity entity)
        {
            Gallery galleryEntity = (Gallery)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(galleryEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_FILE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.File;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_SUMMARY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)galleryEntity.GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ITEM_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)galleryEntity.GalleryItemType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.ParentObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    galleryEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_GALLERY_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return galleryEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Gallery galleryEntity = (Gallery)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(galleryEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_FILE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.File;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_SUMMARY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)galleryEntity.GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ITEM_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)galleryEntity.GalleryItemType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = galleryEntity.ParentObjectID;
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

        internal static void Delete(int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ID;
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

        internal static void DeleteLogical(int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ID;
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

        internal static List<Gallery> GetGallerys()
        {
            List<Gallery> colGallerys = null;
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colGallerys = new List<Gallery>();
                    while (sqlDataReader.Read())
                    {
                        gallery = GetGallery(colGallerys, sqlDataReader);
                        FillFromReader(gallery, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colGallerys;
        }

        internal static List<Gallery> GetGallerys(int CategoryID, CMSEnums.GalleryType GalleryType)
        {
            List<Gallery> colGallerys = null;
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_GALLERY_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colGallerys = new List<Gallery>();
                    while (sqlDataReader.Read())
                    {
                        gallery = GetGallery(colGallerys, sqlDataReader);
                        FillFromReader(gallery, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colGallerys;
        }

        internal static List<Gallery> GetParentObjGallerysByCategoryID(int CategoryID, CMSEnums.GalleryType GalleryType)
        {
            List<Gallery> colGallerys = null;
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_PARENT_OBJ_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_GALLERY_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colGallerys = new List<Gallery>();
                    while (sqlDataReader.Read())
                    {
                        gallery = GetGallery(colGallerys, sqlDataReader);
                        FillFromReader(gallery, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colGallerys;
        }

        internal static List<Gallery> GetGallerys(int PortalID, int LanguageID, CMSEnums.GalleryType GalleryType)
        {
            List<Gallery> colGallerys = null;
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colGallerys = new List<Gallery>();
                    while (sqlDataReader.Read())
                    {
                        gallery = GetGallery(colGallerys, sqlDataReader);
                        FillFromReader(gallery, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colGallerys;
        }

        internal static Gallery GetGallery(int GalleryID)
        {
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_GALLERY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = GalleryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (gallery == null)
                            gallery = new Gallery();
                        FillFromReader(gallery, sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return gallery;
        }

        internal static Gallery GetGalleryByParentObjIdAndLanguageId(int parentObjID, int languageID)
        {
            Gallery gallery = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_BY_PARENT_OBJ_ID_AND_LANGUAGE_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_GALLERY_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = parentObjID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (gallery == null)
                            gallery = new Gallery();
                        FillFromReader(gallery, sqlDataReader);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return gallery;
        }

        // Publish UnPublish IsUnhandled :
        internal static string GetGallerysPublishXML(int CategoryID, CMSEnums.GalleryType GalleryType, int RowFrom, int RowTo, ref int TotalCount)
        {
            string galleryXML = string.Empty;
            TotalCount = 0;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_GALLERY_GET_BY_CATEGORY_XML, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_GALLERY_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_GALLERY_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)GalleryType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_ROW_FROM, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RowFrom;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_ROW_TO, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RowTo;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(CMSCoreBase.PN_TOTAL_COUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.Modules.Gallery;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_TYPE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.PublishType.PublishNow;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    SqlXml sqlXML = null;
                    while (sqlDataReader.Read())
                    {
                        sqlXML = sqlDataReader.GetSqlXml(0);
                    }
                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();

                    if (!sqlXML.IsNull)
                    {
                        galleryXML = sqlXML.Value;
                        TotalCount = Convert.ToInt32(sqlCommand.Parameters[CMSCoreBase.PN_TOTAL_COUNT].Value);
                    }
                }
            }
            return galleryXML;
        }

        #endregion

        #region GetFromReader

        internal static Gallery GetGallery(List<Gallery> gallerys, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_GALLERY_ID);
            int value = reader.GetInt32(colIndex);

            Gallery gallery = gallerys.Where(c => c.ID == value).FirstOrDefault();
            if (gallery == null)
            {
                gallery = new Gallery();
                gallerys.Add(gallery);
            }
            return gallery;
        }

        internal static void FillFromReader(Gallery gallery, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_GALLERY_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.CategoryID = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_GALLERY_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            gallery.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_GALLERY_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                gallery.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_DETAILS);
            if (!reader.IsDBNull(colIndex))
                gallery.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_FILE);
            if (!reader.IsDBNull(colIndex))
                gallery.File = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                gallery.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_KEYWORDS);
            if (!reader.IsDBNull(colIndex))
                gallery.KeyWords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_NAME);
            if (!reader.IsDBNull(colIndex))
                gallery.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_SUMMARY);
            if (!reader.IsDBNull(colIndex))
                gallery.Summary = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_SEO_NAME);
            if (!reader.IsDBNull(colIndex))
                gallery.SEOName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_URL);
            if (!reader.IsDBNull(colIndex))
                gallery.URL = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_TYPE);
            if (!reader.IsDBNull(colIndex))
                gallery.GalleryType = (CMSEnums.GalleryType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_ITEM_TYPE);
            if (!reader.IsDBNull(colIndex))
                gallery.GalleryItemType = (CMSEnums.GalleryItemType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_ORDER);
            if (!reader.IsDBNull(colIndex))
                gallery.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                gallery.CreatedBy = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GALLERY_PARENT_OBJ_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.ParentObjectID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(PublishDataMapper.CN_PUBLISH_TYPE_ID);
            if (!reader.IsDBNull(colIndex))
                gallery.IsPublished = reader.GetInt32(colIndex) == (int)AJH.CMS.Core.Enums.CMSEnums.PublishType.PublishNow;
        }

        #endregion
    }
}