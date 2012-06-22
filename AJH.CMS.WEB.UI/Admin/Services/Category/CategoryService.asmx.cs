using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for CategoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CategoryService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownCategories(string knownCategoryValues, string category)
        {
            string[] values = category.Split('|');
            int ModuleID = 0;
            if (values.Length > 0)
                int.TryParse(values[0].Replace(CMSConfig.ConstantManager.CategoryCategory, ""), out ModuleID);

            List<Category> categories;
            if (ModuleID > 0)
                categories = CategoryManager.GetCategorys(ModuleID, CMSContext.PortalID, CMSContext.LanguageID);
            else
                categories = CategoryManager.GetCategorys(CMSContext.PortalID, CMSContext.LanguageID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (Category item in categories)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
            }
            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownCategoryItems(string knownCategoryValues, string category)
        {
            string[] values = category.Split('|');
            int currentCategoryID = 0;
            if (values.Length == 2)
            {
                int.TryParse(values[1].Replace(CMSConfig.ConstantManager.CurrentCategory, ""), out currentCategoryID);
            }
            int ModuleID = 0;
            int.TryParse(values[0].Replace(CMSConfig.ConstantManager.CategoryCategory, ""), out ModuleID);

            List<AJH.CMS.Core.Entities.Category> categories = CategoryManager.GetCategorys(ModuleID, CMSContext.PortalID, CMSContext.LanguageID);
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (AJH.CMS.Core.Entities.Category item in categories)
            {
                if (item.ID != currentCategoryID)
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID + ": " + item.Name, item.ID.ToString()));
            }
            return cascadingList.ToArray();
        }
    }
}
