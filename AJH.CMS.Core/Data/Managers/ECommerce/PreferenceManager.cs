using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class PreferenceManager
    {
        public static int Add(Preference preference)
        {
            return PreferenceDataMapper.Add(preference);
        }

        public static void UpdatePreference(int prefernceId, bool isEnabled)
        {
            PreferenceDataMapper.Update(prefernceId, isEnabled);
        }

        public static List<AJH.CMS.Core.Entities.Preference> GetPreferences(int portalID)
        {
            return PreferenceDataMapper.GetPreferences(portalID);
        }

        public static AJH.CMS.Core.Entities.Preference GetPreference(string preferenceName)
        {
            return PreferenceDataMapper.GetPreference(preferenceName);
        }
    }
}