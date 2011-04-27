using System.Collections.Generic;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class HomeController : BaseController {

        public HomeController() : base() {
            List<SubNavItem> subNavItems = new List<SubNavItem>();
            subNavItems.Add(new SubNavItem { LinkText = "Your feed", ActionName = "Index", ControllerName = "Home" });
            subNavItems.Add(new SubNavItem { LinkText = "Your photos", ActionName = "Index", ControllerName = "Photos" });
            subNavItems.Add(new SubNavItem { LinkText = "Popular photos", ActionName = "Popular", ControllerName = "Photos" });

            ViewData["SubNavItems"] = subNavItems;
        }

        public ActionResult Index() {
            if (base.userToken != null) {
                UsersClient client = new UsersClient(userToken.access_token);
                try {
                    ViewData["UserFeed"] = client.SelfFeed();
                    return View(client.User(null).data);
                } catch { }
            }
            return View ();
        }

        public ActionResult About() {
            return View();
        }

        public string TestResult() {
            InstagramUser user = new InstagramUser();
            user.username = "jonezy";
            user.first_name = "Chris";
            user.last_name = "Jones";
            
            return user.Serialize();
        }

        [ChildActionOnly]
        public ActionResult Pager() {
            ApiResponse<FeedItem> model = ViewData["UserFeed"] as ApiResponse<FeedItem>;
            return PartialView("Pager", model.pagination);
        }
    }
}
