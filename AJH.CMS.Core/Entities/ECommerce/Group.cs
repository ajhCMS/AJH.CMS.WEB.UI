using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Group : IEntity
    {
        public bool IsColorGroup
        {
            set;
            get;
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

        public string PublicName
        {
            set;
            get;
        }


        #region IEntity Members

        #endregion

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

        public Group()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.IsDeleted = false;
            this.IsColorGroup = false;
        }
    }
}