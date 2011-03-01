using System.Linq;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class HomeController : BaseController {

        public HomeController() : base() {}

        public ActionResult Index() {
            if (base.userToken != null) {
                UsersController controller = new UsersController(userToken.access_token);
                try {
                    ViewData["UserFeed"] = controller.SelfFeed();
                    return View(controller.User(null));
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
