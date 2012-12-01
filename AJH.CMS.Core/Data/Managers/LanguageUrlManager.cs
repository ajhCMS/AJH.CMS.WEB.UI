using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class LanguageUrlManager
    {
        public static List<LanguageURL> GetLanguageURLs(int portalID)
        {
            return LanguageUrlDataMapper.GetLanguageURLs(portalID);
        }
    }
}