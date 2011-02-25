﻿using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Instagram.Wrapper.Models;

namespace Instagram.Wrapper.Controllers {
    [HandleError]
    public class HomeController : Controller {
        const string COOKIE_ID = "instagrammer";

        public ActionResult Index() {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            
            OAuthToken userToken = new OAuthToken();

            if (Request.Cookies[COOKIE_ID] != null) {   
                HttpCookie userCookie =  Request.Cookies.Get(COOKIE_ID);
                userToken.access_token = userCookie.Values["token"];
            }

            InstagramUserController controller = new InstagramUserController(userToken.access_token);
            InstagramUser self = controller.Single(null);
            List<UserFeed> feedItems = controller.Feed();
            ViewData["UserFeed"] = feedItems;

            return View(self);
        }

        public ActionResult About() {
            return View();
        }
    }
}
