using System.Text.Json;

namespace lesson11.Extensions
{
    public static class JsonExtensions
    {
        public static T ToObject<T>(this string jsonString) 
            => JsonSerializer.Deserialize<T>(jsonString);
        
        public static string ToJson(this object obj, bool indented = false)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = indented
            };
            
            return JsonSerializer.Serialize(obj, settings);
        }
    }
}