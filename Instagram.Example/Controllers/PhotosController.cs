using System.Web.Mvc;
using instagrammer;
using System.Collections.Generic;

namespace Instagrammer.Example.Controllers {
    public class PhotosController : BaseController {
        UsersClient client;
        public PhotosController() : base() {
            client = new UsersClient(base.userToken.access_token);

            List<SubNavItem> subNavItems = new List<SubNavItem>();
            subNavItems.Add(new SubNavItem { LinkText = "Your feed", ActionName = "Index", ControllerName = "Home" });
            subNavItems.Add(new SubNavItem { LinkText = "Your photos", ActionName = "Index", ControllerName = "Photos" });
            subNavItems.Add(new SubNavItem { LinkText = "Popular photos", ActionName = "Popular", ControllerName = "Photos" });

            ViewData["SubNavItems"] = subNavItems;
        }

        //
        // GET: /Photos/
        public ActionResult Index() {
            try {
                ApiResponse<FeedItem> media = client.RecentMedia(null, null, null);

                ViewData["PreviousPage"] = "";
                ViewData["Photos"] = media.data;
            } catch { }
            return View();
        }
        
        public ActionResult Popular() {
            try {
                
                MediaClient mediaClient = new MediaClient(base.userToken.access_token);
                ApiResponse<FeedItem> popular = mediaClient.Popular(EnvironmentHelpers.GetConfigValue("ClientId"));

                ViewData["Photos"] = popular.data;
            } catch { }
            
            return View();
        }

        public ActionResult Next() {
            string next_max_id = RouteData.Values["id"] != null ? RouteData.Values["id"].ToString() : "";
            UsersClient client = new UsersClient(base.userToken.access_token);
            ApiResponse<FeedItem> media = client.RecentMedia(null, next_max_id, null);
            
            ViewData["PreviousPage"] = media.data[0].id;
            ViewData["Photos"] = media;

            return View("Index");
        }

        public ActionResult Previous() {
            string prev_max_id = RouteData.Values["id"] != null ? RouteData.Values["id"].ToString() : "";
            ApiResponse<FeedItem> media = client.RecentMedia(null, null, prev_max_id);

            ViewData["PreviousPage"] = media.data[0].id;
            ViewData["Photos"] = media;

            return View("Index");
        }

        public ActionResult Details() {
            object mediaId;
            RouteData.Values.TryGetValue("id", out mediaId);
            
            try {
                MediaClient mediaClient = new MediaClient(userToken.access_token);
                ViewData["PhotoDetails"] = mediaClient.Media(mediaId.ToString()).data;

            } catch (System.Net.WebException ex) {
                ViewData["Error"] = ex.Message;
            }

            return View();
        }
    }
}
