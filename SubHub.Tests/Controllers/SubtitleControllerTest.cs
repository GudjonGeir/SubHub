using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SubHub.Models;
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
            // Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
			{
			    subtitles.Add(new Subtitle
                    {
                        Name = "subtitle" + i.ToString(),
                        DateAired = DateTime.Now.AddDays(-rnd.Next(100)), 
                        DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)), 
                        Genre = "genre" + i.ToString(), 
                        Id = i, 
                        ImdbUrl = "url" + i.ToString(), 
                        Language = "language" + i.ToString(), 
                        PosterUrl = "poster" + i.ToString(), 
                        Type = "type" + i.ToString()
                    });                
			}
            // List<Subtitle> shuffledSubtitles = (List<Subtitle>)subtitles.OrderBy( s => rnd.Next());

            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result1 = controller.ViewSubtitle(1);

            // Assert:

            var viewResult1 = (ViewResult)result1;

            Subtitle model1 = viewResult1.Model as Subtitle;
            Assert.IsTrue(model1.Id == 1);
            Assert.IsTrue(model1.Name == "subtitle1");

        }
        [TestMethod]
        public void TestViewSubtitleWithIncorrectId()
        {
            // Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                {
                    Name = "subtitle" + i.ToString(),
                    DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                    DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                    Genre = "genre" + i.ToString(),
                    Id = i,
                    ImdbUrl = "url" + i.ToString(),
                    Language = "language" + i.ToString(),
                    PosterUrl = "poster" + i.ToString(),
                    Type = "type" + i.ToString()
                });
            }
            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result = controller.ViewSubtitle(11);

            // Assert:
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [TestMethod]
        public void TestViewSubtitleWitNullId()
        {
            // Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                {
                    Name = "subtitle" + i.ToString(),
                    DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                    DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                    Genre = "genre" + i.ToString(),
                    Id = i,
                    ImdbUrl = "url" + i.ToString(),
                    Language = "language" + i.ToString(),
                    PosterUrl = "poster" + i.ToString(),
                    Type = "type" + i.ToString()
                });
            }
            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result = controller.ViewSubtitle(null);

            // Assert:
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [TestMethod]
        public void TestEditSubtitleWithCorrectId()
        {
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                {
                    Name = "subtitle" + i.ToString(),
                    DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                    DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                    Genre = "genre" + i.ToString(),
                    Id = i,
                    ImdbUrl = "url" + i.ToString(),
                    Language = "language" + i.ToString(),
                    PosterUrl = "poster" + i.ToString(),
                    Type = "type" + i.ToString()
                });
            }


            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result1 = controller.EditSubtitle(1);

            // Assert:

            var viewResult1 = (ViewResult)result1;

            Subtitle model1 = viewResult1.Model as Subtitle;
            Assert.IsTrue(model1.Id == 1);
            Assert.IsTrue(model1.Name == "subtitle1");
        }

        [TestMethod]
        public void TestEditSubtitleWithIncorrectId()
        {
            // Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                {
                    Name = "subtitle" + i.ToString(),
                    DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                    DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                    Genre = "genre" + i.ToString(),
                    Id = i,
                    ImdbUrl = "url" + i.ToString(),
                    Language = "language" + i.ToString(),
                    PosterUrl = "poster" + i.ToString(),
                    Type = "type" + i.ToString()
                });
            }
            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result = controller.EditSubtitle(11);

            // Assert:
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }

        [TestMethod]
        public void TestEditSubtitleWithNullId()
        {
            // Arrange:
            Random rnd = new Random();
            List<Subtitle> subtitles = new List<Subtitle>();
            for (int i = 1; i <= 10; i++)
            {
                subtitles.Add(new Subtitle
                {
                    Name = "subtitle" + i.ToString(),
                    DateAired = DateTime.Now.AddDays(-rnd.Next(100)),
                    DateSubmitted = DateTime.Now.AddDays(-rnd.Next(100)),
                    Genre = "genre" + i.ToString(),
                    Id = i,
                    ImdbUrl = "url" + i.ToString(),
                    Language = "language" + i.ToString(),
                    PosterUrl = "poster" + i.ToString(),
                    Type = "type" + i.ToString()
                });
            }
            var mockRepo = new MockSubtitleRepository(subtitles);
            var controller = new SubtitleController(mockRepo);

            // Act:
            var result = controller.EditSubtitle(null);

            // Assert:
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Error", viewResult.ViewName);
        }
    }
}

