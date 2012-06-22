
namespace AJH.CMS.Core.Enums
{
    public class CMSEnums
    {
        public enum MenuType : int
        {
            URL = 0,
            Static = 1,
            Page = 2
        }

        public enum ArticleType : int
        {
            Internal = 0,
            External = 1
        }

        public enum GalleryType : int
        {
            Photo = 0,
            Document = 1,
            Video = 2
        }

        public enum GalleryItemType : int
        {
            Internal = 0,
            External = 1
        }

        public enum PageType : int
        {
            Admin = 0,
            User = 1,
            System = 2
        }

        public enum Modules : int
        {
            Article = 1,
            HTML = 2,
            Menu = 3,
            Gallery = 4,
            Event = 5,
            Banner = 6,
            General = 7
        }

        public enum AccessType : int
        {
            Deny = 0,
            Allow = 1
        }

        public enum PublishType : int
        {
            NotPublish = 0,
            PublishNow = 1,
            PublishLater = 2
        }

        public enum ECommerceModule
        {
            Attribute = 1,
            Catalog = 2,
            CombinationProduct = 3,
            Feature = 4,
            Group = 5,
            Manufacturar = 6,
            Supplier =7,
            Product = 8,
            ProductImage = 9,
        }
    }
}