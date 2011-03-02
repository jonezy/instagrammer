using System.Web.Mvc;
using instagrammer;
using System.Collections.Generic;

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
                UsersController controller = new UsersController(userToken.access_token);
                try {
                    ViewData["UserFeed"] = controller.SelfFeed().data;
                    return View(controller.User(null).data);
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
    }
}
