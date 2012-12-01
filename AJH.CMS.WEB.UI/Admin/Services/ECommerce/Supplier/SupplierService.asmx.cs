using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for SupplierService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SupplierService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownSuppliers(string knownCategoryValues, string category)
        {
            List<Supplier> Suppliers = SupplierManager.GetSuppliers(CMSContext.PortalID, CMSContext.LanguageID);

            int cuurentSupplierId = 0;
            int.TryParse(category, out cuurentSupplierId);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Suppliers != null && Suppliers.Count > 0)
                foreach (Supplier item in Suppliers)
                {
                    if (item.ID != cuurentSupplierId)
                        cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }


        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetAllSuppliers(string knownCategoryValues, string category)
        {
            List<Supplier> Suppliers = SupplierManager.GetSuppliers(CMSContext.PortalID, CMSContext.LanguageID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Suppliers != null && Suppliers.Count > 0)
                foreach (Supplier item in Suppliers)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
