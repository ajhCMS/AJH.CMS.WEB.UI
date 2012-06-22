using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Gallery : IEntity
    {
        public string Description
        {
            get;
            set;
        }

        public string Summary
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

        public string File
        {
            get;
            set;
        }

        public int CategoryID
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

        public CMSEnums.GalleryType GalleryType
        {
            get;
            set;
        }

        public CMSEnums.GalleryItemType GalleryItemType
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

        public Gallery()
        {
            this.GalleryType = CMSEnums.GalleryType.Photo;
            this.GalleryItemType = CMSEnums.GalleryItemType.Internal;
            this.CategoryID = 0;
            this.CreationDate = DateTime.Now;
            this.Description = string.Empty;
            this.Details = string.Empty;
            this.ID = 0;
            this.File = string.Empty;
            this.IsDeleted = false;
            this.KeyWords = string.Empty;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.SEOName = string.Empty;
            this.Summary = string.Empty;
            this.URL = string.Empty;
            this.Order = 0;
            this.CreatedBy = 0;
            this.ParentObjectID = 0;
        }
    }
}