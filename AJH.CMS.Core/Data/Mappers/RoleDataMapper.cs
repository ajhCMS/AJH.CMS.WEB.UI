using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class RoleDataMapper
    {
        #region Constant

        internal const string CN_ROLE_ID = "ROLE_ID";
        internal const string CN_ROLE_NAME = "ROLE_NAME";
        internal const string CN_ROLE_DESCRIPTION = "ROLE_DESCRIPTION";
        internal const string CN_ROLE_IS_DELETED = "ROLE_IS_DELETED";

        internal const string PN_ROLE_ID = "P_ROLE_ID";
        internal const string PN_ROLE_NAME = "P_ROLE_NAME";
        internal const string PN_ROLE_DESCRIPTION = "P_ROLE_DESCRIPTION";
        internal const string PN_ROLE_IS_DELETED = "P_ROLE_IS_DELETED";

        internal const string SN_ROLE_ADD = "[SECURITY].[RoleAdd]";
        internal const string SN_ROLE_DELETE = "[SECURITY].[RoleDelete]";
        internal const string SN_ROLE_DELETE_LOGICAL = "[SECURITY].[RoleDeleteLogical]";
        internal const string SN_ROLE_GET_ALL = "[SECURITY].[RoleGetAll]";
        internal const string SN_ROLE_GET_BY_ID = "[SECURITY].[RoleGetByID]";
        internal const string SN_ROLE_GET_BY_CODE = "[SECURITY].[RoleGetByName]";
        internal const string SN_ROLE_UPDATE = "[SECURITY].[RoleUpdate]";
        internal const string SN_ROLE_USER_DELETE = "[SECURITY].[RoleUserDelete]";
        internal const string SN_ROLE_USER_ADD = "[SECURITY].[RoleUserAdd]";
        internal const string SN_ROLE_GET_NOT_IN_FORM = "[SECURITY].[RoleGetNotInForm]";

        #endregion

        #region RoleDataMapper

        internal static int Add(Role roleEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    roleEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ROLE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return roleEntity.ID;
        }

        internal static void Update(Role roleEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ROLE_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = roleEntity.IsDeleted;
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
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
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

        internal static List<Role> GetRoles()
        {
            List<Role> colRoles = null;
            Role role = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colRoles = new List<Role>();
                    while (sqlDataReader.Read())
                    {
                        role = GetRole(colRoles, sqlDataReader);
                        FillFromReader(role, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colRoles;
        }

        internal static List<Role> GetRolesNotInForm(int FormID)
        {
            List<Role> colRoles = null;
            Role role = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_GET_NOT_IN_FORM, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(FormDataMapper.PN_FORM_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = FormID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colRoles = new List<Role>();
                    while (sqlDataReader.Read())
                    {
                        role = GetRole(colRoles, sqlDataReader);
                        FillFromReader(role, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colRoles;
        }

        internal static Role GetRoleById(int RoleID)
        {
            Role role = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = RoleID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (role == null)
                            role = new Role();
                        FillFromReader(role, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return role;
        }

        internal static Role GetRoleByRoleName(string RoleName)
        {
            Role role = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_GET_BY_CODE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_ROLE_NAME, System.Data.SqlDbType.NVarChar);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = RoleName;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (role == null)
                            role = new Role();
                        FillFromReader(role, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return role;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleID">By default: -1</param>
        /// <param name="UserID">By default: -1</param>
        internal static void DeleteRoleUser(int RoleID, int UserID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_USER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RoleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(UserDataMapper.PN_USER_ID, System.Data.SqlDbType.Int);
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

        internal static void AddRoleUser(int RoleID, int UserID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ROLE_USER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RoleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(UserDataMapper.PN_USER_ID, System.Data.SqlDbType.Int);
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

        #endregion

        #region GetFromReader

        internal static Role GetRole(List<Role> roles, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ROLE_ID);
            int value = reader.GetInt32(colIndex);

            Role role = roles.Where(c => c.ID == value).FirstOrDefault();
            if (role == null)
            {
                role = new Role();
                roles.Add(role);
            }
            return role;
        }

        internal static void FillFromReader(Role role, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_ROLE_ID);
            if (!reader.IsDBNull(colIndex))
                role.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ROLE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                role.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_ROLE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                role.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_ROLE_NAME);
            if (!reader.IsDBNull(colIndex))
                role.Name = reader.GetString(colIndex);
        }

        #endregion
    }
}