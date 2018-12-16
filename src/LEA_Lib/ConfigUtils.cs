using LEA_Lib.Exceptions;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace LEA.Lib
{
    public class ConfigUtils
    {
        private static NameValueCollection appSettings = null;

        private ConfigUtils() { }

        private static ConfigUtils configUtils = null;

        public static ConfigUtils GetConfig()
        {

            if (configUtils == null)
            {
                configUtils = new ConfigUtils();
                ReadAppSettings();
            }
            return configUtils;

        }

        public string this[string key]
        {
            get
            {
                string[] values = appSettings.GetValues(key);
                return values?[0];
            }

        }

        private static void ReadAppSettings()
        {
            try
            {
                // Get the AppSettings section.
                appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    throw new ConfigException("AppSettings section is empty");
                }

            }
            catch (Exception ex)
            {
                throw new ConfigException(ex.Message);
            }
        }

    }
}

