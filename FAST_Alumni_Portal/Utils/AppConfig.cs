using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FAST_Alumni_Portal.Utils
{
    public class AppConfig
    { 
           public static string Get(string key)
    {
        if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
        {
            return ConfigurationManager.AppSettings[key];
        }
        else
        {
            throw new Exception("Configuration Key not configured properly. Key Name: " + key);
        }
    }
}
}