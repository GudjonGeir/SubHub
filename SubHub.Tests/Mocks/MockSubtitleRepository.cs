using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Models;

namespace SubHub.Tests.Mocks
{
    public class MockSubtitleRepository : ISubtitleRepository
    {
        private readonly List<Subtitle> _subtitles;

        public MockSubtitleRepository(List<Subtitle> subtitles)
        {
            _subtitles = subtitles;
        }


        public IQueryable<Models.Subtitle> GetSubtitles()
        {
            return _subtitles.AsQueryable();
        }
    }
}
