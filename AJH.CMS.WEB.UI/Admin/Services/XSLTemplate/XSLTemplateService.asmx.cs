using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for TemplateService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class XSLTemplateService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownXSLTemplates(string knownCategoryValues, string category)
        {
            StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int ModuleId = 0;
            int.TryParse(knownCategoryValuesDictionary["Modules"], out ModuleId);

            List<XSLTemplate> xslTemplates = XSLTemplateManager.GetXSLTemplates(ModuleId, CMSContext.PortalID, CMSContext.LanguageID);
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (XSLTemplate xslTemplate in xslTemplates)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(xslTemplate.Name, xslTemplate.ID.ToString()));
            }
            return cascadingList.ToArray();
        }
    }
}