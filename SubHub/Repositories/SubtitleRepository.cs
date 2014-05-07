using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubHub.Model;

namespace SubHub.Repositories
{
    public class SubtitleRepository
    {
        private static SubtitleRepository _instance;

        private static SubtitleRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SubtitleRepository();
                return _instance;
            }
        }

        private List<Subtitle> m_subtitles = null;

        public IQueryable<Subtitle> GetSubtitles()
        {
            //var result = from c in m_subtitles
            //             orderby dateSubmitted ascending
            //             select c;
            //return result;
            return null;
        }

        public void AddSubtitle(Subtitle s)
        {
            int newId = 1;
            if (m_subtitles.Count() > 0)
            {
                newId = m_subtitles.Max(x => x.Id) + 1;
            }
            s.Id = newId;
            s.DateSubmitted = DateTime.Now;
            m_subtitles.Add(s);
        }
        
        public void DeleteSubtitle(int? id)
        {
            
        }

    }
}