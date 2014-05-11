using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SubHub.Models;
using SubHub.Repositories;
using System.Linq;
using SubHub.Tests.Mocks;
using SubHub.Controllers;
using System.Web.Mvc;
using System.Security.Claims;


namespace SubHub.Tests.Controllers
{
    [TestClass]
    public class SubtitleControllerTest
    {
        [TestMethod]
        public void TestViewSubtitleWithCorrectId()
        {
        //Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                    {
                        //Name = "subtitle" + i.ToString(),
                        //DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                        Id = i,
                        Media = new Media{ Id = 1, Name = "subtitle" + i.ToString(), GenreId = i, TypeId = i},
                        DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                        Language = new SubtitleLanguage { Id = i, Language = "language" + i.ToString() },
                        //Genre = "genre" + i.ToString(),
                        //Id = i,
                        //ImdbUrl = "url" + i.ToString(),
                        //Language = "language" + i.ToString(),
                        //PosterUrl = "poster" + i.ToString(),
                        //Type = "type" + i.ToString()
                    });
            }

            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

        //Act:
            var result1 = controller.ViewSubtitle(1);

        //Assert:

            var viewResult1 = (ViewResult)result1;

            Subtitle model1 = viewResult1.Model as Subtitle;
            Assert.IsTrue(model1.Id == 1);
            Assert.IsTrue(model1.Media.Name == "subtitle1");

        }
        //[TestMethod]
        //public void TestViewSubtitleWithIncorrectId()
        //{
        //Arrange:
        //    Random rnd = new Random();
        //    List<Subtitle> subtitles = new List<Subtitle>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        subtitles.Add(new Subtitle
        //        {
        //            Name = "subtitle" + i.ToString(),
        //            DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
        //            DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
        //            Genre = "genre" + i.ToString(),
        //            Id = i,
        //            ImdbUrl = "url" + i.ToString(),
        //            Language = "language" + i.ToString(),
        //            PosterUrl = "poster" + i.ToString(),
        //            Type = "type" + i.ToString()
        //        });
        //    }
        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    var result = controller.ViewSubtitle(11);

        //Assert:
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual("Error", viewResult.ViewName);
        //}

        //[TestMethod]
        //public void TestViewSubtitleWitNullId()
        //{
        //Arrange:
        //    Random rnd = new Random();
        //    List<Subtitle> subtitles = new List<Subtitle>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        subtitles.Add(new Subtitle
        //        {
        //            Name = "subtitle" + i.ToString(),
        //            DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
        //            DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
        //            Genre = "genre" + i.ToString(),
        //            Id = i,
        //            ImdbUrl = "url" + i.ToString(),
        //            Language = "language" + i.ToString(),
        //            PosterUrl = "poster" + i.ToString(),
        //            Type = "type" + i.ToString()
        //        });
        //    }
        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    var result = controller.ViewSubtitle(null);

        //Assert:
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual("Error", viewResult.ViewName);
        //}

        //[TestMethod]
        //public void TestEditSubtitleWithCorrectId()
        //{
        //    Random rnd = new Random();
        //    List<Subtitle> subtitles = new List<Subtitle>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        subtitles.Add(new Subtitle
        //        {
        //            Name = "subtitle" + i.ToString(),
        //            DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
        //            DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
        //            Genre = "genre" + i.ToString(),
        //            Id = i,
        //            ImdbUrl = "url" + i.ToString(),
        //            Language = "language" + i.ToString(),
        //            PosterUrl = "poster" + i.ToString(),
        //            Type = "type" + i.ToString()
        //        });
        //    }


        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    var result1 = controller.EditSubtitle(1);

        //Assert:

        //    var viewResult1 = (ViewResult)result1;

        //    Subtitle model1 = viewResult1.Model as Subtitle;
        //    Assert.IsTrue(model1.Id == 1);
        //    Assert.IsTrue(model1.Name == "subtitle1");
        //}

        //[TestMethod]
        //public void TestEditSubtitleWithIncorrectId()
        //{
        //Arrange:
        //    Random rnd = new Random();
        //    List<Subtitle> subtitles = new List<Subtitle>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        subtitles.Add(new Subtitle
        //        {
        //            Name = "subtitle" + i.ToString(),
        //            DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
        //            DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
        //            Genre = "genre" + i.ToString(),
        //            Id = i,
        //            ImdbUrl = "url" + i.ToString(),
        //            Language = "language" + i.ToString(),
        //            PosterUrl = "poster" + i.ToString(),
        //            Type = "type" + i.ToString()
        //        });
        //    }
        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    var result = controller.EditSubtitle(11);

        //Assert:
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual("Error", viewResult.ViewName);
        //}

        //[TestMethod]
        //public void TestEditSubtitleWithNullId()
        //{
        //Arrange:
        //    Random rnd = new Random();
        //    List<Subtitle> subtitles = new List<Subtitle>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        subtitles.Add(new Subtitle
        //        {
        //            Name = "subtitle" + i.ToString(),
        //            DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
        //            DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
        //            Genre = "genre" + i.ToString(),
        //            Id = i,
        //            ImdbUrl = "url" + i.ToString(),
        //            Language = "language" + i.ToString(),
        //            PosterUrl = "poster" + i.ToString(),
        //            Type = "type" + i.ToString()
        //        });
        //    }
        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    var result = controller.EditSubtitle(null);

        //Assert:
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual("Error", viewResult.ViewName);
        //}

        //[TestMethod]
        //public void TestUpvoteSubtitle()
        //{
        //Arrange:
        //    ApplicationUser user1 = new ApplicationUser { UserName = "user1", Id = "user1ID" };
        //    ApplicationUser user2 = new ApplicationUser { UserName = "user2", Id = "user2ID" };
        //    ApplicationUser user3 = new ApplicationUser { UserName = "user3", Id = "user3ID" };
        //    Subtitle subtitle1 = new Subtitle { Id = 1, Name = "Catch me if you can", DateAired = new DateTime(2002, 12, 25), DateSubmitted = DateTime.Now.AddDays(-3), Genre = "Biography", ImdbUrl = "http://www.imdb.com/title/tt0264464/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_SX640_SY720_.jpg", Type = "Movie" };
        //    SubtitleRating rating1 = new SubtitleRating() { Count = 1, SubtitleId = 1, Users = new List<ApplicationUser> { user3 }, Subtitle = subtitle1 };
        //    subtitle1.SubtitleRating = rating1;
        //    Subtitle subtitle2 = new Subtitle { Id = 2, Name = "The Notebook", DateAired = new DateTime(2003, 06, 25), DateSubmitted = DateTime.Now.AddDays(-10), Genre = "Romace", ImdbUrl = "http://www.imdb.com/title/tt0332280/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTUwMDg3OTA2N15BMl5BanBnXkFtZTcwNzc5OTYwOQ@@._V1_SX640_SY720_.jpg", Type = "Movie" };
        //    Subtitle subtitle3 = new Subtitle { Id = 3, Name = "The Matrix", DateAired = new DateTime(1999, 3, 21), DateSubmitted = DateTime.Now.AddDays(-13), Genre = "Sci-Fi", ImdbUrl = "http://www.imdb.com/title/tt0133093/?ref_=nv_sr_1", Language = "English", PosterUrl = "http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_SX640_SY720_.jpg", Type = "Movie" };
        //    rating1.Subtitle = subtitle1;
        //    var subtitles = new List<Subtitle>() { subtitle1, subtitle2, subtitle3 };
        //    var mockRepo = new MockSubtitleRepository(subtitles);
        //    var controller = new SubtitleController(mockRepo);

        //Act:
        //    controller.Upvote(1, user2);

        //Assert:
        //    var result = mockRepo.GetSubtitles();
        //    var theSubtitle = (from r in result
        //                       where r.Id == 1
        //                       select r).SingleOrDefault();


        //    Assert.IsTrue(theSubtitle.SubtitleRating.Count == 2);
        //}
    }
}
