using Newtonsoft.Json;

namespace Aplazame.Serializer
{
    public class JsonSerializer
    {
        public static string AsJsonString(dynamic value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
