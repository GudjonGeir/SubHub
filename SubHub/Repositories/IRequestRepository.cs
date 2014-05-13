using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Repositories
{
    public interface IRequestRepository
    {
        IQueryable<Request> GetRequests();
        IQueryable<RequestRating> GetRequestRatings();
        void RemoveRequest(int? id);
        void SetCompleted(int id);
        int UpdateRating(int id, int value);
        void RemoveUserFromRating(int id, string userId);
        void AddUserToRating(int id, string userId);
        IQueryable<SubtitleLanguage> GetSubtitleLanguages();
        void AddRequest(Request m);
        IQueryable<ApplicationUser> GetUsers();
    }
}
