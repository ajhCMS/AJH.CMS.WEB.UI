using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class UserDataMapper
    {
        #region Constant

        internal const string CN_USER_ID = "USER_ID";
        internal const string CN_USER_NAME = "USER_NAME";
        internal const string CN_USER_EMAIL = "USER_EMAIL";
        internal const string CN_USER_PASSWORD = "USER_PASSWORD";
        internal const string CN_USER_IS_ACTIVE = "USER_IS_ACTIVE";
        internal const string CN_USER_IS_DELETED = "USER_IS_DELETED";
        internal const string CN_USER_CREATION_DAY = "USER_CREATION_DAY";
        internal const string CN_USER_CREATION_SEC = "USER_CREATION_SEC";

        internal const string PN_USER_ID = "P_USER_ID";
        internal const string PN_USER_NAME = "P_USER_NAME";
        internal const string PN_USER_EMAIL = "P_USER_EMAIL";
        internal const string PN_USER_PASSWORD = "P_USER_PASSWORD";
        internal const string PN_USER_IS_ACTIVE = "P_USER_IS_ACTIVE";
        internal const string PN_USER_IS_DELETED = "P_USER_IS_DELETED";
        internal const string PN_USER_CREATION_DAY = "P_USER_CREATION_DAY";
        internal const string PN_USER_CREATION_SEC = "P_USER_CREATION_SEC";

        internal const string SN_USER_ADD = "[SECURITY].[UserAdd]";
        internal const string SN_USER_DELETE = "[SECURITY].[UserDelete]";
        internal const string SN_USER_DELETE_LOGICAL = "[SECURITY].[UserDeleteLogical]";
        internal const string SN_USER_GET_ALL = "[SECURITY].[UserGetAll]";
        internal const string SN_USER_GET_BY_ID = "[SECURITY].[UserGetByID]";
        internal const string SN_USER_GET_BY_NAME = "[SECURITY].[UserGetByName]";
        internal const string SN_USER_UPDATE = "[SECURITY].[UserUpdate]";
        internal const string SN_USER_UPDATE_ACTIVE = "[SECURITY].[UserUpdateActive]";
        internal const string SN_USER_GET_BY_ROLE_ID = "[SECURITY].[UserGetByRoleID]";
        internal const string SN_USER_GET_NOT_IN_ROLE = "[SECURITY].[UserGetNotInRole]";
        internal const string SN_USER_GET_NOT_IN_FORM = "[SECURITY].[UserGetNotInForm]";

        #endregion

        #region UserDataMapper

        internal static int Add(IEntity entity)
        {
            User userEntity = (User)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(userEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_USER_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_EMAIL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.Email;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_IS_ACTIVE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.IsActive;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_PASSWORD, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = EncryptAndDecrypt.Encrypt(userEntity.Password, true);
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    userEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_USER_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            User userEntity = (User)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(userEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_USER_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_EMAIL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.Email;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_IS_ACTIVE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.IsActive;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = userEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_PASSWORD, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = EncryptAndDecrypt.Encrypt(userEntity.Password, true);
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
                SqlCommand sqlCommand = new SqlCommand(SN_USER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_USER_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
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

        internal static void UpdateActive(int ID, bool IsActive)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_UPDATE_ACTIVE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_USER_IS_ACTIVE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = IsActive;
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

        internal static List<User> GetUsers()
        {
            List<User> colUsers = null;
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colUsers = new List<User>();
                    while (sqlDataReader.Read())
                    {
                        user = GetUser(colUsers, sqlDataReader);
                        FillFromReader(user, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colUsers;
        }

        internal static User GetUserById(int UserID)
        {
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_USER_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = UserID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (user == null)
                            user = new User();
                        FillFromReader(user, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return user;
        }

        internal static User GetUserByUserName(string UserName)
        {
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_BY_NAME, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_USER_NAME, System.Data.SqlDbType.NVarChar);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = UserName;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (user == null)
                            user = new User();
                        FillFromReader(user, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return user;
        }

        internal static List<User> GetUsers(int RoleID)
        {
            List<User> colUsers = null;
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_BY_ROLE_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(RoleDataMapper.PN_ROLE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = RoleID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colUsers = new List<User>();
                    while (sqlDataReader.Read())
                    {
                        user = GetUser(colUsers, sqlDataReader);
                        FillFromReader(user, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colUsers;
        }

        internal static List<User> GetUsersNotInRole(int RoleID)
        {
            List<User> colUsers = null;
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_NOT_IN_ROLE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(RoleDataMapper.PN_ROLE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = RoleID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colUsers = new List<User>();
                    while (sqlDataReader.Read())
                    {
                        user = GetUser(colUsers, sqlDataReader);
                        FillFromReader(user, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colUsers;
        }

        internal static List<User> GetUsersNotInForm(int FormID)
        {
            List<User> colUsers = null;
            User user = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_USER_GET_NOT_IN_FORM, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(FormDataMapper.PN_FORM_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = FormID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colUsers = new List<User>();
                    while (sqlDataReader.Read())
                    {
                        user = GetUser(colUsers, sqlDataReader);
                        FillFromReader(user, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colUsers;
        }

        #endregion

        #region GetFromReader

        internal static User GetUser(List<User> users, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_USER_ID);
            int value = reader.GetInt32(colIndex);

            User user = users.Where(c => c.ID == value).FirstOrDefault();
            if (user == null)
            {
                user = new User();
                users.Add(user);
            }
            return user;
        }

        internal static void FillFromReader(User user, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_USER_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            user.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_USER_EMAIL);
            if (!reader.IsDBNull(colIndex))
                user.Email = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_ID);
            if (!reader.IsDBNull(colIndex))
                user.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_IS_ACTIVE);
            if (!reader.IsDBNull(colIndex))
                user.IsActive = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                user.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_NAME);
            if (!reader.IsDBNull(colIndex))
                user.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_USER_PASSWORD);
            if (!reader.IsDBNull(colIndex))
                user.Password = EncryptAndDecrypt.Decrypt(reader.GetString(colIndex), true);
        }

        #endregion
    }
}