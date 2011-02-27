using System.Linq;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class HomeController : BaseController {

        public HomeController() : base() {}

        public ActionResult Index() {
            UserController controller = new UserController(userToken.access_token);
            UserFollowsController followsController = new UserFollowsController(userToken.access_token);
            InstagramUser self = controller.User(null);
            
            ViewData["UserData"] = self;
            ViewData["UserFeed"] = controller.SelfFeed();
            ViewData["RecentMedia"] = controller.RecentMedia(null);
            ViewData["Following"] = followsController.Follows(null).Take(12).ToList();
            ViewData["FollowedBy"] = followsController.FollowedBy(null).Take(12).ToList();

            return View(self);
        }

        public ActionResult About() {
            return View();
        }
    }
}
