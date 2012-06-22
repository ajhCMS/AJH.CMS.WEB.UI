﻿using System;

namespace AJH.CMS.Core.Entities
{
    public class Style : IEntity
    {
        public string Details
        {
            get;
            set;
        }

        public string FileName
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

        public Style()
        {
            this.CreationDate = DateTime.Now;
            this.Details = string.Empty;
            this.FileName = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.CreatedBy = 0;
        }
    }
}