using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubHub.Tests.Mocks;
using SubHub;
using SubHub.Models;
using SubHub.Controllers;

namespace SubHub.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private List<Media> PopulateMedia()
        {
            MediaType movies = new MediaType { Type = "Kvikmyndir" };
            MediaType tvShows = new MediaType { Type = "Þættir" };

            MediaGenre avisaga = new MediaGenre { Genre = "Ævisaga" };
            MediaGenre romantik = new MediaGenre { Genre = "Rómantík" };
            MediaGenre scifi = new MediaGenre { Genre = "Sci-Fi" };

            Media media1 = new Media { Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", Genre = avisaga, TypeId = 1, DownloadCount = 1 };
            Media media2 = new Media { Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", Genre = romantik, TypeId = 1, DownloadCount = 5 };
            Media media3 = new Media { Name = "The Matrix", DateAired = new DateTime(1999, 3, 21), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg", Genre = scifi, TypeId = 1, DownloadCount = 7 };
            var medias = new List<Media>() { media1, media2, media3 };
            return medias;
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            List<Media> theMedia = PopulateMedia();
            var mockRepo = new MockSubtitleRepository(theMedia);
            HomeController controller = new HomeController(mockRepo);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            var result1 = result.Model as List<Media>;
            Assert.IsTrue(result1[1].Name == "The Notebook");
            Assert.IsTrue(result1[0].Name == "The Matrix");
            Assert.IsTrue(result1[2].Name == "Catch me if you can");
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
