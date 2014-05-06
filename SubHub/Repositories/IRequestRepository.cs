using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;

namespace SubHub.Repositories
{
    public interface IRequestRepository
    {
        IQueryable<Request> GetRequests();
    }
}
