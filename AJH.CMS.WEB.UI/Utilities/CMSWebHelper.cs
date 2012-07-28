using System;
using System.Collections.Generic;
using System.IO;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.WEB.UI.Utilities
{
    public static class CMSWebHelper
    {
        #region GetEnumDataSource
        public static Dictionary<string, int> GetEnumDataSource(System.Resources.ResourceManager ResourceManager, Type myEnumType)
        {
            Dictionary<string, int> returnCollection = new Dictionary<string, int>();
            string[] enumNames = Enum.GetNames(myEnumType);

            for (int i = 0; i <= enumNames.Length - 1; i++)
            {
                try
                {
                    returnCollection.Add(ResourceManager.GetString(enumNames[i]).ToString(), (int)Enum.Parse(myEnumType, enumNames[i]));
                }
                catch
                {
                    returnCollection.Add((enumNames[i]).ToString() + ":resource key not found", (int)Enum.Parse(myEnumType, enumNames[i]));
                    continue;
                }
            }

            return returnCollection;
        }
        #endregion

        #region Menu
        public static string GetMenuCategoryFileName(int CategoryID)
        {
            return "MenuCategory" + CategoryID + "Lang" + CMSContext.LanguageID + ".xml";
        }

        public static string GetMenuPathByCategory(int CategoryID)
        {
            return CMSContext.CurrentPath + "Portals\\Portal" + CMSContext.PortalID + "\\Menu\\" + GetMenuCategoryFileName(CategoryID);
        }
        #endregion

        #region Style
        public static string GetStyleFileName(int StyleID)
        {
            return "CMSStyle" + StyleID + ".css";
        }

        public static string GetStyleFileVirtualPath(int StyleID)
        {
            return "App_Themes/Portals/Portal" + CMSContext.PortalID + "/" + GetStyleFileName(StyleID);
        }

        public static string GetStyleFilePath(int StyleID)
        {
            return CMSContext.CurrentPath + "App_Themes\\Portals\\Portal" + CMSContext.PortalID + "\\" + GetStyleFileName(StyleID);
        }
        #endregion

        #region XSLTemplate
        public static string GetXSLTemplateFileName(int XSLTemplateID)
        {
            return "XSLTemplate" + XSLTemplateID + ".xslt";
        }

        public static string GetXSLTemplateFilePath(int XSLTemplateID)
        {
            return CMSContext.CurrentPath + "Portals\\Portal" + CMSContext.PortalID + "\\XSLTemplate\\" + GetXSLTemplateFileName(XSLTemplateID);
        }
        #endregion

        #region Template
        public static string GetTemplateFileName(int TemplateID)
        {
            return "TemplateMasterPage" + TemplateID + ".Master";
        }

        public static string GetTemplateMasterPagePath(int TemplateID)
        {
            return CMSContext.CurrentPath + GetTemplateFileName(TemplateID);
        }

        public static string GetTemplateMasterPageVirtualPath(int TemplateID)
        {
            return "~/" + GetTemplateFileName(TemplateID);
        }

        public static string GetInitialTemplateValue()
        {
            string InitialTemplateValuePath = CMSContext.CurrentPath + "Portals\\Builder\\InitialTemplateValue.txt";
            StreamReader streamReader = new StreamReader(InitialTemplateValuePath);
            return streamReader.ReadToEnd();
        }
        #endregion

        #region Page
        public static string GetPageFileName(Page page)
        {
            return page.Name + ".aspx";
        }

        public static string GetPagePath(Page page)
        {
            return CMSContext.CurrentPath + GetPageFileName(page);
        }

        public static string GetPageUrl(Page page)
        {
            return "~/" + GetPageFileName(page);
        }

        public static string GetInitialPageValue()
        {
            string InitialPageValuePath = CMSContext.CurrentPath + "Portals\\Builder\\InitialPageValue.txt";
            StreamReader streamReader = new StreamReader(InitialPageValuePath);
            return streamReader.ReadToEnd();
        }
        #endregion

        #region Gallery
        public static string GetGalleryFile(string FileName)
        {
            return CMSContext.VirtualUploadFolder + FileName;
        }
        public static string GetGalleryThumbnailFile(string FileName)
        {
            return CMSContext.VirtualUploadThumbnailFolder + FileName;
        }
        public static string GetGalleryServiceXslUrl()
        {
            return "~/Services/Gallery/frmGalleryServiceXsl.ashx";
        }
        #endregion

        #region ECommerce Methods

        #region Catalog

        public static string GetCatalogFileName()
        {
            return "ECommCatalogLang" + CMSContext.LanguageID + ".xml";
        }

        public static string GetCatalogPath()
        {
            return CMSContext.CurrentPath + "Portals\\Portal" + CMSContext.PortalID + "\\ECommerce\\Catalog\\" + GetCatalogFileName();
        }

        public static string GetCatalogFolderPath()
        {
            return CMSContext.CurrentPath + "Portals\\Portal" + CMSContext.PortalID + "\\ECommerce\\Catalog\\";
        }


        #endregion

        #endregion

        #region Language
        public static string GetLanguageImage(string image)
        {
            return "~/Portals/GeneralPortal/Uploads/Upload/" + image;
        }
        public static string GetLanguageImageThumbnail(string image)
        {
            return "~/Portals/GeneralPortal/Uploads/Thumbnail/" + image;
        }
        public static string GetPublishedImage(bool isPublished)
        {
            if (isPublished)
                return "~/App_Themes/Image/published.png";
            else
                return "~/App_Themes/Image/notpublished.png";
        }
        #endregion
    }
}