using System;

namespace AJH.CMS.Core.Entities
{
    public class Category : IEntity
    {
        public string Description
        {
            get;
            set;
        }

        public int ModuleID
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

        public int ParentID
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

        public string Image
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

        public Category()
        {
            this.CreationDate = DateTime.Now;
            this.Description = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.LanguageID = 0;
            this.ModuleID = 0;
            this.Name = string.Empty;
            this.ParentID = 0;
            this.PortalID = 0;
            this.Order = 0;
            this.CreatedBy = 0;
            this.Image = string.Empty;
        }
    }
}