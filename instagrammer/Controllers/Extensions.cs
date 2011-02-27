using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace instagrammer {
    internal static partial class Extensions {

        public static T Deserialize<T>(this string json) {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();

            return obj;
        }

        public static string Serialize<T>(this T obj) {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();

            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();

            return retVal;
        }

    }
}
