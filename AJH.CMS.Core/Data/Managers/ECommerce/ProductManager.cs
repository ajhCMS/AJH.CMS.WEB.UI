using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class ProductManager
    {
        public static int Add(Product product)
        {
            return ProductDataMapper.Add(product);
        }

        public static void Update(Product product)
        {
            ProductDataMapper.Update(product);
        }

        public static void AddOtherLanguage(Product product)
        {
            ProductDataMapper.AddOtherLanguage(product);
        }

        public static void Delete(int id)
        {
            ProductDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            ProductDataMapper.DeleteLogical(id);
        }

        public static List<Product> GetProducts(int portalID, int languageID)
        {
            return ProductDataMapper.GetProducts(portalID, languageID);
        }

        public static Product GetProduct(int id, int portalID, int languageID)
        {
            return ProductDataMapper.GetProduct(id, portalID, languageID);
        }
    }
}