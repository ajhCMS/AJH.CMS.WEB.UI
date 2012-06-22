using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class CMSControlDataMapper
    {
        #region Constant

        internal const string CN_CMSCONTROL_ID = "CMSCONTROL_ID";
        internal const string CN_CMSCONTROL_NAME = "CMSCONTROL_NAME";
        internal const string CN_CMSCONTROL_DESCRIPTION = "CMSCONTROL_DESCRIPTION";
        internal const string CN_CMSCONTROL_USER_CONTROL_PATH = "CMSCONTROL_USER_CONTROL_PATH";
        internal const string CN_CMSCONTROL_IS_DELETED = "CMSCONTROL_IS_DELETED";
        internal const string CN_CMSCONTROL_MODULE_ID = "CMSCONTROL_MODULE_ID";
        internal const string CN_CMSCONTROL_CREATION_DAY = "CMSCONTROL_CREATION_DAY";
        internal const string CN_CMSCONTROL_CREATION_SEC = "CMSCONTROL_CREATION_SEC";
        internal const string CN_CMSCONTROL_CREATED_BY = "CMSCONTROL_CREATED_BY";

        internal const string PN_CMSCONTROL_ID = "P_CMSCONTROL_ID";
        internal const string PN_CMSCONTROL_NAME = "P_CMSCONTROL_NAME";
        internal const string PN_CMSCONTROL_DESCRIPTION = "P_CMSCONTROL_DESCRIPTION";
        internal const string PN_CMSCONTROL_USER_CONTROL_PATH = "P_CMSCONTROL_USER_CONTROL_PATH";
        internal const string PN_CMSCONTROL_IS_DELETED = "P_CMSCONTROL_IS_DELETED";
        internal const string PN_CMSCONTROL_MODULE_ID = "P_CMSCONTROL_MODULE_ID";
        internal const string PN_CMSCONTROL_CREATION_DAY = "P_CMSCONTROL_CREATION_DAY";
        internal const string PN_CMSCONTROL_CREATION_SEC = "P_CMSCONTROL_CREATION_SEC";
        internal const string PN_CMSCONTROL_CREATED_BY = "P_CMSCONTROL_CREATED_BY";

        internal const string SN_CMSCONTROL_ADD = "[SETUP].[CMSControlAdd]";
        internal const string SN_CMSCONTROL_DELETE = "[SETUP].[CMSControlDelete]";
        internal const string SN_CMSCONTROL_DELETE_LOGICAL = "[SETUP].[CMSControlDeleteLogical]";
        internal const string SN_CMSCONTROL_GET_ALL = "[SETUP].[CMSControlGetAll]";
        internal const string SN_CMSCONTROL_GET_BY_ID = "[SETUP].[CMSControlGetByID]";
        internal const string SN_CMSCONTROL_GET_BY_MODULE = "[SETUP].[CMSControlGetByModuleID]";
        internal const string SN_CMSCONTROL_UPDATE = "[SETUP].[CMSControlUpdate]";

        #endregion

        #region CMSControlDataMapper

        internal static int Add(CMSControl cmsControlEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(cmsControlEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_USER_CONTROL_PATH, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.UserControlPath;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    cmsControlEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_CMSCONTROL_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return cmsControlEntity.ID;
        }

        internal static void Update(CMSControl cmsControlEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(cmsControlEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_DESCRIPTION, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_USER_CONTROL_PATH, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.UserControlPath;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CMSCONTROL_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = cmsControlEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CMSCONTROL_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CMSCONTROL_ID, System.Data.SqlDbType.Int);
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

        internal static List<CMSControl> GetCMSControls()
        {
            List<CMSControl> colCMSControls = null;
            CMSControl cmsControl = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCMSControls = new List<CMSControl>();
                    while (sqlDataReader.Read())
                    {
                        cmsControl = GetCMSControl(colCMSControls, sqlDataReader);
                        FillFromReader(cmsControl, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCMSControls;
        }

        internal static List<CMSControl> GetCMSControls(int ModuleID)
        {
            List<CMSControl> colCMSControls = null;
            CMSControl cmsControl = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_GET_BY_MODULE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CMSCONTROL_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCMSControls = new List<CMSControl>();
                    while (sqlDataReader.Read())
                    {
                        cmsControl = GetCMSControl(colCMSControls, sqlDataReader);
                        FillFromReader(cmsControl, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCMSControls;
        }

        internal static CMSControl GetCMSControlById(int CMSControlID)
        {
            CMSControl cmsControl = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CMSCONTROL_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_CMSCONTROL_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = CMSControlID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (cmsControl == null)
                            cmsControl = new CMSControl();
                        FillFromReader(cmsControl, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return cmsControl;
        }

        #endregion

        #region GetFromReader

        internal static CMSControl GetCMSControl(List<CMSControl> cmsControls, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CMSCONTROL_ID);
            int value = reader.GetInt32(colIndex);

            CMSControl cmsControl = cmsControls.Where(c => c.ID == value).FirstOrDefault();
            if (cmsControl == null)
            {
                cmsControl = new CMSControl();
                cmsControls.Add(cmsControl);
            }
            return cmsControl;
        }

        internal static void FillFromReader(CMSControl cmsControl, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_CMSCONTROL_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            cmsControl.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                cmsControl.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_USER_CONTROL_PATH);
            if (!reader.IsDBNull(colIndex))
                cmsControl.UserControlPath = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_ID);
            if (!reader.IsDBNull(colIndex))
                cmsControl.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                cmsControl.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_NAME);
            if (!reader.IsDBNull(colIndex))
                cmsControl.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                cmsControl.ModuleID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CMSCONTROL_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                cmsControl.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}