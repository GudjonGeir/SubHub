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

        public int AddSubtitle(Subtitle s)
        {
            int newID = m_db.Subtitles.Max(x => x.Id) + 1;
            s.Id = newID;
            m_db.Subtitles.Add(s);
            m_db.SaveChanges();
            return s.Id;
        }


        public void AddSubtitleLine(SubtitleLine sl)
        {
            m_db.SubtitleLines.Add(sl);
            m_db.SaveChanges();
        }
    }
}