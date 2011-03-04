using System.Collections.Generic;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class FriendsController : BaseController {
        UsersClient client;
        public FriendsController() : base() {
            client = new UsersClient(base.userToken.access_token);

            List<SubNavItem> subNavItems = new List<SubNavItem>();
            subNavItems.Add(new SubNavItem { LinkText = "Following", ActionName = "Following", ControllerName="Friends" });
            subNavItems.Add(new SubNavItem { LinkText = "Followers", ActionName = "Followers", ControllerName="Friends" });
            
            ViewData["SubNavItems"] = subNavItems;
        }

        public ActionResult Index() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Follows"] = client.Follows(null).data;
            }
            return View();
        }

        public ActionResult Following() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Follows"] = client.Follows(null).data;
            }
            return View("Index");
        }

        public ActionResult Followers() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Followers"] = client.FollowedBy(null).data;
            }
            return View();
        }

    }
}
