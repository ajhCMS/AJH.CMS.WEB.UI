using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for CatalogService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CatalogService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownCatalogs(string knownCategoryValues, string category)
        {
            List<Catalog> Catalogs = CatalogManager.GetCatalogs(CMSContext.PortalID, CMSContext.LanguageID);

            int cuurentCatalogId = 0;
            int.TryParse(category, out cuurentCatalogId);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Catalogs != null && Catalogs.Count > 0)
                foreach (Catalog item in Catalogs)
                {
                    if (item.ID != cuurentCatalogId)
                        cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
