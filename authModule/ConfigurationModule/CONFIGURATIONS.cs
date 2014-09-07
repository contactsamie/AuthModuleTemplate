using ConfigurationModule.ConfigurationHelper;

using System;
using System.Collections.Generic;

namespace ConfigurationModule
{
    /// <summary>
    /// The name of the class that implements CONFIGURATION will be the name by which configuration data will be accessed
    /// eg if you have  me:CONFIGURATION then you will do me.FromSettings.UserName
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CONFIGURATION<T> where T : new()
    { 
        
        public static PersistedConfiguration<T> FromSettings = new PersistedConfiguration<T>();

        #region Internal Members

        internal static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        internal static string PathToSetupFile = BaseDir + SetUpFile;
      

        protected const string SetUpFile = @"app.config.json";
        protected const string DebugConfigFile = @"debug.config.json";
        protected const string ReleaseConfigFile = @"release.config.json";

        internal static List<SetUpFile> InitialSetUpFileObject = new List<SetUpFile>
        {
                new SetUpFile
                {
                    BaseDir=BaseDir,
                    FileName =  DebugConfigFile,
                    IsActive = true
                },
                new SetUpFile
                {
                    BaseDir=BaseDir,
                    FileName = ReleaseConfigFile,
                    IsActive = false
                }
            };

        #endregion
    }
}