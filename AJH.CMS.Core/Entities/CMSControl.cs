using System;

namespace AJH.CMS.Core.Entities
{
    public class CMSControl
    {
        public string Description
        {
            get;
            set;
        }

        public string UserControlPath
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

        public int ModuleID
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

        #endregion

        public CMSControl()
        {
            this.CreationDate = DateTime.Now;
            this.Description = string.Empty;
            this.UserControlPath = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.Name = string.Empty;
            this.ModuleID = 0;
            this.CreatedBy = 0;
        }
    }
}