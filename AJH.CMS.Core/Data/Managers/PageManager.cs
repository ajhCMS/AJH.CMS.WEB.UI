using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class PageManager
    {
        public static int Add(Page page)
        {
            if (page != null)
                page.Name = page.Name.Replace(" ", "");
            Page tempPage = GetPage(page.Name, page.PortalID, page.LanguageID);
            if (tempPage != null)
                throw new Exception("Page name already exists, please change the page name");
            return PageDataMapper.Add(page);
        }

        public static void Update(Page page)
        {
            if (page != null)
                page.Name = page.Name.Replace(" ", "");
            Page tempPage = GetPage(page.Name, page.PortalID, page.LanguageID);
            if (tempPage != null && tempPage.ID != page.ID)
                throw new Exception("Page name already exists, please change the page name");
            PageDataMapper.Update(page);
        }

        public static void Delete(int ID)
        {
            PageDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            PageDataMapper.DeleteLogical(ID);
        }

        public static List<Page> GetPages()
        {
            return PageDataMapper.GetPages();
        }

        public static List<Page> GetPages(int PortalID, int LanguageID)
        {
            return PageDataMapper.GetPages(PortalID, LanguageID);
        }

        public static List<Page> GetPages(int TemplateID)
        {
            return PageDataMapper.GetPages(TemplateID);
        }

        public static Page GetPage(string Name, int PortalID, int LanguageID)
        {
            return PageDataMapper.GetPage(Name, PortalID, LanguageID);
        }

        public static Page GetPage(int ID)
        {
            return PageDataMapper.GetPage(ID);
        }

        public static Page GetCachePage(string CacheKey, string Name, int PortalID, int LanguageID)
        {
            Page page = CacheManager.GetObject(CacheKey + Name) as Page;
            if (page == null)
            {
                page = PageManager.GetPage(Name, PortalID, LanguageID);
                if (page != null)
                    CacheManager.AddObject(CacheKey + Name, page);
            }
            return page;
        }
    }
}