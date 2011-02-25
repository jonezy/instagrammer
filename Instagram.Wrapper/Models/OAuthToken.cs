using System.Runtime.Serialization;
using System.Web;

namespace Instagram.Wrapper.Models {
    [DataContract]
    public partial class OAuthToken {
        public OAuthToken() : base("") { }
        [DataMember]
        public string access_token { get; set; }
        
        [DataMember]
        public InstagramUser user {get;set;}
    }

    public partial class OAuthToken:ActiveRecordBase {

    }
}
