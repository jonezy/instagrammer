using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class PhotosController : BaseController {
        public PhotosController() : base() { }

        //
        // GET: /Photos/
        public ActionResult Index() {
            UsersController controller = new UsersController(base.userToken.access_token);
            List<UserFeed> media = controller.RecentMedia(null);
            ViewData["Photos"] = media;

            return View();
        }

    }
}
