using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LunoApi.Net.Common
{
    public static class Util
    {
        public static readonly JsonSerializer JsonSerializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
        internal static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            using (var stringReader = new StringReader(value))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return (T)serializer.Deserialize(jsonTextReader, typeof(T));
                }
            }
        }
    }
}
