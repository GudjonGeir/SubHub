using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubHub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

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

        public ActionResult Requests()
        {
            var requests = from r in m_repo.GetRequests()
                           join n in m_repo.GetRequestRatings() on r.Id equals n.RequestId
                           orderby n.count descending
                           select r;

            return View(requests);

        }
        public ActionResult ViewRequest(int? id)
        {
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
        }

        public ActionResult NewRequest()
        {
            var model = new RequestViewModel();
            var languages = m_repo.GetSubtitleLanguages();
            model.SubtitleLanguages = new List<SelectListItem>();
            foreach (var l in languages)
            {
                model.SubtitleLanguages.Add(new SelectListItem { Value = l.Id.ToString(), Text = l.Language });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewRequest(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                Request newRequest = new Request
                {
                    Completed = false,
                    DateSubmitted = DateTime.Now,
                    Name = model.Name,
                    RequestRating = new RequestRating(),
                    LanguageId = model.LanguageId
                };
                m_repo.AddRequest(newRequest);
                return RedirectToAction("Requests");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Upvote(int? id)
        {
            if (id.HasValue)
            {
                IdentityManager im = new IdentityManager();
                string userId = User.Identity.GetUserId();
                var requestRating = (from r in m_repo.GetRequestRatings()
                                     where r.RequestId == id.Value
                                     select r).SingleOrDefault();
                if (requestRating == null)
                {
                    return View("Error");
                }
                else
                {
                    int result;
                    var user = (from u in m_repo.GetUsers()
                                where u.Id == userId
                                select u).SingleOrDefault();
                    if (requestRating.Users.Contains(user))
                    {
                        result = m_repo.UpdateRating(id.Value, -1);
                        m_repo.RemoveUserFromRating(id.Value, userId);
                    }
                    else
                    {
                        result = m_repo.UpdateRating(id.Value, 1);
                        m_repo.AddUserToRating(id.Value, userId);
                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return View("Error");
        }

        [Authorize]
        [HttpPost]
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
                    var model = m_repo.GetRequests();
                    return View("Requests", model);
                }
            }
            return View("Error");
        }
	}
}