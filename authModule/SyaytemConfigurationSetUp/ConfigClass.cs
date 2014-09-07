using System.Collections.Generic;
using System.Linq;
using ModlesLib.ConfigurationModels;


namespace SystemConfigurationSetUp
{
    public class ConfigClass 
    {
        public PSVModule PSV { set; get; }
        public AdminAccount AdminAccount { set; get; }
        public List<SystemEmailAccount> SystemEmailAccounts { set; get; }
        public SystemEmailAccount SystemEmailAccount
        {
            get
            {
                var emailAcount = SystemEmailAccounts.FindAll(x => x.Intention == SystemEmailAccountIntention.UserAccountAndRegistration);
                return emailAcount.FirstOrDefault();
            }
        }
        public ConfigClass()
        {
            PSV=new PSVModule();
            AdminAccount = new AdminAccount();
            SystemEmailAccounts = new List<SystemEmailAccount>();
        }

    }
}