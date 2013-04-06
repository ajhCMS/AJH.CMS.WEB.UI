using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class Countries : IEntity
    {
        public string COUNTRY_NAME
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

        public int Order
        {
            get;
            set;
        }


        #endregion

        public Countries()
        {
            this.COUNTRY_NAME = string.Empty;
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.Order = 0;
            this.PortalID = 0;
            
        }
    }
}
