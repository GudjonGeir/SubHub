using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SubHub.Models;
using System.Linq;
using SubHub.Tests.Mocks;
using SubHub.Controllers;
using System.Web.Mvc;

namespace SubHub.Tests.Controllers
{
    [TestClass]
    public class RequestControllerTest
    {
        [TestMethod]
        public void TestUpvote()
        {
            //Arrange:
            Request request1 = new Request { Id = 1, Completed = false, DateSubmitted = DateTime.Now.AddDays(-3), Name = "Avatar" };
            RequestRating requestRating1 = new RequestRating { count = 2, RequestId = 1 };
            request1.RequestRating = requestRating1;
            requestRating1.Request = request1;
            var requestRatings = new List<Request>() { request1 };


            var mockRepo = new MockRequestRepository(requestRatings);
            var controller = new RequestController(mockRepo);

            //Act:
            controller.Upvote(1);

            //Assert:
            var rating = (from r in mockRepo.GetRequestRatings()
                           where r.RequestId == 1
                           select r).SingleOrDefault();
            Assert.IsTrue(rating.count == 3);
        }

        [TestMethod]
        public void TestComplete()
        {
            Request request1 = new Request { Id = 1, Completed = false, DateSubmitted = DateTime.Now.AddDays(-3), Name = "Avatar" };
            RequestRating requestRating1 = new RequestRating { count = 2, RequestId = 1 };
            request1.RequestRating = requestRating1;
            requestRating1.Request = request1;
            var requestRatings = new List<Request>() { request1 };

            var mockRepo = new MockRequestRepository(requestRatings);
            var controller = new RequestController(mockRepo);

            //Act:
            controller.Complete(1);

            var request = (from r in mockRepo.GetRequests()
                           where r.Id == 1
                           select r).SingleOrDefault();
            Assert.IsTrue(request.Completed == true);
        }
    }
}
