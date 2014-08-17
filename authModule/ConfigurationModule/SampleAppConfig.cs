using System.Collections.Generic;
using ConfigurationModule.ConfigurationModels;

namespace ConfigurationModule
{
    public class SampleAppConfig : AppConfig
    {
        public SampleAppConfig()
        {
            PSV=new PSVModule();
            AdminAccount = new AdminAccount();
            SystemEmailAccounts = new List<SystemEmailAccount>();
        }

    }
}