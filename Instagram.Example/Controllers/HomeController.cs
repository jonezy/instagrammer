using System.Linq;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class HomeController : BaseController {

        public HomeController() : base() {}

        public ActionResult Index() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                UsersController controller = new UsersController(userToken.access_token);
                RelationshipsController followsController = new RelationshipsController(userToken.access_token);
                InstagramUser self = controller.User(null);

                ViewData["UserData"] = self;
                ViewData["UserFeed"] = controller.SelfFeed();
                ViewData["RecentMedia"] = controller.RecentMedia(null).Take(9).ToList();
                ViewData["Following"] = followsController.Follows(null).Take(12).ToList();
                ViewData["FollowedBy"] = followsController.FollowedBy(null).Take(12).ToList();

                return View(self);
            }
            return View ("");
        }

        public ActionResult About() {
            return View();
        }
    }
}
