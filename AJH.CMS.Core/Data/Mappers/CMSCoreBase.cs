
namespace AJH.CMS.Core.Data
{
    public static class CMSCoreBase
    {
        #region Constant

        internal const string PN_ROW_FROM = "P_ROW_FROM";
        internal const string PN_ROW_TO = "P_ROW_TO";
        internal const string PN_TOTAL_COUNT = "P_TOTAL_COUNT";

        #endregion

        public static string CMSCoreConnectionString;

        static CMSCoreBase()
        {
            CMSCoreConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CMSCoreConnectionString"].ConnectionString;
        }
    }
}