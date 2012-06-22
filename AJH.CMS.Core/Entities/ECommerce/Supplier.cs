using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Supplier : IEntity
    {
        public string LogoImage
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            set;
            get;
        }

        public int ParentSupplierID
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

        public Supplier()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.ModuleID = 0;
            this.LogoImage = string.Empty;
            this.IsDeleted = false;
            this.IsEnabled = false;
            this.ParentSupplierID = 0;
            this.Description = string.Empty; ;
            this.MetaTitle = string.Empty; ;
            this.MetaDescription = string.Empty; ;
            this.MetaKeywords = string.Empty; ;
            this.ModuleID = 0;
        }
    }
}