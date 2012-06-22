using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class FormUserDataMapper
    {
        #region Constant

        internal const string CN_FORM_USER_ID = "FORM_USER_ID";
        internal const string CN_FORM_USER_FORM_ID = "FORM_USER_FORM_ID";
        internal const string CN_FORM_USER_USER_ID = "FORM_USER_USER_ID";
        internal const string CN_FORM_USER_ACCESS_TYPE = "FORM_USER_ACCESS_TYPE";

        internal const string PN_FORM_USER_ID = "P_FORM_USER_ID";
        internal const string PN_FORM_USER_FORM_ID = "P_FORM_USER_FORM_ID";
        internal const string PN_FORM_USER_USER_ID = "P_FORM_USER_USER_ID";
        internal const string PN_FORM_USER_ACCESS_TYPE = "P_FORM_USER_ACCESS_TYPE";

        internal const string SN_FORM_USER_ADD = "[SECURITY].[FormUserAdd]";
        internal const string SN_FORM_USER_DELETE = "[SECURITY].[FormUserDelete]";
        internal const string SN_FORM_USER_DELETE_FORM_USER = "[SECURITY].[FormUserDeleteByFormUser]";
        internal const string SN_FORM_USER_GET_BY_FORM_USER = "[SECURITY].[FormUserGetByFormUser]";
        internal const string SN_FORM_USER_UPDATE = "[SECURITY].[FormUserUpdate]";
        internal const string SN_FORM_USER_GET_BY_ID = "[SECURITY].[FormUserGetByID]";

        #endregion

        #region UserDataMapper

        internal static int Add(FormUser formUser)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formUser.FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formUser.UserID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_ACCESS_TYPE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)formUser.AccessType;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    formUser.ID = Convert.ToInt32(sqlCommand.Parameters[PN_FORM_USER_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formUser.ID;
        }

        internal static void Update(FormUser formUser)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formUser.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formUser.FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formUser.UserID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_ACCESS_TYPE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)formUser.AccessType;
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
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_USER_ID, System.Data.SqlDbType.Int);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormID">By default -1</param>
        /// <param name="UserID">By default -1</param>
        internal static void Delete(int FormID, int UserID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_DELETE_FORM_USER, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_USER_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = UserID;
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

        internal static List<FormUser> GetFormsUsers(int FormID, int UserID)
        {
            List<FormUser> colFormUser = null;
            FormUser formUser = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_GET_BY_FORM_USER, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_USER_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_USER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = UserID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colFormUser = new List<FormUser>();
                    while (sqlDataReader.Read())
                    {
                        formUser = GetFormUser(colFormUser, sqlDataReader);
                        FillFromReader(formUser, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colFormUser;
        }

        internal static FormUser GetFormUserById(int ID)
        {
            FormUser formUser = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_USER_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_FORM_USER_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = ID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (formUser == null)
                            formUser = new FormUser();
                        FillFromReader(formUser, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return formUser;
        }

        #endregion

        #region GetFromReader

        internal static FormUser GetFormUser(List<FormUser> formsUsers, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_FORM_USER_ID);
            int value = reader.GetInt32(colIndex);

            FormUser formUser = formsUsers.Where(c => c.ID == value).FirstOrDefault();
            if (formUser == null)
            {
                formUser = new FormUser();
                formsUsers.Add(formUser);
            }
            return formUser;
        }

        internal static void FillFromReader(FormUser formUser, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_FORM_USER_ID);
            if (!reader.IsDBNull(colIndex))
                formUser.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_USER_ACCESS_TYPE);
            if (!reader.IsDBNull(colIndex))
                formUser.AccessType = (CMSEnums.AccessType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_USER_FORM_ID);
            if (!reader.IsDBNull(colIndex))
                formUser.FormID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_USER_USER_ID);
            if (!reader.IsDBNull(colIndex))
                formUser.UserID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(UserDataMapper.CN_USER_NAME);
            if (!reader.IsDBNull(colIndex))
                formUser.UserName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(FormDataMapper.CN_FORM_CODE);
            if (!reader.IsDBNull(colIndex))
                formUser.FormCode = reader.GetString(colIndex);
        }

        #endregion
    }
}