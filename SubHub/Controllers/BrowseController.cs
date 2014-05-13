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
                           where m.Type == "Kvikmyndir"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == movieId
                         select m;
            return View(result);
        }

        public ActionResult MoviesByGenre(string genre)
        {
            int movieId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Kvikmyndir"
                           select m.Id).SingleOrDefault();
            var movies = from m in m_repo.GetMedias()
                         where m.TypeId == movieId
                         select m;
            var genreId = (from g in m_repo.GetMediaGenres()
                           where g.Genre == genre
                           select g.Id).SingleOrDefault();
            var result = from n in movies
                         where n.GenreId == genreId
                         select n;
            ViewBag.Title = genre;
            return View(result);
        }
        public ActionResult TvShows()
        {
            int tvShowId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Þættir"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == tvShowId
                         select m;
            return View(result);
        }
        public ActionResult TvShowsByGenre(string genre)
        {
            int tvShowId = (from m in m_repo.GetMediaTypes()
                            where m.Type == "Þættir"
                            select m.Id).SingleOrDefault();
            var tvShows = from m in m_repo.GetMedias()
                         where m.TypeId == tvShowId
                         select m;
            var genreId = (from g in m_repo.GetMediaGenres()
                           where g.Genre == genre
                           select g.Id).SingleOrDefault();
            var result = from n in tvShows
                         where n.GenreId == genreId
                         select n;
            ViewBag.Title = genre;
            return View(result);
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
                ViewBag.Title = query;
                return View(media);
            }
            return View("Error");
        }

        private SubHubContext db = new SubHubContext();




        // Til að gera prew og next page

        /*
         * Til að gera prew og next page
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
