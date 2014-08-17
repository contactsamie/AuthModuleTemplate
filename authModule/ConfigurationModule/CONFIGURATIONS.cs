using System;
using System.Collections.Generic;
using System.Linq;
using ConfigurationModule.ConfigurationHelper;
using ConfigurationModule.ConfigurationModels;

namespace ConfigurationModule
{
    public  class CONFIGURATIONS : CONFIGURATIONS<SampleAppConfig>
    {
    }

    public  class CONFIGURATIONS<T> where T : AppConfig, new()
    {
        public static PersistedConfiguration<T> Application = new PersistedConfiguration<T>();
        public static SystemEmailAccount SystemEmailAccount { 
            get
            {
              var emailAcount=   Application.Configuration.SystemEmailAccounts.FindAll(x => x.Intention == SystemEmailAccountIntention.UserAccountAndRegistration);
              return emailAcount.FirstOrDefault();
            }
        }

        private const string SetUpFile = @"app.config.json";
        private const string DebugConfigFile = @"debug.config.json";
        private const string ReleaseConfigFile = @"release.config.json";
        public static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string PathToSetupFile = BaseDir + SetUpFile;
       
        public static List<SetUpFile> InitialSetUpFileObject =new List<SetUpFile>
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
    }
}