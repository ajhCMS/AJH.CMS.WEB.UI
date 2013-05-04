using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class OrderDetailsManager
    {
        public static int Add(OrderDetails oOrderDetails)
        {
            return OrderDetailsDataMapper.Add(oOrderDetails);
        }

        public static void Update(OrderDetails oOrderDetails)
        {
            OrderDetailsDataMapper.Update(oOrderDetails);
        }

        public static void Delete(int id)
        {
            OrderDetailsDataMapper.Delete(id);
        }

        public static List<OrderDetails> GetOrderDetailss()
        {
            return OrderDetailsDataMapper.GetAllOrderDetails();
        }

        public static OrderDetails GetOrderDetails(int id)
        {
            return OrderDetailsDataMapper.GetOrderDetailsByID(id);
        }

        public static List<OrderDetails> GetOrderDetailsByOrderID(int id)
        {
            return OrderDetailsDataMapper.GetOrderDetailsByOrderID(id);
        }
    }
}
