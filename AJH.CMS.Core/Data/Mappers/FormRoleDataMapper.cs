using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class FormRoleDataMapper
    {
        #region Constant

        internal const string CN_FORM_ROLE_ID = "FORM_ROLE_ID";
        internal const string CN_FORM_ROLE_FORM_ID = "FORM_ROLE_FORM_ID";
        internal const string CN_FORM_ROLE_ROLE_ID = "FORM_ROLE_ROLE_ID";
        internal const string CN_FORM_ROLE_ACCESS_TYPE = "FORM_ROLE_ACCESS_TYPE";

        internal const string PN_FORM_ROLE_ID = "P_FORM_ROLE_ID";
        internal const string PN_FORM_ROLE_FORM_ID = "P_FORM_ROLE_FORM_ID";
        internal const string PN_FORM_ROLE_ROLE_ID = "P_FORM_ROLE_ROLE_ID";
        internal const string PN_FORM_ROLE_ACCESS_TYPE = "P_FORM_ROLE_ACCESS_TYPE";

        internal const string SN_FORM_ROLE_ADD = "[SECURITY].[FormRoleAdd]";
        internal const string SN_FORM_ROLE_DELETE = "[SECURITY].[FormRoleDelete]";
        internal const string SN_FORM_ROLE_DELETE_FORM_ROLE = "[SECURITY].[FormRoleDeleteByFormRole]";
        internal const string SN_FORM_ROLE_GET_BY_FORM_ROLE = "[SECURITY].[FormRoleGetByFormRole]";
        internal const string SN_FORM_ROLE_UPDATE = "[SECURITY].[FormRoleUpdate]";
        internal const string SN_FORM_ROLE_GET_BY_ID = "[SECURITY].[FormRoleGetByID]";
        internal const string SN_FORM_ROLE_GET_BY_USER = "[SECURITY].[FormRoleGetByUser]";

        #endregion

        #region RoleDataMapper

        internal static int Add(FormRole formRole)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formRole.FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formRole.RoleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ACCESS_TYPE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)formRole.AccessType;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    formRole.ID = Convert.ToInt32(sqlCommand.Parameters[PN_FORM_ROLE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formRole.ID;
        }

        internal static void Update(FormRole formRole)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formRole.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formRole.FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formRole.RoleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ACCESS_TYPE, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)formRole.AccessType;
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
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ID, System.Data.SqlDbType.Int);
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
        /// <param name="RoleID">By default -1</param>
        internal static void Delete(int FormID, int RoleID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_DELETE_FORM_ROLE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ROLE_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RoleID;
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

        internal static List<FormRole> GetFormsRoles(int FormID, int RoleID)
        {
            List<FormRole> colFormRole = null;
            FormRole formRole = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_GET_BY_FORM_ROLE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ROLE_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = FormID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_ROLE_ROLE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = RoleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colFormRole = new List<FormRole>();
                    while (sqlDataReader.Read())
                    {
                        formRole = GetFormRole(colFormRole, sqlDataReader);
                        FillFromReader(formRole, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colFormRole;
        }

        internal static List<FormRole> GetFormsRolesByUserID(int UserID)
        {
            List<FormRole> colFormRole = null;
            FormRole formRole = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_GET_BY_USER, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(UserDataMapper.PN_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = UserID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colFormRole = new List<FormRole>();
                    while (sqlDataReader.Read())
                    {
                        formRole = GetFormRole(colFormRole, sqlDataReader);
                        FillFromReader(formRole, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colFormRole;
        }

        internal static FormRole GetFormRoleById(int ID)
        {
            FormRole formRole = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ROLE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_FORM_ROLE_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = ID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (formRole == null)
                            formRole = new FormRole();
                        FillFromReader(formRole, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return formRole;
        }

        #endregion

        #region GetFromReader

        internal static FormRole GetFormRole(List<FormRole> formsRoles, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_FORM_ROLE_ID);
            int value = reader.GetInt32(colIndex);

            FormRole formRole = formsRoles.Where(c => c.ID == value).FirstOrDefault();
            if (formRole == null)
            {
                formRole = new FormRole();
                formsRoles.Add(formRole);
            }
            return formRole;
        }

        internal static void FillFromReader(FormRole formRole, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_FORM_ROLE_ID);
            if (!reader.IsDBNull(colIndex))
                formRole.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_ROLE_ACCESS_TYPE);
            if (!reader.IsDBNull(colIndex))
                formRole.AccessType = (CMSEnums.AccessType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_ROLE_FORM_ID);
            if (!reader.IsDBNull(colIndex))
                formRole.FormID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_ROLE_ROLE_ID);
            if (!reader.IsDBNull(colIndex))
                formRole.RoleID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(RoleDataMapper.CN_ROLE_NAME);
            if (!reader.IsDBNull(colIndex))
                formRole.RoleName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(FormDataMapper.CN_FORM_CODE);
            if (!reader.IsDBNull(colIndex))
                formRole.FormCode = reader.GetString(colIndex);
        }

        #endregion
    }
}