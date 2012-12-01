using System.Collections.Generic;
using AJH.CMS.Core.Entities;

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

        public static List<Product> GetProductsByCatalogID(int catalogId, int portalID, int languageID)
        {
            return ProductDataMapper.GetProductsByCatalogID(catalogId, portalID, languageID);
        }

        public static List<Product> SearchProducts(int catalogId, string productName, int portalID, int languageID)
        {
            return ProductDataMapper.SearchProducts(catalogId, productName, portalID, languageID);
        }

        public static Product GetProduct(int id, int portalID, int languageID)
        {
            return ProductDataMapper.GetProduct(id, portalID, languageID);
        }
    }
}