namespace ConfigurationModule.ConfigurationHelper
{
    public  class PersistedConfiguration<T> where T : new()
    {
        public T Retrieve {
            get
            {
                return AppUtility.LoadAppConfiguration<T>();
            }
        }
    }
}