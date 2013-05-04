using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class AttributeDataMapper
    {
        #region Constants

        internal const string CN_ATTRIBUTE_GROUP_ID = "ATTRIBUTE_GROUP_ID";
        internal const string CN_ATTRIBUTE_PORTAL_ID = "ATTRIBUTE_PORTAL_ID";
        internal const string CN_ATTRIBUTE_ID = "ATTRIBUTE_ID";
        internal const string CN_ATTRIBUTE_IS_DELETED = "ATTRIBUTE_IS_DELETED";

        internal const string CN_PRODUCT_ATTRIBUTE_ATTRIBUTE_ID = "PRO_ATT_ATTRIBUTE_ID";
        internal const string CN_PRODUCT_ATTRIBUTE_PRODUCT_ID = "PRO_ATT_PRODUCT_ID";
        internal const string CN_PRODUCT_ATTRIBUTE_DETAILS = "PRO_ATT_DETAILS";

        internal const string PN_ATTRIBUTE_ID = "P_ATTRIBUTE_ID";
        internal const string PN_ATTRIBUTE_PORTAL_ID = "P_ATTRIBUTE_PORTAL_ID";
        internal const string PN_ATTRIBUTE_NAME = "P_ATTRIBUTE_NAME";
        internal const string PN_ATTRIBUTE_GROUP_ID = "P_ATTRIBUTE_GROUP_ID";

        internal const string PN_PRODUCT_ATTRIBUTE_ID = "P_PRODUCT_ATTRIBUTE_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_ATTRIBUTE_ID = "P_PRO_ATT_ATTRIBUTE_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_PRODUCT_ID = "P_PRO_ATT_PRODUCT_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_DETAILS = "P_PRO_ATT_DETAILS";

        internal const string SN_ATTRIBUTE_ADD = "[ECOMMERCE].[AttributeAdd]";
        internal const string SN_ATTRIBUTE_UPDATE = "[ECOMMERCE].[AttributeUpdate]";
        internal const string SN_ATTRIBUTE_DELETE = "[ECOMMERCE].[AttributeDelete]";
        internal const string SN_ATTRIBUTE_ADD_OTHER_LANGUAGE = "[ECOMMERCE].[AttributeAddOtherLang]";
        internal const string SN_ATTRIBUTE_DELETE_LOGICAL = "[ECOMMERCE].[AttributeDeleteLogical]";
        internal const string SN_ATTRIBUTE_GET_BY_ID = "[ECOMMERCE].[AttributeGetByID]";
        internal const string SN_ATTRIBUTE_GET_ALL = "[ECOMMERCE].[AttributeGetAll]";
        internal const string SN_ATTRIBUTE_GET_BY_COMBINATION_ID = "[ECOMMERCE].[AttributeGetByCombinationID]";
        internal const string SN_ATTRIBUTE_GET_BY_GROUP_ID = "[ECOMMERCE].[AttributeGetByGroupID]";

        internal const string SN_PRODUCT_ATTRIBUTE_ADD = "[ECOMMERCE].[ProductAttributeAdd]";
        internal const string SN_PRODUCT_ATTRIBUTE_DELETE = "[ECOMMERCE].[ProductAttributeDelete]";
        internal const string SN_PRODUCT_ATTRIBUTE_UPDATE="[ECOMMERCE].[ProductAttributeUpdate]";
        internal const string SN_ATTRIBUTE_GET_BY_PRODUCT_ID="[ECOMMERCE].[AttributeGetByProductID]";
        #endregion

        #region AttributeDataMapper

        internal static int Add(IEntity entity)
        {
            AJH.CMS.Core.Entities.Attribute attributeEntity = (AJH.CMS.Core.Entities.Attribute)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = attributeEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlParameter = new SqlParameter(PN_ATTRIBUTE_GROUP_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.GroupID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.LanguageID;
                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    attributeEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ATTRIBUTE_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return attributeEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            AJH.CMS.Core.Entities.Attribute attributeEntity = (AJH.CMS.Core.Entities.Attribute)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);


                sqlParameter = new SqlParameter(PN_ATTRIBUTE_GROUP_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.GroupID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_PORTAL_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.PortalID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.LanguageID;
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

        internal static void AddOtherLanguage(IEntity entity)
        {
            AJH.CMS.Core.Entities.Attribute attributeEntity = (AJH.CMS.Core.Entities.Attribute)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_ADD_OTHER_LANGUAGE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_NAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.Name;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.ModuleID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeEntity.LanguageID;
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

        internal static void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
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

        internal static void DeleteLogical(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_DELETE_LOGICAL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
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

        internal static List<AJH.CMS.Core.Entities.Attribute> GetAttributes(int languageID)
        {
            List<AJH.CMS.Core.Entities.Attribute> colAttributes = null;
            AJH.CMS.Core.Entities.Attribute attribute = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Attribute;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colAttributes = new List<AJH.CMS.Core.Entities.Attribute>();
                    while (sqlDataReader.Read())
                    {
                        attribute = GetAttribute(colAttributes, sqlDataReader);
                        FillFromReader(attribute, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colAttributes;
        }

        internal static List<AJH.CMS.Core.Entities.Attribute> GetAttributesByCombinationID(int combinationID, int languageID)
        {
            List<AJH.CMS.Core.Entities.Attribute> colAttributes = null;
            AJH.CMS.Core.Entities.Attribute attribute = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_GET_BY_COMBINATION_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(CombinationProductDataMapper.PN_COMBINATION_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combinationID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Attribute;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colAttributes = new List<AJH.CMS.Core.Entities.Attribute>();
                    while (sqlDataReader.Read())
                    {
                        attribute = GetAttribute(colAttributes, sqlDataReader);
                        FillFromReader(attribute, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colAttributes;
        }

        internal static List<AJH.CMS.Core.Entities.Attribute> GetAttributesByGroupID(int groupID, int languageID)
        {
            List<AJH.CMS.Core.Entities.Attribute> colAttributes = null;
            AJH.CMS.Core.Entities.Attribute attribute = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_GET_BY_GROUP_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(GroupDataMapper.PN_GROUP_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = groupID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Attribute;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colAttributes = new List<AJH.CMS.Core.Entities.Attribute>();
                    while (sqlDataReader.Read())
                    {
                        attribute = GetAttribute(colAttributes, sqlDataReader);
                        FillFromReader(attribute, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colAttributes;
        }

        internal static AJH.CMS.Core.Entities.Attribute GetAttribute(int id, int languageID)
        {
            AJH.CMS.Core.Entities.Attribute attribute = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Attribute;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        attribute = new Entities.Attribute();
                        FillFromReader(attribute, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return attribute;
        }

        internal static void AddProductAttribute(int attributeID,int ProductID,string Details)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_ATTRIBUTE_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ATTRIBUTE_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = attributeID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_ATTRIBUTE_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_PRODUCT_ATTRIBUTE_DETAILS, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = Details;
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

        internal static void DeleteProductAttribute(int ProductAttrbuteID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_PRODUCT_ATTRIBUTE_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_PRODUCT_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ProductAttrbuteID;
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

        internal static List<AJH.CMS.Core.Entities.Attribute> GetAttributeByProductId(int productID, int languageID)
        {
            List<AJH.CMS.Core.Entities.Attribute> colAttribute = null;
            AJH.CMS.Core.Entities.Attribute attribute = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ATTRIBUTE_GET_BY_PRODUCT_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_PRODUCT_ATTRIBUTE_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = productID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_ECO_LAN_LAN_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = languageID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(ECommerceDataMapperBase.PN_MODULE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = (int)CMSEnums.ECommerceModule.Attribute;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colAttribute= new List<AJH.CMS.Core.Entities.Attribute>();
                    while (sqlDataReader.Read())
                    {
                        attribute = GetAttribute(colAttribute, sqlDataReader);
                        FillFromReader(attribute, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colAttribute;
        }

        #endregion

        #region GetFromReader

        internal static AJH.CMS.Core.Entities.Attribute GetAttribute(List<AJH.CMS.Core.Entities.Attribute> attributes, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_ID);
            int value = reader.GetInt32(colIndex);

            AJH.CMS.Core.Entities.Attribute attribute = attributes.Where(c => c.ID == value).FirstOrDefault();
            if (attribute == null)
            {
                attribute = new AJH.CMS.Core.Entities.Attribute();
                attributes.Add(attribute);
            }
            return attribute;
        }

        internal static void FillFromReader(AJH.CMS.Core.Entities.Attribute attribute, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_GROUP_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.GroupID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_PORTAL_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.PortalID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                attribute.Name = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_LAN_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.LanguageID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_IS_DELETED);
            if (!reader.IsDBNull(colIndex))
                attribute.IsDeleted = reader.GetBoolean(colIndex);

        }

        #endregion
    }
}