using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class UserRepository
    {
        private static UserRepository _instance;

        private static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserRepository();
                return _instance;
            }
        }
        //private List<User> m_users = null;

        //public IQueryable<User> GetUsers()
        //{
        //    var result = from c in m_users
        //                 orderby c.DateCreated ascending
        //                 select c;
        //    return result;
        //}

        //public void AddUser(User c)
        //{
        //    int newId = 1;
        //    if (m_users.Count() > 0)
        //    {
        //        newId = m_users.Max(x => x.ID) + 1;
        //    }
        //    c.Id = newId;
        //    c.DateCreated = DateTime.Now;
        //    m_users.Add(c);
        //}

        public void RemoveUser(int? id)
        {

        }
    }
}