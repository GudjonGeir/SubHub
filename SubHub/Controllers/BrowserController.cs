using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubHub.Controllers
{
    public class BrowserController : Controller
    {
        public ActionResult Movies()
        {
            return View();
        }
        public ActionResult Movies(string genre)
        {
            return View();
        }
        public ActionResult TvShows()
        {
            return View();
        }
        public ActionResult TvShows(string genre)
        {
            return View();
        }
	}
}