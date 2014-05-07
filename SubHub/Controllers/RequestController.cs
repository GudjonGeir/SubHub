using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubHub.Models;

namespace SubHub.Controllers
{
    public class RequestController : Controller
    {
       private readonly IRequestRepository m_repo;

        public RequestController(IRequestRepository repo)
        {
            m_repo = repo;
        }

        public RequestController()
        {
            m_repo = new RequestRepository();
        }

        public ActionResult GetRequests()
        {
            return View();
        }
        public ActionResult ViewRequest(Request r)
        {
            return View();
        }
        public ActionResult Upvote(int? id)
        {
            if (id.HasValue)
            {
                var requestRating = (from r in m_repo.GetRequestRating()
                                     where r.RequestId == id.Value
                                     select r).SingleOrDefault();
                if (requestRating == null)
                {
                    return View("Error");
                }
                else
                {
                    m_repo.Upvote(id.Value);
                }
            }
            return View("Error");
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