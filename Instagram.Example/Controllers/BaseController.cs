using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class BaseController : Controller {
        protected const string COOKIE_ID = "instagrammer";
        protected OAuthToken userToken;

        public BaseController() {
            userToken = new OAuthToken();

            if (Request.Cookies[COOKIE_ID] != null) {
                HttpCookie userCookie = Request.Cookies.Get(COOKIE_ID);
                userToken.access_token = userCookie.Values["token"];
            }
        }
    }
}
