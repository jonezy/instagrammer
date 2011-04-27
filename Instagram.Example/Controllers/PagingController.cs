using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Instagrammer.Example.Controllers
{
    public class PagingController : Controller
    {
        //
        // GET: /Paging/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Next() {
            return null;
        }

        public ActionResult Previous() {
            return null;
        }

        public ActionResult Back() {
            return null;
        }

    }
}
