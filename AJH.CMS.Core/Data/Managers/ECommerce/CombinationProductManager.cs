using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class CombinationProductManager
    {
        public static int Add(CombinationProduct combinationProduct)
        {
            return CombinationProductDataMapper.Add(combinationProduct);
        }

        public static void Update(CombinationProduct combinationProduct)
        {
            CombinationProductDataMapper.Update(combinationProduct);
        }

        public static void AddOtherLanguage(CombinationProduct combinationProduct)
        {
            CombinationProductDataMapper.AddOtherLanguage(combinationProduct);
        }

        public static void Delete(int id)
        {
            CombinationProductDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            CombinationProductDataMapper.DeleteLogical(id);
        }

        public static List<CombinationProduct> GetCombinationProducts(int languageID)
        {
            return CombinationProductDataMapper.GetCombinationProducts(languageID);
        }

        public static List<CombinationProduct> GetCombinationProductsByProductId(int productID, int languageID)
        {
            return CombinationProductDataMapper.GetCombinationProductsByProductId(productID, languageID);
        }

        public static CombinationProduct GetCombinationProduct(int id, int languageID)
        {
            return CombinationProductDataMapper.GetCombinationProduct(id, languageID);
        }

        public static void AddCombinationImage(int combinationId, int imageId)
        {
            CombinationProductDataMapper.AddCombinationImage(combinationId, imageId);
        }

        public static void DeleteCombinationImage(int combinationId, int imageId)
        {
            CombinationProductDataMapper.DeleteCombinationImage(combinationId, imageId);
        }

        public static void AddCombinationAttribute(int combinationId, int attributeId)
        {
            CombinationProductDataMapper.AddCombinationAttribute(combinationId, attributeId);
        }

        public static void DeleteCombinationAttribute(int combinationId, int attributeId)
        {
            CombinationProductDataMapper.DeleteCombinationAttribute(combinationId, attributeId);
        }
    }
}