using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Tests.Mocks
{
    class MockRequestRepository : IRequestRepository
    {
        private readonly List<Request> m_requests;

        public MockRequestRepository(List<Request> requests)
        {
            m_requests = requests;
        }


        public IQueryable<Request> GetRequests()
        {
            return m_requests.AsQueryable();
        }


        public IQueryable<RequestRating> GetRequestRating()
        {
            throw new NotImplementedException();
        }

        public void RemoveRequest(int? id)
        {
            throw new NotImplementedException();
        }

        public void SetCompleted(int id)
        {
            throw new NotImplementedException();
        }

        public void Upvote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
