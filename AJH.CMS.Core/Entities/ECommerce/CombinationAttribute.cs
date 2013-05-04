using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class CombinationAttribute : IEntity
    {
        int COMBINATION_ID
        {
            set;
            get;
        }
        int ATTRIBUTE_ID
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

        public CombinationAttribute()
        {
            this.ATTRIBUTE_ID = 0;
            this.COMBINATION_ID = 0;
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
        }
    }
}
