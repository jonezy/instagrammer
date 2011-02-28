using System;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers
{
    public class OAuthController : BaseController
    {
        const string _downloadUrl = "https://api.instagram.com/oauth/access_token";

        public ActionResult AccessRequest() {

            string code = TryParse(Request.QueryString["CODE"].ToString());
            AuthenticationController controller = new AuthenticationController();
            OAuthToken oauthToken = null;
            try {
                oauthToken = controller.Request(code, Server.UrlEncode("http://localhost/InstagramWrapper/OAuth/AccessRequest/"));
            } catch {  }

            if (oauthToken != null) {
                // set a cookie with the users access token?
                HttpCookie userCookie = new HttpCookie(COOKIE_ID);
                Response.Cookies.Remove(COOKIE_ID);
                Response.Cookies.Add(userCookie);
                userCookie.Values.Add("token", oauthToken.access_token);
                Response.Cookies[COOKIE_ID].Expires = DateTime.Now.AddYears(1);

                return RedirectToAction("Index", "Home");
            }

            return View(oauthToken);
        }

        private string TryParse(string value) {
            try {
                return value.ToString();
            } catch { return value; }
        }
    }
}
