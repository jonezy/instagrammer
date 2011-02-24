using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace Instagram.Wrapper {
    public static class Requestor {

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
