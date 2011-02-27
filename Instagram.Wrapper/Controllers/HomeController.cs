using System.Collections.Generic;
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

            UserController controller = new UserController(userToken.access_token);
            InstagramUser self = controller.User(null);
            ViewData["UserData"] = self;
            ViewData["UserFeed"] = controller.SelfFeed();
            ViewData["RecentMedia"] = controller.RecentMedia(null);

            UserFollowsController followsController = new UserFollowsController(userToken.access_token);
            ViewData["Following"] = followsController.Follows(null);
            ViewData["FollowedBy"] = followsController.FollowedBy(null);

            return View(self);
        }

        public ActionResult About() {
            return View();
        }
    }
}
