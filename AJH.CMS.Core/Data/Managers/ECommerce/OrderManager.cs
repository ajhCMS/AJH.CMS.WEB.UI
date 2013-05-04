using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class OrderManager
    {
        public static int Add(Order oOrder)
        {
            return OrderDataMapper.Add(oOrder);
        }

        public static void Update(Order oOrder)
        {
            OrderDataMapper.Update(oOrder);
        }

        public static void Delete(int id)
        {
            OrderDataMapper.Delete(id);
        }

        public static List<Order> GetOrders()
        {
            return OrderDataMapper.GetAllOrder();
        }

        public static Order GetOrder(int id)
        {
            return OrderDataMapper.GetOrderByID(id);
        }

        public static List<Order> GetOrderByCustomerID(int id)
        {
            return OrderDataMapper.GetOrderByCustomerID(id);
        }
    }
}
