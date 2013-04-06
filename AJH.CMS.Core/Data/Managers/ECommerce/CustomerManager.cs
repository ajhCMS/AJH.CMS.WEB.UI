using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;
using System.Web;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.Core.Data
{
    public static class CustomerManager
    {
        internal const string CUSTOMER_CURRENT_KEY = "CUSTOMER_CURRENT_KEY";

        public static int Add(Customer oCustomer)
        {
            return CustomerDataMapper.Add(oCustomer);
        }

        public static void Update(Customer oCustomer)
        {
            CustomerDataMapper.Update(oCustomer);
        }

        public static void Delete(int id)
        {
            CustomerDataMapper.Delete(id);
        }

        public static List<Customer> GetCustomers()
        {
            return CustomerDataMapper.GetAllCustomer();
        }

        public static Customer GetCustomer(int id)
        {
            return CustomerDataMapper.GetCustomer(id);
        }

        public static Customer GetCustomerByUserID(int id)
        {
            return CustomerDataMapper.GetCustomerByID(id);
        }

        public static Customer GetCurrentCustomer()
        {
            Customer customer = null;
            User user = UserManager.GetCurrentUser();
            if (user == null)
                return null;

            if (HttpContext.Current.Session[CUSTOMER_CURRENT_KEY] != null)
            {
                customer = HttpContext.Current.Session[CUSTOMER_CURRENT_KEY] as Customer;
                if (customer != null && customer.CUSTOMER_USER_ID != user.ID)
                    customer = null;
            }

            if (customer == null)
            {
                customer = GetCustomerByUserID(user.ID);
            }

            return customer;
        }

    }
}
