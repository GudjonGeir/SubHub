﻿using SubHub.Models;
using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text;

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

        

        public ActionResult ViewSubtitle(int? mediaId, int? languageId)
        {
            if (mediaId.HasValue && languageId.HasValue)
            {
                var model = (from s in m_repo.GetSubtitles()
                             join m in m_repo.GetSubtitleRatings() on s.Id equals m.SubtitleId
                             where s.LanguageId == languageId && s.MediaId == mediaId
                             orderby m.Count descending
                             select s).ToList();
                if (!model.Any())
                {
                    var media = (from m in m_repo.GetMedias()
                                 where m.Id == mediaId.Value
                                 select m).SingleOrDefault();
                    return View("NoSubtitleError", media); // TODO: Offer to make new subtitle
                }
                else
                {
                    ViewBag.LanguageId = languageId;
                    ViewBag.MovieName = model.FirstOrDefault().Media.Name.ToString();
                    return View(model);
                }
                
            }
            return View("Error");
        }


        //Fall ViewSubtitleByGenre
        [HttpGet]
        public ActionResult MediaByGenre(string genre)
        {
            int genreId = (from m in m_repo.GetMediaGenres()
                          where m.Genre == genre
                          select m.Id).SingleOrDefault();

            var result = (from m in m_repo.GetMedias()
                          where m.GenreId == genreId
                          select m).SingleOrDefault();
            return View(result);
        }
        public ActionResult Media(int? id)
        {
            if (id.HasValue)
            {
                var media = (from m in m_repo.GetMedias()
                             where m.Id == id.Value
                             select m).SingleOrDefault();
                var languages = m_repo.GetSubtitleLanguages();
                MediaViewModel model = new MediaViewModel { 
                    DateAired = media.DateAired, 
                    Id = media.Id,
                    Genre = media.Genre, 
                    ImdbUrl = media.ImdbUrl, 
                    Name = media.Name, 
                    PosterUrl = media.PosterUrl, 
                    Type = media.Type,
                    SelectedLanguage = "languageId",
                    SubtitleLanguages = new List<SelectListItem>()};
                foreach (var l in languages)
                {
                    model.SubtitleLanguages.Add(new SelectListItem { Value = l.Id.ToString(), Text = l.Language });
                }
                return View(model);
            }
            return View("Error");
        }

        [Authorize]
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
        [Authorize]
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
                    TypeId = model.TypeId,
                    DownloadCount = 0
                };
                m_repo.AddMedia(newMedia);
                return RedirectToAction("Media", new { id = newMedia.Id });
            }
            return View(model);
        }

        [Authorize]
        public ActionResult NewSubtitle(int? id)
        {
            if (id.HasValue)
            {
                var media = m_repo.GetMedias().Where(s => s.Id == id.Value).SingleOrDefault();
                SubtitleViewModel model = new SubtitleViewModel { MediaId = id.Value, MediaName = media.Name };
                var subtitleLanguages = m_repo.GetSubtitleLanguages().ToList();

                model.SubtitleLanguages = new List<SelectListItem>();
                foreach (var m in subtitleLanguages)
                {
                    model.SubtitleLanguages.Add(new SelectListItem { Value = m.Id.ToString(), Text = m.Language });
                }
                return View(model);
            }
            
            return View("Error");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSubtitle(SubtitleViewModel model)
        {
            var validSubtitleType = new string[]
            {
                "text/plain",
                "application/octet-stream"
            };

            if (model.SrtUpload == null || model.SrtUpload.ContentLength == 0)
            {
                ModelState.AddModelError("SrtUpload", "This field is required");
            }
            else if (!validSubtitleType.Contains(model.SrtUpload.ContentType))
            {
                ModelState.AddModelError("SrtUpload", "Please choose a valid .srt file");
            }

            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                List<ApplicationUser> users = new List<ApplicationUser>();;
                var subtitle = new Subtitle
                {
                    Name = model.Name,
                    LanguageId = model.LanguageId, 
                    MediaId = model.MediaId,
                    Users = users, 
                    Comments = new List<Comment>(), 
                    DateSubmitted = DateTime.Now, 
                    SubtitleRating = new SubtitleRating(), 
                    SubtitleUpvote = new SubtitleUpvote(), 
                    SubtitleDownvote = new SubtitleDownvote()
                };
                int subtId = m_repo.AddSubtitle(subtitle);

                m_repo.AddUserToSubtitle(subtId, userId);

                if (model.SrtUpload != null || model.SrtUpload.ContentLength > 0)
                {
                    StreamReader reader = new StreamReader(model.SrtUpload.InputStream);
                    while (!reader.EndOfStream)
                    {
                        SubtitleLine sl = new SubtitleLine();

                        string tmpString = reader.ReadLine();
                        if (String.IsNullOrEmpty(tmpString))
                        {
                            continue;
                        }
                        //LineNumber:
                        int tmpInt;
                        int.TryParse(tmpString, out tmpInt);
                        sl.LineNumber = tmpInt;

                        //Time:
                        tmpString = reader.ReadLine();
                        sl.Time = tmpString;
                        //LineOne:

                        tmpString = reader.ReadLine();
                        sl.LineOne = tmpString;

                        //LineTwo:
                        tmpString = reader.ReadLine();
                        sl.LineTwo = tmpString;

                        sl.SubtitleId = subtId;
                        m_repo.AddSubtitleLine(sl);

                        if (String.IsNullOrEmpty(tmpString))
                        {
                            continue;
                        }

                        reader.ReadLine();


                    }
                }

                return RedirectToAction("ViewSubtitle", new { mediaID = subtitle.MediaId, languageId = subtitle.LanguageId });
            }
            return View(model);
        }

        [Authorize]
        public ActionResult EditSubtitleLines(int? subtitleId)
        {
            if (subtitleId.HasValue)
            {
                var model = (from s in m_repo.GetSubtitleLines()
                             where s.SubtitleId == subtitleId
                             orderby s.LineNumber
                             select s).ToList();
                if (!model.Any())
                {
                    return View("Error");
                }
                else
                {
                    var media = (from m in m_repo.GetMedias()
                                 join l in m_repo.GetSubtitles() on m.Id equals l.MediaId
                                 where l.Id == subtitleId.Value
                                 select m).SingleOrDefault();
                    ViewBag.Title = media.Name;
                    return View(model);
                }
            }
            return View("Error");
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditSubtitleLines(SubtitleLine s)
        {
            if (ModelState.IsValid)
            {
                SubtitleLine result = new SubtitleLine()
                {
                    SubtitleId = s.SubtitleId,
                    LineNumber = s.LineNumber,
                    Id = s.Id,
                    LineOne = s.LineOne,
                    LineTwo = s.LineTwo,
                    Time = s.Time
                };
                m_repo.UpdateSubtitleLine(result);

                m_repo.AddUserToSubtitle(result.SubtitleId, User.Identity.GetUserId());

                return RedirectToAction("EditSubtitleLines", new { subtitleId = s.SubtitleId });
            }
            return View("Error");
        }

        [Authorize]
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
        [Authorize]
        public ActionResult DeleteSubtitle(int? id)
        {


            return View();
        }

        public ActionResult DownloadSubtitle(int? id)
        {
            if (id.HasValue)
            {
                StringBuilder fileString = new StringBuilder();
                var subtitleLines = from s in m_repo.GetSubtitleLines()
                                    where s.SubtitleId == id.Value
                                    orderby s.LineNumber
                                    select s;
                var media = (from s in m_repo.GetSubtitles()
                               join m in m_repo.GetMedias() on s.MediaId equals m.Id
                               where s.Id == id.Value
                               select m).SingleOrDefault();
                string subtitleName = media.Name;
                m_repo.DownloadCounterUpOne(media.Id);
                               

                foreach(var line in subtitleLines)
                {
                    fileString.Append(line.LineNumber).Append(Environment.NewLine);
                    fileString.Append(line.Time).Append(Environment.NewLine);
                    fileString.Append(line.LineOne).Append(Environment.NewLine);
                    if (!String.IsNullOrEmpty(line.LineTwo))
                    {
                        fileString.Append(line.LineTwo).Append(Environment.NewLine);
                    }
                    fileString.Append(Environment.NewLine);
                }
                return File(Encoding.UTF8.GetBytes(fileString.ToString()), "application/octet-stream", string.Format("{0}.srt", subtitleName));
            }
            return View("Error");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upvote(int? id)
        {
            if (id.HasValue)
            {
                var subtitleRating = (from s in m_repo.GetSubtitles()
                                      where s.Id == id.Value
                                      select s).SingleOrDefault();
                var subtitleUpvote = (from s in m_repo.GetSubtitleUpvotes()
                                      where s.SubtitleId == id.Value
                                      select s).SingleOrDefault();
                var subtitleDownvote = (from s in m_repo.GetSubtitleDownvotes()
                                        where s.SubtitleId == id.Value
                                        select s).SingleOrDefault();
                string userId = User.Identity.GetUserId();
                var user = (from u in m_repo.GetUsers()
                            where u.Id == userId
                            select u).SingleOrDefault();
                if (subtitleDownvote == null || subtitleUpvote == null || subtitleRating == null)
                {
                    return View("Error");
                }

                int result, upvoteCount, downvoteCount;
                if (subtitleUpvote.Users.Contains(user))
                {
                    upvoteCount = m_repo.Upvote(id.Value, -1);
                    downvoteCount = subtitleDownvote.Count;
                    result = upvoteCount - downvoteCount;
                    m_repo.RemoveUserFromUpvotes(id.Value, userId);
                }
                else if (subtitleDownvote.Users.Contains(user))
                {
                    upvoteCount = m_repo.Upvote(id.Value, 1);
                    downvoteCount = m_repo.Downvote(id.Value, -1);
                    result = upvoteCount - downvoteCount;
                    m_repo.RemoveUserFromDownvotes(id.Value, userId);
                    m_repo.AddUserToUpvotes(id.Value, userId);
                }
                else
                {
                    upvoteCount = m_repo.Upvote(id.Value, 1);
                    downvoteCount = subtitleDownvote.Count;
                    result = upvoteCount - downvoteCount;
                    m_repo.AddUserToUpvotes(id.Value, userId);
        
                }
                m_repo.UpdateRating(id.Value, result);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Downvote(int? id)
        {
            if (id.HasValue)
            {
                var subtitleRating = (from s in m_repo.GetSubtitles()
                                      where s.Id == id.Value
                                      select s).SingleOrDefault();
                var subtitleUpvote = (from s in m_repo.GetSubtitleUpvotes()
                                      where s.SubtitleId == id.Value
                                      select s).SingleOrDefault();
                var subtitleDownvote = (from s in m_repo.GetSubtitleDownvotes()
                                        where s.SubtitleId == id.Value
                                        select s).SingleOrDefault();
                string userId = User.Identity.GetUserId();
                var user = (from u in m_repo.GetUsers()
                            where u.Id == userId
                            select u).SingleOrDefault();
                if (subtitleDownvote == null || subtitleUpvote == null || subtitleRating == null)
                {
                    return View("Error");
                }

                int result, upvoteCount, downvoteCount;
                if (subtitleUpvote.Users.Contains(user))
                {
                    upvoteCount = m_repo.Upvote(id.Value, -1);
                    downvoteCount = m_repo.Downvote(id.Value, 1);
                    result = upvoteCount - downvoteCount;
                    m_repo.RemoveUserFromUpvotes(id.Value, userId);
                    m_repo.AddUserToDownvotes(id.Value, userId);
                }
                else if (subtitleDownvote.Users.Contains(user))
                {
                    upvoteCount = subtitleUpvote.Count;
                    downvoteCount = m_repo.Downvote(id.Value, -1);
                    result = upvoteCount - downvoteCount;
                    m_repo.RemoveUserFromDownvotes(id.Value, userId);
                }
                else
                {
                    upvoteCount = subtitleUpvote.Count;
                    downvoteCount = m_repo.Downvote(id.Value, 1);
                    result = upvoteCount - downvoteCount;
                    m_repo.AddUserToDownvotes(id.Value, userId);

                }
                m_repo.UpdateRating(id.Value, result);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Flag(int? id)
        {
            return View();
        }

        public ActionResult SubtitleComments(int? id)
        {
            if (id.HasValue)
            {
                var subtitle = (from s in m_repo.GetSubtitles()
                                where s.Id == id
                                select s).SingleOrDefault();
                if (subtitle != null)
                {
                    return View(subtitle);
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult GetComments(int id)
        {
            var result = (from s in m_repo.GetAllComments()
                          where s.SubtitleId == id
                          select s);

            var newResult = from c in result
                            select new
                            {
                                UserName = c.User.UserName,
                                CommentText = c.CommentText,
                                DateSubmitted = c.DateSubmitted,
                                Id = c.Id,
                            };
            return Json(newResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(Comment comment)
        {
            if(!String.IsNullOrEmpty(comment.CommentText))
            {
                //TestGögn:
                //ApplicationUser user = new ApplicationUser { Id = "user1", UserName = "dorismjatt" };

                string userId = User.Identity.GetUserId();
                DateTime timi = DateTime.Now;
                Comment newComment = new Comment { UserId = userId, SubtitleId = comment.SubtitleId, CommentText = comment.CommentText, DateSubmitted = timi };
                m_repo.AddComment(newComment);
                //return Json string here
                return Json("", JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError("comment", "Commenttext cannot be empty!");
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteComment(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }
            else
            {
                var comment = (from c in m_repo.GetAllComments()
                               where c.Id == id.Value
                               select c).SingleOrDefault();
                string userId = User.Identity.GetUserId();
                if(comment != null && comment.UserId == userId)
                {
                    m_repo.RemoveComment(id);
                }
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public ActionResult TestAddComment(string comment, int? subtitleid)
        {
            if (subtitleid.HasValue && !String.IsNullOrEmpty(comment))
            {
                DateTime timi = DateTime.Now;
                Comment newComment = new Comment {  SubtitleId = subtitleid.Value, CommentText = comment, DateSubmitted = timi };
                //m_repo.AddComment(newComment);
                return View(newComment);
                //return Json string here
            }
            else if (!subtitleid.HasValue)
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
	}
}