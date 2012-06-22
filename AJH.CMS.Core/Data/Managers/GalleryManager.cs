using System.Collections.Generic;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using System;

namespace AJH.CMS.Core.Data
{
    public static class GalleryManager
    {
        public static int Add(Gallery gallery)
        {
            if (gallery.ParentObjectID > 0)
            {
                Gallery gallery2 = GetGalleryByParentObjIdAndLanguageId(gallery.ParentObjectID, gallery.LanguageID);
                if (gallery2 != null)
                    throw new Exception("Gallery is exists in the same language, please choose another language");
            }
            return GalleryDataMapper.Add(gallery);
        }

        public static void Update(Gallery gallery)
        {
            GalleryDataMapper.Update(gallery);
        }

        public static void Delete(int ID)
        {
            GalleryDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            GalleryDataMapper.DeleteLogical(ID);
        }

        public static List<Gallery> GetGallerys()
        {
            return GalleryDataMapper.GetGallerys();
        }

        public static List<Gallery> GetGallerys(int CategoryID, Enums.CMSEnums.GalleryType GalleryType)
        {
            return GalleryDataMapper.GetGallerys(CategoryID, GalleryType);
        }

        public static List<Gallery> GetGallerys(int PortalID, int LanguageID, Enums.CMSEnums.GalleryType GalleryType)
        {
            return GalleryDataMapper.GetGallerys(PortalID, LanguageID, GalleryType);
        }

        public static List<Gallery> GetParentObjGallerysByCategoryID(int CategoryID, Enums.CMSEnums.GalleryType GalleryType)
        {
            return GalleryDataMapper.GetParentObjGallerysByCategoryID(CategoryID, GalleryType);
        }

        public static Gallery GetGallery(int ID)
        {
            return GalleryDataMapper.GetGallery(ID);
        }

        public static Gallery GetGalleryByParentObjIdAndLanguageId(int parentObjID, int languageID)
        {
            return GalleryDataMapper.GetGalleryByParentObjIdAndLanguageId(parentObjID, languageID);
        }

        public static string GetGallerysPublishXML(int CategoryID, Enums.CMSEnums.GalleryType GalleryType, int PageNumber, int PageSize, ref int TotalCount)
        {
            int RowFrom = ((PageNumber - 1) * PageSize) + 1, RowTo = PageNumber * PageSize;
            return GalleryDataMapper.GetGallerysPublishXML(CategoryID, GalleryType, RowFrom, RowTo, ref TotalCount);
        }
    }
}