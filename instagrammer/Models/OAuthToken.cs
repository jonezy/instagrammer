using System.Runtime.Serialization;
using System.Web;

namespace instagrammer {
    [DataContract]
    public partial class OAuthToken {
        [DataMember]
        public string access_token { get; set; }
        
        [DataMember]
        public InstagramUser user {get;set;}
    }
}
