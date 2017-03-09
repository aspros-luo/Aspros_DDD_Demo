using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspros_DDD_Infrastructure.Serializer
{
    public static class SerializerHelper
    {
        public static string ToJson<T>(T str)
        {
            return JsonConvert.SerializeObject(str);
        }

        public static T FromJson<T>(string str) 
        {
            var o= JsonConvert.DeserializeObject(str);
            return (T)o ;
        }
    }
}
