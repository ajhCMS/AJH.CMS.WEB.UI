using System.Configuration;

namespace AJH.CMS.Core.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// CoreConfigSectionHandler
    /// </summary>
    public class CoreConfigSectionHandler : ConfigurationSection
    {
        /// <summary>
        /// <see cref="AJH.CMS.Core.Configuration.CacheConfigElement"/>
        /// </summary>
        [ConfigurationProperty("Cache")]
        public CacheConfigElement CacheElement
        {
            get
            {
                return this["Cache"] as CacheConfigElement;
            }
        }

        /// <summary>
        /// <see cref="AJH.CMS.Core.Configuration.CustomerConfigElement"/>
        /// </summary>
        [ConfigurationProperty("Customer")]
        public CustomerConfigElement CustomerElement
        {
            get
            {
                return this["Customer"] as CustomerConfigElement;
            }
        }

        /// <summary>
        /// <see cref="AJH.CMS.Core.Configuration.SecurityConfigElement"/>
        /// </summary>
        [ConfigurationProperty("Security")]
        public SecurityConfigElement SecurityElement
        {
            get
            {
                return this["Security"] as SecurityConfigElement;
            }
        }
    }
}