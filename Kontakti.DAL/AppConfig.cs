using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Kontakti.DAL
{
    /// <summary>
    /// contains read-only properties that are essentially short cuts to settings in the web.config file.
    /// </summary>
   public static class AppConfig
    {
        #region Public Properties

        /// <summary>Returns the connectionstring for the application.</summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }
        /// <summary>Returns the name of the current connectionstring for the application.</summary>
        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }
        }
        #endregion
    }
}
