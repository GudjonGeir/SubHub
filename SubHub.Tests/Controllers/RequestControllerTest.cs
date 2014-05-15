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


        public void TestViewRequest()
        {
            //Arrange:
            Request request1 = new Request { Id = 1, Completed = false, DateSubmitted = DateTime.Now, Name = "Matrix" };
            RequestRating requestRating1 = new RequestRating { count = 3 , RequestId = 1, Request = request1 };
            var requests = new List<Request>() { request1 };

            var mockRepo = new MockRequestRepository(requests);
            var controller = new RequestController(mockRepo); 
            //Act:
            var result = controller.ViewRequest(1);
            //Assert:
            var viewRequest = (ViewResult)result;

            Request model = viewRequest.Model as Request;
            Assert.IsTrue(model.Id == 1);
            Assert.IsTrue(model.Name == "Matrix");
        }

        [TestMethod]
        public void TestComplete()
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
            controller.Complete(1);

            //Assert:
            var request = (from r in mockRepo.GetRequests()
                           where r.Id == 1
                           select r).SingleOrDefault();
            Assert.IsTrue(request.Completed == true);
        }

        [TestMethod]
        public void TestGetRequests()
        {
            //Arrange:
            RequestRating requestRating1 = new RequestRating { count = 2, RequestId = 1, Users = new List<ApplicationUser>() };
            RequestRating requestRating2 = new RequestRating { count = 3, RequestId = 2, Users = new List<ApplicationUser>() };
            RequestRating requestRating3 = new RequestRating { count = 1, RequestId = 3, Users = new List<ApplicationUser>() };
            Request request1 = new Request { Id = 1, Completed = false, DateSubmitted = DateTime.Now.AddDays(-3), Name = "Avatar", RequestRating = requestRating1 };
            Request request2 = new Request { Id = 2, Completed = true, DateSubmitted = DateTime.Now.AddDays(-4), Name = "Catch me if you can", RequestRating = requestRating2 };
            Request request3 = new Request { Id = 3, Completed = false, DateSubmitted = DateTime.Now.AddDays(-5), Name = "Highlander", RequestRating = requestRating3 };
            requestRating1.Request = request1;
            requestRating2.Request = request2;
            requestRating3.Request = request3;
            var requests = new List<Request>() { request1, request2, request3 };
            var mockRepo = new MockRequestRepository(requests);
            var controller = new RequestController(mockRepo);

            //Act:
            var result = controller.Requests();

            //Assert:
            var viewResult = (ViewResult)result;
            List<Request> requests1 = (viewResult.Model as IEnumerable<Request>).ToList();
            Assert.IsTrue(requests1[0].Completed == true);
            Assert.IsTrue(requests1[1].Name == "Avatar");
            Assert.IsTrue(requests1[0].Name == "Catch me if you can");
            Assert.IsTrue(requests1[2].Completed == false);
        }


    }
}
