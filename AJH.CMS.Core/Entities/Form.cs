
namespace AJH.CMS.Core.Entities
{
    public class Form
    {
        public string Description
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string Code
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

        public Form()
        {
            this.Code = string.Empty;
            this.Description = string.Empty;
            this.ID = 0;
            this.IsDeleted = false;
            this.ModuleID = 0;
            this.Name = string.Empty;
            this.Url = string.Empty;
        }
    }
}