using SubHub.DAL;
using SubHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class SubtitleRepository : ISubtitleRepository
    {
        SubHubContext m_db = new SubHubContext();

        public IQueryable<Subtitle> GetSubtitles()
        {
            return m_db.Subtitles;
        }

        public void AddMedia(Media m)
        {
            m_db.Medias.Add(m);
            m_db.SaveChanges();
        }

        public IQueryable<Media> GetMedias()
        {
            return m_db.Medias;
        }

        public IQueryable<MediaType> GetMediaTypes()
        {
            return m_db.MediaTypes;
        }

        public IQueryable<MediaGenre> GetMediaGenres()
        {
            return m_db.MediaGenres;
        }

        public IQueryable<SubtitleLanguage> GetSubtitleLanguages()
        {
            return m_db.MediaLanguages;
        }

        public int AddSubtitle(Subtitle s)
        {
            m_db.Subtitles.Add(s);
            m_db.SaveChanges();
            return s.Id;
        }

        public IQueryable<SubtitleLine> GetSubtitleLines()
        {
            return m_db.SubtitleLines;
        }

        public void AddSubtitleLine(SubtitleLine sl)
        {
            m_db.SubtitleLines.Add(sl);
            m_db.SaveChanges();
        }

        public void AddUserToSubtitle(int id, string userId)
        {
            var sub = (from m in m_db.Subtitles
                       where m.Id == id
                       select m).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            if (!sub.Users.Contains(user))
            {
                sub.Users.Add(user);
            }

            m_db.SaveChanges();
        }

        public int Upvote(int? id, int value)
        {
            var model = (from m in m_db.SubtitleUpvotes
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count += value;
            m_db.SaveChanges();
            return model.Count;
        }

        public int Downvote(int? id, int value)
        {
            var model = (from m in m_db.SubtitleDownvotes
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count += value;
            m_db.SaveChanges();
            return model.Count;
        }

        public void UpdateRating(int id, int value)
        {
            var model = (from m in m_db.SubtitleRatings
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count = value;
            m_db.SaveChanges();
        }

        public IQueryable<Comment> GetAllComments()
        {
            return m_db.Comments.AsQueryable();
        }

        public void AddComment(Comment comment)
        {
            var theSubtitle = (from c in m_db.Subtitles
                               where c.Id == comment.SubtitleId
                              select c).SingleOrDefault();
            theSubtitle.Comments.Add(comment);
            m_db.SaveChanges();
        }

        public void RemoveComment(int? id)
        {
            var theComment = (from c in m_db.Comments
                              where c.Id == id
                              select c).SingleOrDefault<Comment>();
            m_db.Comments.Remove(theComment);
            m_db.SaveChanges();
        }


        public IQueryable<ApplicationUser> GetUsers()
        {
            return m_db.Users;
        }



        public IQueryable<SubtitleRating> GetSubtitleRatings()
        {
            return m_db.SubtitleRatings;
        }

        public IQueryable<SubtitleUpvote> GetSubtitleUpvotes()
        {
            return m_db.SubtitleUpvotes;
        }

        public IQueryable<SubtitleDownvote> GetSubtitleDownvotes()
        {
            return m_db.SubtitleDownvotes;
        }

        public void AddUserToUpvotes(int id, string userId)
        {
            var upvote = (from u in m_db.SubtitleUpvotes
                          where u.SubtitleId == id
                          select u).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            upvote.Users.Add(user);
            m_db.SaveChanges();
        }
        public void AddUserToDownvotes(int id, string userId)
        {
            var downvote = (from u in m_db.SubtitleDownvotes
                          where u.SubtitleId == id
                          select u).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            downvote.Users.Add(user);
            m_db.SaveChanges();
        }
        public void RemoveUserFromUpvotes(int id, string userId)
        {
            var upvote = (from u in m_db.SubtitleUpvotes
                          where u.SubtitleId == id
                          select u).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            upvote.Users.Remove(user);
            m_db.SaveChanges();
            
        }
        public void RemoveUserFromDownvotes(int id, string userId)
        {
            var downvote = (from u in m_db.SubtitleDownvotes
                          where u.SubtitleId == id
                          select u).SingleOrDefault();
            var user = (from u in m_db.Users
                        where u.Id == userId
                        select u).SingleOrDefault();
            downvote.Users.Remove(user);
            m_db.SaveChanges();
        }
    }
}