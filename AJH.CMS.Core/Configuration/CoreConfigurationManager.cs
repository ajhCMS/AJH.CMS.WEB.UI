using System;
using System.Configuration;

namespace AJH.CMS.Core.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// CoreConfigurationManager
    /// </summary>
    public class CoreConfigurationManager
    {
        #region Members
        /// <summary>
        /// singleton object of config section handler
        /// </summary>
        public static CoreConfigSectionHandler _CoreConfigSectionHandler;
        #endregion

        #region Constants
        /// <summary>
        /// Config Section name
        /// </summary>
        private static readonly string CORE_CONFIG_SECTION_NAME = "CoreConfiguration";
        #endregion

        #region Constructors
        /// <summary>
        /// Static Constructor
        /// </summary>
        static CoreConfigurationManager()
        {
            string message = string.Empty;
            string messageFormat = string.Empty;

            try
            {
                //Get config section
                _CoreConfigSectionHandler = ConfigurationManager.GetSection(CORE_CONFIG_SECTION_NAME) as CoreConfigSectionHandler;
            }
            catch (Exception ex)
            {
                message = string.Format(messageFormat, "Unhandled Exception occured While Loading Settings Configuration");
                throw new ConfigurationErrorsException(message, ex);
            }
        }
        #endregion
    }
}