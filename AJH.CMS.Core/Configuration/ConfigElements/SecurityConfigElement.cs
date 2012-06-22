using System.Configuration;

namespace AJH.CMS.Core.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// SecurityConfigElement
    /// </summary>
    public class SecurityConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("SessionCurrentUserKey", IsRequired = true)]
        public string SessionCurrentUserKey
        {
            get
            {
                return this["SessionCurrentUserKey"] as string;
            }
        }

        [ConfigurationProperty("SessionCurrentRoleKey", IsRequired = true)]
        public string SessionCurrentRoleKey
        {
            get
            {
                return this["SessionCurrentRoleKey"] as string;
            }
        }

        [ConfigurationProperty("SessionCurrentFormKey", IsRequired = true)]
        public string SessionCurrentFormKey
        {
            get
            {
                return this["SessionCurrentFormKey"] as string;
            }
        }
    }
}