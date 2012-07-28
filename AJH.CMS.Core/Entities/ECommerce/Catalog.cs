using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Catalog : IEntity
    {
        public bool IsDisplayed
        {
            get;
            set;
        }

        public bool IsGalleryOnly
        {
            get;
            set;
        }

        public int ParentCalalogID
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string MetaTitle
        {
            get;
            set;
        }

        public string MetaDescription
        {
            get;
            set;
        }

        public string MetaKeywords
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

        public bool IsPublished
        {
            set;
            get;
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

        public int Order
        {
            get;
            set;
        }


        #endregion

        public Catalog()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.IsDisplayed = false;
            this.IsGalleryOnly = false;
            this.ParentCalalogID = 0;
            this.Description = string.Empty;
            this.MetaTitle = string.Empty;
            this.MetaKeywords = string.Empty;
            this.MetaDescription = string.Empty;
            this.IsDeleted = false;
            this.ModuleID = 0;
            this.Order = 0;
            this.IsPublished = false;
        }

    }
}