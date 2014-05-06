using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;

namespace SubHub.Tests.Mocks
{
    public class MockSubtitleRepository : ISubtitleRepository
    {
        private readonly List<Subtitle> _subtitles;

        public MockSubtitleRepository(List<Subtitle> subtitles)
        {
            _subtitles = subtitles;
        }


        public IQueryable<Repositories.Subtitle> GetSubtitles()
        {
            return _subtitles.AsQueryable();
        }
    }
}
