
namespace AJH.CMS.Core.Entities
{
    public class Feature : IEntity
    {
        public bool IsDeleted
        {
            set;
            get;
        }

        public int Value
        {
            set;
            get;
        }

        public int ModuleID
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

        public Feature()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.IsDeleted = false;
            this.Value = 0;
            this.ModuleID = 0;
        }
    }
}