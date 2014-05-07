﻿using SubHub.DAL;
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
            var s = (from l in m_db.RequestRatings
                    where l.RequestId == id
                    select l).SingleOrDefault();
            if (s != null)
            {
                s.count += 1;
                m_db.SaveChanges();
            }
        }

        public IQueryable<RequestRating> GetRequestRating()
        {
            return m_db.RequestRatings;
        }
    }
}