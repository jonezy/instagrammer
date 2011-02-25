using System;
using System.Runtime.Serialization;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public class InstagramResponse {
        [DataMember]
        public Meta meta { get; set; }
        [DataMember]
        public InstagramUser data { get; set; }
    }

    [DataContract(Name="meta")]
    public class Meta {
        [DataMember]
        public string status { get; set; }
    }

    [DataContract(Name="data")]
    public partial class InstagramUser {
        public InstagramUser() : base("") { }
        [DataMember]
        public int id { get; set; }
        
        [DataMember]
        public string username { get; set; }
        
        [DataMember]
        public string first_name { get; set; }
        
        [DataMember]
        public string last_name { get; set; }
        
        [DataMember]
        public string profile_picture { get; set; }
        
        [DataMember]
        public Counts counts { get; set; } 
    }

    [DataContract(Name = "counts")]
    public class Counts {
        [DataMember]
        public string media { get; set; }
        [DataMember]
        public string follows { get; set; }
        [DataMember]
        public string followed_by { get; set; }
    }

    public partial class InstagramUser:ActiveRecordBase {
        public InstagramUser(string token) : base(token) { }

        public static InstagramUser Self(string token) {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("You must provide an instragram token");

            string json = GetJSON(string.Format(ApiUrls.USER_SELF_URL, token), null);
            InstagramResponse response = Deserialize<InstagramResponse>(json);

            return response.data;
        }

    }
}
