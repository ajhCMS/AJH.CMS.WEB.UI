using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class GalleryXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(GalleryXSL_UC_Load);
        }
        #endregion

        #region GalleryXSL_UC_Load
        void GalleryXSL_UC_Load(object sender, EventArgs e)
        {
            LoadGallery();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadGallery
        void LoadGallery()
        {
            int CategoryId = 0;
            CategoryId = base.ContainerValue;
            if (CategoryId <= 0)
                int.TryParse(Request.QueryString[CMSConfig.QueryString.CategoryID], out CategoryId);

            if (base.XSLTemplateID > 0 && CategoryId > 0)
            {
                int PageSize = 10;
                if (!string.IsNullOrEmpty(Attributes["PageSize"]))
                {
                    PageSize = Convert.ToInt32(Attributes["PageSize"]);
                }
                int TotalCount = 0;
                string galleryXML = GalleryManager.GetGallerysPublishXML(CategoryId, Core.Enums.CMSEnums.GalleryType.Photo, 1, PageSize, ref TotalCount);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlGallery.DocumentContent = galleryXML;
                xmlGallery.TransformSource = xslPath;
                xmlGallery.TransformArgumentList = arguments;
                xmlGallery.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Category> articleCategories = CategoryManager.GetCategorys(ModuleID, PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < articleCategories.Count; i++)
            {
                items.Add(articleCategories[i].ID.ToString(), articleCategories[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}