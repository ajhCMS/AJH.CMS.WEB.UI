using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class ProductPriceManager
    {
        public static int Add(ProductPrice productPrice)
        {
            return ProductPriceDataMapper.Add(productPrice);
        }

        public static void Update(ProductPrice productPrice)
        {
            ProductPriceDataMapper.Update(productPrice);
        }

        public static void Delete(int id)
        {
            ProductPriceDataMapper.Delete(id);
        }

        public static List<ProductPrice> GetProductPrices(int moduleID, int languageID)
        {
            return ProductPriceDataMapper.GetProductPrices(moduleID, languageID);
        }

        public static ProductPrice GetProductPrice(int id)
        {
            return ProductPriceDataMapper.GetProductPrice(id);
        }
    }
}