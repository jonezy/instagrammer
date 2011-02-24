using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public partial class InstagramUser {
        public InstagramUser() : base("") { }
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string username { get; set; }
        
        [DataMember]
        public string full_name { get; set; }
    }

    public partial class InstagramUser:ActiveRecordBase {
        public InstagramUser(string token) : base(token) { }

        public static InstagramUser Self(string token) {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("You must provide an instragram token");

            string url = string.Format("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", token);

            string tokenJSON = Requestor.GetJSON(url, null);
            InstagramUser user = new InstagramUser();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(user.GetType());
            MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(tokenJSON));
            user = serializer.ReadObject(memoryStream) as InstagramUser;

            return user;
        }
    }
}
