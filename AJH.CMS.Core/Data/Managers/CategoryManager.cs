using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class CategoryManager
    {
        public static int Add(Category category)
        {
            return CategoryDataMapper.Add(category);
        }

        public static void Update(Category category)
        {
            CategoryDataMapper.Update(category);
        }

        public static void Delete(int ID)
        {
            CategoryDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            CategoryDataMapper.DeleteLogical(ID);
        }

        public static List<Category> GetCategorys()
        {
            return CategoryDataMapper.GetCategorys();
        }

        public static List<Category> GetCategorys(int ModuleID, int PortalID, int LanguageID)
        {
            return CategoryDataMapper.GetCategorys(ModuleID, PortalID, LanguageID);
        }

        public static List<Category> GetCategorys(int PortalID, int LanguageID)
        {
            return CategoryDataMapper.GetCategorys(PortalID, LanguageID);
        }

        public static Category GetCategory(int ID)
        {
            return CategoryDataMapper.GetCategoryById(ID);
        }

        public static string GetCategoryPublishXML(int ModuleID, int ParentID)
        {
            return CategoryDataMapper.GetCategoryPublishXML(ModuleID, ParentID);
        }
    }
}