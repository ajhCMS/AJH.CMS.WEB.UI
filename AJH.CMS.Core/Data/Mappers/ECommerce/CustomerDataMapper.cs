using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using System.Data.SqlClient;   

namespace AJH.CMS.Core.Data
{
    internal static class CustomerDataMapper
    {
        #region Constants

        internal const string CN_CUSTOMER_ID="CUSTOMER_ID";
        internal const string CN_CUSTOMER_FNAME="CUSTOMER_FNAME";
        internal const string CN_CUSTOMER_LNAME="CUSTOMER_LNAME"; 
        internal const string CN_CUSTOMER_GENDER="CUSTOMER_GENDER"; 
        internal const string CN_CUSTOMER_BIRTHDAY ="CUSTOMER_BIRTHDAY";
        internal const string CN_CUSTOMER_ZIP_CODE ="CUSTOMER_ZIP_CODE";
        internal const string CN_CUSTOMER_COUNTRY="CUSTOMER_COUNTRY";
        internal const string CN_CUSTOMER_CITY="CUSTOMER_CITY";
        internal const string CN_CUSTOMER_ADDRESS1="CUSTOMER_ADDRESS1"; 
        internal const string CN_CUSTOMER_ADDRESS2="CUSTOMER_ADDRESS2"; 
        internal const string CN_CUSTOMER_ADDRESS3="CUSTOMER_ADDRESS3";
        internal const string CN_CUSTOMER_MOBILE_PHONE="CUSTOMER_MOBILE_PHONE"; 
        internal const string CN_CUSTOMER_HOME_PHONE="CUSTOMER_HOME_PHONE";
        internal const string CN_CUSTOMER_STATUS="CUSTOMER_STATUS";
        internal const string CN_CUSTOMER_NEWSLETTER="CUSTOMER_NEWSLETTER";
        internal const string CN_CUSTOMER_OPT_IN="CUSTOMER_OPT_IN";
        internal const string CN_CUSTOMER_USER_ID="CUSTOMER_USER_ID";

        internal const string PN_CUSTOMER_ID="P_CUSTOMER_ID";
        internal const string PN_CUSTOMER_FNAME="P_CUSTOMER_FNAME";
        internal const string PN_CUSTOMER_LNAME="P_CUSTOMER_LNAME"; 
        internal const string PN_CUSTOMER_GENDER="P_CUSTOMER_GENDER"; 
        internal const string PN_CUSTOMER_BIRTHDAY ="P_CUSTOMER_BIRTHDAY";
        internal const string PN_CUSTOMER_ZIP_CODE ="P_CUSTOMER_ZIP_CODE";
        internal const string PN_CUSTOMER_COUNTRY="P_CUSTOMER_COUNTRY";
        internal const string PN_CUSTOMER_CITY="P_CUSTOMER_CITY";
        internal const string PN_CUSTOMER_ADDRESS1="P_CUSTOMER_ADDRESS1"; 
        internal const string PN_CUSTOMER_ADDRESS2="P_CUSTOMER_ADDRESS2"; 
        internal const string PN_CUSTOMER_ADDRESS3="P_CUSTOMER_ADDRESS3";
        internal const string PN_CUSTOMER_MOBILE_PHONE="P_CUSTOMER_MOBILE_PHONE"; 
        internal const string PN_CUSTOMER_HOME_PHONE="P_CUSTOMER_HOME_PHONE";
        internal const string PN_CUSTOMER_STATUS="P_CUSTOMER_STATUS";
        internal const string PN_CUSTOMER_NEWSLETTER="P_CUSTOMER_NEWSLETTER";
        internal const string PN_CUSTOMER_OPT_IN="P_CUSTOMER_OPT_IN";
        internal const string PN_CUSTOMER_USER_ID = "P_CUSTOMER_USER_ID";

        internal const string SN_CUSTOMER_ADD = "[ECOMMERCE].[CustomerAdd]";
        internal const string SN_CUSTOMER_UPDATE = "[ECOMMERCE].[CustomerUpdate]";
        internal const string SN_CUSTOMER_DELETE = "[ECOMMERCE].[CustomerDelete]";
        internal const string SN_CUSTOMER_GET_BY_ID = "[ECOMMERCE].[CustomerGetByID]";
        internal const string SN_CUSTOMER_GET_BY_USERID = "[ECOMMERCE].[CustomerGetByUserID]";
        internal const string SN_CUSTOMER_GET_ALL = "[ECOMMERCE].[CustomerGetAll]";

        #endregion

        #region CustomerDataMapper

