using SystemConfigurationSetUp;


namespace SecurityModule
{
    public static class SystemSecurityStrings
    {
        public static string PasswordHash = CONFIGURATION.FromSettings.Retrieve.PSV.P;
        public static string SaltKey =CONFIGURATION.FromSettings.Retrieve.PSV.S;
        public static string VIKey = CONFIGURATION.FromSettings.Retrieve.PSV.V;

    }
}