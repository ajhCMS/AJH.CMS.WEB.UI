using System;
using System.IO;
using System.Web;
using System.Web.Caching;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.Core.Data
{
    public static class CacheManager
    {
        static string FullPathMonitoringFile;

        static int TimeOut;

        static CacheDependency _CacheDependency
        {
            get
            {
                if (string.IsNullOrEmpty(FullPathMonitoringFile))
                    return null;
                return new CacheDependency(FullPathMonitoringFile);
            }
        }

        static CacheItemPriority _CacheItemPriority;

        static DateTime Expiration
        {
            get
            {
                return DateTime.Now.AddMinutes(TimeOut);
            }
        }

        public static object GetObject(string CacheKey)
        {
            return HttpContext.Current.Cache[CacheKey];
        }

        public static void AddObject(string CacheKey, object value, CacheItemPriority cacheItemPriority = 0)
        {
            CheckFile();
            if (Convert.ToInt32(cacheItemPriority) == 0)
            {
                cacheItemPriority = _CacheItemPriority;
            }
            HttpContext.Current.Cache.Add(CacheKey, value, _CacheDependency, Expiration, Cache.NoSlidingExpiration, cacheItemPriority, null);
        }

        public static void RemoveObject(string CacheKey)
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }

        static void CheckFile()
        {
            if (string.IsNullOrEmpty(FullPathMonitoringFile))
                return;
            if (!File.Exists(FullPathMonitoringFile))
            {
                File.Create(FullPathMonitoringFile).Close();
            }
        }

        static CacheManager()
        {
            if (CoreConfigurationManager._CoreConfigSectionHandler.CacheElement.VirtualPathMonitoringFile != string.Empty)
            {
                FullPathMonitoringFile = HttpContext.Current.Server.MapPath(CoreConfigurationManager._CoreConfigSectionHandler.CacheElement.VirtualPathMonitoringFile);
            }
            else
            {
                FullPathMonitoringFile = string.Empty;
            }

            if (CoreConfigurationManager._CoreConfigSectionHandler.CacheElement.CachePriority != string.Empty)
            {
                _CacheItemPriority = (CacheItemPriority)Convert.ToInt32(CoreConfigurationManager._CoreConfigSectionHandler.CacheElement.CachePriority);
            }
            else
            {
                _CacheItemPriority = CacheItemPriority.Normal;
            }

            TimeOut = Convert.ToInt32(CoreConfigurationManager._CoreConfigSectionHandler.CacheElement.TimeOut);
        }
    }
}