using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class OrderPrdouctDetailsManager
    {
        public static int Add(OrderProductDetails oOrderProductDetails)
        {
            return OrderProductDetailsDataMapper.Add(oOrderProductDetails);
        }

        public static void Update(OrderProductDetails oOrderProductDetails)
        {
            OrderProductDetailsDataMapper.Update(oOrderProductDetails);
        }

        public static void Delete(int id)
        {
            OrderProductDetailsDataMapper.Delete(id);
        }

        public static List<OrderProductDetails> GetOrderProductDetails()
        {
            return OrderProductDetailsDataMapper.GetAllOrderProductsDetails();
        }

        public static OrderProductDetails GetOrderProductDetails(int id)
        {
            return OrderProductDetailsDataMapper.GetOrderProductDetailsByID(id);
        }

        public static List<OrderProductDetails> GetOrderProductDetailsByOrderID(int id)
        {
            return OrderProductDetailsDataMapper.GetOrderProductDetailsByDetailsID(id);
        }
    }
}
