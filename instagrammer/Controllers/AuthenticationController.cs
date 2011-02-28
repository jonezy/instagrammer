using System.Web;

namespace instagrammer {
    public class AuthenticationController : ControllerBase {
        public AuthenticationController(string token) : base(token) { }
        public AuthenticationController() : base("") { }

        public OAuthToken Request(string code, string redirect_uri) {
            string dataFormat = "client_id={0}&client_secret={1}&grant_type={2}&redirect_uri={3}&code={4}";
            string postData = string.Format(dataFormat, "bfbdf77fbe934ffc8fbc710f6d15f75e", "5cca14feb8d9421e85d8950e23a80229", "authorization_code", redirect_uri, code);
            string json = base.GetJSON(ApiUrls.OAUTHTOKEN_REQUEST_URL, postData);
            OAuthToken oauthToken = json.Deserialize<OAuthToken>();
            
            return oauthToken;
        }
    }
}
