using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Instagrammer.Example.Controllers
{
    public class SecurityController : BaseController
    {
        public SecurityController() : base () {}
        //
        // GET: /Authentication/

        public ActionResult Logout()
        {
            // set a cookie with the users access token?
            HttpCookie userCookie = new HttpCookie(COOKIE_ID);
            Response.Cookies.Remove(COOKIE_ID);
            Response.Cookies.Add(userCookie);
            Response.Cookies[COOKIE_ID].Expires = DateTime.Now.AddYears(1);

            return RedirectToAction("Index", "Home");
        }

    }
}
