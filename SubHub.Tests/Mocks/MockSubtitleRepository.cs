using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Tests.Mocks
{
    public class MockSubtitleRepository : ISubtitleRepository
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
    }
}
