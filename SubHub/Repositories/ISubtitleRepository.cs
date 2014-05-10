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

        int AddSubtitle(Subtitle s);
        void AddSubtitleLine(SubtitleLine sl);

        void UpVote(int? id, ApplicationUser user);
        IQueryable<Comment> GetAllComments();
        void AddComment(Comment comment);
        void AddMedia(Media m);
        IQueryable<MediaType> GetMediaTypes();
        IQueryable<Media> GetMedias();
        IQueryable<MediaGenre> GetMediaGenres();
        IQueryable<SubtitleLanguage> GetSubtitleLanguages();
    }
}
