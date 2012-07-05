
using System.Web;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using System.Collections.Generic;
using System;

namespace AJH.CMS.WEB.UI.Utilities
{
    public static class CMSContext
    {
        public static int PortalID
        {
            get
            {
                return 1;
            }
        }

        public static int LanguageID
        {
            get
            {
                int languageId = -1;
                List<LanguageURL> languageUrls = CacheManager.GetObject("AllLanguagesUrls" + PortalID) as List<LanguageURL>;

                if (languageUrls == null)
                {
                    languageUrls = LanguageUrlManager.GetLanguageURLs(PortalID);
                    CacheManager.AddObject("AllLanguagesUrls" + PortalID.ToString(), languageUrls);
                }

                string http = "http://";
                string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;

                string domainUrl = absoluteUri.Replace(http, string.Empty);
                domainUrl = domainUrl.Substring(0, domainUrl.IndexOf("/"));
                domainUrl = http + domainUrl;

                foreach (LanguageURL languageURL in languageUrls)
                {
                    if (string.Equals(languageURL.Name, domainUrl, StringComparison.InvariantCultureIgnoreCase))
                        languageId = languageURL.LanguageID;
                }

                return languageId;
            }
        }

        public static int UserID
        {
            get
            {
                User user = UserManager.GetCurrentUser();
                if (user != null)
                    return user.ID;
                return 0;
            }
        }

        public static string CurrentPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~");
            }
        }

        public static string PortalsPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/Portals");
            }
        }

        public static string CurrentPortalPath
        {
            get
            {
                return CMSContext.CurrentPath + "Portals\\Portal" + PortalID + "\\";
            }
        }

        public static string VirtualUploadFolder
        {
            get
            {
                return "~/Portals/Portal" + PortalID + "/Uploads/Upload/";
            }
        }

        public static string VirtualUploadThumbnailFolder
        {
            get
            {
                return "~/Portals/Portal" + PortalID + "/Uploads/Thumbnail/";
            }
        }
    }
}