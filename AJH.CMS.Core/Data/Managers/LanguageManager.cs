using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class LanguageManager
    {
        public static int Add(Language language)
        {
            return LanguageDataMapper.Add(language);
        }

        public static void Update(Language language)
        {
            LanguageDataMapper.Update(language);
        }

        public static void Delete(int ID)
        {
            LanguageDataMapper.Delete(ID);
        }

        public static List<Language> GetLanguages()
        {
            return LanguageDataMapper.GetLanguages();
        }

        public static List<Language> GetLanguages(int portalID)
        {
            return LanguageDataMapper.GetLanguages(portalID);
        }

        public static Language GetLanguage(int languageID)
        {
            return LanguageDataMapper.GetLanguage(languageID);
        }

        public static void AddPortalLanguage(int portalID, int languageID)
        {
            LanguageDataMapper.AddPortalLanguage(portalID, languageID);
        }

        public static void DeletePortalLanguage(int portalID, int languageID)
        {
            LanguageDataMapper.DeletePortalLanguage(portalID, languageID);
        }
    }
}