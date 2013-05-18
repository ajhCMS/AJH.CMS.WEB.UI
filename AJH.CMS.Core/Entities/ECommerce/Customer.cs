using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class Customer : IEntity
    {
        public string CUSTOMER_FNAME
        {
            set;
            get;
        }
        public string CUSTOMER_LNAME
        {
            set;
            get;
        }
        public CMSEnums.Gender CUSTOMER_GENDER
        {
            set;
            get;
        }
        public DateTime CUSTOMER_BIRTHDAY
        {
            set;
            get;
        }
        public string CUSTOMER_ZIP_CODE
        {
            set;
            get;
        }
        public int CUSTOMER_COUNTRY
        {
            set;
            get;
        }
        public string CUSTOMER_CITY
        {
            set;
            get;
        }
        public string CUSTOMER_ADDRESS1
        {
            set;
            get;
        }
        public string CUSTOMER_ADDRESS2
        {
            set;
            get;
        }
        public string CUSTOMER_ADDRESS3
        {
            set;
            get;
        }
        public string CUSTOMER_MOBILE_PHONE
        {
            set;
            get;
        }
        public string CUSTOMER_HOME_PHONE
        {
            set;
            get;
        }
        public CMSEnums.AccessType CUSTOMER_STATUS
        {
            set;
            get;
        }
        public CMSEnums.AccessType CUSTOMER_NEWSLETTER
        {
            set;
            get;
        }
        public CMSEnums.AccessType CUSTOMER_OPT_IN
        {
            set;
            get;
        }
        public int CUSTOMER_USER_ID
        {
            set;
            get;
        }
        public string CUSTOMER_EDUCATION
        { set; get; }
        public string CUSTOMER_POSITION
        { set; get; }
        public string CUSTOMER_LOCATION
        { set; get; }


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

        public Customer()
        {
            this.CUSTOMER_ADDRESS1 = string.Empty;
            this.CUSTOMER_ADDRESS2 = string.Empty;
            this.CUSTOMER_ADDRESS3 = string.Empty;
            this.CUSTOMER_BIRTHDAY = DateTime.Now;
            this.CUSTOMER_CITY = string.Empty;
            this.CUSTOMER_COUNTRY = 0;
            this.CUSTOMER_FNAME = string.Empty;
            this.CUSTOMER_GENDER = 0;
            this.CUSTOMER_HOME_PHONE = string.Empty;
            this.CUSTOMER_LNAME = string.Empty;
            this.CUSTOMER_MOBILE_PHONE = string.Empty;
            this.CUSTOMER_NEWSLETTER = 0;
            this.CUSTOMER_OPT_IN = 0;
            this.CUSTOMER_STATUS = 0;
            this.CUSTOMER_USER_ID = 0;
            this.CUSTOMER_ZIP_CODE = string.Empty;
            this.ID = 0;
            this.LanguageID = 0;
            this.Name = string.Empty;
            this.Order = 0;
            this.PortalID = 0;
            this.CUSTOMER_EDUCATION = string.Empty;
            this.CUSTOMER_POSITION = string.Empty;
            this.CUSTOMER_LOCATION = string.Empty;
            
        }
    }
}
