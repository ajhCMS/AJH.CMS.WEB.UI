
namespace AJH.CMS.Core.Entities
{
    public class Attribute : IEntity
    {
        public int GroupID
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

        public bool IsDeleted
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

        public Attribute()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.ModuleID = 0;
            this.GroupID = 0;
            this.IsDeleted = false;
        }
    }
}