
namespace AJH.CMS.Core.Configuration
{
    public static class CMSConfig
    {
        public static class ConstantManager
        {
            public const string CategoryMenu = "CategoryMenu";
            public const string BreakItem = "|";
            public const string CurrentMenu = "CurrentMenu";
            public const string CurrentCategory = "CurrentCategory";
            public const string CategoryCategory = "CategoryCategory";
            public const string KeyControlValueTopMenu = "KeyControlValueTopMenu";
            public const string KeyControlValueLeftMenu = "KeyControlValueLeftMenu";
            public const string KeyControlValueDashboard = "KeyControlValueDashboard";
            public const string KeyCachePage = "KeyCachePage";
            public const string FileUploadKey = "FileUploadKey";
            public const int DefaultPageSize = 20;
            public const string RoleCategory = "RoleCategory";
            public const string FormCategory = "FormCategory";
            public const string CurrentCatalog = "CurrentCatalog";
            public const string CatalogCatalog = "CatalogCatalog";
            public const string ProductID = "ProductID";
            public const string CombinationProductID = "CombinationProductID";
        }

        public static class QueryString
        {
            public const string TemplateID = "TemplateID";
            public const string PageID = "PageID";
            public const string MenuID = "MenuID";
            public const string ArticleID = "ArticleID";
            public const string CategoryID = "CategoryID";
            public const string ModuleID = "ModuleID";
            public const string XslID = "XslID";
            public const string PageSize = "PageSize";
            public const string PageNumber = "PageNumber";
            public const string ProductID = "ProductID";
            public const string CatalogID = "CatalogID";
        }

        public static class CMSAdminPages
        {
            public static string GetDesignTemplatePagePath(int TemplateID)
            {
                return "~/Admin/Template/FrmTemplateDesign.aspx?" + QueryString.ModuleID + "=2&" + QueryString.TemplateID + "=" + TemplateID;
            }

            public static string GetDesignPagePath(int PageID)
            {
                return "~/Admin/Page/FrmPageDesign.aspx?" + QueryString.ModuleID + "=2&" + QueryString.PageID + "=" + PageID;
            }

            public static string GetAdminLoginPage()
            {
                return "~/Admin/FrmLogin.aspx";
            }

            public static string GetAdminAccessDenied()
            {
                return "~/Admin/FrmAccessDenied.aspx";
            }

            public static string GetAdminLandingPage()
            {
                return "~/Admin/FrmLanding.aspx";
            }

            public static string GetProcutDetailsPage()
            {
                return "~/Admin/ECommerce/Product/FrmProduct.aspx?" + QueryString.ModuleID + "=4";
            }
        }

        public static class CMSPage
        {
            public static string GetMenuDetailsPage()
            {
                return "~/MenuDetails.aspx";
            }

            public static string GetNewsDetailsPage()
            {
                return "~/NewsDetails.aspx";
            }
        }
    }
}