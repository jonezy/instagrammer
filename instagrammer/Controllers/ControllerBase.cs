using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace instagrammer {
    [DataContract]
    public abstract class ControllerBase {
        protected string _token;

        public ControllerBase(string token) {
             _token = token;
        }

        public virtual string GetJSON(string url, string postData) {
            string returnValue = string.Empty;

            // create the request
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            
            if (!string.IsNullOrEmpty(postData)) {
                // posting data to a url
                byte[] byteSend = Encoding.ASCII.GetBytes(postData);
                webRequest.ContentLength = byteSend.Length;
                webRequest.Method = "POST";

                Stream streamOut = webRequest.GetRequestStream();
                streamOut.Write(byteSend, 0, byteSend.Length);
                streamOut.Flush();
                streamOut.Close();
            } else {
                // getting data
                webRequest.Method = "GET";
            }

            // deal with the response and return
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);

            if (streamReader.Peek() > -1) {
                returnValue = streamReader.ReadToEnd();
            }
            streamReader.Close();
            streamReader.Dispose();

            return returnValue;
        }
    }
}
