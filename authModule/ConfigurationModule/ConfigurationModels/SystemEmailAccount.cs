using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConfigurationModule.ConfigurationModels
{
    public class SystemEmailAccount
    {
      
        public string UserName{ set; get; }
        public string From { set; get; }
        public string Password { set; get; }
        public string Smtp { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SystemEmailAccountIntention Intention { set; get; }

    }
}