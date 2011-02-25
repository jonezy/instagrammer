using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Instagram.Wrapper.Controllers
{
    public class UserFeedController : Controller
    {
        //
        // GET: /UserFeed/

        public ActionResult Index()
        {
            return View();
        }

    }
}
