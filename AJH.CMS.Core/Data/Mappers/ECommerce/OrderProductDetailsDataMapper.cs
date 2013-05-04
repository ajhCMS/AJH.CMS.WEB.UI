using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;
using System.Data.SqlClient;

namespace AJH.CMS.Core.Data
{
    internal static class OrderProductDetailsDataMapper
    {
        #region Constant
        internal const string CN_ORD_PRO_DET_ID = "ORD_PRO_DET_ID";
        internal const string CN_ORD_PRO_DET_PRODUCT_ID = "ORD_PRO_DET_PRODUCT_ID";
        internal const string CN_ORD_PRO_DET_ATTRIBUTE_ID = "ORD_PRO_DET_ATTRIBUTE_ID";
        internal const string CN_ORD_PRO_DET_DETAILS_ID = "ORD_PRO_DET_DETAILS_ID";
        internal const string CN_ORD_PRO_DET_XREF_PRODUCT_DETAILS = "ORD_PRO_DET_XREF_PRODUCT_DETAILS";

        internal const string PN_ORD_PRO_DET_ID = "P_ORD_PRO_DET_ID";
        internal const string PN_ORD_PRO_DET_PRODUCT_ID = "P_ORD_PRO_DET_PRODUCT_ID";
        internal const string PN_ORD_PRO_DET_ATTRIBUTE_ID = "P_ORD_PRO_DET_ATTRIBUTE_ID";
        internal const string PN_ORD_PRO_DET_DETAILS_ID = "P_ORD_PRO_DET_DETAILS_ID";
        internal const string PN_ORD_PRO_DET_XREF_PRODUCT_DETAILS = "P_ORD_PRO_DET_XREF_PRODUCT_DETAILS";

        internal const string SN_ORDER_PRODUCT_DETAILS_ADD = "[ECOMMERCE].[OrderProductDetailsAdd]";
        internal const string SN_ORDER_PRODUCT_DETAILS_DELETE = "[ECOMMERCE].[OrderProductDetailsDelete]";
        internal const string SN_ORDER_PRODUCT_DETAILS_GET_ALL = "[ECOMMERCE].[OrderProductDetailsGetAll]";
        internal const string SN_ORDER_PRODUCT_DETAILS_GET_BY_DETAILS_ID = "[ECOMMERCE].[OrderProductDetailsGetByDetailsID]";
        internal const string SN_ORDER_PRODUCT_DETAILS_GET_BY_ID = "[ECOMMERCE].[OrderProductDetailsGetByID]";
        internal const string SN_ORDER_PRODUCT_DETAILS_UPDATE = "[ECOMMERCE].[OrderProductDetailsUpdate]";
        #endregion

        #region OrderDataMapper

        internal static int Add(IEntity entity)
        {
            OrderProductDetails OrderProductDetailsEntity = (OrderProductDetails)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = OrderProductDetailsEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_ATTRIBUTE_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_DETAILS_ID, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_DETAILS_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_PRODUCT_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_XREF_PRODUCT_DETAILS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_XREF_PRODUCT_DETAILS;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    OrderProductDetailsEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ORD_PRO_DET_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return OrderProductDetailsEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            OrderProductDetails OrderProductDetailsEntity = (OrderProductDetails)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;


                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ATTRIBUTE_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_ATTRIBUTE_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_DETAILS_ID, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_DETAILS_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_PRODUCT_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_XREF_PRODUCT_DETAILS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderProductDetailsEntity.ORD_PRO_DET_XREF_PRODUCT_DETAILS;
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
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ID, System.Data.SqlDbType.Int);
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

        internal static OrderProductDetails GetOrderProductDetailsByID(int id)
        {
            OrderProductDetails oOrderProductDetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (oOrderProductDetails == null)
                            oOrderProductDetails = new OrderProductDetails();

                        FillFromReader(oOrderProductDetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return oOrderProductDetails;
        }

        internal static List<OrderProductDetails> GetAllOrderProductsDetails()
        {
            List<OrderProductDetails> colOrderProductDetails = null;
            OrderProductDetails oOrderProductDetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrderProductDetails = new List<OrderProductDetails>();
                    while (sqlDataReader.Read())
                    {
                        oOrderProductDetails = GetOrderProductDetails(colOrderProductDetails, sqlDataReader);
                        FillFromReader(oOrderProductDetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrderProductDetails;
        }

        internal static List<OrderProductDetails> GetOrderProductDetailsByDetailsID(int OrderDetailsID)
        {
            List<OrderProductDetails> colOrderProductDetails = null;
            OrderProductDetails oOrderProductDetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_PRODUCT_DETAILS_GET_BY_DETAILS_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORD_PRO_DET_DETAILS_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsID;
                sqlCommand.Parameters.Add(sqlParameter);



                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrderProductDetails = new List<OrderProductDetails>();
                    while (sqlDataReader.Read())
                    {
                        oOrderProductDetails = GetOrderProductDetails(colOrderProductDetails, sqlDataReader);
                        FillFromReader(oOrderProductDetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrderProductDetails;
        }

        #endregion

        #region GetFromReader
        internal static OrderProductDetails GetOrderProductDetails(List<OrderProductDetails> oOrderProductDetails, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_ID);
            int value = reader.GetInt32(colIndex);

            OrderProductDetails orderproductdetails = oOrderProductDetails.Where(c => c.ID == value).FirstOrDefault();
            if (orderproductdetails == null)
            {
                orderproductdetails = new OrderProductDetails();
                oOrderProductDetails.Add(orderproductdetails);
            }
            return orderproductdetails;
        }

        internal static void FillFromReader(OrderProductDetails oOrderProductDetails, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderProductDetails.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_ATTRIBUTE_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderProductDetails.ORD_PRO_DET_ATTRIBUTE_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_DETAILS_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderProductDetails.ORD_PRO_DET_DETAILS_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderProductDetails.ORD_PRO_DET_PRODUCT_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORD_PRO_DET_XREF_PRODUCT_DETAILS);
            if (!reader.IsDBNull(colIndex))
                oOrderProductDetails.ORD_PRO_DET_XREF_PRODUCT_DETAILS = reader.GetInt32(colIndex);

        }

        #endregion
    }
}
