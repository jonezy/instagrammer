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
                return View(controller.User(null));
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
