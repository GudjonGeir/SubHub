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
    }
}