namespace ConfigurationModule.ConfigurationHelper
{
    public  class PersistedConfiguration<T> where T : new()
    {
        public T Configuration {
            get
            {
                return AppUtility.LoadAppConfiguration<T>();
            }
        }
    }
}