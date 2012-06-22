using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class CMSControlManager
    {
        public static int Add(CMSControl cmsControl)
        {
            return CMSControlDataMapper.Add(cmsControl);
        }

        public static void Update(CMSControl cmsControl)
        {
            CMSControlDataMapper.Update(cmsControl);
        }

        public static void Delete(int ID)
        {
            CMSControlDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            CMSControlDataMapper.DeleteLogical(ID);
        }

        public static List<CMSControl> GetCMSControls()
        {
            return CMSControlDataMapper.GetCMSControls();
        }

        public static List<CMSControl> GetCMSControls(int ModuleID)
        {
            return CMSControlDataMapper.GetCMSControls(ModuleID);
        }

        public static CMSControl GetCMSControl(int ID)
        {
            return CMSControlDataMapper.GetCMSControlById(ID);
        }
    }
}