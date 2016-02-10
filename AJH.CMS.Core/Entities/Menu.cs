using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Menu : IEntity
    {
        public string Description
        {
            get;
            set;
        }

        public string KeyWords
        {
            get;
            set;
        }

        public string SEOName
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public int PageID
        {
            get;
            set;
        }

        public int CategoryID
        {
            get;
            set;
        }

        public int ParentID
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public CMSEnums.MenuType MenuType
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public int ParentObjectID
        {
            get;
            set;
        }

        public bool IsPublished
        {
            get;
            internal set;
        }

        public int MainParentID
        {
            get;
            set;
        }

        public int GalleryCategoryID
        {
            get;
            set;
        }

        public string PageTitle
        {
            get;
            set;
        }

        #region IEntity Members

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int PortalID
        {
            get;
            set;
        }

        public int LanguageID
        {
            get;
            set;
        }

        #endregion

        public Menu()
        {
            this.CategoryID = 0;
            this.CreationDate = DateTime.Now;
            this.Description = string.Empty;
            this.Details = string.Empty;
            this.ID = 0;
            this.Image = string.Empty;
            this.IsDeleted = false;
            this.KeyWords = string.Empty;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.PageID = 0;
            this.ParentID = 0;
            this.PortalID = 0;
            this.SEOName = string.Empty;
            this.URL = string.Empty;
            this.MenuType = CMSEnums.MenuType.URL;
            this.Order = 0;
            this.CreatedBy = 0;
            this.ParentObjectID = 0;
            this.IsPublished = false;
            this.MainParentID = 0;
            this.GalleryCategoryID = 0;
            this.PageTitle = string.Empty;
        }
    }
}