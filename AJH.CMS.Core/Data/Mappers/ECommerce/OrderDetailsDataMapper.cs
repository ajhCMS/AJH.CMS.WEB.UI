using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;
using System.Data.SqlClient;

namespace AJH.CMS.Core.Data
{
    internal static class OrderDetailsDataMapper
    {
        #region Constants
        internal const string CN_ORDER_DETAILS_ID = "ORDER_DETAILS_ID";
        internal const string CN_ORDER_DETAILS_ORDER_ID = "ORDER_DETAILS_ORDER_ID";
        internal const string CN_ORDER_DETAILS_AMOUNT = "ORDER_DETAILS_AMOUNT";
        internal const string CN_ORDER_DETAILS_PRODUCT_ID = "ORDER_DETAILS_PRODUCT_ID";
        internal const string CN_ORDER_DETAILS_CATEGORY_ID = "ORDER_DETAILS_CATEGORY_ID";
        internal const string CN_ORDER_DETAILS_CREATED_ON = "ORDER_DETAILS_CREATED_ON";
        internal const string CN_ORDER_DETAILS_STATUS = "ORDER_DETAILS_STATUS";
        internal const string CN_ORDER_DETAILS_XREF_ORDER_DETAILS = "ORDER_DETAILS_XREF_ORDER_DETAILS";

        internal const string PN_ORDER_DETAILS_ID = "P_ORDER_DETAILS_ID";
        internal const string PN_ORDER_DETAILS_ORDER_ID = "P_ORDER_DETAILS_ORDER_ID";
        internal const string PN_ORDER_DETAILS_AMOUNT = "P_ORDER_DETAILS_AMOUNT";
        internal const string PN_ORDER_DETAILS_PRODUCT_ID = "P_ORDER_DETAILS_PRODUCT_ID";
        internal const string PN_ORDER_DETAILS_CATEGORY_ID = "P_ORDER_DETAILS_CATEGORY_ID";
        internal const string PN_ORDER_DETAILS_CREATED_ON = "P_ORDER_DETAILS_CREATED_ON";
        internal const string PN_ORDER_DETAILS_STATUS = "P_ORDER_DETAILS_STATUS";
        internal const string PN_ORDER_DETAILS_XREF_ORDER_DETAILS = "P_ORDER_DETAILS_XREF_ORDER_DETAILS";

        internal const string SN_ORDER_DETAILS_ADD = "[ECOMMERCE].[OrderDetailsAdd]";
        internal const string SN_ORDER_DETAILS_DELETE = "[ECOMMERCE].[OrderDetailsDelete]";
        internal const string SN_ORDER_DETAILS_GET_ALL = "[ECOMMERCE].[OrderDetailsGetAll]";
        internal const string SN_ORDER_DETAILS_GET_BY_ID = "[ECOMMERCE].[OrderDetailsGetByID]";
        internal const string SN_ORDER_DETAILS_UPDATE = "[ECOMMERCE].[OrderDetailsUpdate]";
        internal const string SN_ORDER_DETAILS_GET_BY_ORDER_ID = "[ECOMMERCE].[OrderDetailsGetByOrderID]";


        #endregion

        #region OrderDataMapper

        internal static int Add(IEntity entity)
        {
            OrderDetails OrderDetailsEntity = (OrderDetails)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = OrderDetailsEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_AMOUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_AMOUNT;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_CATEGORY_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_CREATED_ON, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_CREATED_ON;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_ORDER_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_PRODUCT_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_XREF_ORDER_DETAILS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_XREF_ORDER_DETAILS;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    OrderDetailsEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ORDER_DETAILS_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return OrderDetailsEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            OrderDetails OrderDetailsEntity = (OrderDetails)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_AMOUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_AMOUNT;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_CATEGORY_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_CATEGORY_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_CREATED_ON, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_CREATED_ON;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_ORDER_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_PRODUCT_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_PRODUCT_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_XREF_ORDER_DETAILS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderDetailsEntity.ORDER_DETAILS_XREF_ORDER_DETAILS;
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
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ID, System.Data.SqlDbType.Int);
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

        internal static OrderDetails GetOrderDetailsByID(int id)
        {
            OrderDetails oOrderDetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (oOrderDetails == null)
                            oOrderDetails = new OrderDetails();

                        FillFromReader(oOrderDetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return oOrderDetails;
        }

        internal static List<OrderDetails> GetAllOrderDetails()
        {
            List<OrderDetails> colOrdersDetails = null;
            OrderDetails oOrderDetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrdersDetails = new List<OrderDetails>();
                    while (sqlDataReader.Read())
                    {
                        oOrderDetails = GetOrderDetails(colOrdersDetails, sqlDataReader);
                        FillFromReader(oOrderDetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrdersDetails;
        }

        internal static List<OrderDetails> GetOrderDetailsByOrderID(int OrderID)
        {
            List<OrderDetails> colOrderDetails = null;
            OrderDetails orderdetails = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DETAILS_GET_BY_ORDER_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_DETAILS_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderID;
                sqlCommand.Parameters.Add(sqlParameter);



                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrderDetails = new List<OrderDetails>();
                    while (sqlDataReader.Read())
                    {
                        orderdetails = GetOrderDetails(colOrderDetails, sqlDataReader);
                        FillFromReader(orderdetails, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrderDetails;
        }

        #endregion

        #region GetFromReader
        internal static OrderDetails GetOrderDetails(List<OrderDetails> oOrderDetails, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_ID);
            int value = reader.GetInt32(colIndex);

            OrderDetails orderDetails = oOrderDetails.Where(c => c.ID == value).FirstOrDefault();
            if (orderDetails == null)
            {
                orderDetails = new OrderDetails();
                oOrderDetails.Add(orderDetails);
            }
            return orderDetails;
        }

        internal static void FillFromReader(OrderDetails oOrderDetails, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_AMOUNT);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_AMOUNT = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_CATEGORY_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_CATEGORY_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_CREATED_ON);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_CREATED_ON = reader.GetDateTime(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_ORDER_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_ORDER_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_PRODUCT_ID);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_PRODUCT_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_STATUS);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_STATUS = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_DETAILS_XREF_ORDER_DETAILS);
            if (!reader.IsDBNull(colIndex))
                oOrderDetails.ORDER_DETAILS_XREF_ORDER_DETAILS = reader.GetInt32(colIndex);

            
        }

        #endregion
    }
}
