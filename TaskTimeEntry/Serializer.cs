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
            return JsonConvert.SerializeObject(Data, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
        }

        public static T DeserializeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
