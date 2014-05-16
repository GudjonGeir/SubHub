using SubHub.Models;
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

        
        /// <summary>
        /// To get the correct subtitle we need the Id for the 
        /// correct media(movie or tvshow) and the requested
        /// requested language id(english or icelandic)
        /// If no subtitle exists, we are redirected to a
        /// nice error page asking if the user wants to make a request
        /// </summary>
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
                    return View("NoSubtitleError", media);
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

        /// <summary>
        /// Gets the required values to fill in for a new 
        /// subtitle into a model and sends it to the view
        /// </summary>
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

        /// <summary>
        /// Takes all properties in the model and assigns
        /// it into a new Media object which we add into
        /// the database
        /// </summary>
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
                var media = m_repo.GetMedias().Where(s => s.Id == id.Value).SingleOrDefault();                      // Get the media the new subtitle belongs to
                SubtitleViewModel model = new SubtitleViewModel { MediaId = id.Value, MediaName = media.Name };     // Create view model with correct data
                var subtitleLanguages = m_repo.GetSubtitleLanguages().ToList();                                     // Get all available languages

                model.SubtitleLanguages = new List<SelectListItem>();                                               // add languages to list of SelectListItem
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
            var validSubtitleType = new string[]                                            // Array of valid filetypes
            {
                "text/plain",
                "application/octet-stream"
            };

            if (model.SrtUpload == null || model.SrtUpload.ContentLength == 0)              // Validation to make sure that a file has been selected for upload
            {
                ModelState.AddModelError("SrtUpload", "This field is required");
            }
            else if (!validSubtitleType.Contains(model.SrtUpload.ContentType))              // Validation for valid filetypes
            {
                ModelState.AddModelError("SrtUpload", "Please choose a valid .srt file");
            }

            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();                                  
                List<ApplicationUser> users = new List<ApplicationUser>();;
                var subtitle = new Subtitle                                                 // Create a new instance of a subtitle with correct data
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
                int subtId = m_repo.AddSubtitle(subtitle);                                  // Add the subtitle to db and get the id

                m_repo.AddUserToSubtitle(subtId, userId);                                   // Add the logged in user to list of contributors

                if (model.SrtUpload != null || model.SrtUpload.ContentLength > 0)
                {
                    StreamReader reader = new StreamReader(model.SrtUpload.InputStream);    // Access the HttpPostedFileBase StreamReader
                    List<SubtitleLine> lines = new List<SubtitleLine>();                    // Create a list to contain the lines until they are saved to db
                    while (!reader.EndOfStream)                                             // Loops until it hits the end of the stream
                    {
                        SubtitleLine sl = new SubtitleLine();                               // Create new line

                        string tmpString = reader.ReadLine();                               // Read the first line and make sure it isn't empty
                        if (String.IsNullOrEmpty(tmpString))                                // Skip this loop if it is
                        {
                            continue;
                        }
                        //LineNumber:
                        int tmpInt;                                                         // Get the line number
                        int.TryParse(tmpString, out tmpInt);
                        sl.LineNumber = tmpInt;

                        //Time:
                        tmpString = reader.ReadLine();                                      // Get the time of the subtitle line
                        sl.Time = tmpString;
                        //LineOne:

                        tmpString = reader.ReadLine();                                      // Get the first display text
                        sl.LineOne = tmpString;

                        //LineTwo:
                        tmpString = reader.ReadLine();                                      // Get the second display text
                        sl.LineTwo = tmpString;

                        sl.SubtitleId = subtId;                                             // Relate the line to the new subtitle
                        lines.Add(sl);                                                      // Add the new line to the list

                        if (String.IsNullOrEmpty(tmpString))                                // Check if the second line was empty,
                        {                                                                   // if it was the next line would be the line number
                            continue;
                        }

                        reader.ReadLine();                                                  // Read the empty line between lines


                    }
                    m_repo.AddSubtitleLine(lines);                                          // Send the list to db

                }

                return RedirectToAction("ViewSubtitle", new { mediaID = subtitle.MediaId, languageId = subtitle.LanguageId }); // Go to the newly created subtitle
            }
            return View(model);
        }

        [Authorize]
        public ActionResult EditSubtitleLines(int? subtitleId)
        {
            if (subtitleId.HasValue)
            {
                var model = (from s in m_repo.GetSubtitleLines()                            // Get the subtitle lines for the corresponding
                             where s.SubtitleId == subtitleId                               // subtitleId and order it by the line number
                             orderby s.LineNumber
                             select s).ToList();
                if (!model.Any())                                                           // If the list is empty there must be something wrong
                {
                    return View("Error");
                }
                else
                {
                    var media = (from m in m_repo.GetMedias()                               // Get the media that the subtitle belongs to to
                                 join l in m_repo.GetSubtitles() on m.Id equals l.MediaId   // display the name with a viewbag
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
                m_repo.UpdateSubtitleLine(result);                                              // Send the edited line to db

                m_repo.AddUserToSubtitle(result.SubtitleId, User.Identity.GetUserId());         // Add the user to list of contributors

                return RedirectToAction("EditSubtitleLines", new { subtitleId = s.SubtitleId });// Return to edit page with updated data
            }
            return View("Error");
        }

        public ActionResult DownloadSubtitle(int? id)
        {
            if (id.HasValue)
            {
                StringBuilder fileString = new StringBuilder();                                 // StringBuilder to prepare the data for download
                var subtitleLines = from s in m_repo.GetSubtitleLines()                         // Get all the lines and order them by number
                                    where s.SubtitleId == id.Value
                                    orderby s.LineNumber
                                    select s;
                var media = (from s in m_repo.GetSubtitles()                                    // Get the media to use the media name for filename
                               join m in m_repo.GetMedias() on s.MediaId equals m.Id
                               where s.Id == id.Value
                               select m).SingleOrDefault();
                string subtitleName = media.Name;
                m_repo.DownloadCounterUpOne(media.Id);                                          // Add to the download counter
                               

                foreach(var line in subtitleLines)                                              // Add each line to the StringBuilder
                {
                    fileString.Append(line.LineNumber).Append(Environment.NewLine);
                    fileString.Append(line.Time).Append(Environment.NewLine);
                    fileString.Append(line.LineOne).Append(Environment.NewLine);
                    if (!String.IsNullOrEmpty(line.LineTwo))                                    // Prevent unnecessary empty line
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
                if (subtitleUpvote.Users.Contains(user))                                            // If the user has already upvoted
                {                                                                                   
                    upvoteCount = m_repo.Upvote(id.Value, -1);                                      // Add to upvotes and get resulting upvote count
                    downvoteCount = subtitleDownvote.Count;                                         // get current downvote count
                    result = upvoteCount - downvoteCount;                                           // get current rating
                    m_repo.RemoveUserFromUpvotes(id.Value, userId);                                 // Remove user from upvotes
                }
                else if (subtitleDownvote.Users.Contains(user))                                     // If the user has downvoted
                {
                    upvoteCount = m_repo.Upvote(id.Value, 1);                                       // Add to upvotes and get resulting upvote count
                    downvoteCount = m_repo.Downvote(id.Value, -1);                                  // Remove from downvotes and get resulting downvote count
                    result = upvoteCount - downvoteCount;                                           // Current rating
                    m_repo.RemoveUserFromDownvotes(id.Value, userId);                               // Remove user from downvotes
                    m_repo.AddUserToUpvotes(id.Value, userId);                                      // Add user to upvotes
                }
                else
                {
                    upvoteCount = m_repo.Upvote(id.Value, 1);                                       // Add to upvotes and get resulting upvote count
                    downvoteCount = subtitleDownvote.Count;                                         // get current downvote count
                    result = upvoteCount - downvoteCount;                                           // Current rating
                    m_repo.AddUserToUpvotes(id.Value, userId);                                      // Add user to upvotes
        
                }
                m_repo.UpdateRating(id.Value, result);                                              // Upvote rating with result in db
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Downvote(int? id)                                                       // See upvote comments for explanation
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

        /// <summary>
        /// Returns the model for the correct subtitle into
        /// the comment section
        /// </summary>
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

        /// <summary>
        /// If the id doesnt have a value or the subitle
        /// doesnt exist we return a error page, if it does
        /// we return a collection of comments for the 
        /// corresponding subtitle
        /// </summary>
        [HttpGet]
        public ActionResult GetComments(int? id)
        {
            if(id.HasValue)
            {
                var result = (from s in m_repo.GetAllComments()
                              where s.SubtitleId == id.Value
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
            return View("Error");
        }

        /// <summary>
        /// Adds a comment into the right subtitle
        /// The javascript takes care of the logic(ex. string is null)
        /// </summary>
        [HttpPost]
        [Authorize]
        public ActionResult AddComment(Comment comment)
        {
                string userId = User.Identity.GetUserId();
                DateTime timi = DateTime.Now;
                Comment newComment = new Comment { UserId = userId, SubtitleId = comment.SubtitleId, CommentText = comment.CommentText, DateSubmitted = timi };
                m_repo.AddComment(newComment);

                return Json("", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the corresponding comment if the id isnt null
        /// </summary>
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

        /// <summary>
        /// This works just like the function above, except it needed
        /// to be implemented this way to test it
        /// </summary>
        [Authorize]
        public ActionResult TestAddComment(string comment, int? subtitleid)
        {
            if (subtitleid.HasValue && !String.IsNullOrEmpty(comment))
            {
                DateTime timi = DateTime.Now;
                Comment newComment = new Comment {  SubtitleId = subtitleid.Value, CommentText = comment, DateSubmitted = timi };
                return View(newComment);
            }
            else if (!subtitleid.HasValue)
            {
                return View("Error");
            }
            else
            {
                ModelState.AddModelError("comment", "Commenttext cannot be empty!");
                return View("Error");
            }
        }
	}
}