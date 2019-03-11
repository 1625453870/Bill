using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bill.Common
{
    public static class JsonExtension
    {
        public static T JsonToT<T>(this string data)
            where T:class,new()
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string TryToJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
