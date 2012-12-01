using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class CatalogImageManager
    {
        public static int Add(CatalogImage CatalogImage)
        {
            return CatalogImageDataMapper.Add(CatalogImage);
        }

        public static void Update(CatalogImage CatalogImage)
        {
            CatalogImageDataMapper.Update(CatalogImage);
        }

        public static void Delete(int id)
        {
            CatalogImageDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            CatalogImageDataMapper.DeleteLogical(id);
        }

        public static List<CatalogImage> GetCatalogImagesByCatalogID(int catalogID)
        {
            return CatalogImageDataMapper.GetCatalogImagesByCatalogID(catalogID);
        }

        public static CatalogImage GetCatalogImageByID(int id)
        {
            return CatalogImageDataMapper.GetCatalogImageByID(id);
        }
    }
}