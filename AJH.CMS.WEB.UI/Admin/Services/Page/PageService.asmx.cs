using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for MenuService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PageService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownPageType(string knownCategoryValues, string category)
        {
            Dictionary<string, int> pageTypes = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.PageType));
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (KeyValuePair<string, int> item in pageTypes)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.Key, item.Value.ToString()));
            }
            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownPages(string knownCategoryValues, string category)
        {
            List<Page> pages = PageManager.GetPages(CMSContext.PortalID, CMSContext.LanguageID);
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (Page item in pages)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.Name, item.ID.ToString()));
            }
            return cascadingList.ToArray();
        }
    }
}