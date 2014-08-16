using System.Collections.Generic;

namespace ConfigurationModule.ConfigurationModels
{
    public class AppConfig
    {
        public AppConfig()
        {
            PSV=new PSVModule();
            AdminAccount = new AdminAccount();
            SystemEmailAccounts = new List<SystemEmailAccount>
            {
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.Common},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.UserAccountAndRegistration},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.TechnicalSupport},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.Information},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.Security},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.SystemNotification},
                new SystemEmailAccount {Intention = SystemEmailAccountIntention.AdminNotification}
            };
        }

        public PSVModule PSV { set; get; }
        public AdminAccount AdminAccount { set; get; }
        public List<SystemEmailAccount> SystemEmailAccounts { set; get; }
    }
}