using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SubHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubtitleRepository m_repo;

        public HomeController(ISubtitleRepository repo)
        {
            m_repo = repo;
        }
        public HomeController()
        {
            m_repo = new SubtitleRepository();
        }
        /// <summary>
        /// We make a linq query to search for the 5 most popular
        /// downloads for movies and tv shows, to display it on the front page
        /// </summary>
        public ActionResult Index()
        {
            int movieId = (from m in m_repo.GetMediaTypes()
                           where m.Type == "Kvikmyndir"
                           select m.Id).SingleOrDefault();
            var result = (from m in m_repo.GetMedias()
                         where m.TypeId == movieId
                         orderby m.DownloadCount descending
                         select m).Take(5).ToList();

            int tvShowId = (from m in m_repo.GetMediaTypes()
                            where m.Type == "Þættir"
                            select m.Id).SingleOrDefault();
            var result2 = (from m in m_repo.GetMedias()
                         where m.TypeId == tvShowId
                         orderby m.DownloadCount descending
                         select m).Take(5);
            foreach (var item in result2)
            {
                result.Add(item);
            }
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}