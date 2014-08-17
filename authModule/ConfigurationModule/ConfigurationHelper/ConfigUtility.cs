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

        private static string Persist<T>(T obj, string file)
        {
            var json = Serialize(obj);
            File.WriteAllText(file, json);
            return File.ReadAllText(file);
        }

        private static T InitializeConfig<T>(string file, T init) where T : new()
        {
            var content = File.ReadAllText(file);
            var hasContent = !string.IsNullOrEmpty(content);
            var existsAndHasContent = (File.Exists(file) && hasContent);
            if (!existsAndHasContent)
            {
                content = Persist(init, file);
            }

            Condition.Requires(content).IsNotNullOrEmpty("Error loading config file content");
            var setUpFileList = DeSerialize<T>(content);

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