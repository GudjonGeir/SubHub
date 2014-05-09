using SubHub.Models;
using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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


        //Fall ViewSubtitleByGenre
        [HttpGet]
        public ActionResult ViewSubtitleByGenre(string genre)
        {
            
            //var result = from s in m_repo.GetSubtitles()
            //             where s.Genre == genre
            //             select s;
            return View();
        }
        public ActionResult Media(int? id)
        {
            if (id.HasValue)
            {
                var model = (from m in m_repo.GetMedias()
                             where m.Id == id.Value
                             select m).SingleOrDefault();
                return View(model);
            }
            return View("Error");
        }

        public ActionResult NewMedia()
        {
            var model = new MediaViewModel();
            var mediaTypes = m_repo.GetMediaTypes().ToList();
            var mediaGenres = m_repo.GetMediaGenres().ToList();

            model.MediaTypes = new List<SelectListItem>();
            foreach (var m in mediaTypes)
            {
                model.MediaTypes.Add(new SelectListItem { Value = m.Id.ToString(), Text = m.Type });
            }

            model.MediaGenres = new List<SelectListItem>();
            foreach (var m in mediaGenres)
            {
                model.MediaGenres.Add(new SelectListItem { Value = m.Id.ToString(), Text = m.Genre });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult NewMedia(MediaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newMedia = new Media()
                {
                    Name = model.Name,
                    DateAired = model.DateAired,
                    GenreId = model.GenreId,
                    ImdbUrl = model.ImdbUrl,
                    PosterUrl = model.PosterUrl,
                    TypeId = model.TypeId
                };
                m_repo.AddMedia(newMedia);
                return RedirectToRoute(
                    "Default",
                    new { controller = "Home", action = "Index" });
            }
            return View(model);
        }

        public ActionResult NewSubtitle()
        {
            return View(new SubtitleViewModel());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult NewSubtitle(SubtitleViewModel model)
        //{
        //    var validSubtitleType = new string[]
        //    {
        //        "text/plain",
        //        "application/octet-stream"
        //    };

        //    if (model.SrtUpload == null || model.SrtUpload.ContentLength == 0)
        //    {
        //        ModelState.AddModelError("SrtUpload", "This field is required");
        //    }
        //    else if (!validSubtitleType.Contains(model.SrtUpload.ContentType))
        //    {
        //        ModelState.AddModelError("SrtUpload", "Please choose a valid .srt file");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var subtitle = new Subtitle
        //        {
        //            Name = model.Name,
        //            Type = model.Type,
        //            PosterUrl = model.PosterUrl,
        //            Genre = model.Genre,
        //            DateAired = model.DateAired,
        //            ImdbUrl = model.ImdbUrl,
        //            Language = model.Language,
        //        };
        //        int subtId = m_repo.AddSubtitle(subtitle);
        //        if (model.SrtUpload != null || model.SrtUpload.ContentLength > 0)
        //        {
        //            StreamReader reader = new StreamReader(model.SrtUpload.InputStream);
        //            while (!reader.EndOfStream)
        //            {
        //                SubtitleLine sl = new SubtitleLine();

        //                string tmpString = reader.ReadLine();
        //                if (String.IsNullOrEmpty(tmpString))
        //                {
        //                    continue;
        //                }
        //                //LineNumber:
        //                int tmpInt;
        //                int.TryParse(tmpString, out tmpInt);
        //                sl.LineNumber = tmpInt;

        //                //Time:
        //                tmpString = reader.ReadLine();
        //                sl.Time = tmpString;
        //                //LineOne:

        //                tmpString = reader.ReadLine();
        //                sl.LineOne = tmpString;

        //                //LineTwo:
        //                tmpString = reader.ReadLine();
        //                sl.LineTwo = tmpString;
                        
        //                sl.SubtitleId = subtId;
        //                m_repo.AddSubtitleLine(sl);

        //                if (String.IsNullOrEmpty(tmpString))
        //                {
        //                    continue;
        //                }

        //                reader.ReadLine();

                        
        //            }
        //        }
                
        //        return RedirectToRoute(
        //            "Default",
        //            new { controller = "Home", action = "Index" });
        //    }
        //    return View(model);
        //}

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

        //[HttpPost]
        //[Authorize]
        //public ActionResult Upvote(int? id)
        //{
        //    if(id.HasValue)
        //    {
        //        var model = (from s in m_repo.GetSubtitles()
        //                     where s.Id == id
        //                     select s).SingleOrDefault();
        //        if(model == null)
        //        {
        //            return View("Error");
        //        }
        //        else
        //        {
        //            IdentityManager manager = new IdentityManager();
        //            string userName = User.Identity.Name;
        //            ApplicationUser user = manager.GetUser(userName);
        //            if(model.SubtitleRating.Users.Contains(user))
        //            {
        //                // TODO: you have already upvoted
        //                return View("Error");
        //            }
        //            m_repo.UpVote(id, user);
        //            //TODO: implement json string
        //        }
        //    }
        //    return View("Error");
        //}

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