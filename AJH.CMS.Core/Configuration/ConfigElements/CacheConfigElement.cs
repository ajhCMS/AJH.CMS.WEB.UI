using System.Configuration;

namespace AJH.CMS.Core.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// CacheConfigElement
    /// </summary>
    public class CacheConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("TimeOut", IsRequired = true)]
        public string TimeOut
        {
            get
            {
                return this["TimeOut"] as string;
            }
        }

        [ConfigurationProperty("VirtualPathMonitoringFile", IsRequired = true)]
        public string VirtualPathMonitoringFile
        {
            get
            {
                return this["VirtualPathMonitoringFile"] as string;
            }
        }

        [ConfigurationProperty("CachePriority", IsRequired = true)]
        public string CachePriority
        {
            get
            {
                return this["CachePriority"] as string;
            }
        }
    }
}