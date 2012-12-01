using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for TaxService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TaxService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetAllTaxs(string knownCategoryValues, string category)
        {
            List<Tax> Taxs = TaxManager.GetTaxs(CMSContext.PortalID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Taxs != null && Taxs.Count > 0)
                foreach (Tax item in Taxs)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Rate, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
