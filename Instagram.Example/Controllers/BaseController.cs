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
                    UsersClient client = new UsersClient(userToken.access_token);
                    ApiResponse<FeedItem> recentMedia = client.RecentMedia(null, null, null);

                    ViewData["UserData"] = client.User(null).data;

                    if (recentMedia != null) {
                        ViewData["RecentMedia"] = recentMedia.data.Take(6).ToList();
                        ViewData["Following"] = client.Follows(null).data.Take(12).ToList();
                        ViewData["FollowedBy"] = client.FollowedBy(null).data.Take(12).ToList();
                    }
                } else {
                    MediaClient mediaClient = new MediaClient("");
                    ViewData["Popular"] = mediaClient.Popular(EnvironmentHelpers.GetConfigValue("ClientId")).data;
                    ViewData["Authenticated"] = "false";
                }
            } catch { }

            base.OnActionExecuting(filterContext);
        }
    }
}
