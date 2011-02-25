using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Instagram.Wrapper.Models;

namespace Instagram.Wrapper.Controllers
{
    public class OAuthController : Controller
    {
        const string _downloadUrl = "https://api.instagram.com/oauth/access_token";
        const string COOKIE_ID = "instagrammer";

        //
        // GET: /OAuth/
        public ActionResult AccessRequest() {

            string code = TryParse(Request.QueryString["CODE"].ToString());

            OAuthToken oauthToken = OAuthToken.Request(code);

            if (oauthToken != null) {
                // set a cookie with the users access token?
                HttpCookie userCookie = new HttpCookie(COOKIE_ID);
                Response.Cookies.Remove(COOKIE_ID);
                Response.Cookies.Add(userCookie);
                userCookie.Values.Add("token", oauthToken.access_token);
                Response.Cookies[COOKIE_ID].Expires = DateTime.Now.AddYears(1);
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
