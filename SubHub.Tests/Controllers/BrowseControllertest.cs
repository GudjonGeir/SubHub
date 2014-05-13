using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SubHub.Models;
using SubHub.Tests.Mocks;
using SubHub.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace SubHub.Tests.Controllers
{
    [TestClass]
    public class BrowseControllerTest
    {
        private List<Media> PopulateMedia()
        {
            MediaType movies = new MediaType { Type = "Kvikmyndir" };
            MediaType tvShows = new MediaType { Type = "Þættir" };

            MediaGenre avisaga = new MediaGenre { Genre = "Ævisaga" };
            MediaGenre romantik = new MediaGenre { Genre = "Rómantík" };
            MediaGenre scifi = new MediaGenre { Genre = "Sci-Fi" };

            Media media1 = new Media { Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", Genre = avisaga };
            Media media2 = new Media { Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", Genre = romantik };
            Media media3 = new Media { Name = "The Matrix", DateAired = new DateTime(1999, 3, 21), ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", Type = movies, PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg", Genre = scifi };
            var medias = new List<Media>() { media1, media2, media3 };
            return medias;
        }
        [TestMethod]
        public void SearchWithResultTest()
        {
            // Arrange:
            var mediaList = PopulateMedia();

            var mockRepo = new MockSubtitleRepository(mediaList);
            var controller = new BrowseController(mockRepo);

            // Act:
            var result = controller.Search("Catch"); // virkar ekki, þótt þetta virki á síðunni sjálfri :/
            // var result = controller.Search("Catch me if you can"); // Þetta virkar hinsvegar

            // Assert:
            var viewResult = (ViewResult)result;

            List<Media> media = (viewResult.Model as IEnumerable<Media>).ToList();
            Assert.IsTrue(media.Count() == 1);
            Assert.IsTrue(media[0].Name == "Catch me if you can");
        }

        [TestMethod]
        public void SearchWithNoResultsTest()
        {
            // Arrange:
            var mediaList = PopulateMedia();

            var mockRepo = new MockSubtitleRepository(mediaList);
            var controller = new BrowseController(mockRepo);

            // Act:
            var result = controller.Search("Hobbit"); 

            // Assert:
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [TestMethod]
        public void SearchWithTwoResults()
        {
            // Arrange:
            var mediaList = PopulateMedia();

            var mockRepo = new MockSubtitleRepository(mediaList);
            var controller = new BrowseController(mockRepo);

            // Act:
            var result = controller.Search("The"); // virkar ekki, þótt þetta virki á síðunni sjálfri :/
            // var result = controller.Search("Catch me if you can"); // Þetta virkar hinsvegar

            // Assert:
            var viewResult = (ViewResult)result;

            List<Media> media = (viewResult.Model as IEnumerable<Media>).ToList();
            media.Sort((x, y) => string.Compare(x.Name, y.Name));
            Assert.IsTrue(media.Count() == 2);
            Assert.IsTrue(media[0].Name == "The Matrix");
            Assert.IsTrue(media[1].Name == "The Notebook");
        }
    }
}
