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
            int newID = m_db.Subtitles.Max(x => x.Id) + 1;
            s.Id = newID;
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

        public void UpVote(int? id, ApplicationUser user)
        {
            var model = (from m in m_db.SubtitleRatings
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count += 1;
            model.Users.Add(user);
            m_db.SaveChanges();
        }

        public void DownVote(int? id, ApplicationUser user)
        {
            var model = (from m in m_db.SubtitleRatings
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count -= 1;
            model.Users.Add(user);
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

    }
}