using System.Collections.Generic;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class FriendsController : BaseController {
        UsersController controller;
        public FriendsController() : base() { 
            controller = new UsersController(base.userToken.access_token);

            List<SubNavItem> subNavItems = new List<SubNavItem>();
            subNavItems.Add(new SubNavItem { LinkText = "Following", ActionName = "Following", ControllerName="Friends" });
            subNavItems.Add(new SubNavItem { LinkText = "Followers", ActionName = "Followers", ControllerName="Friends" });
            
            ViewData["SubNavItems"] = subNavItems;
        }

        public ActionResult Index() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Follows"] = controller.Follows(null).data;
            }
            return View();
        }

        public ActionResult Following() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Follows"] = controller.Follows(null).data;
            }
            return View("Index");
        }

        public ActionResult Followers() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Followers"] = controller.FollowedBy(null).data;
            }
            return View();
        }

    }
}
