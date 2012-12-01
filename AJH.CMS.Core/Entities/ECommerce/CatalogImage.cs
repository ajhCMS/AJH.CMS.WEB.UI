
namespace AJH.CMS.Core.Entities
{
    public class CatalogImage
    {
        public int ID
        {
            get;
            set;
        }

        public int CatalogID
        {
            get;
            set;
        }

        public string Image
        {
            set;
            get;
        }

        public bool IsCoverImage
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public CatalogImage()
        {
            this.ID = 0;
            this.CatalogID = 0;
            this.Image = string.Empty;
            this.IsCoverImage = false;
            this.IsDeleted = false;
        }
    }
}