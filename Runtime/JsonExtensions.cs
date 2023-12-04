using Newtonsoft.Json;

namespace Utilities
{
    public static class JsonExtensions
    {
        public static string ToJson(this object target)
        {
            return JsonConvert.SerializeObject(target);
        }

        public static T FromJson<T>(this string target)
        {
            return JsonConvert.DeserializeObject<T>(target);
        }
    }
}