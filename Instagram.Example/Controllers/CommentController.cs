using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers {
    public class CommentController : BaseController {
        public CommentController()
            : base() {

        }
        //
        // GET: /Comment/

        public ActionResult Index() {
            return View();
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id) {
            MediaClient client = new MediaClient(base.userToken.access_token);
            ApiSingleResponse<FeedItem> media = client.Media(id.ToString());

            ViewData["PhotoDetails"] = media.data;

            return PartialView("PhotoDetails", media.data);
        }

        //
        // GET: /Comment/Create
        [HttpPost]
        public JsonResult Create(PhotoComment comment) {
            try {
                MediaClient client = new MediaClient(base.userToken.access_token);
                ApiSingleResponse<Comment> response = client.Comment(comment.id, Server.UrlEncode(comment.text));

                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }




        //
        // GET: /Comment/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id) {
            return View();
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
