using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class MenuDataMapper
    {
        #region Constant

        internal const string CN_MENU_ID = "MENU_ID";
        internal const string CN_MENU_NAME = "MENU_NAME";
        internal const string CN_MENU_DESCRIPTION = "MENU_DESCRIPTION";
        internal const string CN_MENU_KEYWORDS = "MENU_KEYWORDS";
        internal const string CN_MENU_SEO_NAME = "MENU_SEO_NAME";
        internal const string CN_MENU_DETAILS = "MENU_DETAILS";
        internal const string CN_MENU_URL = "MENU_URL";
        internal const string CN_MENU_IMAGE = "MENU_IMAGE";
        internal const string CN_MENU_PAGE_ID = "MENU_PAGE_ID";
        internal const string CN_MENU_CATEGORY_ID = "MENU_CATEGORY_ID";
        internal const string CN_MENU_PARENT_ID = "MENU_PARENT_ID";
        internal const string CN_MENU_CREATION_DAY = "MENU_CREATION_DAY";
        internal const string CN_MENU_CREATION_SEC = "MENU_CREATION_SEC";
        internal const string CN_MENU_IS_DELETED = "MENU_IS_DELETED";
        internal const string CN_MENU_PORTAL_ID = "MENU_PORTAL_ID";
        internal const string CN_MENU_LANGUAGE_ID = "MENU_LANGUAGE_ID";
        internal const string CN_MENU_TYPE = "MENU_TYPE";
        internal const string CN_MENU_ORDER = "MENU_ORDER";
        internal const string CN_MENU_CREATED_BY = "MENU_CREATED_BY";
        internal const string CN_MENU_PARENT_OBJ_ID = "MENU_PARENT_OBJ_ID";

        internal const string PN_MENU_ID = "P_MENU_ID";
        internal const string PN_MENU_NAME = "P_MENU_NAME";
        internal const string PN_MENU_DESCRIPTION = "P_MENU_DESCRIPTION";
        internal const string PN_MENU_KEYWORDS = "P_MENU_KEYWORDS";
        internal const string PN_MENU_SEO_NAME = "P_MENU_SEO_NAME";
        internal const string PN_MENU_DETAILS = "P_MENU_DETAILS";
        internal const string PN_MENU_URL = "P_MENU_URL";
        internal const string PN_MENU_IMAGE = "P_MENU_IMAGE";
        internal const string PN_MENU_PAGE_ID = "P_MENU_PAGE_ID";
        internal const string PN_MENU_CATEGORY_ID = "P_MENU_CATEGORY_ID";
        internal const string PN_MENU_PARENT_ID = "P_MENU_PARENT_ID";
        internal const string PN_MENU_CREATION_DAY = "P_MENU_CREATION_DAY";
        internal const string PN_MENU_CREATION_SEC = "P_MENU_CREATION_SEC";
        internal const string PN_MENU_IS_DELETED = "P_MENU_IS_DELETED";
        internal const string PN_MENU_PORTAL_ID = "P_MENU_PORTAL_ID";
        internal const string PN_MENU_LANGUAGE_ID = "P_MENU_LANGUAGE_ID";
        internal const string PN_MENU_TYPE = "P_MENU_TYPE";
        internal const string PN_MENU_ORDER = "P_MENU_ORDER";
        internal const string PN_MENU_CREATED_BY = "P_MENU_CREATED_BY";
        internal const string PN_MENU_PARENT_OBJ_ID = "P_MENU_PARENT_OBJ_ID";

        internal const string SN_MENU_ADD = "[SETUP].[MenuAdd]";
        internal const string SN_MENU_UPDATE = "[SETUP].[MenuUpdate]";
        internal const string SN_MENU_DELETE = "[SETUP].[MenuDelete]";
        internal const string SN_MENU_GET_BY_ID = "[SETUP].[MenuGetByID]";
        internal const string SN_MENU_GET_ALL = "[SETUP].[MenuGetAll]";
        internal const string SN_MENU_GET_BY_CATEGORY = "[SETUP].[MenuGetByCategory]";
        internal const string SN_MENU_GET_BY_PORTAL_LANGUAGE = "[SETUP].[MenuGetByPortalLanguage]";
        internal const string SN_MENU_GET_BY_PARENT = "[SETUP].[MenuGetByParent]";
        internal const string SN_MENU_DELETE_LOGICAL = "[SETUP].[MenuDeleteLogical]";
        internal const string SN_MENU_GET_BY_PAGE = "[SETUP].[MenuGetByPage]";
        internal const string SN_MENU_GET_BY_PARENT_OBJ_ID = "[SETUP].[MenuGetByParentObjID]";
        internal const string SN_MENU_GET_PARENT_OBJ_BY_CATEGORY = "[SETUP].[MenuGetParentObjByCategory]";
        internal const string SN_MENU_GET_BY_ID_AND_LANGAUGE = "[SETUP].[MenuGetByIDAndLang]";

        #endregion

        #region MenuDataMapper

        internal static int Add(IEntity entity)
        {
            Menu menuEntity = (Menu)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(menuEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_MENU_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.PageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)menuEntity.MenuType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.ParentObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    menuEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_MENU_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return menuEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Menu menuEntity = (Menu)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(menuEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_MENU_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_IMAGE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Image;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_KEYWORDS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.KeyWords;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.PageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_SEO_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.SEOName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.URL;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_TYPE, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)menuEntity.MenuType;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_ORDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.Order;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = menuEntity.ParentObjectID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
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

        internal static List<Menu> GetMenus()
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static List<Menu> GetMenusByCategoryAndLanguage(int CategoryID, int languageID)
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_MENU_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static List<Menu> GetMenusParentObjByCategory(int CategoryID)
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_PARENT_OBJ_BY_CATEGORY, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_MENU_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CategoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static List<Menu> GetMenus(int PortalID, int LanguageID)
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static List<Menu> GetMenus(int ParentID, int PortalID, int LanguageID)
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_PARENT, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_MENU_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static List<Menu> GetMenusByPage(int PageID)
        {
            List<Menu> colMenus = null;
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_PAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_MENU_PAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colMenus = new List<Menu>();
                    while (sqlDataReader.Read())
                    {
                        menu = GetMenu(colMenus, sqlDataReader);
                        FillFromReader(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colMenus;
        }

        internal static Menu GetMenu(int MenuID)
        {
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = MenuID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (menu == null)
                            menu = new Menu();
                        FillFromReader(menu, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return menu;
        }

        internal static Menu GetMenuByIdAndLanguage(int MenuID, int languageID)
        {
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_ID_AND_LANGAUGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter(PN_MENU_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = MenuID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (menu == null)
                            menu = new Menu();
                        FillFromReader(menu, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return menu;
        }


        internal static Menu GetMenu(int parentObjID, int languageID)
        {
            Menu menu = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MENU_GET_BY_PARENT_OBJ_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MENU_PARENT_OBJ_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = parentObjID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_MENU_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PublishDataMapper.PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Menu;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {

                    while (sqlDataReader.Read())
                    {
                        menu = new Menu();
                        FillFromReaderByParentObjID(menu, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return menu;
        }

        #endregion

        #region GetFromReader

        internal static Menu GetMenu(List<Menu> menus, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MENU_ID);
            int value = reader.GetInt32(colIndex);

            Menu menu = menus.Where(c => c.ID == value).FirstOrDefault();
            if (menu == null)
            {
                menu = new Menu();
                menus.Add(menu);
            }
            return menu;
        }

        internal static void FillFromReader(Menu menu, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MENU_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                menu.CategoryID = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_MENU_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            menu.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_MENU_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                menu.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_DETAILS);
            if (!reader.IsDBNull(colIndex))
                menu.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_IMAGE);
            if (!reader.IsDBNull(colIndex))
                menu.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                menu.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_KEYWORDS);
            if (!reader.IsDBNull(colIndex))
                menu.KeyWords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                menu.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_NAME);
            if (!reader.IsDBNull(colIndex))
                menu.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PAGE_ID);
            if (!reader.IsDBNull(colIndex))
                menu.PageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PARENT_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ParentID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                menu.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_SEO_NAME);
            if (!reader.IsDBNull(colIndex))
                menu.SEOName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_URL);
            if (!reader.IsDBNull(colIndex))
                menu.URL = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_TYPE);
            if (!reader.IsDBNull(colIndex))
                menu.MenuType = (CMSEnums.MenuType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_ORDER);
            if (!reader.IsDBNull(colIndex))
                menu.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                menu.CreatedBy = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PARENT_OBJ_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ParentObjectID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(PublishDataMapper.CN_PUBLISH_TYPE_ID);
            if (!reader.IsDBNull(colIndex))
                menu.IsPublished = reader.GetInt32(colIndex) == (int)AJH.CMS.Core.Enums.CMSEnums.PublishType.PublishNow;
        }

        internal static void FillFromReaderByParentObjID(Menu menu, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MENU_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                menu.CategoryID = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_MENU_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            menu.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_MENU_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                menu.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_DETAILS);
            if (!reader.IsDBNull(colIndex))
                menu.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_IMAGE);
            if (!reader.IsDBNull(colIndex))
                menu.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                menu.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_KEYWORDS);
            if (!reader.IsDBNull(colIndex))
                menu.KeyWords = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                menu.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_NAME);
            if (!reader.IsDBNull(colIndex))
                menu.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PAGE_ID);
            if (!reader.IsDBNull(colIndex))
                menu.PageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PARENT_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ParentID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                menu.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_SEO_NAME);
            if (!reader.IsDBNull(colIndex))
                menu.SEOName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_URL);
            if (!reader.IsDBNull(colIndex))
                menu.URL = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_TYPE);
            if (!reader.IsDBNull(colIndex))
                menu.MenuType = (CMSEnums.MenuType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_ORDER);
            if (!reader.IsDBNull(colIndex))
                menu.Order = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                menu.CreatedBy = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MENU_PARENT_OBJ_ID);
            if (!reader.IsDBNull(colIndex))
                menu.ParentObjectID = reader.GetInt32(colIndex);
        }

        #endregion
    }
}