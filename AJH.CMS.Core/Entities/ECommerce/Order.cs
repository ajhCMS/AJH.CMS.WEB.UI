using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJH.CMS.Core.Entities
{
    public class Order : IEntity
    {

        public int ORDER_CUSTOMER_ID
        {
            set;
            get;
        }
        public DateTime ORDER_CREATED_ON
        {
            set;
            get;
        }
        public int ORDER_STATUS
        {
            set;
            get;
        }
        public int ORDER_TOTAL_AMOUNT
        {
            set;
            get;
        }
        public int XREF_ODER
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

        public Order()
        {
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.ORDER_CREATED_ON = DateTime.Now;
            this.ORDER_CUSTOMER_ID = 0;
            this.ORDER_STATUS = 0;
            this.ORDER_TOTAL_AMOUNT = 0;
            this.PortalID = 0;
            this.XREF_ODER = 0;
        }
    }
}