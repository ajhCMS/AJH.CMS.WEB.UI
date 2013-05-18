using System.Collections.Generic;
using System.Web.UI;

namespace AJH.CMS.WEB.UI.Utilities
{
    public class CMSUserControlBase : UserControl
    {
        public int XSLTemplateID
        {
            get;
            set;
        }

        public int ContainerValue
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

        public int CombinationID
        {
            set;
            get;
        }

        public virtual Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            return items;
        }

        public virtual Dictionary<string, string> GetModulesValue(int PortalID, int LanguageID)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            return items;
        }
    }
}