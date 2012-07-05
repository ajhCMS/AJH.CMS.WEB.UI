using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class LanguageURL : IEntity
    {
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

        public LanguageURL()
        {
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
        }
    }
}