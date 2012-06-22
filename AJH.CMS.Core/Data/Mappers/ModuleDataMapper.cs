using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class ModuleDataMapper
    {
        #region Constant

        internal const string CN_MODULE_ID = "MODULE_ID";
        internal const string CN_MODULE_NAME = "MODULE_NAME";
        internal const string CN_MODULE_DESCRIPTION = "MODULE_DESCRIPTION";
        internal const string CN_MODULE_IMAGE = "MODULE_IMAGE";
        internal const string CN_MODULE_IS_DELETED = "MODULE_IS_DELETED";
        internal const string CN_MODULE_CREATED_BY = "MODULE_CREATED_BY";
        internal const string CN_MODULE_CREATION_DAY = "MODULE_CREATION_DAY";
        internal const string CN_MODULE_CREATION_SEC = "MODULE_CREATION_SEC";
        internal const string CN_MODULE_PARENT_ID = "MODULE_PARENT_ID";

        internal const string PN_MODULE_ID = "P_MODULE_ID";
        internal const string PN_MODULE_NAME = "P_MODULE_NAME";
        internal const string PN_MODULE_DESCRIPTION = "P_MODULE_DESCRIPTION";
        internal const string PN_MODULE_IMAGE = "P_MODULE_IMAGE";
        internal const string PN_MODULE_IS_DELETED = "P_MODULE_IS_DELETED";
        internal const string PN_MODULE_CREATED_BY = "P_MODULE_CREATED_BY";
        internal const string PN_MODULE_CREATION_DAY = "P_MODULE_CREATION_DAY";
        internal const string PN_MODULE_CREATION_SEC = "P_MODULE_CREATION_SEC";
        internal const string PN_MODULE_PARENT_ID = "P_MODULE_PARENT_ID";

        internal const string SN_MODULE_GET_ALL = "[SETUP].[ModuleGetAll]";
        internal const string SN_MODULE_GET_BY_PARENT_ID = "[SETUP].[ModuleGetByParentID]";

        #endregion

        #region ModuleDataMapper

        internal static List<Module> GetModules()
        {
            List<Module> colModules = null;
            Module module = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MODULE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colModules = new List<Module>();
                    while (sqlDataReader.Read())
                    {
                        module = GetModule(colModules, sqlDataReader);
                        FillFromReader(module, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colModules;
        }

        internal static List<Module> GetModules(int ParentID)
        {
            List<Module> colModules = null;
            Module module = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_MODULE_GET_BY_PARENT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_MODULE_PARENT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ParentID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colModules = new List<Module>();
                    while (sqlDataReader.Read())
                    {
                        module = GetModule(colModules, sqlDataReader);
                        FillFromReader(module, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colModules;
        }

        #endregion

        #region GetFromReader

        internal static Module GetModule(List<Module> modules, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_MODULE_ID);
            int value = reader.GetInt32(colIndex);

            Module module = modules.Where(c => c.ID == value).FirstOrDefault();
            if (module == null)
            {
                module = new Module();
                modules.Add(module);
            }
            return module;
        }

        internal static void FillFromReader(Module module, SqlDataReader reader)
        {
            int colIndex = 0;

            colIndex = reader.GetOrdinal(CN_MODULE_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                module.CreatedBy = reader.GetInt32(colIndex);

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_MODULE_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            module.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_MODULE_DESCRIPTION);
            if (!reader.IsDBNull(colIndex))
                module.Description = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_ID);
            if (!reader.IsDBNull(colIndex))
                module.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_IMAGE);
            if (!reader.IsDBNull(colIndex))
                module.Image = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                module.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_NAME);
            if (!reader.IsDBNull(colIndex))
                module.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_MODULE_PARENT_ID);
            if (!reader.IsDBNull(colIndex))
                module.ParentID = reader.GetInt32(colIndex);
        }

        #endregion
    }
}