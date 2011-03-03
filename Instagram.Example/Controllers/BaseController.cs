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
            
                try {
                    if (userToken != null) {
                    UsersController controller = new UsersController(userToken.access_token);
                    ApiResponse<FeedItem> recentMedia = controller.RecentMedia(null, null, null);

                    ViewData["UserData"] = controller.User(null).data;
                    if (recentMedia != null)
                        ViewData["RecentMedia"] = recentMedia.data.Take(6).ToList();
                    ViewData["Following"] = controller.Follows(null).data.Take(12).ToList();
                    ViewData["FollowedBy"] = controller.FollowedBy(null).data.Take(12).ToList();
                    } else {
                        MediaController mediaController = new MediaController("");
                        ViewData["Popular"] = mediaController.Popular(EnvironmentHelpers.GetConfigValue("ClientId")).data;
                        ViewData["Authenticated"] = "false";
                    }
                } catch { }


            base.OnActionExecuting(filterContext);
        }
    }
}