        internal static int Add(IEntity entity)
        {
            Customer CustomerEntity = (Customer)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_ADD, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlParameter.Value = CustomerEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_FNAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_FNAME;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_LNAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_LNAME;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_GENDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_GENDER;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_BIRTHDAY, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_BIRTHDAY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ZIP_CODE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ZIP_CODE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_COUNTRY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_COUNTRY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_CITY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_CITY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS1 , System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS1;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS2;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS3, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS3;
                sqlCommand.Parameters.Add(sqlParameter);
                
                sqlParameter = new SqlParameter(PN_CUSTOMER_MOBILE_PHONE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_MOBILE_PHONE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_HOME_PHONE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_HOME_PHONE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_NEWSLETTER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_NEWSLETTER;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_OPT_IN, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_OPT_IN;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_USER_ID;
                sqlCommand.Parameters.Add(sqlParameter);


                try
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    CustomerEntity.ID = Convert.ToInt32(sqlCommand.Parameters[PN_CUSTOMER_ID].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return CustomerEntity.ID;
        }

        internal static void Update(IEntity entity)
        {
            Customer CustomerEntity = (Customer)(entity);

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_UPDATE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.ID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_FNAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_FNAME;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_LNAME, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_LNAME;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_GENDER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_GENDER;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_BIRTHDAY, System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_BIRTHDAY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ZIP_CODE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ZIP_CODE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_COUNTRY, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_COUNTRY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_CITY, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_CITY;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS1, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS1;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS2, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS2;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_ADDRESS3, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_ADDRESS3;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_MOBILE_PHONE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_MOBILE_PHONE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_HOME_PHONE, System.Data.SqlDbType.NVarChar);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_HOME_PHONE;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_STATUS, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_STATUS;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_NEWSLETTER, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_NEWSLETTER;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_OPT_IN, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_OPT_IN;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter(PN_CUSTOMER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = CustomerEntity.CUSTOMER_USER_ID;
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
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_DELETE, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;

                sqlParameter = new SqlParameter(PN_CUSTOMER_ID, System.Data.SqlDbType.Int);
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

        internal static Customer GetCustomer(int id)
        {
            Customer oCustomer = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_GET_BY_ID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CUSTOMER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (oCustomer == null)
                            oCustomer = new Customer();

                        FillFromReader(oCustomer, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return oCustomer;
        }

        internal static List<Customer> GetAllCustomer()
        {
            List<Customer> colCustomers = null;
            Customer oCustomer = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_GET_ALL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    colCustomers = new List<Customer>();
                    while (sqlDataReader.Read())
                    {
                        oCustomer = GetCustomer(colCustomers, sqlDataReader);
                        FillFromReader(oCustomer, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return colCustomers;
        }

        internal static Customer GetCustomerByID(int id)
        {
            Customer oCustomer = null;

            using (SqlConnection sqlConnection = new SqlConnection(CMSCoreBase.CMSCoreConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(SN_CUSTOMER_GET_BY_USERID, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter(PN_CUSTOMER_USER_ID, System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = id;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (sqlDataReader.Read())
                    {
                        if (oCustomer == null)
                            oCustomer = new Customer();

                        FillFromReader(oCustomer, sqlDataReader);
                    }

                    sqlDataReader.Close();
                    sqlCommand.Connection.Close();
                }
            }
            return oCustomer;
        }
        #endregion

        #region GetFromReader

        internal static Customer GetCustomer(List<Customer> oCustomer, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CUSTOMER_ID);
            int value = reader.GetInt32(colIndex);

            Customer customer = oCustomer.Where(c => c.ID == value).FirstOrDefault();
            if (customer == null)
            {
                customer = new Customer();
                oCustomer.Add(customer);
            }
            return customer;
        }

        internal static void FillFromReader(Customer oCustomer, SqlDataReader reader)
        {
            int colIndex = 0;
            colIndex = reader.GetOrdinal(CN_CUSTOMER_ID);
            if (!reader.IsDBNull(colIndex))
                oCustomer.ID = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_FNAME);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_FNAME = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_LNAME);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_LNAME = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_GENDER);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_GENDER = (CMSEnums.Gender)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_BIRTHDAY);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_BIRTHDAY = reader.GetDateTime(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_ZIP_CODE);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_ZIP_CODE = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_COUNTRY);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_COUNTRY = reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_CITY);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_CITY = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_ADDRESS1);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_ADDRESS1 = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_ADDRESS2);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_ADDRESS2 = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_ADDRESS3);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_ADDRESS3 = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_MOBILE_PHONE);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_MOBILE_PHONE = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_HOME_PHONE);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_HOME_PHONE = reader.GetString(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_STATUS);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_STATUS = (CMSEnums.AccessType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_NEWSLETTER);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_NEWSLETTER = (CMSEnums.AccessType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_OPT_IN);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_OPT_IN = (CMSEnums.AccessType)reader.GetInt32(colIndex);

            colIndex = reader.GetOrdinal(CN_CUSTOMER_USER_ID);
            if (!reader.IsDBNull(colIndex))
                oCustomer.CUSTOMER_USER_ID = reader.GetInt32(colIndex);
        }

        #endregion
    }
}
