using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace detect_a_person_in_video
{
    internal static class JsonHelper
    {
        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static string FormatJson<T>(string json)
        {
            return JsonConvert.SerializeObject(FromJson<T>(json), Formatting.Indented);
        }
    }
}