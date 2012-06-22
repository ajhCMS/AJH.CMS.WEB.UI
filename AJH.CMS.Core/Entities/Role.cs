
namespace AJH.CMS.Core.Entities
{
    public class Role
    {
        public string Description
        {
            get;
            set;
        }

        public bool IsDeleted
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

        public string Name
        {
            get;
            set;
        }

        #endregion

        public Role()
        {
            this.Description = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.Name = string.Empty;
        }
    }
}