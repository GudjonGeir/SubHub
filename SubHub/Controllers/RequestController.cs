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
            var requests = from r in m_repo.GetRequests()
                           select r;
            //TODO!! return some kind of Json string
            return View(requests);

        }
        public ActionResult ViewRequest(int? id)
        {
<<<<<<< HEAD
            
            return View();
=======
            if (id.HasValue)
            {
                var model = (from k in m_repo.GetRequests()
                             where k.Id == id.Value
                             select k).SingleOrDefault();
                if(model == null)
                {
                    return View("Error");
                }
                else
                {
                    return View(model);
                }
            }
            return View("Error");
>>>>>>> 444cb1905dd1ed3c2e954f750de954dc8034b597
        }

        [Authorize]
        public ActionResult Upvote(int? id)
        {
            if (id.HasValue)
            {
                var requestRating = (from r in m_repo.GetRequestRatings()
                                     where r.RequestId == id.Value
                                     select r).SingleOrDefault();
                if (requestRating == null)
                {
                    return View("Error");
                }
                else
                {
                    m_repo.Upvote(id.Value);
                    return View();
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
            if(id.HasValue)
            {
                var request = (from r in m_repo.GetRequests()
                               where r.Id == id
                               select r).SingleOrDefault();
                if(request == null)
                {
                    return View("Error");
                }
                else
                {
                    m_repo.SetCompleted(id.Value);
                    return View();
                }
            }
            return View("Error");
        }
	}
}