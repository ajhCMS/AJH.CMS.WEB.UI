using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class ProductAttribute : IEntity
    {
        public int AttributeID { set; get; }
        public string PRO_ATT_DETAILS { set; get; }
        public string ECO_LAN_NAME { set; get; }
        public int GROUP_ID { set; get; }
        public string GroupName { set; get; }


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

        public ProductAttribute()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.AttributeID = 0;
            this.ECO_LAN_NAME = string.Empty;
            this.GROUP_ID = 0;
            this.GroupName = string.Empty;
            this.PRO_ATT_DETAILS = string.Empty;
        }
    }
}
