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
        void AddUserToSubtitle(int id, string userId);
        IQueryable<SubtitleLine> GetSubtitleLines();
        int Upvote(int? id, int value);
        int Downvote(int? id, int value);
        void AddComment(Comment comment);
        void RemoveComment(int? id);
        void AddMedia(Media m);
        void UpdateRating(int id, int value);
        IQueryable<Comment> GetAllComments();
        IQueryable<MediaType> GetMediaTypes();
        IQueryable<Media> GetMedias();
        IQueryable<MediaGenre> GetMediaGenres();
        IQueryable<SubtitleLanguage> GetSubtitleLanguages();
        IQueryable<SubtitleRating> GetSubtitleRatings();
        IQueryable<SubtitleUpvote> GetSubtitleUpvotes();
        IQueryable<SubtitleDownvote> GetSubtitleDownvotes();
        IQueryable<ApplicationUser> GetUsers();
        void AddUserToUpvotes(int id, string userId);
        void AddUserToDownvotes(int id, string userId);
        void RemoveUserFromUpvotes(int id, string userId);
        void RemoveUserFromDownvotes(int id, string userId);
    }
}
