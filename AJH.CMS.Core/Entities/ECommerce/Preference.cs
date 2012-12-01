
namespace AJH.CMS.Core.Entities
{
    public class Preference
    {
        public int ID
        {
            set;
            get;
        }

        public string Name
        {
            set;
            get;
        }

        public bool IsEnabled
        {
            set;
            get;
        }

        public int PortalID
        {
            set;
            get;
        }
        public Preference()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.IsEnabled = false;
            this.PortalID = 0;
        }
    }
}