using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    [HandleError]
    public class FriendsController : BaseController {
        public FriendsController() : base() { }
        //
        // GET: /Friends/

        public ActionResult Index() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                RelationshipsController controller = new RelationshipsController(base.userToken.access_token);
                ViewData["Follows"] = controller.Follows(null);
            }
            return View();
        }

        public ActionResult Followers() {
            if (!string.IsNullOrEmpty(base.userToken.access_token)) {
                RelationshipsController controller = new RelationshipsController(base.userToken.access_token);
                ViewData["Followers"] = controller.FollowedBy(null);
            }
            return View();
        }

    }
}
