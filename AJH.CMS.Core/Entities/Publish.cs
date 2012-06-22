using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Publish : IEntity
    {
        public CMSEnums.Modules ModuleID
        {
            get;
            set;
        }

        public int ObjectID
        {
            get;
            set;
        }

        public DateTime FromDate
        {
            get;
            set;
        }

        public DateTime ToDate
        {
            get;
            set;
        }

        public CMSEnums.PublishType PublishType
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

        public Publish()
        {
            this.CreatedBy = 0;
            this.FromDate = DateTime.Now;
            this.ID = 0;
            this.LanguageID = 0;
            this.ModuleID = 0;
            this.Name = string.Empty;
            this.ObjectID = 0;
            this.PortalID = 0;
            this.PublishType = CMSEnums.PublishType.NotPublish;
            this.ToDate = DateTime.Now.AddYears(100);
        }
    }
}