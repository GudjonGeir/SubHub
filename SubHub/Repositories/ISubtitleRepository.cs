using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Repositories
{
    public interface ISubtitleRepository
    {
        IQueryable<Subtitle>GetSubtitles();
        void UpVote(int? id, ApplicationUser user);
    }
}
