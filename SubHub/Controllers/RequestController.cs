using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubHub.Controllers
{
    public class RequestController : Controller
    {
       private readonly IRequestRepository _repo;

        public RequestController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public ActionResult View()
        {
            return View();
        }
        public ActionResult View(int? id)
        {
            return View();
        }
        public ActionResult ViewRequest(Request r)
        {
            return View();
        }
        public ActionResult Upvote(int? id)
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            return View();
        }
        public ActionResult Complete(int? id)
        {
            return View();
        }
	}
}