using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Tests.Mocks
{
    class MockSubtitleRepository : ISubtitleRepository
    {
        private readonly List<Subtitle> m_subtitles;
        private readonly List<Media> m_media;

        public MockSubtitleRepository(List<Subtitle> subtitles)
        {
            m_subtitles = subtitles;
        }

        public MockSubtitleRepository(List<Media> media)
        {
            m_media = media;
        }

        public IQueryable<Subtitle> GetSubtitles()
        {
            return m_subtitles.AsQueryable();
        }


        public int AddSubtitle(Subtitle s)
        {
            throw new NotImplementedException();
        }


        public void AddSubtitleLine(SubtitleLine sl)
        {
            throw new NotImplementedException();
        }

        public void UpVote(int? id, ApplicationUser user)
        {
            var model = (from m in m_subtitles
                         where m.Id == id
                         select m).SingleOrDefault();
            model.SubtitleRating.Count += 1;
            model.SubtitleRating.Users.Add(user);
        }

        public void DownVote(int? id, ApplicationUser user)
        {

        }

        public void AddComment(Comment comment)
        {

        }

        public void RemoveComment(int? id)
        {
            Subtitle theSubtitle = m_subtitles[0];
            var theComment = (from c in theSubtitle.Comments
                              where c.Id == id
                              select c).SingleOrDefault<Comment>();
            theSubtitle.Comments.Remove(theComment);
        }

        public IQueryable<Comment> GetAllComments()
        {
            return m_subtitles[0].Comments.AsQueryable();
        }


        public void AddMedia(Media m)
        {
            throw new NotImplementedException();
        }


        public IQueryable<MediaType> GetMediaTypes()
        {
            throw new NotImplementedException();
        }


        public IQueryable<Media> GetMedias()
        {
            return m_media.AsQueryable();
        }

        public IQueryable<MediaGenre> GetMediaGenres()
        {
            throw new NotImplementedException();
        }


        public IQueryable<SubtitleLanguage> GetSubtitleLanguages()
        {
            throw new NotImplementedException();
        }


        public IQueryable<SubtitleLine> GetSubtitleLines()
        {
            throw new NotImplementedException();
        }


        public void AddUserToSubtitle(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
