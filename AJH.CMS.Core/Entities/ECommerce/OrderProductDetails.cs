using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class OrderProductDetails:IEntity
    {
        public int ORD_PRO_DET_PRODUCT_ID
        {
            set;
            get;
        }
        public int ORD_PRO_DET_ATTRIBUTE_ID
        {
            set;
            get;
        }
        public int ORD_PRO_DET_DETAILS_ID
        {
            set;
            get;
        }
        public int ORD_PRO_DET_XREF_PRODUCT_DETAILS
        {
            set;
            get;
        }
        public int ORD_PRO_DET_GROUP_ID
        {
            set;
            get;
        }

        public int ORD_PRO_DET_COMBINATION_ID
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

        public OrderProductDetails()
        {
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.ORD_PRO_DET_ATTRIBUTE_ID = 0;
            this.ORD_PRO_DET_PRODUCT_ID = 0;
            this.ORD_PRO_DET_DETAILS_ID = 0;
            this.ORD_PRO_DET_XREF_PRODUCT_DETAILS = 0;
            this.ORD_PRO_DET_GROUP_ID = 0;
            this.ORD_PRO_DET_COMBINATION_ID = 0;
        }
    }
}
