using System;
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
    public class CMSControlService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownCMSControls(string knownCategoryValues, string category)
        {
            StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int ModuleId = 0;
            int.TryParse(knownCategoryValuesDictionary["Modules"], out ModuleId);

            List<CMSControl> cmsControls = CMSControlManager.GetCMSControls(ModuleId);
            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            foreach (CMSControl cmsControl in cmsControls)
            {
                cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(cmsControl.Name, cmsControl.ID.ToString()));
            }
            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownContainerValues(string knownCategoryValues, string category)
        {
            StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int CMSControlID = 0;
            int.TryParse(knownCategoryValuesDictionary["CMSControls"], out CMSControlID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            CMSControl cmsControl = CMSControlManager.GetCMSControl(CMSControlID);
            if (cmsControl != null)
            {
                try
                {
                    System.Web.UI.Page page = new System.Web.UI.Page();
                    CMSUserControlBase userControl = page.LoadControl(cmsControl.UserControlPath) as CMSUserControlBase;
                    if (userControl != null)
                    {
                        Dictionary<string, string> itemsControl = userControl.GetContainerValue(cmsControl.ModuleID, CMSContext.PortalID, CMSContext.LanguageID);
                        foreach (KeyValuePair<string, string> itemControl in itemsControl)
                        {
                            cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(itemControl.Value, itemControl.Key));
                        }
                    }
                }
                catch (Exception ex)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(ex.Message, "0"));
                }
            }
            return cascadingList.ToArray();
        }
    }
}