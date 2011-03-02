using System.Web;

namespace instagrammer {
    public class AuthenticationController : ControllerBase {
        public AuthenticationController(string token) : base(token) { }
        public AuthenticationController() : base("") { }

        public OAuthToken Request(string code, string redirect_uri, string clientId, string clientSecret) {
            string dataFormat = "client_id={0}&client_secret={1}&grant_type={2}&redirect_uri={3}&code={4}";
            string postData = string.Format(dataFormat, clientId, clientSecret, "authorization_code", redirect_uri, code);
            string json = base.GetJSON(ApiUrls.OAUTHTOKEN_REQUEST_URL, postData, "POST");
            OAuthToken oauthToken = json.Deserialize<OAuthToken>();
            
            return oauthToken;
        }
    }
}
