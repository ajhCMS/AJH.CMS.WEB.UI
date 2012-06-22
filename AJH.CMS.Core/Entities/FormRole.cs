using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class FormRole
    {
        public string RoleName
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

        public int RoleID
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

        public FormRole()
        {
            this.AccessType = CMSEnums.AccessType.Deny;
            this.FormID = 0;
            this.ID = 0;
            this.RoleID = 0;
            this.RoleName = string.Empty;
        }
    }
}