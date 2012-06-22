using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
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
    public class MenuService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownMenuType(string knownCategoryValues, string category)
        {
            Dictionary<string, int> menuTypes = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.MenuType));
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (KeyValuePair<string, int> item in menuTypes)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.Key, item.Value.ToString()));
            }
            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownMenuItems(string knownCategoryValues, string category)
        {
            string[] values = category.Split('|');
            int currentMenuID = 0;
            if (values.Length == 2)
            {
                int.TryParse(values[1].Replace(CMSConfig.ConstantManager.CurrentMenu, ""), out currentMenuID);
            }
            int CategoryID = 0;
            int.TryParse(values[0].Replace(CMSConfig.ConstantManager.CategoryMenu, ""), out CategoryID);

            List<AJH.CMS.Core.Entities.Menu> menus = MenuManager.GetMenusParentObjByCategory(CategoryID);
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (AJH.CMS.Core.Entities.Menu item in menus)
            {
                if (item.ID != currentMenuID)
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID + ": " + item.Name, item.ID.ToString()));
            }
            return cascadingList.ToArray();
        }
    }
}
