using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class FriendsController : BaseController {
        UsersController controller;
        public FriendsController() : base() { 
            controller = new UsersController(base.userToken.access_token); 
        }

        public ActionResult Index() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {

                ViewData["Follows"] = controller.Follows(null).data;
            }
            return View();
        }

        public ActionResult Followers() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                ViewData["Followers"] = controller.FollowedBy(null).data;
            }
            return View();
        }

    }
}
