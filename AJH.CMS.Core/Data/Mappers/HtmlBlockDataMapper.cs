using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    internal static class HtmlBlockDataMapper
    {
        #region Constant

        internal const string CN_HTMLBLOCK_ID = "HTMLBLOCK_ID";
        internal const string CN_HTMLBLOCK_NAME = "HTMLBLOCK_NAME";
        internal const string CN_HTMLBLOCK_DETAILS = "HTMLBLOCK_DETAILS";
        internal const string CN_HTMLBLOCK_IS_DELETED = "HTMLBLOCK_IS_DELETED";
        internal const string CN_HTMLBLOCK_PORTAL_ID = "HTMLBLOCK_PORTAL_ID";
        internal const string CN_HTMLBLOCK_LANGUAGE_ID = "HTMLBLOCK_LANGUAGE_ID";
        internal const string CN_HTMLBLOCK_CREATION_DAY = "HTMLBLOCK_CREATION_DAY";
        internal const string CN_HTMLBLOCK_CREATION_SEC = "HTMLBLOCK_CREATION_SEC";
        internal const string CN_HTMLBLOCK_CREATED_BY = "HTMLBLOCK_CREATED_BY";

        internal const string PN_HTMLBLOCK_ID = "P_HTMLBLOCK_ID";
        internal const string PN_HTMLBLOCK_NAME = "P_HTMLBLOCK_NAME";
        internal const string PN_HTMLBLOCK_DETAILS = "P_HTMLBLOCK_DETAILS";
        internal const string PN_HTMLBLOCK_IS_DELETED = "P_HTMLBLOCK_IS_DELETED";
        internal const string PN_HTMLBLOCK_PORTAL_ID = "P_HTMLBLOCK_PORTAL_ID";
        internal const string PN_HTMLBLOCK_LANGUAGE_ID = "P_HTMLBLOCK_LANGUAGE_ID";
        internal const string PN_HTMLBLOCK_CREATION_DAY = "P_HTMLBLOCK_CREATION_DAY";
        internal const string PN_HTMLBLOCK_CREATION_SEC = "P_HTMLBLOCK_CREATION_SEC";
        internal const string PN_HTMLBLOCK_CREATED_BY = "P_HTMLBLOCK_CREATED_BY";

        internal const string SN_HTMLBLOCK_ADD = "[SETUP].[HtmlBlockAdd]";
        internal const string SN_HTMLBLOCK_DELETE = "[SETUP].[HtmlBlockDelete]";
        internal const string SN_HTMLBLOCK_DELETE_LOGICAL = "[SETUP].[HtmlBlockDeleteLogical]";
        internal const string SN_HTMLBLOCK_GET_ALL = "[SETUP].[HtmlBlockGetAll]";
        internal const string SN_HTMLBLOCK_GET_BY_ID = "[SETUP].[HtmlBlockGetByID]";
        internal const string SN_HTMLBLOCK_GET_BY_PORTAL_LANGUAGE = "[SETUP].[HtmlBlockGetByPortalLanguage]";
        internal const string SN_HTMLBLOCK_UPDATE = "[SETUP].[HtmlBlockUpdate]";

        #endregion

        #region HtmlBlockDataMapper

        internal static int Add(IEntity entity)
        {
            HtmlBlock htmlBlockEntity = (HtmlBlock)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(htmlBlockEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.CreatedBy;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    htmlBlockEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_HTMLBLOCK_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return htmlBlockEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            HtmlBlock htmlBlockEntity = (HtmlBlock)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                double days = 0;
                double seconds = 0;
                CMSCoreHelper.GetDaySecondsNumber(htmlBlockEntity.CreationDate, out days, out seconds);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATION_DAY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)days;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATION_SEC, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)seconds;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_DETAILS, System.Data.SqlDbType.NText);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.Details;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_IS_DELETED, System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.IsDeleted;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_CREATED_BY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = htmlBlockEntity.CreatedBy;
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
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_ID, System.Data.SqlDbType.Int);
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
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_ID, System.Data.SqlDbType.Int);
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

        internal static List<HtmlBlock> GetHtmlBlocks()
        {
            List<HtmlBlock> colHtmlBlocks = null;
            HtmlBlock htmlBlock = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colHtmlBlocks = new List<HtmlBlock>();
                    while (sqlDataReader.Read())
                    {
                        htmlBlock = GetHtmlBlock(colHtmlBlocks, sqlDataReader);
                        FillFromReader(htmlBlock, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colHtmlBlocks;
        }

        internal static List<HtmlBlock> GetHtmlBlocks(int PortalID, int LanguageID)
        {
            List<HtmlBlock> colHtmlBlocks = null;
            HtmlBlock htmlBlock = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_GET_BY_PORTAL_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_HTMLBLOCK_LANGUAGE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colHtmlBlocks = new List<HtmlBlock>();
                    while (sqlDataReader.Read())
                    {
                        htmlBlock = GetHtmlBlock(colHtmlBlocks, sqlDataReader);
                        FillFromReader(htmlBlock, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colHtmlBlocks;
        }

        internal static HtmlBlock GetHtmlBlockById(int HtmlBlockID)
        {
            HtmlBlock htmlBlock = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_HTMLBLOCK_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter(PN_HTMLBLOCK_ID, System.Data.SqlDbType.Int);
                parameter.Direction = System.Data.ParameterDirection.Input;
                parameter.Value = HtmlBlockID;
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        if (htmlBlock == null)
                            htmlBlock = new HtmlBlock();
                        FillFromReader(htmlBlock, reader);
                    }
                    reader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return htmlBlock;
        }

        #endregion

        #region GetFromReader

        internal static HtmlBlock GetHtmlBlock(List<HtmlBlock> htmlBlocks, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_ID);
            int value = reader.GetInt32(colIndex);

            HtmlBlock htmlBlock = htmlBlocks.Where(c => c.ID == value).FirstOrDefault();
            if (htmlBlock == null)
            {
                htmlBlock = new HtmlBlock();
                htmlBlocks.Add(htmlBlock);
            }
            return htmlBlock;
        }

        internal static void FillFromReader(HtmlBlock htmlBlock, SqlDataReader reader)
        {
            int colIndex = 0;

            int days = 0, seconds = 0;
            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_CREATION_DAY);
            if (!reader.IsDBNull(colIndex))
                days = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_CREATION_SEC);
            if (!reader.IsDBNull(colIndex))
                seconds = reader.GetInt32(colIndex);

            htmlBlock.CreationDate = CMSCoreHelper.GetDateTime(days, seconds);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_DETAILS);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.Details = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_ID);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.IsDeleted = reader.GetBoolean(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_LANGUAGE_ID);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_NAME);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_HTMLBLOCK_CREATED_BY);
            if (!reader.IsDBNull(colIndex))
                htmlBlock.CreatedBy = reader.GetInt32(colIndex);
        }

        #endregion
    }
}