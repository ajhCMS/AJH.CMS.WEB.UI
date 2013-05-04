using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class OrderDetails:IEntity
    {

        public int ORDER_DETAILS_ORDER_ID
        {
            set;
            get;
        }
        public int ORDER_DETAILS_AMOUNT
        {
            set;
            get;
        }
        public int ORDER_DETAILS_PRODUCT_ID
        {
            set;
            get;
        }
        public int ORDER_DETAILS_CATEGORY_ID
        {
            set;
            get;
        }
        public DateTime ORDER_DETAILS_CREATED_ON
        {
            set;
            get;
        }
        public int ORDER_DETAILS_STATUS
        {
            set;
            get;
        }
        public int ORDER_DETAILS_XREF_ORDER_DETAILS
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

        public OrderDetails()
        {
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.ORDER_DETAILS_AMOUNT = 0;
            this.ORDER_DETAILS_CATEGORY_ID = 0;
            this.ORDER_DETAILS_CREATED_ON = DateTime.Now;
            this.ORDER_DETAILS_ORDER_ID = 0;
            this.ORDER_DETAILS_PRODUCT_ID = 0;
            this.ORDER_DETAILS_STATUS = 0;
            this.ORDER_DETAILS_XREF_ORDER_DETAILS = 0;
            this.PortalID = 0;
        }
    }
}
