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

        public void UpVote(int? id, ApplicationUser user)
        {
            var model = (from m in m_db.SubtitleRatings
                         where m.SubtitleId == id
                         select m).SingleOrDefault();
            model.Count += 1;
            model.Users.Add(user);
            m_db.SaveChanges();
        }
    }
}