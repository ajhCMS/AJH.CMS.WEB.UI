using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for GroupService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GroupService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetAllGroups(string knownCategoryValues, string category)
        {
            List<Group> Groups = GroupManager.GetGroups(CMSContext.PortalID, CMSContext.LanguageID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Groups != null && Groups.Count > 0)
                foreach (Group item in Groups)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
