using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for ManufacturarService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ManufacturarService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownManufacturars(string knownCategoryValues, string category)
        {
            List<Manufacturar> Manufacturars = ManufacturarManager.GetManufacturars(CMSContext.PortalID, CMSContext.LanguageID);

            int cuurentManufacturarId = 0;
            int.TryParse(category, out cuurentManufacturarId);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Manufacturars != null && Manufacturars.Count > 0)
                foreach (Manufacturar item in Manufacturars)
                {
                    if (item.ID != cuurentManufacturarId)
                        cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Description, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetAllManufacturars(string knownCategoryValues, string category)
        {
            List<Manufacturar> Manufacturars = ManufacturarManager.GetManufacturars(CMSContext.PortalID, CMSContext.LanguageID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Manufacturars != null && Manufacturars.Count > 0)
                foreach (Manufacturar item in Manufacturars)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Description, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
