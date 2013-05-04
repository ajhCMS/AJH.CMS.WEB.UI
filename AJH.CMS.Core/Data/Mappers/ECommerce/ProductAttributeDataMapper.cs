using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    internal static class ProductAttributeDataMapper
    {
        #region Constant
        internal const string CN_PRODUCT_ATTRIBUTE_ID = "PRODUCT_ATTRIBUTE_ID";
        internal const string CN_PRODUCT_ATTRIBUTE_ATTRIBUTE_ID = "PRO_ATT_ATTRIBUTE_ID";
        internal const string CN_PRODUCT_ATTRIBUTE_PRODUCT_ID = "PRO_ATT_PRODUCT_ID";
        internal const string CN_PRODUCT_ATTRIBUTE_DETAILS = "PRO_ATT_DETAILS";
        internal const string CN_ATTRIBUTE_ID = "ATTRIBUTE_ID";
        internal const string CN_ECO_LAN_NAME = "ECO_LAN_NAME";
        internal const string CN_GROUP_ID = "GROUP_ID";
        internal const string CN_GroupName = "GroupName";

        internal const string PN_PRODUCT_ATTRIBUTE_ID = "P_PRODUCT_ATTRIBUTE_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_ATTRIBUTE_ID = "P_PRO_ATT_ATTRIBUTE_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_PRODUCT_ID = "P_PRO_ATT_PRODUCT_ID";
        internal const string PN_PRODUCT_ATTRIBUTE_DETAILS = "P_PRO_ATT_DETAILS";

        internal const string SN_ATTRIBUTE_GET_BY_PRODUCT_ID = "[ECOMMERCE].[AttributeGetByProductID]";
        #endregion

        #region AttributeDataMapper
        internal static List<AJH.CMS.Core.Entities.ProductAttribute> GetAttributeByProductId(int productID, int languageID)
        {
            List<AJH.CMS.Core.Entities.ProductAttribute> colAttribute = null;
            AJH.CMS.Core.Entities.ProductAttribute attribute = null;

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
                    colAttribute = new List<AJH.CMS.Core.Entities.ProductAttribute>();
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

        private static void FillFromReader(Entities.ProductAttribute attribute, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_ATTRIBUTE_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GROUP_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.GROUP_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_GroupName);
            if (!reader.IsDBNull(colIndex))
                attribute.GroupName = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(ECommerceDataMapperBase.CN_ECO_LAN_NAME);
            if (!reader.IsDBNull(colIndex))
                attribute.ECO_LAN_NAME = reader.GetString(colIndex);


            colIndex = reader.GetOrdinal(CN_ATTRIBUTE_ID);
            if (!reader.IsDBNull(colIndex))
                attribute.AttributeID = reader.GetInt32(colIndex);
        }
        #endregion

        #region GetFromReader
        internal static AJH.CMS.Core.Entities.ProductAttribute GetAttribute(List<AJH.CMS.Core.Entities.ProductAttribute> attributes, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_PRODUCT_ATTRIBUTE_ID);
            int value = reader.GetInt32(colIndex);

            AJH.CMS.Core.Entities.ProductAttribute attribute = attributes.Where(c => c.ID == value).FirstOrDefault();
            if (attribute == null)
            {
                attribute = new AJH.CMS.Core.Entities.ProductAttribute();
                attributes.Add(attribute);
            }
            return attribute;
        }

    
        #endregion

    }
}
