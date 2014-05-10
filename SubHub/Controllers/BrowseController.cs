using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SubHub.Repositories;
using SubHub.DAL;
using SubHub.Models;

namespace SubHub.Controllers
{
    public class BrowseController : Controller
    {
         private readonly ISubtitleRepository m_repo;

        public BrowseController(ISubtitleRepository repo)
        {
            m_repo = repo;
        }
        public BrowseController()
        {
            m_repo = new SubtitleRepository();
        }

        public ActionResult Movies()
        {
            int movieId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Movie"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == movieId
                         select m;
            return View(result);
        }

        public ActionResult Movies(string genre)
        {
            return View();
        }
        public ActionResult TvShows()
        {
            int tvShowId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "TvShow"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == tvShowId
                         select m;
            return View(result);
        }
        public ActionResult TvShows(string genre)
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            var media = (from m in m_repo.GetMedias()
                        select m);

            if (!String.IsNullOrEmpty(query))
            {
                media = media.Where(m => m.Name.Contains(query));
                if (!media.Any())
                {
                    return View("Error"); // TODO: Specific error page, no results found
                }
                return View(media);
            }
            return View();
        }

        private SubHubContext db = new SubHubContext();


        // GET: /Browse/
        public ActionResult Index()
        {
            return View(db.Subtitles);
        }

        // GET: /Browse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtitle subtitle = db.Subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // GET: /Browse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Browse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Language,Type,Genre,Name,ImdbUrl,DateSubmitted,DateAired,PosterUrl")] Subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                db.Subtitles.Add(subtitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subtitle);
        }

        // GET: /Browse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtitle subtitle = db.Subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // POST: /Browse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Language,Type,Genre,Name,ImdbUrl,DateSubmitted,DateAired,PosterUrl")] Subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subtitle);
        }

        // GET: /Browse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtitle subtitle = db.Subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // POST: /Browse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subtitle subtitle = db.Subtitles.Find(id);
            db.Subtitles.Remove(subtitle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Til að gera prew og next page
        /*
         * Síða: http://stackoverflow.com/questions/9321710/how-to-do-prev-next-page
         public PaginatedList<T>(IQueryable<T> source, int pageIndex, int? pageSize)
         {
             PageIndex = pageIndex; //global variable
             PageSize = pageSize ?? source.Count(); //global variable
             TotalCount = source.Count(); //global variable
             TotalPages = (int)Math.Ceiling(TotalCount /(double)PageSize); //global variable
             this.AddRange(source.Skip(PageIndex*PageSize).Take(PageSize));
          }
          public bool HasPreviousPage
          {  
              get {   return(PageIndex >0); //same global variable  }
           }
          public bool HasNextPage
          {  
              get {   return(PageIndex <0); //same global variable   }
           }
         */
    }
}
