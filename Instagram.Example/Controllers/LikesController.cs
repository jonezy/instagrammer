using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using instagrammer;

namespace Instagrammer.Example.Controllers
{
    public class LikesController : BaseController
    {
        public LikesController() :base() {

        }
        //
        // GET: /Likes/

        public ActionResult Index(string mediaId)
        {
            return View();
        }

        //
        // GET: /Likes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Likes/Create
        [HttpPost]
        public JsonResult Create(FeedItem feedItem)
        {
            MediaController controller = new MediaController(base.userToken.access_token);
            ApiSingleResponse<string> response = controller.Like(feedItem.id);

            if(response.meta.status == "200")
                return Json(new { success = true });
            else
                return Json(new { success = false });
        } 

        //
        // GET: /Likes/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Likes/Edit/5

        //[HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Likes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Likes/Delete/5

        //[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
