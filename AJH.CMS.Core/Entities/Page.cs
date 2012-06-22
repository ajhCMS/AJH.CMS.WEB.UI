using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Page : IEntity
    {
        public string Description
        {
            get;
            set;
        }

        public string Details
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

        public string Title
        {
            get;
            set;
        }

        public string Icon
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

        public CMSEnums.PageType PageType
        {
            get;
            set;
        }

        public int TemplateID
        {
            get;
            set;
        }

        public int CreatedBy
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

        public Page()
        {
            this.CreationDate = DateTime.Now;
            this.Description = string.Empty;
            this.Details = string.Empty;
            this.Icon = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.KeyWords = string.Empty;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.PageType = CMSEnums.PageType.User;
            this.PortalID = 0;
            this.SEOName = string.Empty;
            this.Title = string.Empty;
            this.TemplateID = 0;
            this.CreatedBy = 0;
        }
    }
}