using System.Linq;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class BaseController : Controller {
        protected const string COOKIE_ID = "instagrammer";
        protected OAuthToken userToken;

        public BaseController() {
            userToken = CookieHelper.GetOAuthToken(COOKIE_ID);

            ViewData["UserToken"] = userToken;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (userToken != null) {
                try {
                    UsersController controller = new UsersController(userToken.access_token);
                    RelationshipsController followsController = new RelationshipsController(userToken.access_token);
                    ApiResponse<UserFeed> recentMedia = controller.RecentMedia(null, null,null);

                    ViewData["UserData"] = controller.User(null);
                    ViewData["RecentMedia"] = recentMedia.data.Take(6).ToList();
                    ViewData["Following"] = followsController.Follows(null).Take(12).ToList();
                    ViewData["FollowedBy"] = followsController.FollowedBy(null).Take(12).ToList();
                } catch { }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
