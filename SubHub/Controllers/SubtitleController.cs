using SubHub.Models;
using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubHub.Controllers
{
    public class SubtitleController : Controller
    {
        private readonly ISubtitleRepository m_repo;

        public SubtitleController(ISubtitleRepository repo)
        {
            m_repo = repo;
        }

        public SubtitleController()
        {
            m_repo = new SubtitleRepository();
        }


        public ActionResult ViewSubtitle(int? id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewSubtitle(Subtitle s)
        {
            return View();
        }

        public ActionResult EditSubtitle(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditSubtitle(Subtitle s)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSubtitle(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upvote(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Downvote(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Flag(int? id)
        {
            return View();
        }
	}
}