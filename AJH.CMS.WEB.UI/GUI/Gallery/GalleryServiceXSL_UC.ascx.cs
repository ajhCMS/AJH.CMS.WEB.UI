using System;
using System.Collections.Generic;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class GalleryServiceXSL_UC : CMSUserControlBase
    {
        #region Properties
        protected string _GalleryServiceXslUrl
        {
            get;
            set;
        }
        protected int _CategoryID
        {
            get;
            set;
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegisterService();
        }
        #endregion

        #endregion

        #region Methods

        #region RegisterService
        void RegisterService()
        {
            _GalleryServiceXslUrl = ResolveClientUrl(CMSWebHelper.GetGalleryServiceXslUrl());

            int CategoryId = 0;
            CategoryId = base.ContainerValue;
            if (CategoryId <= 0)
                int.TryParse(Request.QueryString[CMSConfig.QueryString.CategoryID], out CategoryId);
            _CategoryID = CategoryId;
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