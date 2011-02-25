using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
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
        public OAuthToken(string token) : base(token) { }

        public static OAuthToken Request(string code) {
            string dataFormat = "client_id={0}&client_secret={1}&grant_type={2}&redirect_uri={3}&code={4}";
            string postData = string.Format(dataFormat, "bfbdf77fbe934ffc8fbc710f6d15f75e", "5cca14feb8d9421e85d8950e23a80229", "authorization_code", HttpContext.Current.Server.UrlEncode("http://localhost/InstagramWrapper/OAuth/AccessRequest/"), code);
            string json = GetJSON(ApiUrls.OAUTHTOKEN_REQUEST_URL, postData);
            OAuthToken oauthToken = Deserialize<OAuthToken>(json);
            
            return oauthToken;
        }
    }
}
