using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public abstract class ActiveRecordBase {
        protected string _token;

        public ActiveRecordBase(string token) {
            _token = token;
        }

        protected static T Deserialize<T>(string json) {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
        
        protected static string Serialize<T>(T obj) {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static string GetJSON(string url, string postData) {
            WebRequest webRequest = null;
            byte[] byteSend = null;
            Stream streamOut = null;
            WebResponse webResponse = null;
            StreamReader streamReader = null;
            StreamWriter writer = null;

            // create the request
            webRequest = WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(postData)) {
                // push the data to the stream
                byteSend = Encoding.ASCII.GetBytes(postData);
                webRequest.ContentLength = byteSend.Length;
                webRequest.Method = "POST";

                streamOut = webRequest.GetRequestStream();
                streamOut.Write(byteSend, 0, byteSend.Length);
                streamOut.Flush();
                streamOut.Close();
            } else {
                webRequest.Method = "GET";
            }

            // deal with the response and save the file.
            try {
                // grab the response.
                webResponse = webRequest.GetResponse();
                streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);

                // only try and write something if there are records in the file
                if (streamReader.Peek() > -1) {
                    return streamReader.ReadToEnd();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                if (streamReader != null) {
                    streamReader.Close();
                    streamReader.Dispose();
                }
                if (writer != null) {
                    writer.Close();
                    writer.Dispose();
                }
            }
            return null;
        }
    }
}
