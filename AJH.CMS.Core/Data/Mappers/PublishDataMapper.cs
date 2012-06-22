using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class PublishDataMapper
    {
        #region Constant

        internal const string CN_PUBLISH_ID = "PUBLISH_ID";
        internal const string CN_PUBLISH_MODULE_ID = "PUBLISH_MODULE_ID";
        internal const string CN_PUBLISH_OBJECT_ID = "PUBLISH_OBJECT_ID";
        internal const string CN_PUBLISH_TYPE_ID = "PUBLISH_TYPE_ID";
        internal const string CN_PUBLISH_FROM_DAY = "PUBLISH_FROM_DAY";
        internal const string CN_PUBLISH_FROM_SEC = "PUBLISH_FROM_SEC";
        internal const string CN_PUBLISH_TO_DAY = "PUBLISH_TO_DAY";
        internal const string CN_PUBLISH_TO_SEC = "PUBLISH_TO_SEC";
        internal const string CN_PUBLISH_CREATED_BY = "PUBLISH_CREATED_BY";
        internal const string CN_PUBLISH_PORTAL_ID = "PUBLISH_PORTAL_ID";
        internal const string CN_PUBLISH_LANGUAGE_ID = "PUBLISH_LANGUAGE_ID";

        internal const string PN_PUBLISH_ID = "P_PUBLISH_ID";
        internal const string PN_PUBLISH_MODULE_ID = "P_PUBLISH_MODULE_ID";
        internal const string PN_PUBLISH_OBJECT_ID = "P_PUBLISH_OBJECT_ID";
        internal const string PN_PUBLISH_TYPE_ID = "P_PUBLISH_TYPE_ID";
        internal const string PN_PUBLISH_FROM_DAY = "P_PUBLISH_FROM_DAY";
        internal const string PN_PUBLISH_FROM_SEC = "P_PUBLISH_FROM_SEC";
        internal const string PN_PUBLISH_TO_DAY = "P_PUBLISH_TO_DAY";
        internal const string PN_PUBLISH_TO_SEC = "P_PUBLISH_TO_SEC";
        internal const string PN_PUBLISH_CREATED_BY = "P_PUBLISH_CREATED_BY";
        internal const string PN_PUBLISH_PORTAL_ID = "P_PUBLISH_PORTAL_ID";
        internal const string PN_PUBLISH_LANGUAGE_ID = "P_PUBLISH_LANGUAGE_ID";

        internal const string SN_PUBLISH_ADD = "[SETUP].[PublishAdd]";
        internal const string SN_PUBLISH_DELETE = "[SETUP].[PublishDelete]";
        internal const string SN_PUBLISH_GET_ALL = "[SETUP].[PublishGetAll]";
        internal const string SN_PUBLISH_GET_BY_ID = "[SETUP].[PublishGetByID]";
        internal const string SN_PUBLISH_GET_BY_MODULE = "[SETUP].[PublishGetByModuleID]";
        internal const string SN_PUBLISH_UPDATE = "[SETUP].[PublishUpdate]";
        internal const string SN_PUBLISH_DELETE_BY_OBJECT_ID = "[SETUP].[PublishDeleteByObjID]";

        #endregion

        #region PublishDataMapper

        internal static int Add(IEntity entity)
        {
            Publish publishEntity = (Publish)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PUBLISH_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(publishEntity.FromDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PUBLISH_FROM_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_FROM_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_OBJECT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.ObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                days = 0;
                seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(publishEntity.ToDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PUBLISH_TO_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_TO_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_TYPE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)publishEntity.PublishType;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    if (sqlCommand.Parameters[PN_PUBLISH_ID].Value != DBNull.Value)
                        publishEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_PUBLISH_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return publishEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Publish publishEntity = (Publish)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PUBLISH_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(publishEntity.FromDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PUBLISH_FROM_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_FROM_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_OBJECT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.ObjectID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = publishEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                days = 0;
                seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(publishEntity.ToDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_PUBLISH_TO_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_TO_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_TYPE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)publishEntity.PublishType;
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
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_DELETE_BY_OBJECT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PUBLISH_ID, System.Data.SqlDbType.Int);
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

        internal static void DeleteByObjectIDAndModuleId(int objectID, int moduleID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_DELETE_BY_OBJECT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PUBLISH_OBJECT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = objectID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = moduleID;
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

        internal static List<Publish> GetPublishs()
        {
            List<Publish> colPublishs = null;
            Publish publish = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPublishs = new List<Publish>();
                    while (sqlDataReader.Read())
                    {
                        publish = GetPublish(colPublishs, sqlDataReader);
                        FillFromReader(publish, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPublishs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModuleID">By default: -1</param>
        /// <param name="PortalID"></param>
        /// <param name="LanguageID">By default: -1</param>
        /// <returns></returns>
        internal static List<Publish> GetPublishs(int ModuleID, int PortalID, int LanguageID)
        {
            List<Publish> colPublishs = null;
            Publish publish = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_GET_BY_MODULE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PUBLISH_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PUBLISH_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colPublishs = new List<Publish>();
                    while (sqlDataReader.Read())
                    {
                        publish = GetPublish(colPublishs, sqlDataReader);
                        FillFromReader(publish, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colPublishs;
        }

        internal static Publish GetPublishById(int PublishID)
        {
            Publish publish = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PUBLISH_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_PUBLISH_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = PublishID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (publish == null)
                            publish = new Publish();
                        FillFromReader(publish, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return publish;
        }

        #endregion

        #region GetFromReader

        internal static Publish GetPublish(List<Publish> publishs, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PUBLISH_ID);
            int value = reader.GetInt32(colIndex);

            Publish publish = publishs.Where(c => c.ID == value).FirstOrDefault();
            if (publish == null)
            {
                publish = new Publish();
                publishs.Add(publish);
            }
            return publish;
        }

        internal static void FillFromReader(Publish publish, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_PUBLISH_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                publish.CreatedBy = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_PUBLISH_FROM_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_FROM_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            publish.FromDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_PUBLISH_ID);
            if (!reader.IsDBNull(colIndex))
                publish.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                publish.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                publish.ModuleID = (AJH.CMS.Core.Enums.CMSEnums.Modules)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_OBJECT_ID);
            if (!reader.IsDBNull(colIndex))
                publish.ObjectID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                publish.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_TO_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_PUBLISH_TO_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            publish.ToDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_PUBLISH_TYPE_ID);
            if (!reader.IsDBNull(colIndex))
                publish.PublishType = (CMSEnums.PublishType)reader.GetInt32(colIndex);
        }

        #endregion
    }
}