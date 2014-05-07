using SubHub.Models;
using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class RequestRepository : ISubtitleRepository
    {
        //private static RequestRepository _instance;

        //private static RequestRepository Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new RequestRepository();
        //        return _instance;
        //    }
        //}
        //private List<Request> m_requests = null;

        //public IQueryable<Request> GetRequests()
        //{
        //    //var result = from c in m_users
        //    //             orderby c.DateSubmitted ascending
        //    //             select c;
        //    return result;
        //}

        //public void AddRequest(Request c)
        //{
        //    int newId = 1;
        //    if (m_requests.Count() > 0)
        //    {
        //        newId = m_requests.Max(x => x.ID) + 1;
        //    }
        //    c.Id = newId;
        //    c.DateSubmitted = DateTime.Now;
        //    m_requests.Add(c);
        //}


        //private AppDataContext _context;

        public void RemoveRequest(int? id)
        {

        }

        public void SetCompleted(int id)
        {

        }

        public void Upvote(int id)
        {

        }

        public void Downvote(int id)
        {

        }

        public IQueryable<Subtitle> GetSubtitles()
        {
            //return _context;
            return null;
        }
    }
}