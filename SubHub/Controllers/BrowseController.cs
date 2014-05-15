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

/// <summary>
/// Smiðir fyrir þetta controller, fyrri smiðurinn
/// erum við í raun aðeins að nota til þess að geta
/// framkvæmt einingarprófanir fyrir þessi föll
/// </summary>
        public BrowseController(ISubtitleRepository repo)
        {
            m_repo = repo;
        }
        public BrowseController()
        {
            m_repo = new SubtitleRepository();
        }
        /// <summary>
        /// Returns a collection of all movies in db
        /// </summary>
        /// <returns></returns>
        public ActionResult Movies()
        {
            int movieId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Kvikmyndir"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == movieId
                         orderby m.Name
                         select m;
            return View(result);
        }

        /// <summary>
        /// Returns a model into the view which contains
        /// all movies in the specified genre
        /// </summary>
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
                         orderby n.Name
                         select n;
            ViewBag.Title = genre;
            return View(result);
        }
        /// <summary>
        /// Returns a collection of all Tv shows
        /// in the database
        /// </summary>
        /// <returns></returns>
        public ActionResult TvShows()
        {
            int tvShowId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Þættir"
                           select m.Id).SingleOrDefault();
            var result = from m in m_repo.GetMedias()
                         where m.TypeId == tvShowId
                         orderby m.Name
                         select m;
            return View(result);
        }
        /// <summary>
        /// Returns a collcetion of all tv shows specified by
        /// genre
        /// </summary>
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
                         orderby n.Name
                         select n;
            ViewBag.Title = genre;
            return View(result);
        }

        /// <summary>
        /// If the keyword you search for is not empty or null
        /// we make a lambda expression which checks if our query 
        /// string matches the name of any media in our database
        /// If it doesnt match we return a nice error message 
        /// telling the user that what he is looking for doesnt exist
        /// and that he can make a request
        /// </summary>
        public ActionResult Search(string query)
        {
            var media = (from m in m_repo.GetMedias()
                        select m);

            if (!String.IsNullOrEmpty(query))
            {
                media = media.Where(m => m.Name.Contains(query));
                if (!media.Any())
                {
                    return View("Error");
                }
                media = media.OrderBy(m => m.Name);
                ViewBag.Title = query;
                return View(media);
            }
            return View("Error");
        }
    }
}
