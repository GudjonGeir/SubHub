using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubHub.Model;

namespace SubHub.Repositories
{
    public class CommentRepository
    {
        private static CommentRepository _instance;

        private static CommentRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CommentRepository();
                return _instance;
            }
        }
        private List<Comment>m_comments = null;

        public IQueryable<Comment> GetComments()
        {
            //var result = from c in m_comments
            //             orderby c.CommentDate ascending
            //             select c;
           return null;
        }

        public void AddComment(Comment c)
        {
            //int newId = 1;
            //if (m_comments.Count() > 0)
            //{
            //    newId = m_comments.Max(x => x.ID) + 1;
            //}
            //c.ID = newId;
            //c.CommentDate = DateTime.Now;
            //m_comments.Add(c);
        }

        public void RemoveComment(int? id)       
        { 

        }

        
    }
}