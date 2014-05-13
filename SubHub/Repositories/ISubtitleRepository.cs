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
        IQueryable<SubtitleLine> GetSubtitleLines();
        void UpVote(int? id, ApplicationUser user);
        void DownVote(int? id, ApplicationUser user);
        void AddComment(Comment comment);
        void RemoveComment(int? id);
        void AddMedia(Media m);
        IQueryable<Comment> GetAllComments();
        IQueryable<MediaType> GetMediaTypes();
        IQueryable<Media> GetMedias();
        IQueryable<MediaGenre> GetMediaGenres();
        IQueryable<SubtitleLanguage> GetSubtitleLanguages();
    }
}
