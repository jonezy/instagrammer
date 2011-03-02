using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Instagrammer.Example {
    public static class EnvironmentHelpers {

        public static string GetConfigValue(string partialKey) {
            string fullKey = string.Format("{0}.{1}", ConfigurationManager.AppSettings["Environment"].ToString(), partialKey);

            try {
                return ConfigurationManager.AppSettings[fullKey].ToString();
            } catch {
                return "";
            }
        }

    }
}
