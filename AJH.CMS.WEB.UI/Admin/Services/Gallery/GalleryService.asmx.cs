using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for ArticleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GalleryService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownGalleryItemType(string knownCategoryValues, string category)
        {
            Dictionary<string, int> articleTypes = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.GalleryItemType));
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (KeyValuePair<string, int> item in articleTypes)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.Key, item.Value.ToString()));
            }
            return cascadingList.ToArray();
        }
    }
}