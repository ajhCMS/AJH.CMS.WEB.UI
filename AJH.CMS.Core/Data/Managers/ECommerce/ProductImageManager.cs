using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class ProductImageManager
    {
        public static int Add(ProductImage productImage)
        {
            return ProductImageDataMapper.Add(productImage);
        }

        public static void Update(ProductImage productImage)
        {
            ProductImageDataMapper.Update(productImage);
        }

        public static void Delete(int id, int languageID)
        {
            ProductImageDataMapper.Delete(id, languageID);
        }

        public static void DeleteLogical(int id)
        {
            ProductImageDataMapper.DeleteLogical(id);
        }

        public static List<ProductImage> GetProductImages(int languageID)
        {
            return ProductImageDataMapper.GetProductImages(languageID);
        }

        public static ProductImage GetProductImage(int id, int languageID)
        {
            return ProductImageDataMapper.GetProductImage(id, languageID);
        }

        public static List<ProductImage> GetProductImagesByProductID(int productID, int languageID)
        {
            return ProductImageDataMapper.GetProductImagesByProductID(productID, languageID);
        }

        public static List<ProductImage> GetProductImagesByCombinationID(int combinationID, int languageID)
        {
            return ProductImageDataMapper.GetProductImagesByCombinationID(combinationID, languageID);
        }
    }
}