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
            if (id.HasValue)
            {
                var model = (from s in m_repo.GetSubtitles()
                              where s.Id == id.Value
                              select s).SingleOrDefault();
                if (model == null)
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

        [HttpPost]
        public ActionResult NewSubtitle(Subtitle s)
        {
            //IdentityManager manager = new IdentityManager();
            //string userName = User.Identity.Name;
            //ApplicationUser user = manager.GetUser(userName);
            


            return View();
        }

        public ActionResult EditSubtitle(int? id)
        {
            if (id.HasValue)
            {
                var model = (from s in m_repo.GetSubtitles()
                             where s.Id == id
                             select s).SingleOrDefault();
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

        [HttpPost]
        public ActionResult EditSubtitle(int? id, Subtitle s)
        {


            return View();
        }

        [HttpPost]
        public ActionResult DeleteSubtitle(int? id)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upvote(int? id, ApplicationUser theUser)
        {
            if(id.HasValue)
            {
                var model = (from s in m_repo.GetSubtitles()
                             where s.Id == id
                             select s).SingleOrDefault();
                if(model == null)
                {
                    return View("Error");
                }
                else
                {
                    if(theUser == null)
                    {
                        IdentityManager manager = new IdentityManager();
                        string userName = User.Identity.Name;
                        ApplicationUser user = manager.GetUser(userName);
                        if (model.SubtitleRating.Users.Contains(user))
                        {
                            // TODO: you have already upvoted
                            return View("Error");
                        }
                    }

                    m_repo.UpVote(id, theUser);
                    //TODO: implement json string
                }
            }
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

        [HttpGet]
        public ActionResult GetComments(int? id)
        {
            var result = (from s in m_repo.GetAllComments()
                          where s.SubtitleId == id
                          select s);
            if(result != null)
            {
                //return somekind of json string
                return View(result);
            }

            return View("Error");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(string comment, int? subtitleid)
        {
            if(subtitleid.HasValue && !String.IsNullOrEmpty(comment))
            {
                IdentityManager manager = new IdentityManager();
                string userName = User.Identity.Name;
                ApplicationUser user = manager.GetUser(userName);
                string userId = user.Id;
                DateTime timi = DateTime.Now;
                Comment newComment = new Comment { UserId = userId, SubtitleId = subtitleid.Value, CommentText = comment, DateSubmitted = timi, User = user };
                //m_repo.AddComment(newComment);
                return View(newComment);
                //return Json string here
            }
            else if(!subtitleid.HasValue)
            {
                return View("Error");
            }
            else
            {
                ModelState.AddModelError("comment", "Commenttext cannot be empty!");
                return View("Error");
                //return some Json string
            }
        }

        [HttpPost]
        public ActionResult DeleteComment(int? id)
        {
            return View();
        }


	}
}