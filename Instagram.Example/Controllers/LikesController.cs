using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class LikesController : BaseController {
        public LikesController()
            : base() {

        }
        //
        // GET: /Likes/

        public ActionResult Index(string mediaId) {
            return View();
        }

        //
        // GET: /Likes/Create
        [HttpPost]
        public JsonResult Create(FeedItem feedItem) {
            try {
                MediaClient client = new MediaClient(base.userToken.access_token);
                ApiSingleResponse<string> response = client.Like(feedItem.id);

                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }

        //
        // GET: /Likes/Delete/5
        [HttpPost]
        public JsonResult Delete(FeedItem feedItem) {
            try {
                MediaClient client = new MediaClient(base.userToken.access_token);
                ApiSingleResponse<string> response = client.UnLike(feedItem.id);

                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }
    }
}
