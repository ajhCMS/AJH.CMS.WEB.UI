using System;

namespace AJH.CMS.Core.Entities
{
    public class User : IEntity
    {
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public DateTime CreationDate
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

        public User()
        {
            this.CreationDate = DateTime.Now;
            this.Email = string.Empty;
            this.ID = 0;
            this.IsActive = false;
            this.IsDeleted = false;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.Password = string.Empty;
            this.PortalID = 0;
        }
    }
}