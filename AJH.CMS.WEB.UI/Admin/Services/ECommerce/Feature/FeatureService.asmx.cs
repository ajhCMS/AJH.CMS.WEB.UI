﻿using System.Collections.Generic;
using System.Web.Services;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin.Services
{
    /// <summary>
    /// Summary description for FeatureService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FeatureService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetFilteredFeatures(string knownCategoryValues, string category)
        {
            List<Feature> Features = FeatureManager.GetFeatures(CMSContext.PortalID);
            int cuurentFeatureId = 0;
            int.TryParse(category, out cuurentFeatureId);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Features != null && Features.Count > 0)
                foreach (Feature item in Features)
                {
                    if (item.ID != cuurentFeatureId)
                        cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetAllFeatures(string knownCategoryValues, string category)
        {
            List<Feature> Features = FeatureManager.GetFeatures(CMSContext.PortalID);

            List<AjaxControlToolkit.CascadingDropDownNameValue> cascadingList = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

            if (Features != null && Features.Count > 0)
                foreach (Feature item in Features)
                {
                    cascadingList.Add(new AjaxControlToolkit.CascadingDropDownNameValue(item.ID.ToString() + ": " + item.Name, item.ID.ToString()));
                }

            return cascadingList.ToArray();
        }
    }
}
