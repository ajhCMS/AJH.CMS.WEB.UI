using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class FormDataMapper
    {
        #region Constant

        internal const string CN_FORM_ID = "FORM_ID";
        internal const string CN_FORM_NAME = "FORM_NAME";
        internal const string CN_FORM_DESCRIPTION = "FORM_DESCRIPTION";
        internal const string CN_FORM_URL = "FORM_URL";
        internal const string CN_FORM_CODE = "FORM_CODE";
        internal const string CN_FORM_IS_DELETED = "FORM_IS_DELETED";
        internal const string CN_FORM_MODULE_ID = "FORM_MODULE_ID";

        internal const string PN_FORM_ID = "P_FORM_ID";
        internal const string PN_FORM_NAME = "P_FORM_NAME";
        internal const string PN_FORM_DESCRIPTION = "P_FORM_DESCRIPTION";
        internal const string PN_FORM_URL = "P_FORM_URL";
        internal const string PN_FORM_CODE = "P_FORM_CODE";
        internal const string PN_FORM_IS_DELETED = "P_FORM_IS_DELETED";
        internal const string PN_FORM_MODULE_ID = "P_FORM_MODULE_ID";

        internal const string SN_FORM_ADD = "[SECURITY].[FormAdd]";
        internal const string SN_FORM_DELETE = "[SECURITY].[FormDelete]";
        internal const string SN_FORM_DELETE_LOGICAL = "[SECURITY].[FormDeleteLogical]";
        internal const string SN_FORM_GET_ALL = "[SECURITY].[FormGetAll]";
        internal const string SN_FORM_GET_BY_ID = "[SECURITY].[FormGetByID]";
        internal const string SN_FORM_GET_BY_CODE = "[SECURITY].[FormGetByCode]";
        internal const string SN_FORM_UPDATE = "[SECURITY].[FormUpdate]";

        #endregion

        #region FormDataMapper

        internal static int Add(Form formEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Url;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_CODE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Code;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    formEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_FORM_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formEntity.ID;
        }

        internal static void Update(Form formEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_DESCRIPTION, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Description;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_URL, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Url;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_CODE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.Code;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_FORM_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = formEntity.IsDeleted;
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
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_FORM_ID, System.Data.SqlDbType.Int);
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

        internal static List<Form> GetForms()
        {
            List<Form> colForms = null;
            Form form = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colForms = new List<Form>();
                    while (sqlDataReader.Read())
                    {
                        form = GetForm(colForms, sqlDataReader);
                        FillFromReader(form, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colForms;
        }

        internal static Form GetFormById(int FormID)
        {
            Form form = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_FORM_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = FormID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (form == null)
                            form = new Form();
                        FillFromReader(form, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return form;
        }

        internal static Form GetFormByFormCode(string FormCode)
        {
            Form form = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_FORM_GET_BY_CODE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_FORM_CODE, System.Data.SqlDbType.NVarChar);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = FormCode;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (form == null)
                            form = new Form();
                        FillFromReader(form, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return form;
        }

        #endregion

        #region GetFromReader

        internal static Form GetForm(List<Form> forms, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_FORM_ID);
            int value = reader.GetInt32(colIndex);

            Form form = forms.Where(c => c.ID == value).FirstOrDefault();
            if (form == null)
            {
                form = new Form();
                forms.Add(form);
            }
            return form;
        }

        internal static void FillFromReader(Form form, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_FORM_ID);
            if (!reader.IsDBNull(colIndex))
                form.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_CODE);
            if (!reader.IsDBNull(colIndex))
                form.Code = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                form.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                form.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                form.ModuleID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_NAME);
            if (!reader.IsDBNull(colIndex))
                form.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_FORM_URL);
            if (!reader.IsDBNull(colIndex))
                form.Url = reader.GetString(colIndex);
        }

        #endregion
    }
}