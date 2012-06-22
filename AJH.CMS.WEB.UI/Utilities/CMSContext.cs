
using System.Web;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
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
                return 1;
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