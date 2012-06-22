using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class FormUser
    {
        public string UserName
        {
            get;
            internal set;
        }

        public string FormCode
        {
            get;
            internal set;
        }

        public int FormID
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public CMSEnums.AccessType AccessType
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

        #endregion

        public FormUser()
        {
            this.AccessType = CMSEnums.AccessType.Deny;
            this.FormID = 0;
            this.ID = 0;
            this.UserID = 0;
            this.UserName = string.Empty;
        }
    }
}