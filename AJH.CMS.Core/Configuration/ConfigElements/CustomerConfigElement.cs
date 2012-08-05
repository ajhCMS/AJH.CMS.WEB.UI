using System.Configuration;

namespace AJH.CMS.Core.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// CustomerConfigElement
    /// </summary>
    public class CustomerConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["Name"] as string;
            }
        }

        [ConfigurationProperty("Image", IsRequired = true)]
        public string Image
        {
            get
            {
                return this["Image"] as string;
            }
        }

        [ConfigurationProperty("EmailAdmin", IsRequired = true)]
        public string EmailAdmin
        {
            get
            {
                return this["EmailAdmin"] as string;
            }
        }

        [ConfigurationProperty("EmailInfo", IsRequired = true)]
        public string EmailInfo
        {
            get
            {
                return this["EmailInfo"] as string;
            }
        }

        [ConfigurationProperty("EmailInfo2", IsRequired = true)]
        public string EmailInfo2
        {
            get
            {
                return this["EmailInfo2"] as string;
            }
        }
    }
}