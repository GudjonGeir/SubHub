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

        public MockSubtitleRepository(List<Subtitle> subtitles)
        {
            m_subtitles = subtitles;
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

        public void AddComment(Comment comment)
        {

        }

        public IQueryable<Comment> GetAllComments()
        {
            return null;
        }
    }
}
