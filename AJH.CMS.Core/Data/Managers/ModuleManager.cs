using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class ModuleManager
    {
        public static List<Module> GetModules()
        {
            return ModuleDataMapper.GetModules();
        }

        public static List<Module> GetModules(int ParentID)
        {
            return ModuleDataMapper.GetModules(ParentID);
        }
    }
}