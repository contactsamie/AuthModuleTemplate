using System.IO;
using System.Linq;
using CuttingEdge.Conditions;
using Newtonsoft.Json;


namespace ConfigurationModule.ConfigurationHelper
{
    public static class AppUtility
    {
        private static string AppConfigLocation { set; get; }

        private static string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        private static T DeSerialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        private static void Persist<T>(T obj, string file)
        {
            string json = Serialize(obj);
            File.WriteAllText(file, json);
        }

        private static T InitializeConfig<T>(string file, T init) where T : new()
        {
            if (!File.Exists(file) || string.IsNullOrEmpty(File.ReadAllText(file)))
            {
                Persist(init, file);
            }

            var setUpFileList = DeSerialize<T>(File.ReadAllText(file));

            return setUpFileList;
        }

        public static T LoadAppConfiguration<T>() where T : new()
        {
            var setupFileConfigs = InitializeConfig(CONFIGURATIONS.PathToSetupFile, CONFIGURATIONS.InitialSetUpFileObject);
            var firstActiveConfig = setupFileConfigs.FindAll(x => x.IsActive).FirstOrDefault();

            Condition.Requires(firstActiveConfig).IsNotNull("No Active Configuration Setup");

            AppConfigLocation = firstActiveConfig.FileName;
            Condition.Requires(firstActiveConfig.BaseDir).IsNotNullOrEmpty("MissingBase Dir");
            Condition.Requires(AppConfigLocation).IsNotNullOrEmpty("Name missing from active configuration");

            return InitializeConfig(firstActiveConfig.BaseDir + AppConfigLocation, new T());
        }
    }
}