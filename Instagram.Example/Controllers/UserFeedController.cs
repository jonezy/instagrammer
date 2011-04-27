using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class UserFeedController : BaseController {
        UsersClient client;
        public UserFeedController()
            : base() {
            client = new UsersClient(base.userToken.access_token);
        }
        //
        // GET: /UserFeed/

        public ActionResult Index() {
            return View();
        }

        public ActionResult Next() {
            string next_max_id = RouteData.Values["id"] != null ? RouteData.Values["id"].ToString() : "";
            UsersClient client = new UsersClient(base.userToken.access_token);
            ApiResponse<FeedItem> media = client.SelfFeed(next_max_id, null);

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

    }
}
