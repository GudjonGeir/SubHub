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
        private readonly List<Media> m_media;
        private readonly List<SubtitleLanguage> m_mediaLanguages;

        public MockRequestRepository(List<Request> requests)
        {
            m_requests = requests;
        }

        public MockRequestRepository(List<Media> media)
        {
            m_media = media;
        }

        public MockRequestRepository(List<SubtitleLanguage> medialanguages, List<Request> requests)
        {
            m_mediaLanguages = medialanguages;
            m_requests = requests;
        }


        public IQueryable<Request> GetRequests()
        {
            return m_requests.AsQueryable();
        }


        public IQueryable<RequestRating> GetRequestRatings()
        {
            List<RequestRating> requestRatings = new List<RequestRating>();
            foreach (Request r in m_requests)
            {
                requestRatings.Add(r.RequestRating);
            }
            return requestRatings.AsQueryable();
        }

        public void RemoveRequest(int? id)
        {
            throw new NotImplementedException();
        }

        public void SetCompleted(int id)
        {
            var s = (from l in m_requests
                     where l.Id == id
                     select l).SingleOrDefault();
            if(s != null)
            {
                s.Completed = true;
            }
        }

        public void Upvote(int id)
        {
            var s = (from l in m_requests
                     where l.RequestRating.RequestId == id
                     select l).SingleOrDefault();
            if (s != null)
            {
                s.RequestRating.count += 1;
            }
        }

        public void AddRequest(Request m)
        {
            m_requests.Add(m);
        }


        public IQueryable<SubtitleLanguage> GetSubtitleLanguages()
        {
            return m_mediaLanguages.AsQueryable();
        }




        public int UpdateRating(int id, int value)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromRating(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void AddUserToRating(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
