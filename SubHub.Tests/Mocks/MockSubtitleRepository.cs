﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Repositories;
using SubHub.Models;

namespace SubHub.Tests.Mocks
{
    class MockSubtitleRepository : ISubtitleRepository
    {
        private readonly List<Subtitle> m_subtitles;
        private readonly List<SubtitleLanguage> m_mediaLanguages;
        private readonly List<Media> m_media;
        private readonly List<MediaType> m_mediaTypes;

        public MockSubtitleRepository(List<Media> media)
        {
            m_media = media;
        }

        public MockSubtitleRepository(List<MediaType> mediaTypes)
        {
            m_mediaTypes = mediaTypes;
        }

        public MockSubtitleRepository(List<Subtitle> subtitles)
        {
            m_subtitles = subtitles;
        }

        public MockSubtitleRepository(List<SubtitleLanguage> media)
        {
            m_mediaLanguages = media;
        }

        public IQueryable<Subtitle> GetSubtitles()
        {
            return m_subtitles.AsQueryable();
        }


        public int AddSubtitle(Subtitle s)
        {
            throw new NotImplementedException();
        }


        public void AddSubtitleLine(SubtitleLine sl)
        {
            throw new NotImplementedException();
        }

        public void UpVote(int? id, ApplicationUser user)
        {
            //var model = (from m in m_subtitles
            //             where m.Id == id
            //             select m).SingleOrDefault();
            //model.SubtitleRating.Count += 1;
            //model.SubtitleRating.Users.Add(user);
        }

        public void DownVote(int? id, ApplicationUser user)
        {
            //var model = (from m in m_subtitles
            //             where m.Id == id
            //             select m).SingleOrDefault();
            //model.SubtitleRating.Count -= 1;
            //model.SubtitleRating.Users.Add(user);

        }

        public void AddComment(Comment comment)
        {
            var model = (from m in m_subtitles
                         where m.Id == comment.SubtitleId
                         select m).SingleOrDefault();
            model.Comments.Add(comment);
        }

        public void RemoveComment(int? id)
        {
            Subtitle theSubtitle = m_subtitles[0];
            var theComment = (from c in theSubtitle.Comments
                              where c.Id == id
                              select c).SingleOrDefault<Comment>();
            theSubtitle.Comments.Remove(theComment);
        }

        public IQueryable<Comment> GetAllComments()
        {
            return m_subtitles[0].Comments.AsQueryable();
        }

        public void DownloadCounterUpOne(int mediaId)
        {
            var media = m_media.Where(m => m.Id == mediaId).SingleOrDefault();
            media.DownloadCount++;
        }

        public void AddUserToSubtitle(int id, string userId)
        {

        }

        public void AddMedia(Media m)
        {
            throw new NotImplementedException();
        }


        public IQueryable<MediaType> GetMediaTypes()
        {
            List<MediaType> types = new List<MediaType>();
            MediaType movies = new MediaType {  Type = "Kvikmyndir", Id = 1 };
            MediaType tvShows = new MediaType { Type = "Þættir", Id = 2 };
            types.Add(movies);
            types.Add(tvShows);
            return types.AsQueryable();
        }


        public IQueryable<Media> GetMedias()
        {
            return m_media.AsQueryable();
        }

        public IQueryable<MediaGenre> GetMediaGenres()
        {
            throw new NotImplementedException();
        }


        public IQueryable<SubtitleLanguage> GetSubtitleLanguages()
        {
            return m_mediaLanguages.AsQueryable();

        }


        public IQueryable<SubtitleLine> GetSubtitleLines()
        {
            throw new NotImplementedException();
        }


        public int Upvote(int? id, int value)
        {
            throw new NotImplementedException();
        }

        public int Downvote(int? id, int value)
        {
            throw new NotImplementedException();
        }

        public void UpdateRating(int id, int value)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubtitleRating> GetSubtitleRatings()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubtitleUpvote> GetSubtitleUpvotes()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubtitleDownvote> GetSubtitleDownvotes()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUserToUpvotes(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void AddUserToDownvotes(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromUpvotes(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromDownvotes(int id, string userId)
        {
            throw new NotImplementedException();
        }


        public void UpdateSubtitleLine(SubtitleLine s)
        {
            throw new NotImplementedException();
        }


        public void DownloadCounterUpOne(int mediaId)
        {
            throw new NotImplementedException();
        }
    }
}
