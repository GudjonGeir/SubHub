using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;

namespace SubHub.Tests.Mocks
{
    class MockRequestRepository : IRequestRepository
    {
        private readonly List<Request> _requests;

        public MockRequestRepository(List<Request> requests)
        {
            _requests = requests;
        }


        public IQueryable<Repositories.Request> GetRequests()
        {
            return _requests.AsQueryable();
        }
    }
}
