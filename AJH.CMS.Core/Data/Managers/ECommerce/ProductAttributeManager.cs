using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class ProductAttributeManager
    {
        public static List<ProductAttribute> GetAttributeByProductID(int productID, int LanguageID)
        {
            return ProductAttributeDataMapper.GetAttributeByProductId(productID, LanguageID);
        }
    }
}
