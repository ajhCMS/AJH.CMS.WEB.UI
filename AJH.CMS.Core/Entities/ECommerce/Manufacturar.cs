using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Manufacturar : IEntity
    {
        public string Image
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public bool IsEnabled
        {
            set;
            get;
        }

        public string Description
        {
            set;
            get;
        }

        public string ShortDescription
        {
            set;
            get;
        }

        public string MetaTitle
        {
            set;
            get;
        }

        public string MetaDescription
        {
            set;
            get;
        }

        public string MetaKeywords
        {
            set;
            get;
        }

        public int ModuleID
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

        #endregion

        public Manufacturar()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.ModuleID = 0;
            this.Image = string.Empty;
            this.IsDeleted = false;
            this.IsEnabled = false;
            this.Description = string.Empty;
            this.ShortDescription = string.Empty;
            this.MetaDescription = string.Empty;
            this.MetaTitle = string.Empty;
            this.MetaKeywords = string.Empty;
        }
    }
}