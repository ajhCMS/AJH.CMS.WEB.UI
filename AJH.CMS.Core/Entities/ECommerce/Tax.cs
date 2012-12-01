
namespace AJH.CMS.Core.Entities
{
    public class Tax
    {
        public int ID
        {
            get;
            set;
        }

        public decimal Rate
        {
            get;
            set;
        }

        public int PortalID
        {
            set;
            get;
        }

        public bool IsEnabled
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public Tax()
        {
            this.ID = 0;
            this.Rate = 0;
            this.PortalID = 0;
            this.IsEnabled = false;
            this.IsDeleted = false;
        }
    }
}