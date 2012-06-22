
namespace AJH.CMS.Core.Entities
{
    public class Language
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

        public string Culture
        {
            set;
            get;
        }

        public string Image
        {
            set;
            get;
        }

        public Language()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Culture = string.Empty;
            this.Image = string.Empty;

        }
    }
}