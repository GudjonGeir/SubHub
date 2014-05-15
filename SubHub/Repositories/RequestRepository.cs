using SubHub.DAL;
using SubHub.Models;
using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        SubHubContext m_db = new SubHubContext();

        public IQueryable<Request> GetRequests()
        {
            return m_db.Requests;
        }

        public void RemoveRequest(int? id)
        {
            throw new NotImplementedException();
        }

        public void SetCompleted(int id)
        {
            var s = (from l in m_db.Requests
                     where l.Id == id
                     select l).SingleOrDefault();
            if(s != null)
            {
                s.Completed = true;
                m_db.SaveChanges();
            }
        }

        public int UpdateRating(int id, int value)
        {
            var s = (from l in m_db.RequestRatings
                    where l.RequestId == id
                    select l).SingleOrDefault();
            if (s != null)
            {

                s.count += value;
                m_db.SaveChanges();
                return s.count;
            }
            return 0;
        }

        public void RemoveUserFromRating(int id, string userId)
        {
            var rating = (from l in m_db.RequestRatings
                     where l.RequestId == id
                     select l).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            rating.Users.Remove(user);
            m_db.SaveChanges();
        }

        public void AddUserToRating(int id, string userId)
        {
            var rating = (from l in m_db.RequestRatings
                          where l.RequestId == id
                          select l).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            rating.Users.Add(user);
            m_db.SaveChanges();
        }

        public IQueryable<RequestRating> GetRequestRatings()
        {
            return m_db.RequestRatings;
        }

        public IQueryable<SubtitleLanguage> GetSubtitleLanguages()
        {
            return m_db.SubtitleLanguages;
        }

        public void AddRequest(Request m)
        {
            m_db.Requests.Add(m);
            m_db.SaveChanges();
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return m_db.Users;
        }
    }
}