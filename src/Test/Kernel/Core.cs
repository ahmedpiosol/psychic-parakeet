using TestApp.View;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading;

namespace TestApp.Kernel
{
    public class Core
    {
        /// <summary>
        /// Program Theme settings
        /// </summary>
        public static string Theme = Properties.Settings.Default.Theme, Color = Properties.Settings.Default.Color;

        /// <summary> 
        /// The first thing that program is going to do before showing up
        /// like checking for the user language etc
        /// </summary> 
        public static void StartUp_Engine()
        {
            UserLocalAppFolderPath();
            //upgrade the database if there is any changes 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }
        /// <summary>
        /// Get you the path for the Settings Config file in the Current User Local AppData Folder
        /// </summary>
        /// <returns>the Current Settings Folder Path and ends with \</returns>
        public static string UserLocalAppFolderPath()
        {
            var level = ConfigurationUserLevel.PerUserRoamingAndLocal;
            var configuration = ConfigurationManager.OpenExeConfiguration(level);
            var configurationFilePath = configuration.FilePath.Replace("user.config", "");
            return configurationFilePath;
        }
    }
}