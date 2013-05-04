using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;
using System.Data.SqlClient;

namespace AJH.CMS.Core.Data
{
    internal static class OrderDataMapper
    {
        
        #region Constant

        internal const string CN_ORDER_ID = "ORDER_ID";
        internal const string CN_ORDER_CUSTOMER_ID = "ORDER_CUSTOMER_ID";
        internal const string CN_ORDER_CREATED_ON = "ORDER_CREATED_ON";
        internal const string CN_ORDER_STATUS = "ORDER_STATUS";
        internal const string CN_ORDER_TOTAL_AMOUNT = "ORDER_TOTAL_AMOUNT";
        internal const string CN_XREF_ODER = "XREF_ODER";

        internal const string PN_ORDER_ID = "P_ORDER_ID";
        internal const string PN_ORDER_CUSTOMER_ID = "P_ORDER_CUSTOMER_ID";
        internal const string PN_ORDER_CREATED_ON = "P_ORDER_CREATED_ON";
        internal const string PN_ORDER_STATUS = "P_ORDER_STATUS";
        internal const string PN_ORDER_TOTAL_AMOUNT = "P_ORDER_TOTAL_AMOUNT";
        internal const string PN_XREF_ODER = "P_XREF_ODER";

        internal const string SN_ORDER_ADD = "[ECOMMERCE].[OrderAdd]";
        internal const string SN_ORDER_DELETE = "[ECOMMERCE].[OrderDelete]";
        internal const string SN_ORDER_GET_ALL = "[ECOMMERCE].[OrderGetALL]";
        internal const string SN_ORDER_GET_BY_ID = "[ECOMMERCE].[OrderGetByID]";
        internal const string SN_ORDER_UPDATE = "[ECOMMERCE].[OrderUpdate]";
        internal const string SN_ORDER_GET_BY_CUSTOMER_ID = "[ECOMMERCE].[OrderGetByCustomerID]";

        #endregion 

        #region OrderDataMapper

        internal static int Add(IEntity entity)
        {
            Order OrderEntity = (Order)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = OrderEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_CUSTOMER_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_CREATED_ON, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_CREATED_ON;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_TOTAL_AMOUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_TOTAL_AMOUNT;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XREF_ODER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.XREF_ODER;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    OrderEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_ORDER_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return OrderEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Order OrderEntity = (Order)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_CUSTOMER_ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_CREATED_ON, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_CREATED_ON;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_ORDER_TOTAL_AMOUNT, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.ORDER_TOTAL_AMOUNT;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_XREF_ODER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = OrderEntity.XREF_ODER;
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
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_ID, System.Data.SqlDbType.Int);
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

        internal static Order GetOrderByID(int id)
        {
            Order oOrder = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_ORDER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (oOrder == null)
                            oOrder = new Order();

                        FillFromReader(oOrder, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return oOrder;
        }

        internal static List<Order> GetAllOrder()
        {
            List<Order> colOrders = null;
            Order oOrder = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrders = new List<Order>();
                    while (sqlDataReader.Read())
                    {
                        oOrder = GetOrder(colOrders, sqlDataReader);
                        FillFromReader(oOrder, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrders;
        }

        internal static List<Order> GetOrderByCustomerID(int customerID)
        {
            List<Order> colOrder = null;
            Order order = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_ORDER_GET_BY_CUSTOMER_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_ORDER_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = customerID;
                sqlCommand.Parameters.Add(sqlParameter);

                

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colOrder = new List<Order>();
                    while (sqlDataReader.Read())
                    {
                        order = GetOrder(colOrder, sqlDataReader);
                        FillFromReader(order, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colOrder;
        }

        #endregion

        #region GetFromReader
        internal static Order GetOrder(List<Order> oOrder, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORDER_ID);
            int value = reader.GetInt32(colIndex);

            Order order = oOrder.Where(c => c.ID == value).FirstOrDefault();
            if (order == null)
            {
                order = new Order();
                oOrder.Add(order);
            }
            return order;
        }

        internal static void FillFromReader(Order oOrder, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_ORDER_ID);
            if (!reader.IsDBNull(colIndex))
                oOrder.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_CREATED_ON);
            if (!reader.IsDBNull(colIndex))
                oOrder.ORDER_CREATED_ON = reader.GetDateTime(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_CUSTOMER_ID);
            if (!reader.IsDBNull(colIndex))
                oOrder.ORDER_CUSTOMER_ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_STATUS);
            if (!reader.IsDBNull(colIndex))
                oOrder.ORDER_STATUS = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_ORDER_TOTAL_AMOUNT);
            if (!reader.IsDBNull(colIndex))
                oOrder.ORDER_TOTAL_AMOUNT = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_XREF_ODER);
            if (!reader.IsDBNull(colIndex))
                oOrder.XREF_ODER = reader.GetInt32(colIndex);
        }

        #endregion
    }
}
