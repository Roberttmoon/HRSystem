using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public static class Serializer<T>
    {
        public static string SerializeToJson(T Data)
        {
            return JsonConvert.SerializeObject(Data);
        }

        public static T DeserializeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static Dictionary<T, T> CreateDictionary(T data1, T data2)
        {
            Dictionary<T, T> mapped = new Dictionary<T, T>();
            mapped.Add(data1, data2);
            return mapped;
        }
    }
}
