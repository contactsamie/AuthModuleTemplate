using System.Collections.Generic;

namespace ConfigurationModule.ConfigurationModels
{
    public abstract class AppConfig
    {
        public PSVModule PSV { set; get; }
        public AdminAccount AdminAccount { set; get; }
        public List<SystemEmailAccount> SystemEmailAccounts { set; get; }
    }
}